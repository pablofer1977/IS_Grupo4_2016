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

    <asp:ScriptManager ID="sManager" runat="server"></asp:ScriptManager>
                
    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="Modal_Error" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal_Error" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><asp:Label ID="lblTituloError" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
