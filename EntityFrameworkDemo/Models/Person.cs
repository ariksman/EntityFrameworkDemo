using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EntityFrameworkDemo.Models
{
    public class Person : ModelBase
    {
        private readonly Random _random;

        public Person()
        {
            _random = new Random();
        }

        public List<Person> CreatePersonData(int count)
        {
            var persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var newPerson = new Person()
                {
                    Id = i,
                    Name = "test " + i,
                    Age = _random.Next(),
                };

                persons.Add(newPerson);
            }

            return persons;
        }

        #region Public properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged();
            } 
        }

        private string _workplace;
        public string WorkPlace
        {
            get { return _workplace; }
            set
            {
                if (_workplace == value)
                {
                    return;
                }
                _workplace = value;
                OnPropertyChanged();
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age == value)
                {
                    return;
                }
                _age = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
                OnPropertyChanged();
            }
        }
    #endregion
    }
}
