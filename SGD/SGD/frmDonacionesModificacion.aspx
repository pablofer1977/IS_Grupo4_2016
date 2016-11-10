<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonacionesModificacion.aspx.vb" Inherits="SGD.frmDonacionesModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonacionesModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Modificación de Donación</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <label class="control-label col-sm-2" for="nrodonante">Nro. de Donante:</label>
                        <asp:Label ID="lblNroDonante" runat="server"></asp:Label>
                    </div>
                    
                    <div class="row">
                        <label class="control-label col-sm-2" for="nrodonacion">Nro. de Donación:</label>
                        <asp:Label ID="lblNroDonacion" runat="server"></asp:Label>
                    </div>
                    
                    <div class="row">
                        <label class="control-label col-sm-2" for="tipodonacion">Tipo de Donación:</label>
                        <asp:DropDownList ID="cmbTipoDonacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
                    </div>
                  
                    <div class="row">
                        <label class="control-label col-sm-2" for="tarjeta">Nombre de Tarjeta:</label>
                        <asp:DropDownList ID="cmbTarjeta" runat="server"></asp:DropDownList>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio en caso de Tipo de Donación 'Tarjeta']</label>
                    </div>
                  
                    <div class="row">
                        <label class="control-label col-sm-2" for="nrotarjeta">Número de Tarjeta:</label>
                        <asp:TextBox ID="txtNroTarjeta" runat="server" MaxLength="16"></asp:TextBox>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio en caso de Tipo de Donación 'Tarjeta']</label>
                    </div>
                  
                    <div class="row">
                        <label class="control-label col-sm-2" for="banco">Banco Emitente:</label>
                        <asp:TextBox ID="txtBanco" runat="server" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="vto">Vencimiento Tarjeta:</label>
                        <asp:TextBox ID="txtVto" runat="server" MaxLength="10"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="nrocbu">Número de CBU:</label>
                        <asp:TextBox ID="txtNroCBU" runat="server" MaxLength="22"></asp:TextBox>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio en caso de Tipo de Donación 'CBU']</label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="monto">Monto:</label>
                        <asp:TextBox ID="txtMonto" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="tiempo">Tiempo:</label>
                        <asp:TextBox ID="txtTiempo" runat="server" MaxLength="4" TextMode="Number"></asp:TextBox>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="campania">Campaña:</label>
                        <asp:DropDownList ID="cmbCampania" runat="server"></asp:DropDownList>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
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