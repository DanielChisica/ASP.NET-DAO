<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarRecord.aspx.cs" Inherits="DemoDatos.crudtabla.ModificarRecord" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ****************************************************-->
    <!-- ****************************************************-->
    <div id="formularioModificacion" style="padding:20px;">

                        <asp:Label ID="Label1" runat="server" Text="Seleccione el nombre de usuario"></asp:Label>
                        <!-- Campo del nombre en departamento -->
                        <asp:DropDownList ID="userList" runat="server" 
                            DataTextField="Name" DataValueField="id" Height="16px" Width="213px"
                            >
                            <asp:ListItem Value="0">Seleccione un usuario</asp:ListItem>
                        </asp:DropDownList>
                        <!-- Datasource del combo -->
                   <%--     <asp:SqlDataSource ID="origenDatosSample2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
                            SelectCommand="select id, Name from dbo.tbl_Record order by id asc">
                        </asp:SqlDataSource>--%>
                    <asp:Button ID="Button1" runat="server" Text="Modificar usuario" Width="201px" OnClick="Button1_Click"/>
    </div>
    <!-- ****************************************************-->
    <!-- ****************************************************-->
</asp:Content>
