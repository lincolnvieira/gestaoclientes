using GestaoCliente.FacilAssist.Models;
using GestaoCliente.FacilAssist.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCliente.FacilAssist.Pages
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                CarregaTela(id);


            }

        }

        public async void CarregaTela(int id)
        {
            await CarregarCombos();
            await CarregaInfos(id);
        }

        private async Task CarregaInfos(int id)
        {
            try
            {
                var IntegrationJsonString = await CallApi.GetInfo(ApiEndPoint.ApiCliente + ApiEndPoint.Buscar + id);
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(IntegrationJsonString);

                Session["ClienteIdAlterar"] = cliente.ClienteId;

                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;
                lstTipoCliente.SelectedIndex = 0;
                lstSituacao.SelectedIndex = 0;
                lstTipoCliente.SelectedIndex = cliente.mTipoCliente;
                lstSituacao.SelectedIndex = cliente.mSituacao;

                if (cliente.Sexo == "F")
                {
                    rdbFeminino.Checked = true;
                }
                else
                {
                    rdbMasculino.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Page, "Erro ao carregar informações do cliente: " + ex.Message);
            }
        }
        protected async void btnAlterar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                if (!ValidaCPF.IsCpf(txtCPF.Text))
                {
                    MessageBox.Show(this.Page,"CPF inválido");
                    return;
                }

                try
                {
                    Cliente cliente = new Cliente();
                    cliente.ClienteId = int.Parse(Session["ClienteIdAlterar"].ToString());
                    cliente.Nome = txtNome.Text;
                    cliente.CPF = txtCPF.Text.Replace(".","").Replace("-","");
                    cliente.mSituacao = lstSituacao.SelectedIndex;
                    cliente.mTipoCliente = lstTipoCliente.SelectedIndex;
                    if (rdbFeminino.Checked == true)
                        cliente.Sexo = "F";
                    else if (rdbMasculino.Checked == true)
                        cliente.Sexo = "M";


                    var message = JsonConvert.SerializeObject(cliente);
                    var response = await CallApi.InsertAlterInfo(message, HttpMethod.Put, ApiEndPoint.ApiCliente + ApiEndPoint.Atualizar);

                    MessageBox.Show(this.Page, response.ReasonPhrase);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Response.Redirect("Listar.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this.Page, "Erro ao alterar: " + ex.Message);
                } 
            }

        }
        private async Task CarregarCombos()
        {
            try
            {
                var IntegrationJsonStringTipoCliente = await CallApi.GetInfo(ApiEndPoint.ApiTipoCliente + ApiEndPoint.Listar);
                DataTable dtTipoCliente = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonStringTipoCliente, (typeof(DataTable)));

                lstTipoCliente.DataSource = dtTipoCliente;
                lstTipoCliente.DataTextField = dtTipoCliente.Columns["Descricao"].ToString();
                lstTipoCliente.DataValueField = dtTipoCliente.Columns["TipoClienteId"].ToString();
                lstTipoCliente.DataBind();
                lstTipoCliente.Items.Insert(0, "Selecione");

                var IntegrationJsonStringSituacao = await CallApi.GetInfo(ApiEndPoint.ApiSituacao + ApiEndPoint.Listar);
                DataTable dtSituacao = (DataTable)JsonConvert.DeserializeObject(IntegrationJsonStringSituacao, (typeof(DataTable)));

                lstSituacao.DataSource = dtSituacao;
                lstSituacao.DataTextField = dtSituacao.Columns["Descricao"].ToString();
                lstSituacao.DataValueField = dtSituacao.Columns["SituacaoId"].ToString();
                lstSituacao.DataBind();
                lstSituacao.Items.Insert(0, "Selecione");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Page, "Erro carregar combos: " + ex.Message);
            }
        }
    }
}
