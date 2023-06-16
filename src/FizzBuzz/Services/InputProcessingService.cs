using System.Collections.Immutable;
using FizzBuzz.Abstractions;
using FizzBuzz.Abstractions.Services;

namespace FizzBuzz.Services;

public sealed class InputProcessingService
    : IInputProcessingService
{
    private const char QuitCharacter = 'q';
        
    private readonly ImmutableArray<IResponseStrategy> _responseStrategies;

    public InputProcessingService(
        IEnumerable<IResponseStrategy> responseStrategies)
    {
        _responseStrategies
            = responseStrategies
                .ToImmutableArray();
    }

    public void Process(
        TextReader textReader,
        TextWriter textWriter)
    {
        var input
            = textReader
                .ReadLine();
            
        while (input is not null && !input.Contains(QuitCharacter))
        {
            if (int.TryParse(input, out var number))
            {
                Respond(
                    number,
                    textWriter);
            }

            input = Console.ReadLine();
        }
    }
        
    private void Respond(
        int input,
        TextWriter textWriter)
    {
        foreach (var inputHandlerStrategy in _responseStrategies)
        {
            inputHandlerStrategy.Handle(input, textWriter);
        }

        textWriter.WriteLine();
    }
}