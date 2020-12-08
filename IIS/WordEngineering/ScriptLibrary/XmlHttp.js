function createXMLHttp() {
if (typeof XMLHttpRequest != 'undefined')
return new XMLHttpRequest();
else if (window.ActiveXObject) {
var avers = ["Microsoft.XmlHttp", "MSXML2.XmlHttp",
"MSXML2.XmlHttp.3.0", "MSXML2.XmlHttp.4.0",
"MSXML2.XmlHttp.5.0"];
for (var i = avers.length -1; i >= 0; i--) {
try {
httpObj = new ActiveXObject(avers[i]);
return httpObj;
} catch(e) {}
}
}
throw new Error('XMLHttp (AJAX) not supported');
}

var ajaxObj = createXMLHttp(); 