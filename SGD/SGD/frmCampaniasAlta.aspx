<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCampaniasAlta.aspx.vb" Inherits="SGD.frmCampaniasAlta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="CampaniasAlta" ContentPlaceHolderID="body" runat="server">
    <div>
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" MaxLength="50"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="250" Rows="4" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
        </div>
    </div>
</asp:Content>