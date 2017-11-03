using System.Collections.Generic;

namespace PeopleSearch
{
    public class Finder
    {
        private readonly List<Person> _persons;

        public Finder(List<Person> persons)
        {
            _persons = persons;
        }

        /// <summary>
        /// Find a two-person pair using a list of two or more people and the FindType. Populates FirstPerson 
        /// and SecondPerson in ascending order based on birth date.
        /// </summary>
        /// <param name="findType"></param>
        /// <returns></returns>
        public FindResult Find(FindType findType)
        {
            var findResult = new FindResult();

            // verify at least 2 persons in list before executing find
            if (_persons.Count > 1)
            {
                var results = GetFindResults();

                findResult = results[0];

                foreach (var result in results)
                {
                    if (findType == FindType.Closest && result.DateTimeSpan < findResult.DateTimeSpan)
                    {
                        findResult = result;
                    }
                    else if (findType == FindType.Furthest && result.DateTimeSpan > findResult.DateTimeSpan)
                    {
                        findResult = result;
                    }
                }
            }

            return findResult;
        }

        /// <summary>
        /// Gets a list of find results in two-person pairs, ordered by birth date, along with a calculated time span between
        /// each pair of dates.
        /// </summary>
        /// <returns></returns>
        public List<FindResult> GetFindResults()
        {
            var results = new List<FindResult>();

            // The objective is to populate FindResult objects with every possible combination of a given list of people.
            // e.g. If _persons.Count is 4, there are six possible combinations. By nesting one for loop inside
            // another, we can ensure that each combination is accounted for and represented in 'results'.

            for (var i = 0; i < _persons.Count - 1; i++)            
            {
                for (var j = i + 1; j < _persons.Count; j++)       
                {
                    var findResult = new FindResult();
                    if (_persons[i].BirthDate < _persons[j].BirthDate)
                    {
                        findResult.FirstPerson = _persons[i];
                        findResult.SecondPerson = _persons[j];
                    }
                    else
                    {
                        findResult.FirstPerson = _persons[j];
                        findResult.SecondPerson = _persons[i];
                    }

                    findResult.DateTimeSpan = findResult.SecondPerson.BirthDate - findResult.FirstPerson.BirthDate;
                    results.Add(findResult);
                }
            }

            return results;
        }
    }
}