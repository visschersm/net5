using System;

#nullable enable 

// Init only
Person person = new Person
{
    Firstname = "Tony", 
    Lastname = "Stark"
};

Console.WriteLine(person.Firstname);

// target-typed new
Point point = new(1, 2);

Console.WriteLine($"Point: {point.x}, {point.y}");

// Record
var product = new  Product
{
    Name = "VideoGame",
    CategoryId = 1
};

Console.WriteLine(
    $"Product name:\t{product.Name},\t" +
    "CategoryId:\t{product.CategoryId}");

Product otherProduct = new("Movie", 1);

public class Person
{
    public string Firstname { get; init; }
    public string? Middlename { get; init; }
    public string Lastname { get; init; }
}

public class Point
{
    public int x { get; init; }
    public int y { get; init; }

    public Point(int x, int y) 
        => (this.x, this.y) = (x, y);
}

public record Product
{
    public Product() {}
    public Product(string name, int categoryId)
        => (Name, CategoryId) = (name, categoryId);
        
    public string Name { get; init; }
    public int CategoryId { get; init; }
}