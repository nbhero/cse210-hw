using System.Diagnostics.CodeAnalysis;

public class ReflectionActivity : Activity
{
    List<String> _prompts = new List<String>();
    List<string> _questions = new List<string>();


    public ReflectionActivity() : base()
    {
        _name = "Reflection Actiivty";
        _description = "This activity will guide you through reflecting on meaningful past experiences. It will prompt you with experiences to think about and questions to help you reflect more deeply.";
            _prompts.Add("What were the most significant moments or decisions in this experience, and how did they impact the outcome?");
            _prompts.Add("Think of a time when you stood up for someone else.");
            _prompts.Add("Think of a time when you did something really difficult.");
            _prompts.Add("Think of a time when you helped someone in need.");
            _prompts.Add("Think of a time when you did something truly selfless.");
            _questions.Add("What was the experience?");
            _questions.Add("Why was this experience meaningful to you?");
            _questions.Add("Have you ever done anything like this before?");
            _questions.Add("How did you get started?");
            _questions.Add("How did you feel when it was complete?");
            _questions.Add("What made this time different than other times when you were not as successful?");
            _questions.Add("What is your favorite thing about this experience?");
            _questions.Add("What could you learn from this experience that applies to other situations?");
            _questions.Add("What did you learn about yourself through this experience?");
            _questions.Add("How can you keep this experience in mind in the future?");
            _questions.Add("In terms of personal growth and development, what skills or knowledge do I want to acquire in the next few years, and how can I incorporate learning and growth into my daily routine?");
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
    Console.WriteLine("Consider the following question:");
    Console.WriteLine();
    Console.WriteLine($"-- {getRandomPrompt()} --");
    Console.WriteLine();
    Console.WriteLine($"When you have something in mind, press [Enter] to continue...");
    Console.ReadLine();
    Console.WriteLine();
    //Console.Clear();
    Console.WriteLine("Now reflect on the following questions in relation to the experience you have in mind:");
    Console.WriteLine("Beginning in... ");
    showCountdown(3);
    
    while (remainingDuration > 0)
    {
        Console.Clear();
        Console.WriteLine(getRandomQuestion());
        showSpinner(8000);
        Console.WriteLine("\n");
        remainingDuration -= 8; 

        if (remainingDuration <= 0)
            break;

       
    }
   }
}