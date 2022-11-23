<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
        <h1> Employee Details</h1>
    </center>
    <br />
    <br />
    <form id="form1" runat="server">
        <div>
            <table align ="center" class ="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                     <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Employee_id" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"  >
                            <Columns><asp:TemplateField>
                                    <itemTemplate>
                                        <input type="checkbox" runat="server" name="ch"  id="ch" value= '<%#Eval("Employee_id") %>' /> 
                                    </itemTemplate>
                                </asp:TemplateField>
                                
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Designation" HeaderText="Email" />
                                <asp:BoundField DataField="Salary" HeaderText="Age" />
                                <asp:CommandField HeaderText="edit" ShowEditButton="True" />
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                               
                                <asp:HyperLinkField DataNavigateUrlFields="Employee_id" DataNavigateUrlFormatString="test.aspx?id={0}" HeaderText="view details" Text="Go" />
                               
                            </Columns>
    

                        </asp:GridView>
                      <center>  <asp:Button ID="Button1" runat="server" Text="DELETE " OnClick="Button1_Click"/></center>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
