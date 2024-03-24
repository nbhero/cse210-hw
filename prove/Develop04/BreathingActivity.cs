class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        base._name = "Deep Breathing";
        base._description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        int remainingDuration = base._duration;
        
        Console.Clear();
        while (remainingDuration > 0)
        {
            Console.Write("Inhale slowly through the nose...");
            showCountdown(5);
            Console.WriteLine("");
            remainingDuration -= 5; 

            if (remainingDuration <= 0)
                break;

            Console.Write("Exhale slowly through the mouth...");
            showCountdown(8);
            Console.WriteLine("");
            remainingDuration -= 8;
        }
    }
}