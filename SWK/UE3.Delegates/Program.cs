var timer = new UE3.Delegates.Timer(1000);

timer.Elapsed += (time) => Console.WriteLine($"Lambda tick at {time}");

void OnTick(DateTime time)
{
    Console.WriteLine($"Method tick at {time}");
}

timer.Elapsed += OnTick;

timer.Elapsed += delegate (DateTime time)
{
    Console.WriteLine($"Anonymous tick at {time}");
};

timer.Start();