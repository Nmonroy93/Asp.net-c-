<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarHabilidades.aspx.cs" Inherits="examen.AgregarHabilidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        form { 
margin: 0 auto; 
width:250px;
}
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
     <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <table >
            <tr>
                
                <td>

                    <asp:Label ID="Label1" runat="server" Text="Agregar Habilidades" Font-Bold="True" Width="206px"></asp:Label>
                    <br />
                </td>
                    
            </tr>
            
            
            <tr>
                <td>Nombre Empleado:</td>
                <td>
                    
                    <asp:DropDownList ID="empleado_lista" runat="server" Width="200px">
                    </asp:DropDownList>
                </td>
       
            </tr>
            <tr>
                <td>Habilidad Asignar:</td>
                <td>
                    <asp:DropDownList ID="habilidades_lista" runat="server" Width="200px">
    <asp:ListItem Enabled="true" Text="Selecccionar Habilidad" Value="-1"></asp:ListItem>
    <asp:ListItem Text=".NET" Value="1"></asp:ListItem>
    <asp:ListItem Text="SQL Server" Value="2"></asp:ListItem>
    <asp:ListItem Text="Subversion" Value="3"></asp:ListItem>
    <asp:ListItem Text="Oracle" Value="4"></asp:ListItem>
    <asp:ListItem Text="Java" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
          
                </tr>
            
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" /></td>
                <td>
                    <br />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>

    </asp:Panel>
</div> 
    
    </form>
</body>
</html>

