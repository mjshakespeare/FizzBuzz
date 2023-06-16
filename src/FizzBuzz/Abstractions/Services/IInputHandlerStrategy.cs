namespace FizzBuzz.Abstractions.Services;

public interface IResponseStrategy  
{
    public void Handle(
        int input,
        TextWriter textWriter);
}