<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonantesListado.aspx.vb" Inherits="SGD.frmDonantesListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonantesListado" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Filtros de Búsqueda</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <label class="control-label col-sm-2" for="apellido">Nro. de Donante:</label>
                            <asp:TextBox ID="txtNroDonante" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipodonante">Tipo de Donante:</label>
                            <asp:DropDownList ID="cmbTipoDonante" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="apellido">Nombre, Apellido o Razón Social:</label>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
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
                            <label class="control-label col-sm-2" for="nrodocumento">Nro. de Documento o CUIL/CUIT:</label>
                            <asp:TextBox ID="txtNroDocumento" runat="server" MaxLength="11"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="telinea">Teléfono:</label>
                            <asp:TextBox ID="txtTE" runat="server" MaxLength="15"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="email">Correo Electrónico:</label>
                            <asp:TextBox ID="txtEMail" runat="server" MaxLength="50"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="apellido">Nro. de Donación:</label>
                            <asp:TextBox ID="txtNroDonacion" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipodonacion">Estado:</label>
                            <asp:DropDownList ID="cmbEstado" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipodonacion">Tipo de Donación:</label>
                            <asp:DropDownList ID="cmbTipoDonacion" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tarjeta">Nombre de Tarjeta:</label>
                            <asp:DropDownList ID="cmbTarjeta" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="nrotarjeta">Número de Tarjeta o CBU:</label>
                            <asp:TextBox ID="txtNroTarjetaCBU" runat="server" MaxLength="22"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="campania">Campaña:</label>
                            <asp:DropDownList ID="cmbCampania" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>  
                    </div>
            
                </div>
            </div>

           <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Donantes</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donantes para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ver Donaciones" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            CommandName="VerDonaciones" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Ver.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro. de Donante"/>
                                <asp:BoundField DataField="FechaIng" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="Id_TipoDonante" Visible="False" />
                                <asp:BoundField DataField="TipoDonante" HeaderText="Tipo de Donante"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Apellido/s y Nombre/s o Razón Social"/>
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección"/>
                                <asp:BoundField DataField="Localidad" HeaderText="Localidad"/>
                                <asp:BoundField DataField="CP" HeaderText="Código Postal"/>
                                <asp:BoundField DataField="Id_Provincia" Visible="False" />
                                <asp:BoundField DataField="Provincia" HeaderText="Provincia"/>
                                <asp:BoundField DataField="DNI" HeaderText="Nro. de Documento"/>
                                <asp:BoundField DataField="CUIL_CUIT" HeaderText="Nro. de CUIL/CUIT"/>
                                <asp:BoundField DataField="TE" HeaderText="Teléfono/s"/>
                                <asp:BoundField DataField="EMail" HeaderText="Correo Electrónico"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>
                
                <div class="panel-footer">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Donante" CssClass="btn btn-primary"/>
                </div>
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">   
                    <h4><asp:Label ID="lblDonante" runat="server">Listado de Donaciones</asp:Label></h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grdD" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donaciones para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="ModificarD" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenModificar_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Dar de Baja" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="Baja" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenEstado_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro. de Donación"/>
                                <asp:BoundField DataField="Id_TipoDonacion" Visible="False"/>
                                <asp:BoundField DataField="TipoDonacion" HeaderText="Tipo de Donación"/>
                                <asp:BoundField DataField="Id_Tarjeta" Visible="False"/>
                                <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta"/>
                                <asp:BoundField DataField="NroTarjeta" HeaderText="Número de Tarjeta"/>
                                <asp:BoundField DataField="CBU" HeaderText="Número de CBU"/>
                                <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo"/>
                                <asp:BoundField DataField="Id_Campania" Visible="False"/> 
                                <asp:BoundField DataField="Campania" HeaderText="Campaña"/>
                                <asp:BoundField DataField="Id_Estado" Visible="False"/> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaDon" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnNuevoD" runat="server" Text="Nueva Donación" CssClass="btn btn-primary"/>
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