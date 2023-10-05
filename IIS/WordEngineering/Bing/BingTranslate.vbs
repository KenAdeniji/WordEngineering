Set http = CreateObject("Microsoft.XmlHttp")
strURL="http://api.search.live.net/xml.aspx?AppId=0635D7FCDC7EEF370678CA58B4D1F4CB9E03898E&amp;Query=Hello, world&amp;Sources=Translation&amp;Version=2.2&amp;Translation.SourceLanguage=en&amp;Translation.TargetLanguage=es"
http.open "GET", strURL, FALSE
http.send ""
WScript.Echo http.responseXML.xml
