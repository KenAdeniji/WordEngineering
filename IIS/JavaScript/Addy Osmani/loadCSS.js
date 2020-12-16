//Asynchronous load CSS with loadCSS.js
function loadCss(href, before, media) {
	var ss = window.document.createElement("link");
	var ref = before || window.document.getElementsTagName("script")[0];
	ss.rel = "stylesheet";
	ss.href = href;
	ss.media = "only x";
	//inject link
	ref.parentNode.insertBefore(ss, ref);
	setTimeout( function() {
		ss.media = media || "all";
	});
	return ss;
}
