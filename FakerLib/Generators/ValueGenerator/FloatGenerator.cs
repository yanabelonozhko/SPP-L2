using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators
{
    public class FloatGenerator:IGenerator
    {
        public object Generate(Type type, GeneratorContext context)
        {
            return (float)((context.Random.NextSingle() - 0.5) * float.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }
    }
}
