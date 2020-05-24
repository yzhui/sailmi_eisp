// JScript 文件

function Checkstr()
{
 if(document.getElementById("txtTitle").value.length==0)
 {
 alert("标题不能为空");
 document.getElementById("txtTitle").focus();
 return false;
 }
 


 
}