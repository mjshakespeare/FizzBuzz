namespace FizzBuzz.Abstractions;

public interface IInputProcessingService
{
    void Process(
        TextReader textReader,
        TextWriter textWriter);
}