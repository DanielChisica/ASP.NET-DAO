<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta2.aspx.cs" Inherits="DemoDatos.crudtabla.Consulta2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formularioCreacion" style="padding:20px;">
        <!--Contenido del formulario de consulta de registros-->        
        <table id="tablaCrear" border="1" class="tablaDatos" align="center">
            <tr>
                <td style="width: 143px">
                    <asp:Label ID="Label2" runat="server" Text="Departamento:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="sel_Departamentos" runat="server" 
                        DataSourceID="origenDatosSample" 
                        AppendDataBoundItems="true"
                        DataTextField="nombre" DataValueField="id" Height="16px" Width="295px">
                        <asp:ListItem Value="0">Seleccione un Departamento</asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="origenDatosSample" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>"
                        SelectCommand="SELECT [id], [nombre] FROM [tbl_States]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="width: 143px; height: 12px;"></td>
                <td style="height: 12px">
                    <asp:Button ID="btn_Consultar" runat="server" Text="Consultar" 
                         Width="151px" OnClick="btn_Consultar_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="tablaDatosRecords" runat="server" >



        </asp:GridView>
        
    </div>
</asp:Content>
