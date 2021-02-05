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
