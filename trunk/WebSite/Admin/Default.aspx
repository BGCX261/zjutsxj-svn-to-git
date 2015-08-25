<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理后台</title>
</head>
<frameset rows="71,*,25" cols="*" framespacing="0" frameborder="no" border="0">
  <frame src="main/top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  
    <frameset rows="*" cols="180,*" framespacing="0" frameborder="no" border="1">
      <frame src="main/left.aspx" name="leftFrame" scrolling="scroll" style="border-right:solid 1px #6CB2CF" noresize="noresize" id="leftFrame" title="leftFrame" />
      <frame src="main/main.aspx" name="frame_main" id="mainFrame" title="mainFrame"  scrolling="Yes" style="overflow-x:hidden;" />
    </frameset>
    
  <frame src="main/bottom.aspx" name="bottomFrame" style="border-top:solid 2px #6CB2CF;" scrolling="No" noresize="noresize" id="bottomFrame" title="bottomFrame" />
</frameset>
<body>
<div>你的浏览器不支持框架。</div>
</body>
</html>
