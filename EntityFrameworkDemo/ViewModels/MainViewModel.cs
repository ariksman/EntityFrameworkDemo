using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonServiceLocator;
using EntityFrameworkDemo.Core;
using EntityFrameworkDemo.Core.Domain;
using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.ViewModels.HelperClasses;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EntityFrameworkDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                var person = new Person().CreatePersonData(20);
            }
        }


        #region Relay commands
        private RelayCommand _loadPersonsCommand;
        public RelayCommand LoadPersonsCommand => _loadPersonsCommand
                                                  ??
                                                  (_loadPersonsCommand =
                                                      new RelayCommand(LoadPersonsExecute));
        private RelayCommand _saveNewPersonsCommand;
        public RelayCommand SaveNewPersonsCommand => _saveNewPersonsCommand
                                                  ??
                                                  (_saveNewPersonsCommand =
                                                      new RelayCommand(SaveNewPersonsExcecute));

        private RelayCommand _loadDatabaseCommand;
        public RelayCommand LoadDatabaseCommand => _loadDatabaseCommand
                                                  ??
                                                  (_loadDatabaseCommand =
                                                      new RelayCommand(LoadDatabaseExecute));

        private RelayCommand _seedDatabaseCommand;
        public RelayCommand SeedDatabaseCommand => _seedDatabaseCommand
                                                  ??
                                                  (_seedDatabaseCommand =
                                                      new RelayCommand(SeedDatabaseExecute));
        private RelayCommand _deletePersonCommand;
        public RelayCommand DeletePersonCommand => _deletePersonCommand
                                                  ??
                                                  (_deletePersonCommand =
                                                      new RelayCommand(DeletePersonExecute));

        private void DeletePersonExecute()
        {
            throw new NotImplementedException();
        }

        private void SeedDatabaseExecute()
        {
            using (IUnitOfWork context = ServiceLocator.Current.GetInstance<IUnitOfWork>("LocalDatabase"))
            {
                var dataSeeder = new DatabaseSeeder(context);
                dataSeeder.SeedDatabase();
            }
        }

        private void LoadDatabaseExecute()
        {
            var workers = new List<Worker>();
            using (IUnitOfWork context = ServiceLocator.Current.GetInstance<IUnitOfWork>("LocalDatabase"))
            {
                workers = context.Workers?.GetAllWorkersWithEmployers();
            }

            CreatePersonListFromSource(workers);

            IsChecked = true;
        }

        private void CreatePersonListFromSource(IEnumerable<Worker> source)
        {
            Persons = new ObservableCollection<Person>();

            foreach (var worker in source)
            {
                var newPerson = new Person()
                {
                    Name = worker.Name,
                    WorkPlace = worker.Employer1.Name,
                    Age = worker.Age,
                    Id = worker.WorkerId,
                };
                Persons.Add(newPerson);
            }
        }

        private void SaveNewPersonsExcecute()
        {
            var newPerson = new Person()
            {
                Age = _currentPersonAge,
                Name = _currentPersonName,
                Id = _currentPersonId,
            };

            Persons.Add(newPerson);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadPersonsExecute()
        {
            Persons = new Person().CreatePersonData(25);

            IsChecked = false;
        }
        #endregion


        #region Public collections

        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                if (_persons == value)
                {
                    return;
                }
                _persons = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Public properties

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged();
            }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }
                _selectedPerson = value;

                if(_selectedPerson == null) return;

                CurrentPersonId = _selectedPerson.Id;
                CurrentPersonAge = _selectedPerson.Age;
                CurrentPersonName = _selectedPerson.Name;

                RaisePropertyChanged();
            }
        }

        private int _currentPersonId;
        public int CurrentPersonId
        {
            get { return _currentPersonId; }
            set
            {
                if (_currentPersonId == value)
                {
                    return;
                }
                _currentPersonId = value;
                RaisePropertyChanged();
            }
        }

        private int _currentPersonAge;
        public int CurrentPersonAge
        {
            get { return _currentPersonAge; }
            set
            {
                if (_currentPersonAge == value)
                {
                    return;
                }
                _currentPersonAge = value;
                RaisePropertyChanged();
            }
        }

        private string _currentPersonName;
        public string CurrentPersonName
        {
            get { return _currentPersonName; }
            set
            {
                if (_currentPersonName == value)
                {
                    return;
                }
                _currentPersonName = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}