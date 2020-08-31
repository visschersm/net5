using System;

Person person = new(
    "Tony",
    "Stark",
    "10880 Malibu Point",
    "Malibu",
    "Red"
);

Console.WriteLine($"Person:\n" + 
    $"Firstname: {person.Firstname} {person.Lastname}\n" +
    $"Address: {person.Address} {person.City}\n" +
    $"FavoriteColor: {person.FavoriteColor}");

public record Person(
    string Firstname,
    string Lastname,
    string Address,
    string City,
    string FavoriteColor);