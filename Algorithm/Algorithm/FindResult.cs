using System;

namespace PeopleSearch
{
    public class FindResult
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan DateTimeSpan { get; set; }
    }
}