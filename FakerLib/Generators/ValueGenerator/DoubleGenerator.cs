using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib;



namespace FakerLib.Generators
{
    public class DoubleGenerator : IGenerator
    {
        public bool CanGenerate(Type cheackedType)
        {
            if (cheackedType == typeof(float))
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
            return (float)faker.Random.NextDouble() + faker.Random.Next(-1000, 1001);
        }
    }
}
