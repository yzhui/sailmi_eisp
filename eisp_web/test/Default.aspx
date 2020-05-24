<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multi Select DropDown</title>
    <link href="MyStyles.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">	        
        var timoutID;
	    function ShowMList()
	    {
	        var divRef = document.getElementById("divCheckBoxList");
	        divRef.style.display = "block";
	        var divRefC = document.getElementById("divCheckBoxListClose");
	        divRefC.style.display = "block";
	    }
    	
	    function HideMList()
	    {
	        document.getElementById("divCheckBoxList").style.display = "none";   
	        document.getElementById("divCheckBoxListClose").style.display = "none";   
	    }
	    
        function FindSelectedItems(sender,textBoxID)
        {       
            var cblstTable = document.getElementById(sender.id);
            var checkBoxPrefix = sender.id + "_";
            var noOfOptions = cblstTable.rows.length;
            var selectedText = "";
            for(i=0; i < noOfOptions ; ++i)
            {
                if(document.getElementById(checkBoxPrefix+i).checked)
                {
                    if(selectedText == "")                
                        selectedText = document.getElementById(checkBoxPrefix+i).parentNode.innerText;
                    else
                        selectedText = selectedText + "," + document.getElementById(checkBoxPrefix+i).parentNode.innerText;
                }
            }    
            document.getElementById(textBoxID.id).value = selectedText;   
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="Default">      
        <asp:ScriptManager ID="smDefault" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="upDefault" runat="server">
            <ContentTemplate>     
                <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label> <br />
                <div id="divCustomCheckBoxList" runat="server" onmouseover="clearTimeout(timoutID);" onmouseout="timoutID = setTimeout('HideMList()', 750);">
                    <table>
                        <tr>
                            <td align="right" class="DropDownLook">
                                <input id="txtSelectedMLValues" type="text" readonly="readonly" onclick="ShowMList()" style="width:229px;" runat="server" />
                            </td>
                            <td align="left" class="DropDownLook">
                                <img id="imgShowHide" runat="server" src="drop.gif" onclick="ShowMList()" align="left" />                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="DropDownLook">
                                <div>
            	                    <div runat="server" id="divCheckBoxListClose" class="DivClose">			                        
		                                <label runat="server" onclick="HideMList();" class="LabelClose" id="lblClose"> x</label>
		                            </div>
                                    <div runat="server" id="divCheckBoxList" class="DivCheckBoxList">
		                                <asp:CheckBoxList ID="lstMultipleValues" runat="server" Width="250px" CssClass="CheckBoxList"></asp:CheckBoxList>						        			           			        
		                            </div>
		                        </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Selection" OnClick="btnSubmit_Click" /> 
                    <br />
                    <br />
                    <asp:Label ID="lblTextSelected" runat="server" Text="" Font-Bold="true" ></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>   
    </form>
</body>
</html>
