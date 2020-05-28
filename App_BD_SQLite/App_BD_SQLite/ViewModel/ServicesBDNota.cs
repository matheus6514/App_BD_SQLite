using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App_BD_SQLite.Model;

namespace App_BD_SQLite.ViewModel
{
    public class ServicesBDNota
    {
        //objeto de conexão
        SQLiteConnection conn;
        //Variável de retorno do status (resultado) do BD
        public string StatusMessage { get; set; }
        //Método construtor, criação do Banco de Dados
        public ServicesBDNota(String dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<ModelNota>();
        }

        public void Inserir(ModelNota nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Titulo da nota não informado");
                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Dados da nota não informado");
                int result = conn.Insert(nota);
                if (result != 0)
                {
                    this.StatusMessage =
                        String.Format("{0} registro(s) adicionado(s): [Nota: {1}]",
                        result, nota.Titulo);
                }
                else
                {
                    string.Format("0 registro(s) adicionado(s)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelNota> Listar()
        {
            List<ModelNota> Lista = new List<ModelNota>();
            try
            {
                Lista = conn.Table<ModelNota>().ToList();
                this.StatusMessage = "Listagem das Notas";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Lista;
        }

        public void Alterar(ModelNota nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Título da nota não informado");
                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Dados da nota não informados");
                if (nota.Id <= 0)
                    throw new Exception("Id da nota não informado");

                int result = conn.Update(nota);
                StatusMessage = string.Format("{0} Registros alterados", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelNota>().Delete(r => r.Id == id);
                StatusMessage = string.Format("{0} Registros deletados.", result);
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public List<ModelNota> Localizar(String Titulo)
        {
            List<ModelNota> lista = new List<ModelNota>();
            try
            {
                var resp = from p in conn.Table<ModelNota>() where p.Titulo.ToLower().Contains(titulo.ToLower()) select p;
                lista = resp.ToList();
            }catch (Exception ex)
            {
                throw new Exception(String.Format("ERRO: {0}", ex.Message));
            }
            return lista;
        }

        public List<ModelNota> LocalizarFavorito(String titulo)
        {
            List<ModelNota> lista = new List<ModelNota>();
            try
            {
                var resp = from p in conn.Table<ModelNota>() where p.Favorito == true select p;
                lista = resp.ToList();
            }catch (Exception ex)
            {
                throw new Exception(String.Format("ERRO: {0}", ex.Message));
            }
            return lista;
        }
    }
}
