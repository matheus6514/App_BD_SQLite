using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App_BD_SQLite.Model
{
    /*Representação da tabela no banco de dados, assim como nosso
    * objeto a ser trabalhado nas Pages
    */
    [Table("Anotações")]//Nome da tabela no banco de dados
    public class ModelNota
    {
        //propriedades da tabela anotações (campos)
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Titulo { get; set; }
        [NotNull]
        public String Dados { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        //método construtor da classe, inicialização dos registros
        public ModelNota()
        {
            this.Id = 0;
            this.Dados = "";
            this.Favorito = false;
            this.Titulo = "";
        }
    }
}
