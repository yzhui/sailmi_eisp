<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="Eisp.Web.Admin.New.News_Edit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻添加</title>
<link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/ckfinder/ckfinder.js"></script>
<script language="javascript" type="text/javascript" src="function.js"></script>
</head>

<body>
    <form id="form1" runat="server" method="post">
     
            <table cellpadding="0" cellspacing="0" class="twidth" width="95%">
                <tr>
                    <td align="center" >
                        <div class="mframe">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="tl">
                                    </td>
                                    <td class="tm">
                                        <span class="tt">新闻编辑</span></td>
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
                                                    标&nbsp;&nbsp;题：
                                               
                                                    <asp:TextBox ID="txtTitle" runat="server" Columns="50" MaxLength="255"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>  
                                              <tr>
                                                <td >
                                                    类&nbsp;&nbsp;别：
                                               
                                                    <asp:DropDownList ID="drpClass" runat="server">
                                                    </asp:DropDownList> 
                                                           
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td >
                                                    关键词：
                                               
                                                    <asp:TextBox ID="txtKeyword" runat="server" Columns="50" MaxLength="255"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>     
                                            <tr>
                                                <td >
                                                    来&nbsp;&nbsp;源：
                                               
                                                    <asp:TextBox ID="txtLocation" runat="server" Columns="50" MaxLength="255"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>     
                                            <tr>
                                               
                                                <td >   
                                                内&nbsp;&nbsp;容：
                                                <asp:HiddenField ID="txtID" runat="server" /> 
                             <!-- 编辑器调用开始 -->
                                                  <!-- 注意 TEXTAREA 的 NAME 应与 ID=??? 相对应-->
                                                  <textarea name="content" id="content" style="display:none" runat="server"></textarea>
                                                  <script type="text/javascript">
				                                        CKEDITOR.replace( 'content',
				                                        {
                                                            filebrowserBrowseUrl : '/ckfinder/ckfinder.html',
                                                            filebrowserImageBrowseUrl : '/ckfinder/ckfinder.html?Type=Images',
                                                            filebrowserFlashBrowseUrl : '/ckfinder/ckfinder.html?Type=Flash',
                                                            filebrowserUploadUrl : '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                                                            filebrowserImageUploadUrl : '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                                                            filebrowserFlashUploadUrl : '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                                                         } );
			                                      </script>
                                                  <!-- 编辑器调用结束 -->
                      
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdbg-dark" colspan="2">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 40px" colspan="2">
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
