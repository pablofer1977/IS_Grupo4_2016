<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmUsuariosAlta.aspx.vb" Inherits="SGD.frmUsuariosAlta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="UsuariosAlta" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Alta de Usuario</h4>
            </div>

            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-sm-2" for="usuario">Usuario:</label>
                    <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="password">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="password2">Confirme Password:</label>
                    <asp:TextBox ID="txtPassword2" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="perfil">Perfil:</label>
                    <asp:DropDownList ID="cmdPerfil" runat="server"></asp:DropDownList>
                </div>

            </div>

            <div class="panel-footer">
                <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
