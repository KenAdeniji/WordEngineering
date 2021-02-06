/*
	2021-02-05T08:38:00 https://www.codeproject.com/Articles/179106/Web-Workers-in-HTML
*/

importScripts("WebWorkers_XMLHttpRequest.js");

onmessage = function(e) {
    getData
	(
		"/WordEngineering/WordUnion/AlphabetSequenceWebService.asmx/Query?",
		"word=" + e.data[0]	//Word
	);
}
