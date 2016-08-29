<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmTarjetasRechazosModificacion.aspx.vb" Inherits="SGD.frmTarjetasRechazosModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="frmTarjetasRechazosModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Modificación de Causas de Rechazos</h4>
            </div>

            <div class="panel-body">
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Código de Tarjeta:</label>
                    <asp:Label ID="lblIdTarjeta" runat="server"></asp:Label>
                </div>
        
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Nombre de Tarjeta o CBU:</label>
                    <asp:Label ID="lblNombreTarjeta" runat="server"></asp:Label>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Tipo de Presentación:</label>
                    <asp:Label ID="lblTipoPresentacion" runat="server"></asp:Label>
                </div>
        
                <div class="row">
                    <label class="control-label col-sm-2" for="nombre">Código Banco:</label>
                    <asp:TextBox ID="txtCodBanco" runat="server" MaxLength="5"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="descripcion">Causa Rechazo:</label>
                    <asp:TextBox ID="txtCausaRechazo" runat="server" MaxLength="150"></asp:TextBox>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="descripcion">Causa OK:</label>
                    <asp:RadioButton ID="optCausaOK_SI" runat="server" Text="SI" GroupName="optCausaOK" Checked="True" />
                    <asp:RadioButton ID="optCausaOK_NO" runat="server" Text="NO" GroupName="optCausaOK" />
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="estado">Estado:</label>
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="estado">Fecha de Alta:</label>
                    <asp:Label ID="lblFechaAlta" runat="server"></asp:Label>
                </div>

                <div class="row">
                    <label class="control-label col-sm-2" for="estado">Fecha de Baja:</label>
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
