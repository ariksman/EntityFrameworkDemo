using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Core.Domain
{
    public class Worker : ModelBase
    {
        public Worker()
        {
            
        }

        private int _workerId;
        public int WorkerId
        {
            get { return _workerId; }
            set
            {
                if (_workerId == value)
                {
                    return;
                }
                _workerId = value;
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

        public virtual Employer Employer1 { get; set; }
    }
}
