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

            // 🔥 Apaga o banco antigo (apenas durante desenvolvimento)
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "gestorfrota.db3");
            if (File.Exists(dbPath))
                File.Delete(dbPath); // <-- Isso apaga o banco SQLite

            MainPage = new NavigationPage(new MainPage());
        }
    }

}