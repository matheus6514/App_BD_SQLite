using App_BD_SQLite.Model;
using App_BD_SQLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_BD_SQLite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarDetail : ContentPage
    {
        public ListarDetail()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
            ListaNotas.ItemsSource = dbNotas.Listar();
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNota nota = (ModelNota)ListaNotas.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new CadastrarDetail(nota));
        }

        private void SwFavorito_Toggled(object sender, ToggledEventArgs e)
        {
            //criação do objeto da classe ServiceBDNota
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
            //ação de quando o control do switch estiver selecionado
            if(swfavorito.IsToggled)
            {
                ListaNotas.ItemsSource = dbNotas.ListarFavoritos();    
            }else // ação de quando o control do switch NÃO estiver selecionado
            {
                //faz a busca pela lista inteira
                AtualizaLista();
            }
        }

        private void btLocalizar_Clicked(object sender, EventArgs e)
        {
            String titulo="";//captura do texto da busca
            if(txtNota.Text != null) titulo = txtNota.Text;
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
            //chamada do método de busca por título da nota
            ListaNotas.ItemsSource = dbNotas.Localizar(titulo);
            txtNota.Text = ""; //Limpa o text
        }

        private void btTodos_Clicked(object sender, EventArgs e)
        {
            //retorna a lista inteira
            AtualizaLista();
        }
    }
}