using FizzBuzz.Abstractions.Services;

namespace FizzBuzz.Services.ResponseStrategies;

public sealed class FizzResponseStrategy
    : IResponseStrategy
{
    public void Handle(
        int number,
        TextWriter textWriter)
    {
        if (ShouldRespond(number))
        {
            Respond(textWriter);
        }
    }

    private static bool ShouldRespond(
        int number)
    {
        return number % 3 == 0;
    }

    private static void Respond(
        TextWriter textWriter)
    {
        textWriter.Write("Fizz");
    }
}