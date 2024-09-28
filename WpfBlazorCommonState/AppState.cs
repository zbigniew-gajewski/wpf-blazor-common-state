using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BlazorWpfTest
{
    public class AppState : INotifyPropertyChanged
    {
        public ObservableCollection<string> ToDoTasks { get; set; }

        public AppState()
        {
            ToDoTasks = new ObservableCollection<string>();
        }

        private int _counter;

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged(nameof(Counter));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddTask()
        {
            Counter++;
            ToDoTasks.Add(@$"My Next Task No.: {Counter}");
        }
    }
}
