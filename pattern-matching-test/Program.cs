using System;

var superhero = new superhero
{
    Firstname = "Tony",
    Lastname = "Stark",
    MaxSpeed = 10000
};

static decimal GetFuelCost(Superhero hero) =>
    hero.MaxSpeed switch
    {
        < 1000 => 10.0m,
        <= 10000 => 7.00m,
        null => throw new ArgumentNullException(nameof(hero)),
        not null => throw new ArgumentException($"Not a know hero: {hero}", nameof(hero))
    };
    Console.WriteLine(GetFuelCost(superHero));
}

public class Person
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string FavoriteColor { get; set; }
}

public class Superhero : Person
{
    public int MaxSpeed { get; set; }
}