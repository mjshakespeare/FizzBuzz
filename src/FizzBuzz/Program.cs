using FizzBuzz.Abstractions;
using FizzBuzz.Abstractions.Services;
using FizzBuzz.Services;
using FizzBuzz.Services.ResponseStrategies;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider
    = new ServiceCollection()
        .AddSingleton<IResponseStrategy, FizzResponseStrategy>()
        .AddSingleton<IResponseStrategy, BuzzResponseStrategy>()
        .AddSingleton<IInputProcessingService, InputProcessingService>()
        .BuildServiceProvider();

var inputProcessingService
    = serviceProvider
        .GetRequiredService<IInputProcessingService>();

inputProcessingService
    .Process(
        Console.In,
        Console.Out);