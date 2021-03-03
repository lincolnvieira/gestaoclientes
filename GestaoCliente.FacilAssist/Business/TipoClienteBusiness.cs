using GestaoCliente.FacilAssist.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Business
{
    public class TipoClienteBusiness
    {
        private static TipoClienteBusiness _instance;

        public static TipoClienteBusiness GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TipoClienteBusiness();
            }
            return _instance;
        }

        public DataTable Listar()
        {
            return TipoClienteDao.GetInstance().Listar();
        }
    }
}