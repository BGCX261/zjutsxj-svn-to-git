<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>框架导航</title>
    <script language="javascript" type="text/javascript" src="../JavaScript/Tree.JS"></script>
    <style type="text/css">
    html{overflow-x: hidden; overflow-y:auto; }
    /* 分类树型列表CSS */
    .dtree { font-family: Verdana, Geneva, Arial, Helvetica, sans-serif; font-size: 12px; color: #666; white-space: nowrap;}
    .dtree img { border: 0px; vertical-align: middle;}
    .dtree a { color: #333; text-decoration: none; }
    .dtree a.node, .dtree a.nodeSel { white-space: nowrap; padding: 1px 2px 1px 2px; }
    .dtree a.node:hover, .dtree a.nodeSel:hover { color: #333; text-decoration: underline; }
    .dtree a.nodeSel { background-color: #ffffff; }
    .dtree .clip { overflow: hidden; }
    /* 分类树型列表CSS结束 */
    body {
      margin-left: 5px;
      margin-top: 5px;
    }
    img { border: 0px; vertical-align: middle;}
    </style>
</head>
<body>
<script type="text/javascript" language="javascript">
//第一个参数，表示当前节点的ID        
//第二个参数，表示当前节点的父节点的ID,根节点的值为 -1       
//第三个参数，节点要显示的文字        
//第四个参数，节点的Url        
//第五个参数，鼠标移至该节点时节点的Title        
//第六个参数，节点的target   
//第七个参数，用做节点的图标,节点没有指定图标时使用默认值   
//第八个参数，用做节点打开的图标,节点没有指定图标时使用默认值   
//第九个参数，判断节点是否打开
Tree = new dTree('Tree');
Tree.add(0,-1,'网站后台管理系统');
Tree.add(10002,0,'系统管理',null,'','','../Images/panel.gif','../Images/panel.gif');
Tree.add(20+1000,10002,'后台首页','../Main/main.aspx','','frame_main','../Images/root.gif');
Tree.add(21+1000,10002,'网站设置','../lang_zh_cn/System/default.aspx','','frame_main','../Images/event.gif');
Tree.add(26+1000,10002,'管理员管理','../Administrator/default.aspx','','frame_main','../Images/Users.gif');
Tree.add(27+1000,10002,'会员管理','../lang_zh_cn/Member/default.aspx','','frame_main','../Images/Users.gif');

Tree.add(1,0,'基本信息',null,'','frame_main');
Tree.add(129,1,'企业信息','../lang_zh_cn/BasicInformation/Default.aspx','','frame_main');
Tree.add(130,1,'企业图片','../lang_zh_cn/BasicInformation/PictureList.aspx','','frame_main');

Tree.add(8,0,'产品管理',null,'','frame_main');
Tree.add(129,8,'产品列表','../lang_zh_cn/Products/default.aspx','','frame_main');
Tree.add(130,8,'添加产品','../lang_zh_cn/Products/AddProducts.aspx','','frame_main');
Tree.add(39,8,'系列管理','../lang_zh_cn/Products/ProClass.aspx','','frame_main');
Tree.add(40,8,'添加系列','../lang_zh_cn/Products/AddProClass.aspx','','frame_main');

Tree.add(13,0,'新闻管理',null,'','frame_main');
Tree.add(129,13,'新闻列表','../lang_zh_cn/News/default.aspx','','frame_main');
Tree.add(130,13,'添加新闻','../lang_zh_cn/News/AddNews.aspx','','frame_main');
Tree.add(125,13,'类别管理','../lang_zh_cn/News/NewsType.aspx','','frame_main');
Tree.add(126,13,'添加类别','../lang_zh_cn/News/AddNewsType.aspx','','frame_main');
Tree.add(127,13,'评论管理','../lang_zh_cn/News/Comments.aspx','','frame_main');

Tree.add(14,0,'留言管理',null,'','frame_main');
Tree.add(129,14,'留言信息','../lang_zh_cn/Message/default.aspx','','frame_main');
Tree.add(127,14,'留言设置','../lang_zh_cn/Message/MessageSite.aspx','','frame_main');

Tree.add(10,0,'招聘管理',null,'','frame_main');
Tree.add(107,10,'招聘列表','../lang_zh_cn/Work/default.aspx','','frame_main');
Tree.add(108,10,'添加招聘','../lang_zh_cn/Work/AddWork.aspx','','frame_main');
Tree.add(109,10,'应聘人员','../lang_zh_cn/Work/Candidates.aspx','','frame_main');

Tree.add(10000,0,'订单管理',null,'','','../Images/setting.gif','../Images/setting.gif');
Tree.add(150,10000,'订单列表','../lang_zh_cn/Orders/Default.aspx','','frame_main','../Images/globe.gif','../Images/globe.gif');
Tree.add(151,10000,'添加订单','../lang_zh_cn/Orders/AddOrders.aspx','','frame_main','../Images/folders.gif','../Images/folders.gif');

Tree.add(10001,0,'系统设置',null,'','','../Images/root.gif','../Images/root.gif');
Tree.add(200,10001,'栏目导航','../system/Default.aspx','','frame_main','../Images/outbox.gif');
Tree.add(201,10001,'友情链接','../lang_zh_cn/Links/Default.aspx','','frame_main','../Images/event.gif');
Tree.add(202,10001,'日志管理','../lang_zh_cn/System/logFile.aspx','','frame_main','../Images/folders.gif');
Tree.add(203,10001,'系统参数','../lang_zh_cn/System/Parameters.aspx','','frame_main','../Images/catch.gif');

Tree.add(10003,0,'网站推广',null,'','','../Images/globe.gif','../Images/globe.gif');
Tree.add(300,10003,'百度登录入口','http://www.baidu.com/search/url_submit.html','','frame_main','../Images/outbox.gif');
Tree.add(301,10003,'Google登录入口','http://www.google.com/addurl/?hl=zh-CN&continue=/addurl','','frame_main','../Images/outbox.gif');
Tree.add(302,10003,'Yahoo登录入口','http://search.help.cn.yahoo.com/h4_4.html','','frame_main','../Images/outbox.gif');
Tree.add(303,10003,'Live登录入口','http://search.msn.com/docs/submit.aspx','','frame_main','../Images/outbox.gif');
Tree.add(304,10003,'Dmoz登录入口','http://www.dmoz.org/World/Chinese_Simplified/','','frame_main','../Images/outbox.gif');
Tree.add(305,10003,'Alexa登录入口','http://www.alexa.com/site/help/webmasters','','frame_main','../Images/outbox.gif');
Tree.add(306,10003,'中搜登录入口','http://ads.zhongsou.com/register/page.jsp','','frame_main','../Images/outbox.gif');
Tree.add(307,10003,'爱问登录入口','http://iask.com/guest/add_url.php','','frame_main','../Images/outbox.gif');
document.write(Tree);
</script>
</body>
</html>
