<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="clientesForm.aspx.vb" Inherits="EstudiantesOnline.clientesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        <style type="text/css" >
        .form-style-3 {
            max-width: 450px;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .form-style-3 label {
            display: block;
            margin-bottom: 10px;
        }

            .form-style-3 label > span {
                float: left;
                width: 100px;
                font-weight: bold;
                font-size: 13px;
                text-shadow: 1px 1px 1px #fff;
            height: 15px;
        }

        .form-style-3 fieldset {
            border-radius: 10px;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            margin: 0px 0px 10px 0px;
            border: 1px solid #FFD2D2;
            padding: 20px;
            background: #FFF4F4;
            box-shadow: inset 0px 0px 15px #FFE5E5;
            -moz-box-shadow: inset 0px 0px 15px #FFE5E5;
            -webkit-box-shadow: inset 0px 0px 15px #FFE5E5;
            background-color: #99CCFF;
        }

            .form-style-3 fieldset legend {
                border-top: 1px solid #FFD2D2;
                border-left: 1px solid #FFD2D2;
                border-right: 1px solid #FFD2D2;
                border-radius: 5px 5px 0px 0px;
                -webkit-border-radius: 5px 5px 0px 0px;
                -moz-border-radius: 5px 5px 0px 0px;
                background: #FFF4F4;
                background-color: #99CCFF;
                padding: 0px 8px 3px 8px;
                box-shadow: -0px -1px 2px #F1F1F1;
                -moz-box-shadow: -0px -1px 2px #F1F1F1;
                -webkit-box-shadow: -0px -1px 2px #F1F1F1;
                font-weight: normal;
                font-size: 12px;
            }

        .form-style-3 textarea {
            width: 250px;
            height: 100px;
        }

        .form-style-3 input[type=text],
        .form-style-3 input[type=date],
        .form-style-3 input[type=datetime],
        .form-style-3 input[type=number],
        .form-style-3 input[type=search],
        .form-style-3 input[type=time],
        .form-style-3 input[type=url],
        .form-style-3 input[type=email],
        .form-style-3 select,
        .form-style-3 textarea {
            border-radius: 3px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border: 1px solid #FFC2DC;
            outline: none;
            padding: 5px 8px 5px 8px;
            box-shadow: inset 1px 1px 4px #FFD5E7;
            -moz-box-shadow: inset 1px 1px 4px #FFD5E7;
            -webkit-box-shadow: inset 1px 1px 4px #FFD5E7;
            background: #FFEFF6;
            margin-left: 44px;
        }

        .form-style-3 input[type=submit],
        .form-style-3 input[type=button] {
            background: #EB3B88;
            border: 1px solid #C94A81;
            padding: 5px 15px 5px 15px;
            color: #FFCBE2;
            box-shadow: inset -1px -1px 3px #FF62A7;
            -moz-box-shadow: inset -1px -1px 3px #FF62A7;
            -webkit-box-shadow: inset -1px -1px 3px #FF62A7;
            border-radius: 3px;
            border-radius: 3px;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            font-weight: bold;
        }

        .required {
            color: red;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="margin: 40px 400px 40px 400px;">
    <div class="form-style-3">
        <div style="width: fit-content; background-color: #99CCFF;">
            <h2>REGISTRO DE CLIENTES</h2>
            <fieldset>
                <legend>Cliente</legend>
                <label for="txtID">
                    <span>ID <span class="required">*</span></span>
                    <asp:TextBox ID="txtID" runat="server" Width="50px"></asp:TextBox>
                </label>
                <label for="field1">
                    <span>Nombre <span class="required">*</span></span>
                    <asp:TextBox ID="field1" runat="server" Width="215px"></asp:TextBox>
                </label>
                <label for="field2">
                    <span>Email <span class="required">*</span></span>
                    <asp:TextBox ID="field2" runat="server" Width="215px"></asp:TextBox>
                </label>
                <label for="field3">
                    <span>Telefono<span class="required"> *</span></span>
                    <asp:TextBox ID="field3" runat="server" Width="215px"></asp:TextBox>
                </label>
                <label for="field4">
                    <span>DUI<span class="required"> *</span></span>
                    <asp:TextBox ID="field4" runat="server" Width="215px"></asp:TextBox>
                </label>
                <label for="field5">
                    <span>Direccion<span class="required"> *</span></span>
                    <asp:TextBox ID="field5" runat="server" Width="215px"></asp:TextBox>
                </label>
            </fieldset>
            <fieldset>
                <legend>Acciones</legend>
                <label>
                    <asp:Button ID="btnBuscar" runat="server" Text="VER" Width="119px" />
                    <asp:Button ID="Button2" runat="server" Text="AGREGAR NUEVO" Width="200px" />
                    <asp:Button ID="Button5" runat="server" Text="ACEPTAR" Width="119px" />
                    <asp:Button ID="Button3" runat="server" Text="EDITAR" Width="119px" />
                    <asp:Button ID="Button1" runat="server" Text="CANCELAR" Width="119px" />
                    <asp:Button ID="Button4" runat="server" Text="ELIMINAR" Width="119px" />
                </label>
            </fieldset>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="672px">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />
                    <asp:BoundField DataField="CORREO" HeaderText="CORREO" />
                    <asp:BoundField DataField="TELEFONO" HeaderText="TELEFONO" />
                    <asp:BoundField DataField="DOCUMENTO" HeaderText="DOCUMENTO" />
                    <asp:BoundField DataField="DIRECCION" HeaderText="DIRECCION" />
                    <asp:ButtonField CommandName="Select" HeaderText="CHECK" ShowHeader="True" Text="SELECT" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
