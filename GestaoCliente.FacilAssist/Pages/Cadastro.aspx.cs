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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoCliente.FacilAssist.Pages
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCombos();
            }
        }
        private async void CarregarCombos()
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
                MessageBox.Show(this.Page, "Erro ao carregar combos: " + ex.Message);
            }
        }

        protected async void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = txtNome.Text;
                    cliente.CPF = txtCPF.Text.Replace(".", "").Replace("-", "");
                    cliente.mSituacao = lstSituacao.SelectedIndex;
                    cliente.mTipoCliente = lstTipoCliente.SelectedIndex;
                    if (rdbFeminino.Checked == true)
                        cliente.Sexo = "F";
                    else if (rdbMasculino.Checked == true)
                        cliente.Sexo = "M";

                    var message = JsonConvert.SerializeObject(cliente);

                    HttpResponseMessage response = await CallApi.InsertAlterInfo(message, HttpMethod.Post, ApiEndPoint.ApiCliente + ApiEndPoint.Inserir);

                    MessageBox.Show(this.Page, response.ReasonPhrase);

                    if (response.StatusCode == HttpStatusCode.Created)
                        LimparCampos();
                    else
                        txtCPF.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this.Page, "Erro ao cadastrar cliente: " + ex.Message);
                }
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;
            lstSituacao.SelectedIndex = 0;
            lstTipoCliente.SelectedIndex = 0;
            rdbMasculino.Checked = true;

        }

 
    }
}