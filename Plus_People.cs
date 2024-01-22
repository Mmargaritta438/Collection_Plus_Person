using Collection_Plus_Person;
using System;
using System.Collections;
using System.Linq;


namespace Collection_Plus_Person
{
    public class Plus_People
    {
        public Plus_People(string fName, string lName) 
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public string firstName;
        public string lastName;
    }

    public class People : Enumerable
    {
        private Plus_People[] _people;

        public People(Plus_People[] pArray) 
        { 
            _people = new Plus_People[pArray.Length];

            for (int i = 0; i < pArray.Length; i++) 
            {
                _people[i] = pArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        { 
            return (IEnumerator).GetEnumerator(); 
        } 

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Plus_People[] _people;

        int position = -1;

        public PeopleEnum(Plus_People[] list)
        {
            _people = list;
        }   
        
        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public virtual Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Plus_People Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}



class App
{
    static void Main()
    {
        Plus_People[] peopleArray = new Plus_People[3]
        {
            new Plus_People("John", "Smith"),
            new Plus_People("Jim", "Johnson"),
            new Plus_People("Sue", "Rabon"),
        };

        People peopleList = new People(peopleArray);
        foreach (Plus_People p in peopleList)
            Console.WriteLine(p.firstName + "" + p.lastName);
    }
}