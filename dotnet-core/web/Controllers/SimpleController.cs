using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SimpleController {
    private readonly ScopedService scopedService;

    public SimpleController(TransientService transientService, ScopedService scopedService) {
        Console.WriteLine("SimpleController() constructor called!");    
        this.scopedService = scopedService;
    }

     [HttpGet("Ping")]
     public async Task<String> Ping() {
        await scopedService.DoWork();
        return "Pong!";
     }
}