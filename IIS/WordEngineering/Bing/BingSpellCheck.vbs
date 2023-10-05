Set http = CreateObject("Microsoft.XmlHttp")
strURL = "http://api.search.live.net/xml.aspx?AppId=0635D7FCDC7EEF370678CA58B4D1F4CB9E03898E&amp;Query=coffee&amp;Sources=Spell"
http.open "GET", strURL, FALSE
http.send ""
WScript.Echo http.responseXML.xml