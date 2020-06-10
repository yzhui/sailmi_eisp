var zoomSize= 0;
function zoom(event, e) {
    e.style.cursor="pointer";
    if (e.width > 380) { e.width = 380; } 
     e.onmouseout=function(){closeDetail();}
     e.onmousemove = function() { moveSee(event, e); }
     e.onmouseover = function() { showDetail(e); };
 }

function showDetail(eventElement) {
    if (document.getElementById("showDetail") == null) {
        var e = document.createElement("div");
        e.id = "showDetail";
        e.className = "ShowDetail";
        e.style.top = getAbsPoint(document.getElementById("ProductInfoField")).y;
        e.style.left = getAbsPoint(document.getElementById("ProductInfoField")).x;
        var img = document.createElement("img");
        img.id = "photoDateil";
        img.style.position = "relative";
        img.src = eventElement.src;
        e.appendChild(img);
        document.body.appendChild(e);
    }
    else {
        document.getElementById("showDetail").style.top = getAbsPoint(document.getElementById("ProductInfoField")).y ;
        document.getElementById("showDetail").style.left = getAbsPoint(document.getElementById("ProductInfoField")).x;
        document.getElementById("showDetail").style.visibility = "visible";
    }
}
//获取某元素的座标值////////////////////////////////////
function getAbsPoint(e) {
    var x = e.offsetLeft;
    var y = e.offsetTop;
    while (e = e.offsetParent) {
        x += e.offsetLeft;
        y += e.offsetTop;
    }
    return { "x": x, "y": y };
}
function closeDetail() {
    if (document.getElementById("showDetail") != null)
    document.getElementById("showDetail").style.visibility ="hidden";
}
function moveSee(event, e) {
    var x = event.clientX - getAbsPoint(e).x;
    var y = event.clientY - getAbsPoint(e).y;
    (document.documentElement.scrollLeft != 0) ? x += document.documentElement.scrollLeft : x += document.body.scrollLeft;
    (document.documentElement.scrollTop != 0) ? y += document.documentElement.scrollTop : y += document.body.scrollTop;
    if (document.getElementById("photoDateil") != null) {
        zoomSize = (document.getElementById("photoDateil").width-350) / 380;
        document.getElementById("photoDateil").style.left = -1*  x * zoomSize;
        document.getElementById("photoDateil").style.top = -1 * y * zoomSize; 
    }
}