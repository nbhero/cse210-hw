using System.Text.Json;

class GoalManager{
	private List<Goal> _goals { get; set; }
	private int _score { get; set; }

	public GoalManager()
	{
		_goals = new List<Goal>();
		_score = 0;
	}

	public void Start(){
		
        while (true)
        {
			Console.WriteLine();
			Console.WriteLine($"You have {_score} points");
			Console.WriteLine();
            Console.WriteLine("1. Create Goal");
			Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
			Console.WriteLine("4. Load Goals");
			Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
					CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals(); // Save goals before exiting
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
	}
	public void DisplayPlayerInfo(){
		Console.WriteLine($"You have {_score} points.");
		Console.WriteLine();
	}
	public void ListGoalNames()
	{	
		Console.Clear();
		Console.WriteLine("The goals are:");
		ListGoalDetails();
	}

	public void ListGoalDetails(){
		
		int n = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{n}. {goal.GetStringRepresentation()}");
			n++;
        }
	}
	public void CreateGoal(){
		Console.Clear();
		Console.WriteLine("Please select a goal type: \n\t1: Simple \n\t2: Eternal \n\t3: Checklist");
		Console.Write("Which type of goal would you like to create? ");
        string typeInput = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("How many points for completing this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeInput)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("What is the target number of times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("How many	bonus points for completing reaching the target? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
	}
	public void RecordEvent(){
		Console.Clear();
		Console.WriteLine("Select a goal to record an event for:");
		ListGoalDetails();
		int i = Int32.Parse(Console.ReadLine());
		Goal selectedGoal = _goals[i-1];
		_score += selectedGoal.RecordEvent();
	}	

	public void SaveGoals()
    {
		Console.Clear();
		GoalManagerData data = new GoalManagerData
		{
			Goals = _goals,
			Score = _score
		};
		Console.WriteLine("What file would you like to save your goals as?");
		String filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
		{
			// Write the score on the first line
			writer.WriteLine($"Score: {_score}");

			// Write each goal and its details
			foreach (var goal in _goals)
			{
				writer.WriteLine($"{goal.GetType().Name},{goal.GetDetailsString()}");
				if (goal is ChecklistGoal checklistGoal)
				{
					writer.WriteLine($"ChecklistGoal:{checklistGoal.GetShortName()},{checklistGoal.GetDescription()},{checklistGoal.GetPoints()},{checklistGoal.GetAmountComplete()},{checklistGoal.GetTarget()},{checklistGoal.GetBonus()}");
				}
				if (goal is EternalGoal eternalGoal)
				{
					writer.WriteLine($"EternalGoal:{eternalGoal.GetShortName()},{eternalGoal.GetDescription()},{eternalGoal.GetPoints()}");
				}
				if (goal is SimpleGoal simpleGoal)
				{
					writer.WriteLine($"SimpleGoal:{simpleGoal.GetShortName()},{simpleGoal.GetDescription()},{simpleGoal.GetPoints()},{simpleGoal.IsComplete()}");
				}
			}
		}
        Console.WriteLine("Goals saved successfully.");
    }

	public void LoadGoals()
	{
		Console.Clear();
		Console.WriteLine("Enter the file name to load goals from:");
		string filename = Console.ReadLine();

		if (File.Exists(filename))
		{
			_goals.Clear();
			using (StreamReader reader = new StreamReader(filename))
			{
				// Read the score from the first line
				string scoreLine = reader.ReadLine();
				if (scoreLine != null && scoreLine.StartsWith("Score:"))
				{
					_score = int.Parse(scoreLine.Substring("Score:".Length).Trim());
				}
				else
				{
					Console.WriteLine("Invalid score format in the file.");
					return;
				}

				// Read each goal and its details
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] parts = line.Split(':');
					if (parts.Length != 2)
					{
						Console.WriteLine("Invalid format for a goal in the file.");
						continue;
					}

					string[] goalDetails = parts[1].Split(',');

					switch (parts[0])
					{
						case "SimpleGoal":
							if (goalDetails.Length >= 4)
							{
								string shortName = goalDetails[0];
								string description = goalDetails[1];
								int points = int.Parse(goalDetails[2]);
								bool isComplete = bool.Parse(goalDetails[3]);

								SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
								if (isComplete)
								{
									simpleGoal.SetComplete(); // Mark as complete
								}
								_goals.Add(simpleGoal);
							}
							break;
						case "EternalGoal":
							if (goalDetails.Length >= 3)
							{
								string shortName = goalDetails[0];
								string description = goalDetails[1];
								int points = int.Parse(goalDetails[2]);

								_goals.Add(new EternalGoal(shortName, description, points));
							}
							break;
						case "ChecklistGoal":
							if (goalDetails.Length >= 6)
							{
								string shortName = goalDetails[0];
								string description = goalDetails[1];
								int points = int.Parse(goalDetails[2]);
								int amountComplete = int.Parse(goalDetails[3]);
								int target = int.Parse(goalDetails[4]);
								int bonus = int.Parse(goalDetails[5]);

								ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
								if(amountComplete > 0)
								{
									checklistGoal.SetAmountComplete(amountComplete); // Mark as complete
								}
								_goals.Add(checklistGoal);
							}
							break;
						default:
							Console.WriteLine($"Unknown goal type: {parts[0]}. Skipping...");
							break;
					}
				}
			}

			Console.WriteLine("Goals loaded successfully.");
		}
		else
		{
			Console.WriteLine("File not found.");
		}
	}
}
class GoalManagerData
{
	public GoalManagerData(){}
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }
}