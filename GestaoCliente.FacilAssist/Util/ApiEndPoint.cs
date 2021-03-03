using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Util
{
    public static class ApiEndPoint
    {
        public const string ApiCliente = "https://localhost:44397/api/ClienteApi/";
        public const string ApiTipoCliente = "https://localhost:44397/api/TipoClienteApi/";
        public const string ApiSituacao = "https://localhost:44397/api/SituacaoApi/";
        
        public const string Inserir = "Inserir";
        public const string Atualizar = "Atualizar";
        public const string Listar = "Listar";
        public const string Deletar = "Deletar/";
        public const string Buscar = "Buscar/";
    }
}