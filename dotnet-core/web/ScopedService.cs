using System;
using System.Threading;
using System.Threading.Tasks;

public class ScopedService {
    private readonly ScopedChildService scopedChildService;

    public ScopedService(ScopedChildService scopedChildService) {
        Console.WriteLine("ScopedService() constructor called!");
        this.scopedChildService = scopedChildService;
    }

    public async Task<String> DoWork() {
        await Task.Delay(3000);
        scopedChildService.DoWork();
        return "Work done!";
    }
}
