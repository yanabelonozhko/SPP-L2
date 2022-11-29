using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators.DataTime
{
    internal class DateTimeGenerator : IGenerator
    {
        public DateTime MinValue { get; set; } = new(1900, 1, 1, 0, 0, 0, 0);
        public DateTime MaxValue { get; set; } = new(2100, 1, 1, 0, 0, 0, 0);

        public object Generate(Type type, GeneratorContext context)
        {
            return MinValue.AddSeconds(context.Random.NextDouble() * (MaxValue - MinValue).TotalSeconds);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}
