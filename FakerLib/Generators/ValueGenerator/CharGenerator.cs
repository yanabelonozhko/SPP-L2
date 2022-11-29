using FakerLib;

namespace FakerLib.Generators;

public class CharGenerator : IGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (char)context.Random.Next(char.MinValue, char.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(char);
    }
}