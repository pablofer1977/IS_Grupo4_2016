<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmTarjetasModificacion.aspx.vb" Inherits="SGD.frmTarjetasModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="frmTarjetasModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Modificación de Tarjeta</h4>
            </div>

            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Código de Tarjeta:</label>
                    <asp:Label ID="lblId" runat="server"></asp:Label>
                </div>
        
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Nombre de Tarjeta o CBU:</label>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="30"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Tipo de Presentación:</label>
                    <asp:Label ID="lblTipoPresentacion" runat="server"></asp:Label>
                </div>
        
                <div class="row">
                    <label class="control-label col-sm-2" for="descripcion">Nombre del Archivo:</label>
                    <asp:TextBox ID="txtNombreArchivo" runat="server" MaxLength="100"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="descripcion">Nro. de Comercio:</label>
                    <asp:TextBox ID="txtNroComercio" runat="server" MaxLength="15"></asp:TextBox>
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