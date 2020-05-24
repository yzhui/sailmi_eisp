<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productedit.aspx.cs" Inherits="Eisp.Web.Admin.Products.productedit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品编辑</title>
<link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="/ckfinder/ckfinder.js"></script>
<script language="javascript" type="text/javascript" src="function.js"></script>
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
    <style type="text/css">
        .style1
        {
            width: 426px;
        }
    </style>
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
                                        <span class="tt">产品编辑</span></td>
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
                                                <td colspan="2" >
                                                    产品名称：
                                               
                                                    <asp:TextBox ID="txtTitle" runat="server" Columns="50" MaxLength="255"></asp:TextBox>
                                                  <asp:HiddenField ID="txtProid" runat="server" />
                                                           
                                                </td>
                                            </tr> 
                                            
                                            <tr>
                                                <td colspan="2" >
                                                    产品排序：
                                               
                                                    <asp:TextBox ID="txtSort" runat="server" Columns="50" MaxLength="255" Text="0"></asp:TextBox>
                                                           
                                                </td>
                                            </tr>  
                                             
                                             <tr>
                                                <td colspan="2" >
                                                    所属类别：
                                               
                                                    <asp:DropDownList ID="drpClass" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="cbProvider" runat="server" />采购招标
                                                    <asp:CheckBox ID="cbCommend" runat="server" />是否推荐
                                                           
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td >
                                                    缩略图片：
                                                    <asp:TextBox ID="txtImgPath" runat="server" Width="266px"></asp:TextBox>
                                                    <input type="button" value=" 浏 览 " onclick="BrowseServer('<%=txtImgPath.ID %>');" />                                                           
                                                </td>
                                                <td >
                                                    附加分类：</td>
                                            </tr>     
                                            <tr>
                                                <td class="style1" >
                                                    产品规格：
                                               
                                                    <textarea id="txtGuige" cols="40" rows="3" runat="server"></textarea>    
                                                           
                                                </td>
                                                <td rowspan="3" >
                                                    <asp:ListBox ID="lbClass" runat="server" Width="200px" Height="300px" 
                                                        SelectionMode="Multiple"></asp:ListBox></td>
                                            </tr> 
                                            
                                              <tr>
                                                <td >
                                                    应用场合：
                                               
                                                    <textarea id="txtYingyong" cols="40" rows="3" runat="server"></textarea>    
                                                           
                                                </td>
                                            </tr>  
                                            
                                                   <tr>
                                                <td >
                                                    适用行业：
                                               
                                                    <textarea id="hangye" cols="40" rows="3" runat="server"></textarea>    
                                                           
                                                </td>
                                            </tr> 
                                            <tr>
                                               
                                                <td colspan="2" >   
                                                产品描述：
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
                                                    <asp:Button ID="btnAdd" runat="server" Text="编辑" OnClick="btnAdd_Click"/></td>
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