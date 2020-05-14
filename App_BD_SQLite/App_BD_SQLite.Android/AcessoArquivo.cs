using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App_BD_SQLite.Droid
{
    /*Classe para saber onde estará armazenado o BD no celular*/
     public class AcessoArquivo
    {
        public static string GetLocalFilePath(String filename) 
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);//retorna o local onde estará o banco
            //local: /usr/var/app_BD_SQLite/data.db
        }
    }
}