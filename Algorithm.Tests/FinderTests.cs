﻿using System;
using System.Collections.Generic;
using Xunit;

namespace PeopleSearch.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(FindType.Closest);

            Assert.Null(result.FirstPerson);
            Assert.Null(result.SecondPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(FindType.Closest);

            Assert.Null(result.FirstPerson);
            Assert.Null(result.SecondPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(FindType.Closest);

            Assert.Same(sue, result.FirstPerson);
            Assert.Same(greg, result.SecondPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(FindType.Furthest);

            Assert.Same(greg, result.FirstPerson);
            Assert.Same(mike, result.SecondPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FindType.Furthest);

            Assert.Same(sue, result.FirstPerson);
            Assert.Same(sarah, result.SecondPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FindType.Closest);

            Assert.Same(sue, result.FirstPerson);
            Assert.Same(greg, result.SecondPerson);
        }

        Person sue   = new Person() { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        Person greg  = new Person() { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike  = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}