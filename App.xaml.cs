using Frotas.Services;

namespace Frotas
{
    public partial class App : Application
    {

        
            private static SQLiteHelper _banco;
            public static SQLiteHelper Banco
            {
                get
                {
                    if (_banco == null)
                    {
                        string dbPath = Path.Combine(
                            FileSystem.AppDataDirectory, "gestorfrota.db3");
                        _banco = new SQLiteHelper(dbPath);
                    }
                    return _banco;
                }
            }

            public App()
            {
                InitializeComponent();
                MainPage = new NavigationPage(new MainPage());
            }
        }
    
}