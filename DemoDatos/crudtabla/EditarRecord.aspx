<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarRecord.aspx.cs" Inherits="DemoDatos.crudtabla.EditarRecord" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div id="formularioEdicion" style="padding:20px;">

                        <asp:TextBox ID="username" runat="server" DataTextField="Name" DataValueField="Name" ></asp:TextBox>
                        <!-- Campo del nombre en departamento -->
                        <asp:DropDownList ID="stateList" runat="server" 
                            DataTextField="nombre" DataValueField="id" Height="16px" Width="213px"
                            >
                            <asp:ListItem Value="0">Seleccione departamento</asp:ListItem>
                        </asp:DropDownList>
                        <!-- Datasource del combo -->
                   <%--     <asp:SqlDataSource ID="origenDatosSample2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:SampleConnectionString %>" 
                            SelectCommand="select id, Name from dbo.tbl_Record order by id asc">
                        </asp:SqlDataSource>--%>
                        <asp:Button ID="Button1" runat="server" Text="Actualizar usuario" Width="201px" OnClick="Button1_Click" />
</div>
</asp:Content>

