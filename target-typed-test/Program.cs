using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

var personList = new List<Person>
{
    new ("Tony", "Stark"),
    new ("Howard", "Stark"),
    new ("Client", "Barton"),
    new ("Steven", "Rogers")
};

Student student = new Student("Dave", "Brock", "Programming");
Superhero superhero = new Superhero("Tony", "Stark", 10000);

// Currently not working
//Person anotherPerson = student ?? superhero;

public class Person 
{
    private string _firstName;
    private string _lastName;

    public Person(string firstName, string lastName) 
        => (_firstName, _lastName) = (firstName, lastName);
}

public class Student : Person
{
    private string _favoriteSubject;

    public Student(string firstName, string lastName, string favoriteSubject)
        : base(firstName, lastName)
        => _favoriteSubject = favoriteSubject;
}

public class Superhero : Person
{
    private int _maxSpeed;

    public Superhero(string firstName, string lastName, int maxSpeed)
        : base(firstName, lastName)
        => _maxSpeed = maxSpeed;
}

public class PersonManager
{
    public virtual Person Get()
    {
        return new Person("Harry", "Potter");
    }
}

public class StudentManager : PersonManager
{
    public override Student Get()
    {
        return new Student("Mark", "Visschers", "Programming");
    }
}

public class SuperheroManager : PersonManager
{
    public override Superhero Get()
    {
        return new Superhero("Bruce", "Banner", 100);
    }
}