<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCampaniasModificacion.aspx.vb" Inherits="SGD.frmCampaniasModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="frmCampaniasModificacion" ContentPlaceHolderID="body" runat="server">
    <div>
        <div>
            <asp:Label ID="lblNro" runat="server" Text="Nro.:"></asp:Label>
            <asp:Label ID="lblId" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" Rows="4" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblEstado2" runat="server" Text="Estado:"></asp:Label>
            <asp:Label ID="lblEstado" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lblFechaAlta2" runat="server" Text="Fecha de Alta:"></asp:Label>
            <asp:Label ID="lblFechaAlta" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Label ID="lblFechaBaja2" runat="server" Text="Fecha de Baja:"></asp:Label>
            <asp:Label ID="lblFechaBaja" runat="server"></asp:Label>
        </div>

        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </div>
    </div>
</asp:Content>