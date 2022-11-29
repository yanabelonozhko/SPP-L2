using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib;
public class GeneratorContext
{
    public IFaker Faker { get; }
    public Random Random { get; }

    public GeneratorContext(IFaker faker, Random random)
    {
        Faker = faker;
        Random = random;
    }

    public GeneratorContext()
    {
        Random = new Random();
    }
}
