<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="examen.Empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 860px;
            height: 664px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
   
        <br />
         <asp:Panel ID="Panel1" runat="server" Height="617px" HorizontalAlign="Center">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label5" runat="server" Font-Bold="True" HorizontalAlign="Center" Text="Listado De Empleados"></asp:Label>
             <br />
             <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_agregar_empleado" runat="server" OnClick="btn_agregar_empleado_Click" Text="Agregar Empleado" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btn_menu" runat="server" OnClick="btn_menu_Click" Text="Regresar" Width="147px" />
             <br />
             <br />
             <asp:Label ID="Label12" runat="server" Text="Ordenar por Area:"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged = "OnSelectedIndexChanged">
             </asp:DropDownList>
             
             <br />
             <br />
             <asp:GridView ID="GridView1" runat="server" AllowPaging="False" 
                 AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                 HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging" 
                
               
                 OnRowCommand="GridView1_RowCommand" 
                 OnRowDeleting="GridView1_RowDeleting" 

                  AutoGenerateEditButton = "True" 
                OnRowEditing = "GridView_RowEditing" 
                OnRowCancelingEdit = "GridView_RowCancelingEdit"

                 OnRowUpdating="GridView1_RowUpdating"  DataKeyNames="IdEmpleado"
                 OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                 ShowFooter="false" Width="477px" OnRowDataBound="GridView1_RowDataBound"
                 >
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                      <asp:TemplateField HeaderText="IdEmpleado">
                         <EditItemTemplate>
                             
                             <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("IdEmpleado") %>' Enabled="false"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label11" runat="server" Text='<%# Bind("IdEmpleado") %>'></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="NombreCompleto">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NombreCompleto") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("NombreCompleto") %>'></asp:Label>
                             </ItemTemplate>
                         
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Cedula">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Cedula") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label2" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                         </ItemTemplate>
                         
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Correo">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Correo") %>' TextMode="Email"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
                         </ItemTemplate>
                       </asp:TemplateField>

              <asp:TemplateField HeaderText="Jefe" >
                <EditItemTemplate>
                     <asp:DropDownList id="ddljefe"   AutoPostBack="true"      EnableViewState="true"
                        runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:Label ID="jefe" runat="server" Text='<%# Bind("IdJefe") %>' Visible="false"></asp:Label>
                     <asp:Label ID="lbljefe" runat="server" Text='<%# Eval("jefe")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                         <asp:TemplateField HeaderText="Area" >
                <EditItemTemplate>
                     <asp:DropDownList id="ddlarea"   AutoPostBack="true"  EnableViewState="true"
                        runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:Label ID="area" runat="server" Text='<%# Bind("IdArea") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lblarea" runat="server" Text='<%# Eval("area")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                     

                     <asp:TemplateField HeaderText="Reclutamiento">
                          <EditItemTemplate>
                               <asp:TextBox ID="fecha" runat="server" Height="16px" type="date" Width="215px" Text='<%# Bind("f2") %>'></asp:TextBox>
                      </EditItemTemplate>
                        <ItemTemplate>
                     
                      <asp:Label ID="Label23" runat="server" Text='<%# Bind("f2") %>'></asp:Label>
                             
                          </ItemTemplate>
                       </asp:TemplateField>


                     <asp:TemplateField HeaderText="Nacimiento">
                         <EditItemTemplate>
                               <asp:TextBox ID="fecha2" runat="server" Height="16px" type="date" Width="215px" Text='<%# Bind("f1") %>'></asp:TextBox>
                          
                      </EditItemTemplate>
                        <ItemTemplate>
                            
                            <asp:Label ID="Label13" runat="server" Text='<%# Bind("f1") %>'></asp:Label>
                          </ItemTemplate>
                       </asp:TemplateField>



                    <%-- FOTO--%>
                     <asp:TemplateField HeaderText="Foto">
                          <ItemTemplate>
                       <asp:Image ID="Image1" runat="server" Width="75"  Height="75"/>
                         </ItemTemplate>
                      </asp:TemplateField>
                     

                                       
    
                     

               
                     <asp:TemplateField HeaderText="Eliminar">
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandArgument='<%#Bind("IdEmpleado") %>' CommandName="Eliminar" OnClientClick="javascript: return confirm('Esta Seguro de Eliminar este Registro?')" Text="Eliminar"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Información">
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton55" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Seleccionar" Text="Seleccionar"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                   <%--<asp:TemplateField HeaderText="Actualizar">
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton155" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Actualizar" Text="Editar"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>--%>
                   <asp:TemplateField HeaderText="Edición de Fotografia">
                         <ItemTemplate>
                             <asp:FileUpload ID="FileUpload1" runat="server" />
                             <asp:LinkButton ID="LinkButton200" runat="server" CausesValidation="False" CommandArgument="<%# Container.DataItemIndex %>" CommandName="EditarFoto" Text="Subir Foto"></asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                    
                     
          

                 </Columns>
                 
             </asp:GridView>
             
        </asp:Panel>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
