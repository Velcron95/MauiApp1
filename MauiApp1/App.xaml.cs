using MauiApp1.Data;
using MauiApp1.ViewModels;
using System.IO;

namespace MauiApp1
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; }

        public App()
        {
            InitializeComponent();

            
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TodoList.db3");
            Database = new DatabaseService(dbPath);

            
            MainPage = new AppShell();
        }
    }
}
