<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="examen.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="144px" HorizontalAlign="Center" Width="860px">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Areas" Width="147px" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Ver Organización" Width="147px" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Empleados" Width="147px" />
    </asp:Panel>
    <br />
</asp:Content>
