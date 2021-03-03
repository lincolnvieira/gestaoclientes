<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout/Site.Master" AutoEventWireup="true" Async="true" CodeBehind="Listar.aspx.cs" Inherits="GestaoCliente.FacilAssist.Pages.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <script type="text/javascript">
         jQuery(function ($) {
             $("#ContentPlaceHolder1_gridClientes_lblCPF_1").mask("999.999.999-99");
         });
          </script> 
            <div class="m-3">
            <asp:Repeater ID="gridClientes" runat="server">
                <HeaderTemplate>
                    <h4>Lista de Clientes</h4>
                    <table class="table col-10">
                        <tr>
                            <th scope="col" style="width: 50px">ID</th>
                            <th scope="col" style="width: 200px">Nome </th>
                            <th scope="col" style="width: 120px">CPF</th>
                            <th scope="col" style="width: 120px">Sexo</th>
                            <th scope="col" style="width: 130px">Tipo de Cliente</th>
                            <th scope="col" style="width: 120px">Situação</th>
                            <th scope="col" style="width: 150px">Ações</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblClienteId" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "ClienteId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblNome" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCPF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CPF") %>' />
                        </td>
                                       <td>
                            <asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Sexo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoCliente") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Situacao") %>' />
                        </td>
                        <td>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CssClass="btn btn-secondary"
                                CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "ClienteId") %>' />

                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
                                OnClientClick="javascript:return confirm('Deseja realmente excluir?')" CssClass="btn btn-danger"
                                OnClick="btnExcluir_Click" CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "ClienteId") %>'/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
