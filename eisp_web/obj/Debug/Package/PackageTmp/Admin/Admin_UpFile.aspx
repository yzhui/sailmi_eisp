<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_UpFile.aspx.cs" Inherits="Eisp.Web.Admin.Admin_UpFile" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文件上传</title>
    <link href="../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
        
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td align="center">
                        <div class="mframe">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tl">
                                    </td>
                                    <td class="tm">
                                        <span class="tt">上传文件</span></td>
                                    <td class="tr">
                                    </td>
                                </tr>
                            </table>
                            

                           
        </div>
        
                                    
                   
        
        </td>
        
        </tr>
        </table>
         <asp:Panel runat="server" ID="panel1" >
                                            <table cellpadding="3" cellspacing="3" >
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        支持文件类型：JPG,JPEG,GIF</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="style2">
                                                        选择文件：</td>
                                                    <td class="style3">
                                                        <input id="File1" runat="server" style="width: 292px" type="file" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                    <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="btnUpload_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="panel2" Visible="false">
                                            <table id="UploadedTbl" runat="server" cellpadding="3" cellspacing="3" >
                                                <tr>
                                                    <td align="center" colspan="2" style="Color:Red">
                                                        文件上传成功。</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        文件地址：</td>
                                                    <td>
                                                        <input id="CopyTxt" runat="server" readonly="readonly" size="50" type="text" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="height: 30px">
                                                        <input onclick="DoCopy()" type="button" value="复制到剪贴板"/>
                                                        <input onclick="window.open('../' + CopyTxt.value,'Preview')" type="button" value="预览图片"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>       
        
        
    </form>
</body>
</html>
<script type="text/javascript">
function DoCopy()
{
	if (document.form1.CopyTxt.value != "")
	{
		document.form1.CopyTxt.select();
		textRange = document.form1.CopyTxt.createTextRange();
		textRange.execCommand("Copy");
	}
}
</script>

