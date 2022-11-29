﻿using System.Text;
using FakerLib;

namespace FakerLib.Generators;

public class StringGenerator : IGenerator
{
    public string Characters { get; set; } = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ           ";
    public int MinLength { get; set; } = 1;
    public int MaxLength { get; set; } = 50;

    public object Generate(Type type, GeneratorContext context)
    {
        var length = context.Random.Next(MinLength, MaxLength + 1);
        var str = new StringBuilder(length);
        for (var i = 0; i < length; i++) str.Append(Characters[context.Random.Next(Characters.Length)]);

        return str.ToString();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(string);
    }
}