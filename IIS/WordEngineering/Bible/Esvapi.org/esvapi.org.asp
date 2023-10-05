<%
 'Reference Search
  key = "IP"
  strSearch = "John 1"
  passage = Server.URLEncode(strSearch)
  options = "include-passage-references=true"
  set objHTTP = Server.CreateObject("Microsoft.XMLHTTP")
  objHTTP.open "GET", "www.esvapi.org/v2/rest/passageQuery?key=" & _
  key & "&passage=" & passage & "&" & options, false
  objHTTP.send
  Response.Write(objHTTP.responseText)
 %>
 