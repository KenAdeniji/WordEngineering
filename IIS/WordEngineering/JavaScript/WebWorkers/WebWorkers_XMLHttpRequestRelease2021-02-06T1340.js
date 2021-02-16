/*
	2021-02-05T08:38:00 https://www.codeproject.com/Articles/179106/Web-Workers-in-HTML
*/
var xhr;

function getData(url, params) {
    try {
        xhr = new XMLHttpRequest();        
        xhr.open('POST', url, false);
        xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                if (xhr.status == 200) {
                    postMessage(xhr.responseText);
                }
            }
        };
        xhr.send(params);
    } catch (e) {
        postMessage('Error occured');
    }
}

function getDataFuture(url, params) 
{
	//url = "http://localhost/WordEngineering/WordUnion/AlphabetSequenceWebService.asmx/Query?";
	
	//let requestUrl = new URL(url);
	//requestUrl.searchParams.set('word', 'hi');

	requestUrl = url + params;

	console.log(requestUrl);

    try 
	{
        xhr = new XMLHttpRequest();  
		
		//xhr.overrideMimeType("application/json");		
		
		//xhr.responseType = 'json';
		
		console.log("xhr.response");
		
		// the parameter 'q' is encoded
		xhr.open('POST', requestUrl); // https://google.com/search?		
		
		//xhr.responseType = 'json';
		
		xhr.setRequestHeader('Content-Type', 'application/json');
		
		xhr.send()
		
		xhr.onload = function() {
			//postMessage(xhr.response);
			postMessage(xhr.response);
		};
    } catch (e) {
		console.log(e);
        postMessage('Error occured');
    }
}
