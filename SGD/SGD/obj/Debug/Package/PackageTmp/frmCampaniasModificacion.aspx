<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCampaniasModificacion.aspx.vb" Inherits="SGD.frmCampaniasModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="frmCampaniasModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Modificación de Campaña</h4>
            </div>

            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="descripcion">Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary"/>
            </div>
        </div>
    </div>
</div>
</asp:Content>