using System;
using System.Threading.Tasks;

public class ScopedChildService
{
    public ScopedChildService() {
        Console.WriteLine("ScopedChildService() constructor called!");
    }

    public async void DoWork()
    {
        await Task.Delay(3000);
    }
}