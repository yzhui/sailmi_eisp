<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Eisp.Web.Admin.Index" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>后台管理</title>
    
</head>
<frameset border="0" rows="75,*" frameborder="no" framespacing="0" rows="*">
	<frame id="TopFrame" name="TopFrame" noresize="noresize" scrolling="No" src="TopFrame.aspx?lang=<%=Request["lang"] %>" title="TopFrame" />
	<frameset border="0" frameborder="no" framespacing="0" cols="180,*">
    	<frame id="LeftFrame" name="LeftFrame" noresize="noresize" src="LeftFrame.aspx?lang=<%=Request["lang"] %>" title="LeftFrame" />
		<frame id="MainFrame" name="MainFrame" noresize="noresize" src="Admin_Main.aspx?lang=<%=Request["lang"] %>" title="MainFrame" />
	</frameset>
<noframes>

</noframes>
</frameset>
<body>

</body>
</html>
