using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FakerLib.Generators;

namespace FakerLib;

public class Faker : IFaker
{
    private readonly List<IGenerator> _generators;
    private readonly GeneratorContext _context;
    private readonly HashSet<Type> _typesBeingCreated = new();

    public Faker(Random random)
    {
        _generators = GetGenerators();
        _context = new GeneratorContext(this, random);
    }

    public Faker() : this(new Random())
    {
    }

    private static List<IGenerator> GetGenerators()
    {
        var result = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IGenerator)))
            .Select(t => (IGenerator)Activator.CreateInstance(t)).ToList();


        string[] allfiles = Directory.GetFiles("C:\\Users\\yr\\Desktop\\SPP-L2\\FakerLib\\FakerDll");
        foreach (string filename in allfiles)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(filename);
                Type[] types = asm.GetTypes();
                foreach (Type type in types)
                {
                    if (type.GetInterfaces().Contains(typeof(IGenerator)))
                    {
                        var asmList = (asm.GetTypes()
                        .Where(t => t.GetInterfaces().Contains(typeof(IGenerator)))
                        .Select(t => (IGenerator)Activator.CreateInstance(t)).ToList());

                        result.AddRange(asmList);
                    }
                }
            }
            catch { }
        }
        return result;
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public object Create(Type type)
    {
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(type))
            {
                return generator.Generate(type, _context);
            }
        }

        if (_typesBeingCreated.Contains(type))
            return GetDefaultValue(type);

        _typesBeingCreated.Add(type);
        var obj = CreateComplex(type);
        if (obj == null)
        {
            return null;
        }
        FillFields(obj);
        FillProps(obj);
        _typesBeingCreated.Remove(type);
        return obj;
    }

    private object CreateComplex(Type type)
    {
        var constructors = type.GetConstructors().ToList()
            .OrderByDescending(c => c.GetParameters().Length).ToList();
        foreach (var constructor in constructors)
        {
            try
            {
                return constructor.Invoke(constructor.GetParameters()
                    .Select(info => Create(info.ParameterType)).ToArray());
            }
            catch (Exception) { }
        }
        return GetDefaultValue(type);
    }
    private void FillFields(object obj)
    {
        var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            if (!field.IsInitOnly)
                field.SetValue(obj, Create(field.FieldType));
        }
    }

    private void FillProps(object obj)
    {
        var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var prop in props)
        {
            if (prop.CanWrite)
            {
                prop.SetValue(obj, Create(prop.PropertyType));
            }
        }
    }

    private static object GetDefaultValue(Type t)
    {
        return t.IsValueType ? Activator.CreateInstance(t) : null;
    }
}