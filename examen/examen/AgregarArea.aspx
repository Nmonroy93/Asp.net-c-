<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArea.aspx.cs" Inherits="examen.AgregarArea" %>

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

                    <asp:Label ID="Label1" runat="server" Text="Agregar Nuevas Areas" Font-Bold="True" Width="206px"></asp:Label>
                    <br />
                </td>
                    
            </tr>
            
            
            <tr>
                <td>Nombre:</td>
                <td>
                    
                    <asp:TextBox ID="Nombre" runat="server" Width="214px"   ></asp:TextBox></td>
       
            </tr>
            <tr>
                <td>Descripción:</td>
                <td>
                    <asp:TextBox ID="Descripcion" runat="server" Height="43px" Width="215px" ></asp:TextBox></td>
          
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
