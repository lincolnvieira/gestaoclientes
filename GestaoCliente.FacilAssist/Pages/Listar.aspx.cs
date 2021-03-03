using GestaoCliente.FacilAssist.Models;
using GestaoCliente.FacilAssist.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCliente.FacilAssist.Pages
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaRepeater();
            }
        }
        private async void CarregaRepeater()
        {
            try
            {
                var IntegrationJsonString = await CallApi.GetInfo(ApiEndPoint.ApiCliente + ApiEndPoint.Listar);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonString, (typeof(DataTable)));

                foreach (DataRow item in dt.Rows)
                {
                    string cpf = item["CPF"].ToString();
                    cpf = cpf.Insert(3, ".");
                    cpf = cpf.Insert(7, ".");
                    cpf = cpf.Insert(11, "-");
                    item["CPF"] = cpf;
                }

                gridClientes.DataSource = dt;
                gridClientes.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Page, "Erro ao carregar listar clientes: " + ex.Message);
            }

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var id = ((Button)sender).CommandArgument;
            Response.Redirect("Editar.aspx?id=" + id, false);
        }
        protected async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var id = ((Button)sender).CommandArgument;

                HttpResponseMessage response = await CallApi.DeleteInfo(ApiEndPoint.ApiCliente + ApiEndPoint.Deletar + id);

                MessageBox.Show(this.Page, response.ReasonPhrase);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    CarregaRepeater();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Page, "Erro ao excluir cliente: " + ex.Message);
            }
        }

    }
}