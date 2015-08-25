<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="5">
            <ItemTemplate>
                <table border="0" cellpadding="1" cellspacing="2" 
    width="100">
                    <tr>
                        <td align="center" height="100">
                            <img alt="" src="image/<%#Eval("ImageUrl") %>" /></td>
                    </tr>
                    <tr>
                        <td align="center"><%#Eval("ImageName") %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
