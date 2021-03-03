using GestaoCliente.FacilAssist.Business;
using GestaoCliente.FacilAssist.Models;
using GestaoCliente.FacilAssist.Models.Enum;
using GestaoCliente.FacilAssist.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoCliente.FacilAssist.Service
{
    public class ClienteApiController : ApiController
    {
        [HttpPost]
        [Route("api/ClienteApi/Inserir")]
        public HttpResponseMessage Inserir([FromBody] Cliente cliente)
        {
            Resultado resultado = ClienteBusiness.GetInstance().Inserir(cliente);
            if (resultado == Resultado.CLIENTE_CADASTRADO_SUCESSO)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created);
                response.ReasonPhrase = RetornoMensagem.Mensagem;
                return response;
            }
            else
            {
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no servidor"),
                    ReasonPhrase = RetornoMensagem.Mensagem
                };
                return erro;
            }
        }

        [HttpPut]
        [Route("api/ClienteApi/Atualizar")]
        public HttpResponseMessage Atualizar([FromBody] Cliente cliente)
        {
            Resultado resultado = ClienteBusiness.GetInstance().Atualizar(cliente);
            if (resultado == Resultado.CLIENTE_CADASTRADO_SUCESSO)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.ReasonPhrase = RetornoMensagem.Mensagem;
                return response;
            }
            else
            {
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no servidor"),
                    ReasonPhrase = RetornoMensagem.Mensagem
                };
                return erro;
            }
        }

        [HttpGet]
        [Route("api/ClienteApi/Buscar/{id}")]
        public Cliente Buscar(int id)
        {
            return ClienteBusiness.GetInstance().Buscar(id);
        }

        [HttpGet]
        public DataTable Listar()
        {
            return ClienteBusiness.GetInstance().Listar();
        }

        [HttpDelete]
        [Route("api/ClienteApi/Deletar/{id}")]
        public HttpResponseMessage Deletar(int id)
        {
            Resultado resultado = ClienteBusiness.GetInstance().Deletar(id);
            if (resultado == Resultado.CLIENTE_EXCLUIDO)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.ReasonPhrase = RetornoMensagem.Mensagem;
                return response;
            }
            else
            {
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no servidor"),
                    ReasonPhrase = RetornoMensagem.Mensagem
                };
                return erro;
            }
        }
    }
}
