<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Eisp.Web.Admin.About.About" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<title>公司简介</title>
<link  media="all" rel="stylesheet" type="text/css" href='<%= SYSDOMAIN %>/Styles/admin_Default.css' />
<script type="text/javascript" src="<%= SYSDOMAIN %>/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="<%= SYSDOMAIN %>/ckfinder/ckfinder.js"></script>
</head>

<body>

    <form id="form1" runat="server" method="post">
            <table cellpadding="0" cellspacing="0" class="twidth" width="95%">
                <tr>
                    <td align="center" >
                        <div class="mframe">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="tl">
                                    </td>
                                    <td class="tm">
                                        <span class="tt">公司基础信息</span></td>
                                    <td class="tr">
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="ml">
                                    </td>
                                    <td class="mm">
                                        <table width="100%">
                                            <tr><td bgcolor="silver" width="80">
                                            公司名称
                                            </td><td>
                                                    <asp:TextBox ID="txtEnName" runat="server" Width="400px"></asp:TextBox>
                                                </td></tr>
                                            <tr><td bgcolor="silver">
                                            公司地址
                                            </td><td>
                                                    <asp:TextBox ID="txtEnAddr" runat="server" Width="400px"></asp:TextBox>
                                            </td></tr>
                                            <tr><td bgcolor="silver">
                                            公司关键词
                                            </td><td>
                                                    <asp:TextBox ID="txtEnKeywords" runat="server" Width="400px"></asp:TextBox>
                                            </td></tr>
                                            <tr><td bgcolor="silver">
                                            公司简介
                                            </td><td>
                                                  <textarea name="txtEnDesc" id="txtEnDesc" runat="server"></textarea>
                                                  <script type="text/javascript">
                                                      CKEDITOR.replace('txtEnDesc',
				                                        { toolbar: 'Basic',
				                                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
				                                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?Type=Images',
				                                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?Type=Flash',
				                                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
				                                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
				                                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
				                                        });
			                                      </script>
                                            </td></tr>
                                            <tr><td bgcolor="silver">
                                            联系方式
                                            </td><td>
                                                  <textarea name="txtEnContact" id="txtEnContact" runat="server"></textarea>
                                                  <script type="text/javascript">
                                                      CKEDITOR.replace('txtEnContact',
				                                        {   toolbar : 'Basic',
				                                            filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
				                                            filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?Type=Images',
				                                            filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?Type=Flash',
				                                            filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
				                                            filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
				                                            filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
				                                        });
			                                      </script>
			                                   </td></tr>
			                                   <tr><td bgcolor="silver">
                                                在线联系方式
                                                </td><td>
                                                      <textarea name="txtEnOnlineContact" id="txtEnOnlineContact" runat="server"></textarea>
                                                      <script type="text/javascript">
                                                          CKEDITOR.replace('txtEnOnlineContact',
				                                            {   toolbar: 'Simple',
				                                                filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
				                                                filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?Type=Images',
				                                                filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?Type=Flash',
				                                                filebrowserUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
				                                                filebrowserImageUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
				                                                filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
				                                            });
			                                          </script>
			                                   </td></tr>
                                            <tr><td bgcolor="silver">
                                            详细描述
                                            </td>
                                                <td >   
                                                <asp:HiddenField ID="txtID" runat="server" /> 
                                                  <!-- 编辑器调用开始 -->
                                                  <!-- 注意 TEXTAREA 的 NAME 应与 ID=??? 相对应-->
                                                  <textarea name="content" id="content" runat="server"></textarea>
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
                                                <td align="center" colspan="2" style="height: 30px">
                                                    <asp:Button ID="btnAdd" runat="server" Text="修改" OnClick="btnAdd_Click"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="mr">
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