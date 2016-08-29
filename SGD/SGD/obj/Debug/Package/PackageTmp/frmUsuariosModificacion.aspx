<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmUsuariosModificacion.aspx.vb" Inherits="SGD.frmUsuariosModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="UsuariosModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Modificación de Usuario</h4>
            </div>

            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-sm-2" for="usuario">Usuario:</label>
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </div>
        
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="perfil">Perfil:</label>
                    <asp:DropDownList ID="cmdPerfil" runat="server"></asp:DropDownList>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="estado">Estado:</label>
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="fechaalta">Fecha de Alta:</label>
                    <asp:Label ID="lblFechaAlta" runat="server"></asp:Label>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="fechabaja">Fecha de Baja:</label>
                    <asp:Label ID="lblFechaBaja" runat="server"></asp:Label>
                </div>
            </div>

            <div class="panel-footer">
                <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
