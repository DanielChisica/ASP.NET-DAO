<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Autenticar.aspx.cs" Inherits="DemoDatos.crudtabla.Autenticar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table id="tablaCrear" border="1" class="tablaDatos" align="center">
            <tr>
                <td style="width: 143px">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Nombre de Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_User" runat="server" Width="294px"></asp:TextBox>
                </td>
            </tr>
        <tr>
                <td style="width: 143px">
                    <asp:Label ID="Label2" runat="server" 
                        Text="Contraseña"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_password" runat="server" Width="294px"></asp:TextBox>
                </td>
            </tr>
        <tr style="">
            <td><asp:Button Text="Ingresar" runat="server" ID="btn_Ingresar" OnClick="btn_Ingresar_Click" /></td> 
            <td>
                    <asp:Label ID="txt_DatosAtuenticacion" runat="server" 
                        Text=""></asp:Label>
                </td>
        </tr>
    </table>
</asp:Content>
