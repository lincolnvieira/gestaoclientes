using GestaoCliente.FacilAssist.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Business
{
    public class SituacaoBusiness
    {
        private static SituacaoBusiness _instance;

        public static SituacaoBusiness GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SituacaoBusiness();
            }
            return _instance;
        }

        public DataTable Listar()
        {
            return SituacaoDao.GetInstance().Listar();
        }
    }
}