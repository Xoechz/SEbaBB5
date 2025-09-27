namespace UE3.Delegates;

public class Timer(int interval)
{
    private readonly int _interval = interval;
    public event Action<DateTime>? Elapsed;

    public void Start()
    {
        while (true)
        {
            Thread.Sleep(_interval);
            Elapsed?.Invoke(DateTime.Now);
        }
    }
}