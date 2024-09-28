using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BlazorWpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowVm? MainWindowVm => DataContext as MainWindowVm;

        public MainWindow()
        {
            DataContext = new MainWindowVm();
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            InitializeBlazorWebView();
        }

        private void InitializeBlazorWebView()
        {
            var blazorServices2 = new ServiceCollection();
            blazorServices2.AddWpfBlazorWebView();

            if (MainWindowVm?.AppState != null)
            {
                blazorServices2.AddSingleton(MainWindowVm.AppState);
            }

#if DEBUG
            blazorServices2.AddBlazorWebViewDeveloperTools();
#endif
            MainWindowBlazorWebView2.HostPage = @"wwwroot\index.html";
            MainWindowBlazorWebView2.Services = blazorServices2.BuildServiceProvider();
            MainWindowBlazorWebView2.RootComponents.Add(new RootComponent { Selector = "#app", ComponentType = typeof(TheListComponent) });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowVm?.AppState?.AddTask();
        }
    }
}
