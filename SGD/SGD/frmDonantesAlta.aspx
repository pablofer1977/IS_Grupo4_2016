<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonantesAlta.aspx.vb" Inherits="SGD.frmDonantesAlta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonantesAlta" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Alta de Donante</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <label class="control-label col-sm-2" for="tipodonante">Tipo de Donante:</label>
                        <asp:DropDownList ID="cmbTipoDonante" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </div>
                  
                    <div class="row">
                        <label class="control-label col-sm-2" for="apellido">Apellido/s:</label>
                        <asp:TextBox ID="txtApellido" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                  
                    <div class="row">
                        <label class="control-label col-sm-2" for="nombre">Nombre/s:</label>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="razonsocial">Razón Social:</label>
                        <asp:TextBox ID="txtRazonSocial" runat="server" MaxLength="100"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="direccion">Dirección:</label>
                        <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="localidad">Localidad:</label>
                        <asp:TextBox ID="txtLocalidad" runat="server" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="codigopostal">Código Postal:</label>
                        <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="10"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="provincia">Provincia:</label>
                        <asp:DropDownList ID="cmbProvincia" runat="server"></asp:DropDownList>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="nrodocumento">Nro. de Documento:</label>
                        <asp:TextBox ID="txtNroDocumento" runat="server" MaxLength="8"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="cuit">Nro. de CUIL/CUIT:</label>
                        <asp:TextBox ID="txtCUIT" runat="server" MaxLength="11"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="telinea">Teléfono de Línea:</label>
                        <asp:TextBox ID="txtTE_Linea" runat="server" MaxLength="15"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="tecelular">Teléfono Celular:</label>
                        <asp:TextBox ID="txtTE_Celular" runat="server" MaxLength="15"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="telaboral">Teléfono Laboral:</label>
                        <asp:TextBox ID="txtTE_Laboral" runat="server" MaxLength="15"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="email">Correo Electrónico:</label>
                        <asp:TextBox ID="txtEMail" runat="server" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="comentarios">Comentarios:</label>
                        <asp:TextBox ID="txtComentarios" runat="server" MaxLength="250" Rows="4" TextMode="MultiLine"></asp:TextBox>
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