<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_system_Default" StyleSheetTheme="" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站导航</title>
    <link href="../style/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Top_Div">
    <div class="Top_bg_right">栏目导航</div>
    </div>
    <div class="Top_Div1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CssClass="Body_border" HorizontalAlign="Left" Width="100%">
            <RowStyle CssClass="Body_Row" />
            <Columns>
                <asp:TemplateField HeaderText="栏目名称">
                    <ItemTemplate>
                        <%#Eval("Manage_Title")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Manage_Url" HeaderText="管理地址" />
                <asp:BoundField DataField="Manage_Target" HeaderText="Target" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="Manage_CollapseImage" HeaderText="节点折叠">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:ImageField DataImageUrlField="Manage_OpenImage" HeaderText="节点打开">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:TemplateField HeaderText="当前状态">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">显示</asp:ListItem>
                            <asp:ListItem Value="0">隐藏</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作栏目">
                    <ItemTemplate>
                        修改&nbsp; |&nbsp; 删除
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="Body_Header" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
