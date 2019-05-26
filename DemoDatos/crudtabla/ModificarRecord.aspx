<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarRecord.aspx.cs" Inherits="DemoDatos.crudtabla.ModificarRecord" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ****************************************************-->
    <!-- ****************************************************-->
    <div id="formularioModificacion" style="padding:20px;">
                        <!-- Campo del nombre en departamento -->
                        <asp:DropDownList ID="user" runat="server" 
                            AppendDataBoundItems="true" 
                            DataTextField="nombre" DataValueField="id"
                            SelectedValue='<%# Bind("Name") %>' 
                            DataSourceID="origenDatosSample2">
                            <asp:ListItem Value="0">Seleccione un usuario</asp:ListItem>
                        </asp:DropDownList>
                        <!-- Datasource del combo -->
                        <asp:SqlDataSource ID="origenDatosSample2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
                            SelectCommand="select id, Name from dbo.tbl_Record order by id asc">
                        </asp:SqlDataSource>
    </div>
    <!-- ****************************************************-->
    <!-- ****************************************************-->
</asp:Content>
