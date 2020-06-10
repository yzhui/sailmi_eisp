<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadAdd.aspx.cs" Inherits="Eisp.Web.Admin.Downloads.DownloadAdd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>销售网络添加</title>
<link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/ckfinder/ckfinder.js"></script>
<script language="javascript" type="text/javascript" src="../function.js"></script>
<script type="text/javascript">
    function BrowseServer(inputId) {
        var finder = new CKFinder();
        finder.BasePath = '/ckfinder/';  //导入CKFinder的路径
        finder.SelectFunction = SetFileField; //设置文件被选中时的函数
        finder.SelectFunctionData = inputId;  //接收地址的input ID
        finder.Popup();
    }
                

     //文件选中时执行
    function SetFileField(fileUrl, data) {
        document.getElementById(data["selectFunctionData"]).value = fileUrl;
    }
                
</script>

</head>

<body>
    <form id="form1" runat="server" method="post">
     
            <table cellpadding="0" cellspacing="0" class="twidth" width="700">
                <tr>
                    <td align="center" >
                        <div class="mframe">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tl">
                                    </td>
                                    <td class="tm">
                                        <span class="tt">资料添加</span></td>
                                    <td class="tr">
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="ml" style="height: 100%">
                                    </td>
                                    <td class="mm" style="height: 100%">
                                        <table width="100%">
                                            
                                              <tr>
                                                <td >
                                                    名&nbsp;&nbsp;&nbsp; 称：
                                               
                                                    <asp:TextBox ID="txtTitle" runat="server" Width="312px"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td >
                                                    关&nbsp;键&nbsp;词：
                                               
                                                    <asp:TextBox ID="txtKeywords" runat="server" Width="312px"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>  
                                              <tr>
                                                <td >
                                                    资料类型：<asp:DropDownList ID="drpFileClass" runat="server">
                                                        <asp:ListItem Text="产品资料" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="工具软件" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                           
                                                </td>
                                            </tr>  
                                              <tr>
                                                <td >
                                                    描&nbsp;&nbsp;&nbsp; 述：
                                               
                                                    <asp:TextBox ID="txtDesc" runat="server" Height="70px" Rows="3" Width="314px" 
                                                       TextMode="MultiLine"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td >
                                                    文件图片：
                                                    <asp:TextBox ID="txtImgPath" runat="server" Width="310px"></asp:TextBox>
                                                    <input type="button" value=" 浏 览 " onclick="BrowseServer('<%=txtImgPath.ID %>');" />                                                           
                                                </td>
                                            </tr>     
                                            <tr>
                                                <td >
                                                    文件选择：
                                                    <asp:TextBox ID="txtFilePath" runat="server" Width="310px"></asp:TextBox>
                                                    <input type="button" value=" 浏 览 " onclick="BrowseServer('<%=txtFilePath.ID %>');" />                                                           
                                                </td>
                                            </tr>     
                                       
                                            <tr>
                                                <td class="tdbg-dark">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 40px">
                                                    <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="mr" style="height: 100%">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>

