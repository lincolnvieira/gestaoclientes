<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Async="true" Inherits="GestaoCliente.FacilAssist.Pages.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
         jQuery(function ($) {
             $("#ContentPlaceHolder1_txtCPF").mask("999.999.999-99"), { reverse: true };
         });
      </script> 
        <h4 class="m-3">Alterar</h4>
        <div class="form-row col-7">
            <div class="form-group col-md-8">
                <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtNome" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Nome invalido" ControlToValidate="txtNome" ForeColor="Red"
      ValidationExpression="^[a-zA-Z ]*$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="Label2" runat="server" Text="CPF"></asp:Label>
                <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control"></asp:TextBox>   
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtCPF" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Tipo de Cliente"></asp:Label>
                <asp:DropDownList ID="lstTipoCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Escolha uma opção" ControlToValidate="lstTipoCliente" InitialValue="Selecione" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="Label4" runat="server" Text="Situação"></asp:Label>
                <asp:DropDownList ID="lstSituacao" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Escolha uma opção" ControlToValidate="lstSituacao" InitialValue="Selecione" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="form-row col-7">
            <div class="form-group col-md-4">
                <asp:Label ID="Label5" runat="server" Text="Sexo"></asp:Label>
                <br />
                <asp:RadioButton ID="rdbMasculino" runat="server" GroupName="Sexo" Text=" Masculino" Checked="true" />
                <br />
                <asp:RadioButton ID="rdbFeminino" runat="server" GroupName="Sexo" Text=" Feminino" />
            </div>
        </div>
        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" CssClass="btn btn-primary m-3" OnClick="btnAlterar_Click" />
    </form>
</asp:Content>
