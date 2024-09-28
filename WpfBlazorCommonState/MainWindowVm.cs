using System.ComponentModel;

namespace BlazorWpfTest
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public AppState AppState { get; set; } = new();

        public MainWindowVm()
        {
            AppState.PropertyChanged += (s, e) =>
            {
                Counter = AppState.Counter;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
            };
        }

        public int Counter { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
