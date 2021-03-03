using GestaoCliente.FacilAssist.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.DataAccess
{
    public class TipoClienteDao : Dao<TipoCliente, int>
    {
        private static TipoClienteDao _instance;

        public static TipoClienteDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TipoClienteDao();
            }
            return _instance;
        }
        public override int Atualizar(TipoCliente item)
        {
            throw new NotImplementedException();
        }

        public override DataTable Buscar(int chave)
        {
            throw new NotImplementedException();
        }

        public override int Deletar(int chave)
        {
            throw new NotImplementedException();
        }

        public override int Incluir(TipoCliente item)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listar(int chave = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexao();
                cmd.CommandText = "sp_listarTipoCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }

            return dataTable;
        }
    }
}