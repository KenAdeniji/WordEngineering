<?php
$url = "http://api.flickr.com/services/feeds/photos_public.gne?tags=chicago&lang=en-us&format=atom";
$content = file_get_contents($url);
echo $content;
?>
