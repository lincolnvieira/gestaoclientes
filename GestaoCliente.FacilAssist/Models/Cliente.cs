using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int mTipoCliente { get; set; }
        public string Sexo { get; set; }
        public int mSituacao { get; set; }
    }
}