function ChangeFontColor()
{
    var changeText="公司一直以满足客户需求为宗旨，可以按照客户样品、图纸、或者各种特殊需求生产各种各样的产品。";
    var oldContent=document.getElementById("ProfileContent").innerHTML;
    document.getElementById("ProfileContent").innerHTML=oldContent.replace(changeText,"<Font style=\"color:#CC3300;font-weight:bold;\">"+changeText+"</Font>");
}
ChangeFontColor();