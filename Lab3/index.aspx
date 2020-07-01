<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Lab3.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            
            <asp:Panel runat="server">
            <table>
                <tr>
                    <td><asp:Label Text="Nombre Herramienta" runat="server" /></td>
                    <td><asp:TextBox runat="server" id="txtCT_nombre"/></td>
                </tr>
                <tr>
                    <td><asp:Label Text="Codigo Herramienta" runat="server" /></td>
                    <td><asp:TextBox runat="server" id="txtCT_codigo"/></td>
                </tr>
                <tr>
                    <td><asp:Label Text="Marca Herramienta" runat="server" /></td>
                    <td><asp:TextBox runat="server" id="txtCT_marca"/></td>
                </tr>
                <tr>
                   <td><asp:Label runat="server" Text="Categoría" /></td>
                            <td><asp:DropDownList runat="server" ID="DropDownListcategoriaHerramienta">

                                </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label Text="Precio" runat="server" /></td>
                    <td><asp:TextBox runat="server" id="txtCT_precio"/></td>
                </tr>
            </table>
                <asp:Button Text="Registrar" runat="server" id="btnregistrar" OnClick="btnregistrar_Click"/>
                <asp:Button Text="Borrar" runat="server" id="btnborrar" OnClick="btnborrar_Click"/>
                <asp:Button Text="Actualizar" runat="server" id="btnactualizar" OnClick="btnactualizar_Click"/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
