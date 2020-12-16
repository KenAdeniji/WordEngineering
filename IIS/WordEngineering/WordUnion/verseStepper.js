var i = 0;
var timer;
var Word;

function timedCount() {
    i = i + 1;
	if ( i >= Word.length - 1)
	{
		i = 1;
	}
	postMessage(Word[i]);	
    timer = setTimeout("timedCount()",5000);
}

(function(){

function init(dataset) {
    Word = dataset;
	timedCount();
}

onmessage = function(e){
	if ( e.data === "Pause" ) {
		clearTimeout(timer);
	}
	else {
		timedCount();
	}	
};

// ref: http://stackoverflow.com/a/1293163/2343
// This will parse a delimited string into an array of
// arrays. The default delimiter is the comma, but this
// can be overriden in the second argument.
function CSVToArray( strData, strDelimiter ){
    strDelimiter = (strDelimiter || ",");
    var objPattern = new RegExp(
        (
            // Delimiters.
            "(\\" + strDelimiter + "|\\r?\\n|\\r|^)" +

            // Quoted fields.
            "(?:\"([^\"]*(?:\"\"[^\"]*)*)\"|" +

            // Standard fields.
            "([^\"\\" + strDelimiter + "\\r\\n]*))"
        ),
        "gi"
        );
    var arrData = [[]];
    var arrMatches = null;
    while (arrMatches = objPattern.exec( strData )){
        var strMatchedDelimiter = arrMatches[ 1 ];
        if (
            strMatchedDelimiter.length &&
            strMatchedDelimiter !== strDelimiter
            ){
            arrData.push( [] );
        }
        var strMatchedValue;
        if (arrMatches[ 2 ]){
            strMatchedValue = arrMatches[ 2 ].replace(
                new RegExp( "\"\"", "g" ),
                "\""
                );
        } else {
            strMatchedValue = arrMatches[ 3 ];
        }
        arrData[ arrData.length - 1 ].push( strMatchedValue );
    }
    return( arrData );
}

function ajaxfetch(url){
  var request = new XMLHttpRequest();
  request.open('get',url,true);
  request.onreadystatechange = function() {
    if (request.readyState == 4) {
      if (request.status && /200|304/.test(request.status)) {
        init(CSVToArray(request.responseText, ','));
      } 
    }
  }
  request.setRequestHeader('If-Modified-Since','Wed, 05 Apr 2006 00:00:00 GMT');
  request.send(null);
}
var data = ajaxfetch('/WordEngineering/Wordsearch/Word.csv');

})();
