using System.Collections.Generic;
using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Core.Domain
{
    public class Employer : ModelBase
    {
        public Employer()
        {
            
        }

        private int _employerId;
        public int EmployerId
        {
            get { return _employerId; }
            set
            {
                if (_employerId == value)
                {
                    return;
                }
                _employerId = value;
                OnPropertyChanged();
            }
        }

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

        // one-to-many relation for workers
        public virtual ICollection<Worker> Workers { get; set; }
    }
}