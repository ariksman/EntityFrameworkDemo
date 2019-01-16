using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp.Properties;

namespace WpfApp.Models
{
    public class Person : ModelBase
    {
        private readonly Random _random;

        public Person()
        {
            _random = new Random();
        }

        public ObservableCollection<Person> CreatePersonData(int count)
        {
            var persons = new ObservableCollection<Person>();

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

    

    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
