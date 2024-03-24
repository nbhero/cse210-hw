using System.ComponentModel;

public class Activity
{
    protected string _name {get; set;}
    protected string _description {get; set;}
    protected int _duration {get; set;} //number of seconds
    public Activity()
    {

    }

    public string GetDetails(){
        return $"{_name}, {_description}, {_duration}";
    }
    public int getDuration(){
        return this._duration;
    }
    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("How long would you like this activity to last? (Seconds)");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        showSpinner(3000);
    }
   public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        showSpinner(2000);
        Console.WriteLine($"You have completed {_duration} seconds of {_name}");

    }
    public void showSpinner(int mseconds){
        DateTime currentTime = DateTime.Now;
        DateTime targetTime = currentTime.AddMilliseconds(mseconds);
        char[] spinner = { '|', '/', '-', '\\' };
         int index = 0;
        while(currentTime < targetTime){
            Console.Write("\r" + spinner[index]);
            index = (index + 1) % spinner.Length;
            Thread.Sleep(100);
            currentTime = DateTime.Now;
        }
    }
     public void showCountdown(int seconds){
        DateTime currentTime = DateTime.Now;
        DateTime targetTime = currentTime.AddSeconds(seconds);
        while(currentTime < targetTime){
            Console.Write(seconds);
            seconds--;
            Thread.Sleep(1000);
            currentTime = DateTime.Now;
            Console.Write("\b");
        }
        Console.Write(" ");
        Console.WriteLine("");
    }
}