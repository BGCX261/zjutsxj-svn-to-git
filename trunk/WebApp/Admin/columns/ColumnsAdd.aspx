<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ColumnsAdd.aspx.cs" Inherits="WebApp.Admin.system.ManageAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加栏目</title>
    <link href="../style/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Top_Div">
    <div class="Top_bgcolor_right"><a href="Default.aspx">栏目导航</a></div>
    <div class="Top_bg_right">添加栏目</div>
    </div>
    <table style="width:100%;">
        <tr>
            <td style="width:100px;">
                栏目名称：</td>
            <td valign="middle">
                <asp:TextBox ID="Manage_Name" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>所属栏目：</td>
            <td>
                <asp:DropDownList ID="Manage_ParentId" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>折叠图片：</td>
            <td>
                <asp:TextBox ID="Manage_CollapseImage" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>打开图片：</td>
            <td>
                <asp:TextBox ID="Manage_OpenImage" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>管理地址：</td>
            <td>
                <asp:TextBox ID="Manage_Url" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Target：</td>
            <td>
                <asp:TextBox ID="Manage_Target" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>是否显示：</td>
            <td>
                <asp:RadioButtonList ID="Manage_Show" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="true">显示</asp:ListItem>
                    <asp:ListItem Value="false">隐藏</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="添加栏目" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    </form>
    </body>
</html>
