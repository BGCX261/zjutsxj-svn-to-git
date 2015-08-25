<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Admin.system.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>网站导航</title>
    <link href="../style/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Top_Div">
    <div class="Top_bg_right">栏目导航</div>
    <div class="Top_bgcolor_right"><a href="ColumnsAdd.aspx">添加栏目</a></div>
    </div>
    <div class="Top_Div1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CssClass="Body_border" HorizontalAlign="Left" Width="100%">
            <RowStyle CssClass="Body_Row" />
            <Columns>
                <asp:TemplateField HeaderText="栏目名称">
                    <ItemTemplate>
                        <%#WxSpace.Function.BackSpaces(Convert.ToInt16(Eval("Manage_Child"))) %><%#Eval("Manage_Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Manage_Url" HeaderText="管理地址" >
                    <HeaderStyle Width="150px" />
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Manage_Target" HeaderText="Target" >
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="Manage_CollapseImage" HeaderText="节点折叠" 
                    NullImageUrl="~/Admin/images/folder.gif">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:ImageField DataImageUrlField="Manage_OpenImage" HeaderText="节点打开" 
                    NullImageUrl="~/Admin/images/folderopen.gif">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:TemplateField HeaderText="当前状态">
                    <ItemTemplate>
                        <%#Eval("Manage_Show").ToString()=="True"?"显示":"隐藏"%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作栏目">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            CommandArgument='<%# Eval("Manage_Id") %>' oncommand="LinkButton1_Command">上移</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton
                            ID="LinkButton2" runat="server" CommandArgument='<%# Eval("Manage_Id") %>' 
                            oncommand="LinkButton2_Command">下移</asp:LinkButton>&nbsp;|&nbsp;<a href="ColumnsEdit.aspx?id=<%#Eval("Manage_Id") %>">修改</a>&nbsp;|&nbsp;<asp:LinkButton 
                            ID="LinkButton3" runat="server" CommandArgument='<%# Eval("Manage_Id") %>' 
                            CommandName='<%# Eval("Manage_ParentId") %>' 
                            onclientclick="return confirm('删除该栏目的同时将删除该栏目下的所有数据！');" 
                            oncommand="LinkButton3_Command">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="160px" />
                    <ItemStyle HorizontalAlign="Center" Width="160px" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="Body_Header" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
