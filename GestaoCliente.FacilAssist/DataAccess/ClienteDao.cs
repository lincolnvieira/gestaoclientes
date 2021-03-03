using GestaoCliente.FacilAssist.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.DataAccess
{
    public class ClienteDao : Dao<Cliente, int>
    {
        private static ClienteDao _instance;

        public static ClienteDao GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClienteDao();
            }
            return _instance;
        }

        public override int Atualizar(Cliente item)
        {
            try
            {
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_alteracao";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", item.ClienteId);
                cmd.Parameters.AddWithValue("@nome", item.Nome);
                cmd.Parameters.AddWithValue("@cpf", item.CPF);
                cmd.Parameters.AddWithValue("@tipoCliente", item.mTipoCliente);
                cmd.Parameters.AddWithValue("@sexo", item.Sexo);
                cmd.Parameters.AddWithValue("@situacao", item.mSituacao);

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@status",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
                int status = (int)parameter.Value;
                return status;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public override DataTable Buscar(int chave)
        {
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexao();
                cmd.CommandText = "sp_buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", chave);
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public override int Deletar(int chave)
        {
            try
            {
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_exclusao";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", chave);

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@status",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();



                int status = (int)parameter.Value;
                return status;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public override int Incluir(Cliente item)
        {
            try
            {
                AbrirConexao();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_inclusao";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", item.Nome);
                cmd.Parameters.AddWithValue("@cpf", item.CPF);
                cmd.Parameters.AddWithValue("@tipoCliente", item.mTipoCliente);
                cmd.Parameters.AddWithValue("@sexo", item.Sexo);
                cmd.Parameters.AddWithValue("@situacao", item.mSituacao);

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@status",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
                return (int)parameter.Value;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }
        }

        public override DataTable Listar(int chave = 0)
        {
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexao();
                cmd.CommandText = "sp_listagem";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FecharConexao();
            }
            
        }
    }
}