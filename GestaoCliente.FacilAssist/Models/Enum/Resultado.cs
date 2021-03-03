using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoCliente.FacilAssist.Models.Enum
{
    public enum Resultado
    {
        CLIENTE_CADASTRADO_SUCESSO = 1,
        CLIENTE_EXISTE,
        CLIENTE_NAO_ENCONTRADO,
        CLIENTE_EXCLUIDO,
        ERRO
    }
}