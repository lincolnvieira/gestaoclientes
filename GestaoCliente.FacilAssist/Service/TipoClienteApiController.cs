using GestaoCliente.FacilAssist.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestaoCliente.FacilAssist.Service
{
    public class TipoClienteApiController : ApiController
    {
        [HttpGet]
        public DataTable Listar()
        {

            return TipoClienteBusiness.GetInstance().Listar();
        }
    }
}
