using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators;
public class ByteGenerator : IGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (byte)context.Random.Next(byte.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(byte);
    }
}
