using App_BD_SQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BD_SQLite
{
    public partial class App : Application
    {
        //declaração de propriedades públicas (globais)
        public static String DbName;
        public static String DbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new PageMenu();
        }
        //Método construtor recebendo o local e o nome do BD

        public App(String dbPath, String dbName)
        {
            InitializeComponent();
            //armazenando os valores nas propriedades públicas (globais)
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new PageMenu();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
