﻿<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultarRecords.aspx.cs" Inherits="DemoDatos.crudtabla.ConsultarRecords" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ****************************************************-->
    <!-- ****************************************************-->
    <script lang="JavaScript" type="text/javascript">
        function actualizarRegistro(registro)
        {
            console.log("entro a la funcion");
            alert("El registro del usuario " + registro + " se actualizó exitosamente");
        }

        function actualizarRegistroEliminacion(nombre)
        {
            if (nombre === "SIN REGISTRO") {
                alert("No se pudo eliminar el registro del contacto");
            }
            else
            {
                alert("El registro del usuario " + nombre + " se eliminó correctamente");
            }
        }

    </script>
    <div id="formularioConsulta" style="padding:20px;">
        <!--Contenido del formulario de consulta de registros-->
        <h5><b>CONSULTA DE REGISTROS DE LA TABLA RECORDS</b></h5>
        
        <br />
        <asp:GridView ID="tablaDatosRecords" runat="server" 
            ViewStateMode="Enabled"
            AllowPaging="True" AllowSorting="True" 
            AutoGenerateColumns="False" 
            AutoGenerateEditButton="True" 
            AutoGenerateDeleteButton="True"
            onrowupdating="tablaDatosRecords_RowUpdating" 
            onrowdeleting="tablaDatosRecords_RowDeleting"
            onrowcancelingedit="tablaDatosRecords_RowCancelingEdit"
            onrowediting="tablaDatosRecords_RowEditing"
            DataKeyNames="id"  
            CellPadding="5" Width="400px" BorderWidth="1px"
            BackColor="#DEBA84" BorderColor="black" CellSpacing="2" OnSelectedIndexChanged="tablaDatosRecords_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Nombre Contacto">
                    <ItemTemplate>
                        <!--  Campo sin editar del nombre -->
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <!-- Campo del nombre en edición -->
                        <asp:TextBox ID="name" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Departamento">
                    <ItemTemplate>
                        <!--  Campo sin editar del departamento -->
                        <asp:DropDownList ID="sel_State" runat="server" 
                            AppendDataBoundItems="True" Enabled="False"
                            DataTextField="nombre" DataValueField="id"
                            SelectedValue='<%# Bind("State") %>' 
                            DataSourceID="origenDatosSampleConsulta">
                            <asp:ListItem Value="0">Seleccione un Departamento</asp:ListItem>
                        </asp:DropDownList>
                        <!-- Datasource del combo -->
                        <asp:SqlDataSource ID="origenDatosSampleConsulta" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
                            SelectCommand="select id, nombre from dbo.tbl_States order by id asc">
                        </asp:SqlDataSource>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <!-- Campo del nombre en departamento -->
                        <asp:DropDownList ID="state" runat="server" 
                            AppendDataBoundItems="true" 
                            DataTextField="nombre" DataValueField="id"
                            SelectedValue='<%# Bind("State") %>' 
                            DataSourceID="origenDatosSample">
                            <asp:ListItem Value="0">Seleccione un Departamento</asp:ListItem>
                        </asp:DropDownList>
                        <!-- Datasource del combo -->
                        <asp:SqlDataSource ID="origenDatosSample" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
                            SelectCommand="select id, nombre from dbo.tbl_States order by id asc">
                        </asp:SqlDataSource>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="datasourceGrilla" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
            SelectCommand="SELECT * FROM [tbl_Record] order by id desc">
        </asp:SqlDataSource>
        <br />
        <asp:LinkButton ID="enlaceRetorno" runat="server" OnClick="enlaceRetorno_Click">Regresar a la Página Principal</asp:LinkButton>
    </div>
    <!-- ****************************************************-->
    <!-- ****************************************************-->
</asp:Content>
