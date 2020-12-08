//http://javascript.about.com/od/hintsandtips/fl/Using-External-JavaScript-with-Script-Tags.htm
function addJavascript(jsname,pos) {
var th = document.getElementsByTagName(pos)[0];
var s = document.createElement('script');
s.setAttribute('type','text/javascript');
s.setAttribute('src',jsname);
th.appendChild(s);
}

addJavascript('newExternal.js','body');
addJavascript('newExternal2.js','head');
