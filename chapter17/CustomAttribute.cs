using System;
using System.Reflection;
using System.Collections.Generic;

class HeroAttribute : Attribute
{
    public static IList<string> SearchHeros(object o)
    {
        List<string> heros = new List<string>();

        Type t = o.GetType();
        foreach (PropertyInfo p in t.GetProperties())
        {
            HeroAttribute attribute = p.GetCustomAttribute<HeroAttribute>();
            if (attribute != null)
            {
                heros.Add(p.Name);
            }
        }

        return heros;
    }
}

class People
{
    [Hero]
    public string IronMan
    {
        get
        {
            return "Iron Man";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IList<string> heros = HeroAttribute.SearchHeros(new People());
        foreach (string hero in heros)
        {
            Console.WriteLine(hero);
        }
    }
}
