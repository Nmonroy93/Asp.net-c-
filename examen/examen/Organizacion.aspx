<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organizacion.aspx.cs" Inherits="examen.Organizacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <h3>Vista de la Organización.</h3>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Regresar" Width="154px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Agregar Habilidad" />
        </p>

<hr />
<asp:TreeView ID="TreeView1" runat="server" NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged1">
    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
</asp:TreeView>
    </form>
</body>
</html>
