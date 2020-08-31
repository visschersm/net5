using System;
using Microsoft.EntityFrameworkCore;

using(var context = new AnimalContext())
{
    context.Cats.Add(new Cat 
    {
        Species = "cat",
        Name = "Barry",
        EducationLevel = "strong"
    });

    context.Dogs.Add(new Dog
    {
        Species = "dog",
        Name = "Max",
        FavoriteToy = "Pluchy duck"
    });
    
    context.SaveChanges();

    foreach(var pet in context.Pets)
    {
        Console.WriteLine($"Pet:\tSpecies: {pet.Species}\tName: {pet.Name}");
    }
}

public class Animal
{
    public int Id { get; set; }
    public string Species { get; set; }
}

public class Pet : Animal 
{
    public string Name { get; set; }
}

public class Cat : Pet 
{
    public string EducationLevel { get; set; }
}

public class Dog : Pet
{
    public string FavoriteToy { get; set; }
}

public class AnimalContext : DbContext 
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    public AnimalContext()
        : base()
    {

    }

    public AnimalContext(DbContextOptions<AnimalContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=animalcontext.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>().ToTable("Animals");
        modelBuilder.Entity<Animal>().HasKey(animal => animal.Id);

        modelBuilder.Entity<Pet>().ToTable("Pets");

        modelBuilder.Entity<Cat>().ToTable("Cats");

        modelBuilder.Entity<Dog>().ToTable("Dogs");
    }
}
