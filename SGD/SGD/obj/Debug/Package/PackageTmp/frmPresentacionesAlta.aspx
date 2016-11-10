<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPresentacionesAlta.aspx.vb" Inherits="SGD.frmPresentacionesAlta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="CampaniasAlta" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Generación Archivos para Presentaciones</h4>
                </div>

                <div class="panel-body">        
                    <div class="row">
                        <label class="control-label col-sm-2" for="tipopresentacion">Tipo de Presentación:</label>
                        <asp:DropDownList ID="cmbTipoPresentacion" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                       
                    <div class="row">
                        <label class="control-label col-sm-2" for="tarjeta">Nombre de Tarjeta:</label>
                        <asp:DropDownList ID="cmbTarjeta" runat="server"></asp:DropDownList>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="mes">Mes:</label>
                        <asp:DropDownList ID="cmbMes" runat="server"></asp:DropDownList>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="anio">Año:</label>
                        <asp:TextBox ID="txtAnio" runat="server" MaxLength="4"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="anio">Carpeta:</label>
                        <asp:Label ID="lblCarpeta" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnGenerar" runat="server" Text="Generar Archivo" CssClass="btn btn-primary"/>
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