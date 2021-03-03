using GestaoCliente.FacilAssist.DataAccess;
using GestaoCliente.FacilAssist.Models;
using GestaoCliente.FacilAssist.Models.Enum;
using GestaoCliente.FacilAssist.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Business
{
    public class ClienteBusiness
    {
        private static ClienteBusiness _instance;

        public static ClienteBusiness GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClienteBusiness();
            }
            return _instance;
        }
        public Resultado Inserir(Cliente cliente)
        {
            int result = ClienteDao.GetInstance().Incluir(cliente);

            return VerificaResult(result);
        }

        public Cliente Buscar(int id)
        {
            DataTable dataTable = ClienteDao.GetInstance().Buscar(id);

            Cliente cliente = new Cliente();
            foreach (DataRow item in dataTable.Rows)
            {
                cliente.ClienteId = (int)item["ClienteId"];
                cliente.Nome = item["Nome"].ToString();
                cliente.CPF = item["CPF"].ToString();
                cliente.Sexo = item["Sexo"].ToString();
                cliente.mTipoCliente = (int)item["mTipoCliente"];
                cliente.mSituacao = (int)item["mSituacao"];
            }

            return cliente;
        }

        public Resultado Atualizar(Cliente cliente)
        {
            int result = ClienteDao.GetInstance().Atualizar(cliente);

            return VerificaResult(result);
        }
        public DataTable Listar()
        {
            return ClienteDao.GetInstance().Listar();
        }
        public Resultado Deletar(int id)
        {
            int result = ClienteDao.GetInstance().Deletar(id);

            return VerificaResult(result);
        }
        private Resultado VerificaResult(int result)
        {
            RetornoMensagem.Mensagem = string.Empty;
            switch (result)
            {
                case 1:
                    RetornoMensagem.Mensagem = "Cliente Cadastrado com sucesso";
                    return Resultado.CLIENTE_CADASTRADO_SUCESSO;
                case 2:
                    RetornoMensagem.Mensagem = "Cliente já existente com este CPF";
                    return Resultado.CLIENTE_EXISTE;
                case 3:
                    RetornoMensagem.Mensagem = "Cliente não encontrado";
                    return Resultado.CLIENTE_NAO_ENCONTRADO;
                case 4:
                    RetornoMensagem.Mensagem = "Cliente excluido com sucesso";
                    return Resultado.CLIENTE_EXCLUIDO;
                default:
                    return Resultado.ERRO;
            }
        }


    }
}