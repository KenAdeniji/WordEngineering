<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleMapVersion3.aspx.cs" Inherits="GoogleMapVersion3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8″ />
<title>Google Map 3.0</title>
<style type="text/css">
.formatText{color:Green;font-size:11px;font-family:Arial;font-weight:bold;}
</style>
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<script type="text/javascript">
var map;
function initialize() {
var myLatlng = new google.maps.LatLng(40.764015, -73.982797);
var myOptions = {
zoom: 8,
center: myLatlng,
mapTypeId: google.maps.MapTypeId.ROADMAP
}

map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);

for (var i = 0; i < locationList.length; i++) {
var args = locationList[i].split(",");
var location = new google.maps.LatLng(args[0], args[1])
var marker = new google.maps.Marker({
position: location,
map: map
});
var j = i + 1;
marker.setTitle(message[i].replace(/(<([^>]+)>)/ig,""));
attachSecretMessage(marker, i);
}
}

function attachSecretMessage(marker, number) {
var infowindow = new google.maps.InfoWindow(
{ content: message[number],
size: new google.maps.Size(50, 50)
});
google.maps.event.addListener(marker, 'click', function() {
infowindow.open(map, marker);
});
}
</script>

</head>
<body style="margin: 0px; padding: 0px;" onload="initialize()">
<form runat="server">
<div style="padding-top: 10%;padding-left:20%">
<div id="map_canvas" style="width: 50%; height: 50%">
</div>
</div>
</form>
</body>
</html>
