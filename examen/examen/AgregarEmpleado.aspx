<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="examen.AgregarEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
 
 
        .auto-style1 {
            margin-left: 219px;
        }
        .auto-style2 {
            width: 201px;
        }
 
        </style>
</head>
<body>
    <form id="form1" runat="server">
           
                
        <div>
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" CssClass="auto-style1" >  
     
        <table >
            <tr>
                
                <td class="auto-style2">
                   <td>
                       <asp:Label ID="Label1" runat="server" Text="Agregar Nuevos Empleados" Font-Bold="True" Width="242px" >

                       </asp:Label>

                   </td>
                      <caption>
                          <br />
                    </caption>
                </td>
                    
            </tr>


            <tr>
                
                <td class="auto-style2">
                   <td>
              <br />
                   </td>
                      <caption>
                          <br />
                    </caption>
                </td>
                    
            </tr>
            
            
            <tr>
                <td class="auto-style2">Nombre Completo:</td>
                <td>
                    
                    <asp:TextBox ID="Nombre" runat="server" Width="214px" ></asp:TextBox></td>
       
            </tr>
            <tr>
                <td class="auto-style2">Cedula:</td>
                <td>
                    <asp:TextBox ID="cedula" runat="server" Height="16px" Width="215px"></asp:TextBox></td>
          
                </tr>
            
           
                <tr>
                <td class="auto-style2">Correo:</td>
                <td>
                    <asp:TextBox ID="correo" runat="server" Height="16px" Width="215px" TextMode="Email"></asp:TextBox></td>
          
                </tr>

               
                   <tr>
                <td class="auto-style2">Area:</td>
                <td>
                    <asp:DropDownList ID="area" runat="server" Height="16px" Width="215px"></asp:DropDownList>
                </td>
                </tr>


                <tr>
                <td class="auto-style2">Jefe:</td>
                <td>
                    <asp:DropDownList ID="jefe" runat="server" Height="16px" Width="215px"></asp:DropDownList>
                </td>
                    
                </tr>


            <tr>
                <td class="auto-style2">Nacimiento:</td>
                <td>
                    <asp:TextBox ID="fecha" runat="server" Height="16px" type="date" Width="215px"></asp:TextBox>
                   </td>
                </tr>


                        <tr>
                <td class="auto-style2">Reclutamiento:</td>
                <td>
                    <asp:TextBox ID="fecha2" runat="server" Height="16px" type="date" Width="215px"></asp:TextBox>
                 </td>
                </tr>

                <tr>
                <td class="auto-style2">Añadir Foto:</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    
                </td>
                </tr>

            
            <tr>
                <td class="auto-style2">
                    <br />
                    <asp:Button ID="guardar_empleado" runat="server" Text="Guardar Empleado" OnClick="btnSave_Click" /></td>
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
