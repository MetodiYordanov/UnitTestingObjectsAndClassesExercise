using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;
    [SetUp]
    public void Setup()
    {
        this._person = new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        Person firstPerson = new Person
        {
            Name = "Alice",
            Id = "A001",
            Age = 35,
        };
        Person secondPerson = new Person
        {
            Name = "Bob",
            Id = "B002",
            Age = 30,
        };
        List<Person> expectedPeopleList = new List<Person> { firstPerson, secondPerson };

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));
        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_AddPeople_ReturnsEmptyList_WhenNoDataIsGiven()
    {
        // Arrange
        string[] peopleData = { };

        // Act
        List<Person> result = this._person.AddPeople(peopleData);

        //Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };
        string expectedResult = $"Bob with ID: B002 is 30 years old.{Environment.NewLine}" +
            $"Alice with ID: A001 is 35 years old.";

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);
        string actualResult = this._person.GetByAgeAscending(resultPeopleList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_GetByAgeAscending_ReturnsEmptyString_WhenGivenNoData()
    {
        // Arrange
        string[] peopleData = { };
        string expectedResult = string.Empty;

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);
        string actualResult = this._person.GetByAgeAscending(resultPeopleList);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
