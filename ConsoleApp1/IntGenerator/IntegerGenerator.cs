using FakerLib;
using FakerLib.Generators;

namespace IntGenerator
{
    public class IntegerGenerator : IGenerator
    {
        public bool CanGenerate(Type cheackedType)
        {
            if (cheackedType == typeof(char))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Generate(Type type, GeneratorContext faker)
        {
            int n = faker.Random.Next();
            return n;
        }
    }
}