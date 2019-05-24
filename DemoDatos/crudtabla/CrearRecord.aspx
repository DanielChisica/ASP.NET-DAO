<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearRecord.aspx.cs" Inherits="DemoDatos.crudtabla.CrearRecord" MasterPageFile="~/Site.Master"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ****************************************************-->
    <!-- ****************************************************-->
    <script type="text/javascript" lang="JavaScript">
        function confirmarAlmacenamiento(mensaje)
        {
            var confirmacion = confirm(mensaje);

            if (confirmacion == true)
                return (true);
            else
                return (false);
        }
    </script>
    <div id="formularioCreacion" style="padding:20px;">
        <!--Contenido del formulario de consulta de registros-->
        <h2>Creación de un nuevo Contacto</h2>
        <br />
        <table id="tablaCrear" border="1" class="tablaDatos" align="center">
            <tr>
                <td style="width: 143px">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Nombre del contacto:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_Name" runat="server" Width="294px"></asp:TextBox>
                </td>
            </tr>
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
                    <asp:Button ID="btn_Aceptar" runat="server" Text="Grabar Registro" 
                        OnClientClick="return confirmarAlmacenamiento('¿Está seguro que desea almacenar el registro? (S/N)')"
                        OnClick="btn_Aceptar_Click" Width="104px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_Reestablecer" runat="server" Text="Reestablecer" OnClick="btn_Reestablecer_Click" Width="91px" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <h5>Confirmación de la Creación:&nbsp;<b>
            <asp:Label ID="lbl_Confirmacion" runat="server"></asp:Label></b>
        </h5>
        <asp:LinkButton ID="enlaceRetorno" runat="server" OnClick="enlaceRetorno_Click">Regresar al Menú Principal</asp:LinkButton>
        <br />
        <br />
    </div>
    <!-- ****************************************************-->
    <!-- ****************************************************-->
</asp:Content>
