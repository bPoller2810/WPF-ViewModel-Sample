using MvvMHelpers.core;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WPF_APP;

//public abstract class BaseViewModel : INotifyPropertyChanged
//{
//    public event PropertyChangedEventHandler? PropertyChanged;

//    protected void OnPropertyChanged([CallerMemberName] string? propertyname = null)
//    {
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
//    }

//}

public class MainwindowViewModel : BaseViewModel
{
    #region properties

    //example with logic
    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            if (Set(ref _text, value))
            {
                ((Command)AddNameCommand).RaiseCanExecuteChanged();
            }
        }
    }

    //example without logic
    private string? _filter;
    public string? Filter
    {
        get => _filter;
        set => Set(ref _filter, value);
    }

    public ObservableCollection<string> Items { get; }
    #endregion

    #region commands
    public ICommand AddNameCommand { get; init; }
    #endregion

    #region ctor
    public MainwindowViewModel()
    {
        _text = string.Empty;

        Items = new ObservableCollection<string>();

        AddNameCommand = new Command(ExecuteAddName, CanExecuteAddName);
    }
    #endregion

    #region command handling
    private bool CanExecuteAddName(object? obj)
    {
        return !string.IsNullOrWhiteSpace(Text) && !Items.Contains(Text);
    }

    private void ExecuteAddName(object? obj)
    {
        Items.Add(Text);
        Text = string.Empty;
    }
    #endregion

}

