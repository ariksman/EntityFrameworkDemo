using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntityFrameworkDemo.Properties;

namespace EntityFrameworkDemo.Models
{
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