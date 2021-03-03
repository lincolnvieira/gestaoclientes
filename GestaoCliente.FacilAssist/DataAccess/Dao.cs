using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.DataAccess
{
    public abstract class Dao<T, K> where T : class
    {
        //Elementos de acesso a dados
        protected SqlConnection cn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;

        //String de conexão
        private readonly string conexao = "Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=GestaoClientes;Data Source=.";

        //Construtor
        public Dao()
        {
            cn = new SqlConnection(conexao);
            cmd = new SqlCommand();
            cmd.Connection = cn;
            adapter = new SqlDataAdapter();
        }

        //Método para abrir a conexãp
        protected void AbrirConexao()
        {
            cn.Open();
        }

        //Método para fechar a conexao
        protected void FecharConexao()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public abstract int Incluir(T item);
        public abstract int Atualizar(T item);
        public abstract int Deletar(K chave);
        public abstract DataTable Buscar(K chave);
        public abstract DataTable Listar(K chave = default(K));
    }
}