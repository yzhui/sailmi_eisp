<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProClassAdmin.aspx.cs" Inherits="Eisp.Web.Admin.Products.ProClassAdmin" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>产品分类</title>
    <link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 415px;
        }
        .style3
        {
            width: 46px;
        }
    </style>
</head>
<script language="javascript" type="text/javascript">

    function doEdit(id, pro) {


        document.getElementById("txtParentName").value = "编辑分类";
        document.getElementById("txtHiddParentName").value = "编辑分类";
        document.getElementById("txtClassName").value = pro;
        document.getElementById("hidParentID").value = id;
        document.getElementById("sort").style.display = "none";
        document.getElementById("txtClassName").focus();
    }

    function doAdd(id, pro) {

        document.getElementById("txtHiddParentName").value = "添加分类";
        document.getElementById("txtParentName").value = pro;
        document.getElementById("txtClassName").value = "";
        document.getElementById("hidParentID").value = id;
        document.getElementById("sort").style.display = "yes";
        document.getElementById("txtClassName").focus();
    }
    
    </script>
<body>
    <form id="form1" runat="server">
        <div class="mframe">
            <table align="center" width="90%">
            <tr><td  class="tm" style="text-align:left;"> <span class="tt">产品分类管理</span></td><td class="tm"></td></tr>
                <tr>
                    <td valign="top" class="style2"   >
          
                       <%=listsort%>
                        
                     
                    </td>
                    <td style="width: 80%" align="center" valign="top">
                        <table runat="server" id="AddTable" >
                            <tr>
                                <td colspan="2" align="center">
                                  
                                    <asp:Label ID="labMessage" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" class="style3">
                                    
                                </td>
                                <td style="width: 200px" align="left">
                                    <asp:TextBox ID="txtParentName" Enabled="false" runat="server" Text="添加一级分类" ToolTip="请点击左边的导航树,选择需要的编辑"></asp:TextBox> <input type="hidden" id="txtHiddParentName" value="" runat="server" style="width: 60px" />
                                    <input type="hidden" id="hidParentID" value="0" runat="server" style="width: 60px" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center" class="style3">
                                    名称：
                                </td>
                                <td style="width: 200px" align="left">
                                    <asp:TextBox runat="server" ID="txtClassName"></asp:TextBox>
                                </td>
                            </tr>
                             <tr id="sort">
                                <td align="center" class="style3">
                                    排序：
                                </td>
                                <td style="width: 200px" align="left">
                                    <asp:TextBox runat="server" ID="txtSort" Text="0"></asp:TextBox>
                                </td>
                            </tr>
                          
                         
                            <tr>
                                <td class="style3" >
                                </td>
                                <td style="width: 200px">
                                    &nbsp;<asp:Button ID="Button1" runat="server"  Text="提交" OnClick="Button1_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
    
</body>
</html>
