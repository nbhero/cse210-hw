public class ListingActivity : Activity
{
    List<String> _prompts = new List<String>();
    List<string> _questions = new List<string>();


    public ListingActivity() : base()
    {
            _name = "Listing Activity";
            _description = "This activity will help you focus on the good things in your life by having you list as many things as you can.";
            _prompts.Add("Who are people that you appreciate?");
            _prompts.Add("What are personal strengths of yours?");
            _prompts.Add("Who are people that you have helped this week?");
            _prompts.Add("When have you felt the Holy Ghost this month?");
            _prompts.Add("Who are some of your personal heroes?");
    }

   public string getRandomPrompt(){
    Random rand = new Random();
       int index = rand.Next(_prompts.Count);
       return _prompts[index];
   }

   public string getRandomQuestion(){
    Random rand = new Random();
       int index = rand.Next(_questions.Count);
       return _questions[index];
   }
   public void Run(){
    int remainingDuration = base._duration;
    Console.WriteLine("List as many responses as you can to the following prompt:");
    Console.WriteLine();
    Console.WriteLine($"-- {getRandomPrompt()} --");
    Console.WriteLine();
    Console.WriteLine("Beginning in... ");
    showCountdown(3);
    
    DateTime currentTime = DateTime.Now;
    DateTime targetTime = currentTime.AddSeconds(_duration);
    int count = 0;
    while (targetTime  > currentTime)
    {
        Console.ReadLine();
        currentTime = DateTime.Now;
        count++;
    }
    Console.WriteLine($"You listed {count} items!");
    showSpinner(2000);
   }
    
}