<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="reporte.aspx.vb" Inherits="EstudiantesOnline.reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 96px;
        }
        .auto-style2 {
            width: 142px;
        }
        .auto-style3 {
            width: 89%;
        }
        .auto-style4 {
            width: 879px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Reporte de Estudiantes"></asp:Label>
            <br />
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style1">FECHA</td>
                    <td>
                        <asp:Label ID="lbFecha" runat="server" Text="Hoy"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">MATERIA</td>
                    <td>
                        <asp:Label ID="lbMateria" runat="server" Text="Matematicas"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1017px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
            </Columns>
            <HeaderStyle BorderStyle="Solid" ForeColor="#000099" />
        </asp:GridView>
     
        <table class="auto-style3">
            <tr>
                <td class="auto-style2" style="border: thin solid #0000FF">Total de estudiantes</td>
                <td colspan="2" style="border: thin solid #0000FF">
                    <asp:Label ID="LbTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
