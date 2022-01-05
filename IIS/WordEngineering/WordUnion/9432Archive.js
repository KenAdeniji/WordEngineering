/*
	2017-07-24	Created.
	2017-03-01	http://stackoverflow.com/questions/3989324/javascript-set-dropdown-selected-item-based-on-option-text
	2017-03-04	http://stackoverflow.com/questions/18238173/javascript-loop-through-json-array
	2017-03-04 	BibleStatisticsExact.html buildHyperlinkJSON: function(address, parameter) 
	2017-03-05	http://stackoverflow.com/questions/17929356/html-datalist-values-from-array-in-javascript
	2017-04-02	http://stackoverflow.com/questions/14129953/how-to-encode-a-string-in-javascript-for-displaying-in-html
	2017-04-10	http://stackoverflow.com/questions/2998784/how-to-output-integers-with-leading-zeros-in-javascript
	2017-04-24	http://www.kirupa.com/html5/using_the_classlist_api.htm
	2017-05-04	http://davidwalsh.name/essential-javascript-functions
	2017-07-11	https://www.w3schools.com/sql/func_datepart.asp
	2017-08-01	http://bonsaiden.github.io/JavaScript-Garden
	2017-08-01	JSHint.com
	2017-09-14	https://stackoverflow.com/questions/31104879/how-to-check-if-array-is-multidimensional-jquery
	2017-09-16	http://stackoverflow.com/questions/9939760/how-do-i-convert-an-integer-to-binary-in-javascript
	2017-09-17	2017-09-17	http://stackoverflow.com/questions/12272239/javascript-function-returning-an-object
	2017-10-05	What I do, now, is what I do forever; what I do, today, is how I will be publicize, tomorrow.
				Microsoft DataGrid GridView the woman behind, Susan Warren.
	2017-10-10	tsorter.min.js tsorter.create("tableURI");
				<script src="tsorter.min.js" type="text/javascript"></script>	
	2017-10-12	wentAge()
	2017-10-14	renderData()
	2017-10-14	ContactMaintenance.html	scriptLiteral9432.renderDataSet(dataSet, "resultSet");
	2017-10-14	ContactMaintenance.html	scriptLiteral9432.renderDataTable(dataTable, "resultSet");
	2017-11-30	http://en.wikipedia.org/wiki/List_of_file_signatures
	2018-01-13	https://stackoverflow.com/questions/30389769/converting-one-dimensional-array-to-two-dimensional
	2018-07-07	https://stackoverflow.com/questions/10642289/return-html-content-as-a-string-given-url-javascript-function
	2018-07-07	https://stackoverflow.com/questions/703984/is-there-a-getelementsbytagname-like-function-for-javascript-string-variables
	2018-08-04	alphabetSequenceIndex: function(word)
	2018-09-02	scriptLiteral9432.ajax()
	2018-09-10	else if (cellName.includes("URI")) //2018-06-21 ResumeAid.asmx
				{
					
					cellContent = 	"<a href='"  //2018-09-10 prefix http
									+ (cellContent.includes("http") ? cellContent : "http://" + cellContent) 
									+ "'>" + cellContent + "</>";
				}		
	2018-09-13	sumFooter();	http://www.oreilly.com/library/view/javascript-cookbook/9781449390211/ch11s12.html
	2018-09-20	buildHyperlink: function(address, parameter) append directory prefix "/WordEngineering/WordUnion/"
	2014-08-16 	http://stackoverflow.com/questions/1720320/how-to-dynamically-create-css-class-in-javascript-and-apply
	2018-11-04	https://www.w3schools.com/css/css_syntax.asp
	scriptLiteral9432.appendCssRuleSet
	(
		"#directInput",
		"width: 90vw; height: 50vh;"
	);
	2018-12-14	bibleUnits
	2019-05-05	https://www.codexworld.com/export-html-table-data-to-csv-using-javascript
				exportTableToCSV
				July1951NineteenFiftyOne.html
				https://www.codeproject.com/Questions/1024601/How-to-download-HTML-table-data-as-json-data-in-to
	2019-05-06	https://forums.asp.net/t/1963473.aspx?Convert+HTML+table+into+XML+using+JavaScript
	2019-07-06 	https://www.w3.org/TR/FileAPI/	
		scriptLiteral9432.fileReadStartRead(dataFormat.contentWindow.inputFile);
		fileReadStartRead: function(file)
	2019-08-16	var multiDimensionArray = (selectChoices[0].constructor === Array);
				https://stackoverflow.com/questions/31104879/how-to-check-if-array-is-multidimensional-jquery
	2019-08-20	shuffle: function(input) https://www.kirupa.com/html5/extending_built_in_objects_javascript.htm
	2019-09-22 	Idea conceived. 2019-09-23 Created.	
				renderTableRow() renderTableColumn() The Jewish days starts at 6P.M.
	2019-09-29T06:10:00 buildQuerySet created for ExceedingMe.html
	2019-09-29T17:22:00 buildQueryCombine created for ExceedingMe.html
	2019-10-01	renderJsonObject: function(data, caption)
	2019-11-23	censusMapFirstSecond.
	2019-12-12T22:06:00 splitDelimiters(word);
	2019-12-15 IAmTakingYouOnAJourney.html scriptLiteral9432.renderDataTable(selectWhere(ofAMan.journeys, queryID.value), "resultSet");
	2020-01-06	https://stackoverflow.com/questions/24750623/select-a-row-from-html-table-and-send-values-onclick-of-a-button/24750792
	2020-01-06	SelectACode.html
	2020-06-13	SQLServerInfoDatabase.html scriptLiteral9432.buildSelect("databaseName", JSON.parse(data.d));
				Support for JSON, not just arrays.
	2020-11-21	bibleGroups.
	2020-12-05T12:30:00 ... 2020-12-05T13:13:00 Microsoft ASP.NET QueryString
		const urlParams = new URLSearchParams(window.location.search);
		var wordParam = urlParams.get("word");
	2021-01-21T14:40:00	Support for limit, BibleBookGroup, include Apocalyptic Books, Pauline Epistles, General Letters.
	2021-03-05T17:45:00	bibleBookGroups: ["Poetry", "poetry"]
	2021-03-16T15:00:00	bibleBookGroups: ["(All)", "all"]
	2021-06-20
		bibleDays: [
		"Atonement",
		"Exodus",
		"Pentecost",
		"Sabbath",
		"Unleavened Bread"	
	],
	2022-01-04	retrieveSelectionIndex()
*/

var scriptLiteral9432 =
{
	alphabetSequenceScriptureReferenceSelection: [
		["Verse Forward"],
		["Chapter Forward"],
		["Chapter Backward"],
		["Verse Backward"]
	],
	bibleBooks: ["Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"],
	bibleBookClassifications: [
		"Old Testament",
		"New Testament",
		"Pentateuch",
		"Major Prophets",
		"Minor Prophets",
		"Gospels",
		"Pauline Epistles"
	],
	bibleBookGroups: [
		["(All)", "all"],	
		["Old Testament", "old"],
		["New Testament", "new"],
		["Pentateuch", "pentateuch"],
		["Poetry", "poetry"],
		["Major Prophets", "major prophets"],
		["Minor Prophets", "minor prophets"],
		["Gospel", "gospel"],
		["Pauline Epistles", "pauline epistles"],
		["General Epistles", "general epistles"],
		["Apocalyptic Books", "apocalyptic books"]
	],
	bibleDays: [
		"Atonement",
		"Passover",
		"Pentecost",
		"Sabbath",
		"Unleavened Bread"	
	],
	bibleGroups: [
		["Testament", "Testament"],
		["Book", "BookID, BookTitle"],
		["Chapter", "BookID, BookTitle, ChapterID"],
	],
	biblePartitions: [
				["Book", "BookID"],
				["Chapter", "ChapterID"],
				["Verse", "VerseID"],
				["Testament", "Testament"]
	],
	bibleUnits: [
				["Book", "BookID"],
				["Chapter", "ChapterID"],
				["Verse", "VerseID"]
	],
	bibleVersions: [
				["American Standard Bible (ASV)", "AmericanStandardBible"],
				["Bible in Basic English (BBE)", "BibleInBasicEnglish"],
				["Darby Bible (DBY)", "DarbyEnglishBible"],
				["King James Version (KJV)", "KingJamesVersion"],
				["Webster's Bible (WBT)", "WebsterBible"],
				["World English Bible (WEB)", "WorldEnglishBible"],
				["Young's Literal Translation (YLT)", "YoungLiteralTranslation"] 
	],
	calendarTypes: [
		"Biblical",
		"Gregorian"
	],
	censusMapFirstSecond: [
		{"CensusID": 1, "Tribe": "Reuben", "FirstPopulation": 46500, "FirstScriptureReference": "Numbers 1:20-21", "SecondPopulation": 43730, "SecondScriptureReference": "Numbers 26:5-11"},
		{"CensusID": 2, "Tribe": "Simeon", "FirstPopulation": 59300, "FirstScriptureReference": "Numbers 1:22-23", "SecondPopulation": 22200, "SecondScriptureReference": "Numbers 26:12-14"},
		{"CensusID": 3, "Tribe": "Gad", "FirstPopulation": 45650, "FirstScriptureReference": "Numbers 1:24-25", "SecondPopulation": 40500, "SecondScriptureReference": "Numbers 26:15-18"},
		{"CensusID": 4, "Tribe": "Judah", "FirstPopulation": 74600, "FirstScriptureReference": "Numbers 1:26-27", "SecondPopulation": 76500, "SecondScriptureReference": "Numbers 26:19-22"},
		{"CensusID": 5, "Tribe": "Issachar", "FirstPopulation": 54400, "FirstScriptureReference": "Numbers 1:28-29", "SecondPopulation": 64300, "SecondScriptureReference": "Numbers 26:23-25"},
		{"CensusID": 6, "Tribe": "Zebulun", "FirstPopulation": 57400, "FirstScriptureReference": "Numbers 1:30-31", "SecondPopulation": 60500, "SecondScriptureReference": "Numbers 26:26-27"},
		{"CensusID": 7, "Tribe": "Ephraim", "FirstPopulation": 40500, "FirstScriptureReference": "Numbers 1:32-33", "SecondPopulation": 32500, "SecondScriptureReference": "Numbers 26:28, Numbers 26:35-37"},
		{"CensusID": 8, "Tribe": "Manasseh", "FirstPopulation": 32200, "FirstScriptureReference": "Numbers 1:34-35", "SecondPopulation": 52700, "SecondScriptureReference": "Numbers 26:28-34"},
		{"CensusID": 9, "Tribe": "Benjamin", "FirstPopulation": 35400, "FirstScriptureReference": "Numbers 1:36-37", "SecondPopulation": 45600, "SecondScriptureReference": "Numbers 26:38-41"},
		{"CensusID": 10, "Tribe": "Dan", "FirstPopulation": 62700, "FirstScriptureReference": "Numbers 1:38-39", "SecondPopulation": 64400, "SecondScriptureReference": "Numbers 26:42-43"},
		{"CensusID": 11, "Tribe": "Asher", "FirstPopulation": 41500, "FirstScriptureReference": "Numbers 1:40-41", "SecondPopulation": 53400, "SecondScriptureReference": "Numbers 26:44-47"},
		{"CensusID": 12, "Tribe": "Naphtali", "FirstPopulation": 53400, "FirstScriptureReference": "Numbers 1:42-43", "SecondPopulation": 45400, "SecondScriptureReference": "Numbers 26:48-50"},
	],	
	dataFormats: [
		["Comma Separated Value (CSV)", ".csv"],
		["eXtensible Markup Language (XML)", ".xml"],
		["Hypertext Markup Language (HTML)", ".html"],
		["File Upload"],
		["Text", ".txt"],
		["JavaScript Object Notation (JSON)", ".json"]
	],
	daysInMonth: [ 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ],
	fileTypes: [
		["Comma Separated Value (CSV)", ".csv"],
		["JavaScript Object Notation (JSON)", ".json"],		
		["eXtensible Markup Language (XML)", ".xml"]
	],
	groupBys: [
		"BookTitle",
		"BookTitle, ChapterID"
	],
	operators: [
		"+",
		"-",
		'*',
		'/',
		'%',
		'^'
	],
	/*
		2017-05-12	brenocon@cs.umass.edu
		2018-04-24 	http://quondam.csi.edu/ip/adc/faculty/bbennett/ps011exp.htm
		2019-10-10	partsOfSpeechJoined Javascript implementation.
	*/
	partsOfSpeech: [ 
		["verb", "can, could, will, would, shall, should, may, might, must"],
		["adjective", "have, has, had, do, does, did,be, am, is, are, was, were, been, being, a, an, the"],
		["pronoun", "I, he, we, she, they, me, him, us, her, them, it, this, that, who, which, what"],
		["preposition", "my, mine, his, her, hers, our, ours, their, theirs, your, yours, its, whose, at, to, with, from, for, of, on, in, into, onto,between, under, over, against, around"],
		["conjunction", "for, and, nor, but, or, yet, so"],
		["adverb", "not, very, often, here, almost, always, never, there, too"],
		["interjection", "not, very, often, here, almost, always, never, there, too"]
	],
	pi: 22 / 7,
	songOfSolomonBookID: 21,
	sortDirections: [
		["Ascending", "asc"],
		["Descending", "desc"]
	],
    e: 2.718,
	bibleStatistics:
	{
		bookCountOldTestament: 39,
		chapterCount: 1189,
		verseCount: 31102,
		verseCountOldTestament: 23145
	},
	bibleBookGroups: [
		["(All)", "all"],	
		["Old Testament", "old"],
		["New Testament", "new"],
		["Pentateuch", "pentateuch"],
		["Poetry", "poetry"],
		["Major Prophets", "major prophets"],
		["Minor Prophets", "minor prophets"],
		["Gospel", "gospel"],
		["Pauline Epistles", "pauline epistles"],
		["General Epistles", "general epistles"],
		["Apocalyptic Books", "apocalyptic books"]
	],
	calendarUnitOfMeasurement: [ //2021-11-10T12:24:00
		"Day",
		"Week",
		"Biblical Month",
		"Gregorian Month",
		"Biblical Year",
		"Gregorian Year"		
	],
	//2019-02-13 https://stackoverflow.com/questions/24657463/how-to-add-http-to-url-if-no-protocol-is-defined-in-javascript
	addhttp: function(url)
	{
		if (!/^(?:f|ht)tps?\:\/\//.test(url)) 
		{
			url = "http://" + url;
		}
		return url;
	},
	
	alphabetSequenceIndex: function(word)
	{
		var alphabetSequence = 0;
		var notANumber = isNaN(word);
		if (!notANumber)
		{	
			alphabetSequence = Number.parseInt(word)
			return alphabetSequence;
		}
		
		word = word.toUpperCase();

		var ascii = word.charCodeAt(0);
		
		if (word < 'A' || word > 'Z')
		{
			return ascii;
		}		
		
		for 
		(
			var index = 0, length = word.length, currentCode, asciiCode;
			index < length;
			++index
		)
		{
			currentCode = word[index];
			if (currentCode >= 'A' && currentCode <= 'Z')
			{	
				asciiCode = currentCode.charCodeAt(0);
				alphabetSequence += asciiCode - 64;
			}
		}
		return alphabetSequence;
	},	

	/*
		2018-11-04	https://www.w3schools.com/css/css_syntax.asp
		2014-08-16 	http://stackoverflow.com/questions/1720320/how-to-dynamically-create-css-class-in-javascript-and-apply
		scriptLiteral9432.appendCssRuleSet
		(
			"#directInput",
			"width: 90vw; height: 50vh;"
		);
	*/	
	appendCssRuleSet: function 
	(
		selector,
		declaration
	)
	{
		var style = document.createElement('style');
		style.type = 'text/css';
		style.innerHTML = selector + " { " + declaration + " } ";
		document.getElementsByTagName('head')[0].appendChild(style);
	},
	
	/*
		2018-02-15	https://stackoverflow.com/questions/20856197/remove-non-ascii-character-in-string
	*/	
	ascii1to127: function(word)
	{
		return word.replace(/[^\x01-\x7F]/g, "");
	},	
	
	ajax: function
	(
		ajaxUrl,
		ajaxData,
		successCallback,
		errorIndicator
	)
	{
		$.ajax
		({
			type: "POST",
			contentType: "application/json; charset=utf-8",
			url: ajaxUrl,
			data: ajaxData,
			dataType: "json",
			success: function(data) 
			{
				if (successCallback) { successCallback(data); }
			},
			error: function(xhr)
			{
				document.getElementById(errorIndicator).innerHTML =
					'Status: ' + xhr.status + " | " + 
					'StatusText: ' + xhr.statusText + " | " +
					'ResponseText: ' + xhr.responseText;
			} 
		});
		
	},
	
	buildDatalist: function(dataListID, variable)
	{
		var list = document.getElementById(dataListID);
		variable.forEach(function(item){
		   var option = document.createElement('option');
		   option.value = item;
		   list.appendChild(option);
		});					
	},
	
	buildHyperlink: function(address, parameter) 
	{
		if (!parameter) { return ""; }
		var prefix = "";
		if (address.toLowerCase().indexOf("http") === -1)
		{
			prefix = "/WordEngineering/WordUnion/"; 
		}
		var uri = encodeURI(prefix + address + ".html?" + address + "=" + parameter);
		var hyperlink = "<a href=" + uri + ">" + parameter + "</a>";
		return hyperlink;
	},

	buildHyperlinkJSON: function(address, parameter) 
	{
		parameter = JSON.parse(parameter);
		var 
			firstArgument = "",
			hyperlink = "",
			queryString = "",
			uri = "";
		for(var key in parameter){
			if(parameter.hasOwnProperty(key)) {
				console.info(key + ': ' + parameter[key]);
				if (!firstArgument)
				{
					firstArgument = parameter[key];
				}	
				if (queryString)
				{
					queryString += "&";
				}	
				queryString += key + "=" + parameter[key];
			}
		}
		uri = encodeURI(address + "?" + queryString);
		hyperlink = '<a href="' + uri + '">' + firstArgument + "</a>";
		return hyperlink;
	},
	
	buildHead: function() 
	{
		var rowStub = "<thead><tr>";
		var columnValue = "";
		for 
		(
			var columnIndex = 0, columnCount = arguments.length;
			columnIndex < columnCount;
			++columnIndex
		)
		{
			columnValue = arguments[columnIndex] ? arguments[columnIndex] : "";
			rowStub += "<th>" + columnValue + "</th>";
		}
		rowStub += "</tr></thead>";
		return rowStub;
	},

	buildLinkButton: function(methodName, parameter, friendlyName) 
	{
		var hyperlink = "<a href='#' target='_parent' " + 
			"onclick='" + methodName + '(' + parameter + 
			")'>" + friendlyName + "</a>";
		return hyperlink;
	},
	
	//2019-09-29T06:10:00 buildQuerySet Created.
	buildQuerySet: function(containerID, tableName, variable)
	{
		queryTable = "<table>";
		queryTable += "<caption>" + tableName + "</caption>";
		queryTable += "<thead><tr><th>Name</th><th>Value</th></tr></thead><tbody>"; 
		var columnID;
		variable.forEach(function(item){
			columnID = tableName + '_' + item;
			queryTable +=	"<tr>" + 
							"<td>" +
							"<label for='" + columnID + "'>" +
							item +
							"</label></td>" +
							"<td><input type='text' id='" + columnID + "'/></td>" +
							"</tr>";	
			});	
		queryTable += 	"</tbody>";
		queryTable += 	"<tfoot><tr><td colspan='2' align='center'>" +
						"<input type='submit' id='queryColumn'/>" +
						"</td></tr></tfoot>"
		queryTable += 	"</table>";
		containerID.innerHTML = queryTable;
		document.getElementById("queryColumn").addEventListener("click", queryColumnSubmit, false);
	},
	
	//2019-09-29T17:22:00 Created.
	buildQueryCombine: function()	
	{
		var columnInputs = document.getElementById('querySet').getElementsByTagName('input');
		var inputList = Array.prototype.slice.call(columnInputs);

		var inputID;
		var inputName;
		var inputNameIndex;
		var inputValue;
		
		var tableNameIDLength = tableNameID.value.length;
		
		jsonInput = "";
		inputList.forEach(function(item){
			inputID = item.id;
			inputName = "";
			inputNameIndex = inputID.indexOf(tableNameID.value + "_");
			if (inputNameIndex >= 0)
			{
				inputName = inputID.substring(tableNameIDLength + 1);
			}
			inputValue = item.value;
			if (inputValue === "" || inputName === "")
			{
				return;
			}
			if (jsonInput !== "")
			{
				jsonInput += ",";
			}
			jsonInput += inputName + ": " + '\"' + inputValue + '\"';	
		});
		jsonInput = '{' + jsonInput + '}';
		return jsonInput
	},
	
	buildRow: function() 
	{
		var rowStub = "<tr>";
		var columnValue = "";
		for 
		(
			var columnIndex = 0, columnCount = arguments.length;
			columnIndex < columnCount;
			++columnIndex
		)
		{
			columnValue = arguments[columnIndex] ? arguments[columnIndex] : "";
			rowStub += "<td>" + columnValue + "</td>";
		}
		rowStub += "</tr>";
		return rowStub;
	},

	buildScriptureReference: function(bookId, chapterId, verseId)
	{
		var bookTitle = scriptLiteral9432.bibleBooks[bookId - 1];
		var scriptureReference = bookTitle + " " + chapterId + ":" + verseId;
		return scriptureReference;
	},	
	
	buildSelect: function(selectControl, selectChoices)
	{
		var select = document.getElementById(selectControl);
		select.options.length = 0;
		for (var index = 0, length = selectChoices.length; index < length; ++index)
		{
			var option = document.createElement("option");
			var multiDimensionArray = (selectChoices[index].constructor === Array);
			if (selectChoices[index]["text"])
			{
				option.text = selectChoices[index]["text"];
				if (selectChoices[index]["value"])
				{
					option.value = selectChoices[index]["value"];
				}	
				else
				{
					option.value = selectChoices[index]["text"];
				}	
			}	
			else if(multiDimensionArray)				
			{	
				option.text = selectChoices[index][0];
				option.value = selectChoices[index][1];
			}
			else
			{
				option.text = selectChoices[index];
				option.value = selectChoices[index];
			}				
			select.appendChild(option);
		}
	},

	buildUri: function(address)
	{
		if (!address) { return ""; }
		var uri = address;
		var protocolIndex = uri.indexOf(':');
		if (protocolIndex < 0)
		{
			uri = "http://" + uri;
		}
		var hyperlink = "<a href=" + encodeURI(uri) + ">" + address + "</a>";
		return hyperlink;
	},
	
	capitalize: function(string) 
	{
		return string.charAt(0).toUpperCase() + string.slice(1).toLowerCase();
	},

	//2018-02-27 Created.
	captchaGenerate: function(canvasID, lettersLength)
	{
		var captchaSecret = "";
		for (var captchaIndex = 0; captchaIndex < lettersLength; ++captchaIndex)
		{
			captchaSecret += String.fromCharCode(scriptLiteral9432.getRandomIntInclusive(48, 57));
		}
		var canvas = document.getElementById(canvasID);
		var ctx = canvas.getContext("2d");
		ctx.font = "30px Arial";
		ctx.fillText(captchaSecret, 10, 50);
		return captchaSecret;
	},
	
	//2020-11-03	Created.	http://flaviocopes.com/javascript-check-empty-object
	checkEmptyObject: function(obj)
	{
		return (Object.keys(obj).length === 0 && obj.constructor === Object);
	},	
	
	//2018-01-13	https://stackoverflow.com/questions/30389769/converting-one-dimensional-array-to-two-dimensional
	convertOneDimensionArrayIntoTwoDimension: function(oneDimension) 
	{
		var k=0;
		var cubes = [];
		var n = oneDimension.length;
		var i = -1;
		var j = -1;
		for(i=0; i<n; i++){
			cubes[i] = [];
			for(j =0; j<=n; j++){
				cubes[i][j]=oneDimension[k];
			}
			k++
		}
		return cubes
	},
	
	//2019-09-27T02:12:00
	convertJSON2Array: function(dataSet, columnName)
	{
		var dataTable;
		var values = [];
		for (var tableName in dataSet) 
		{
			dataTable = dataSet[tableName];
			for (var rowIndex = 0, rowCount = dataTable.length; rowIndex < rowCount; ++rowIndex)
			{
				values.push(dataTable[rowIndex][columnName]); 
			}
		}
		return values;
	},
	
	//2017-09-04 Created.
	countOccurences: function(data)
	{
		var occurrences = 0;
		for (var table in data) {
			dataTable = data[table];
			occurrences += dataTable.length;
		}
		return occurrences;
	},	

	/*
		2018-02-14	https://stackoverflow.com/questions/966225/how-can-i-create-a-two-dimensional-array-in-javascript
		function createArray(x, y) {
			return Array.apply(null, Array(x)).map(e => Array(y));
		}		
	*/
	createArray: function(x, y) {
		return Array.apply(null, Array(x)).map(function(e) {
			return Array(y);
		});
	},	
	
	datePart: function(part, dated)
	{
		part = part.toLowerCase();
		
		var result = -1;
		
		switch(part)
		{
			case "year":
			case "yyyy":
			case "yy":
				result = parseInt(dated.substr(0, 4)); 
				break;
			case "day":
			case "dd":
			case "d":
				result = parseInt(dated.substr(8, 2)); 
				break;
		}
		
		return result;
	},

	/*
		2018-05-01	http://stackoverflow.com/questions/5741632/javascript-date-7-days?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
	*/
	daysAdd: function(myDate, days) {
		//return new Date(myDate.getTime() + days*24*60*60*1000);
		//return new Date(myDate.setDate(myDate.getDate() + days));
		//2020-12-03T19:50:00
		var result = new Date(myDate);
		result.setDate(result.getDate() + days);
		return result;
	},
	
	daysBetween: function(date1, date2) {
		// The number of milliseconds in one day
		var ONE_DAY = 1000 * 60 * 60 * 24

		// Convert both dates to milliseconds
		var date1_ms = date1.getTime()
		var date2_ms = date2.getTime()

		// Calculate the difference in milliseconds
		var difference_ms = Math.abs(date1_ms - date2_ms)

		// Convert back to days and return
		return Math.round(difference_ms/ONE_DAY)
	},
	
	daysDifference: function (first, second) {
		return Math.round((second-first)/(1000*60*60*24));
	},

	daysDifferenceBiblicalCalendar: function(days)
	{
		var year = Math.trunc(days / 360);
		var remainder = days % 360;
		var month = Math.trunc(remainder / 30);
		var day = Math.trunc(remainder % 30);
		
		var calendar = "";
		
		if (year > 0)
		{
			calendar += year + " year" + (year === 1 ? "" : "s");
		}

		if (month > 0)
		{
			if (calendar != "")
			{
				calendar += ", ";
			}
			
			calendar += month + " month" + (month === 1 ? "" : "s");
		}

		if (day > 0)
		{
			if (calendar != "")
			{
				calendar += ", ";
			}
			calendar += day + " day" + (day === 1 ? "" : "s");
		}

		return calendar;
	},

	daysDifferenceCommonEra: function(dateFrom, dateTo)
	{
		var	dateCurrent = dateFrom;
		var	days = 0;
		var	weeks = 0;
		var	months = 0;
		var	years = 0;
		
		var	weekDays = 0;
		
		var daysInYears = new Array();
		
		while ( dateCurrent < dateTo )
		{
			var daysOffset = 365;
			var isLeap = scriptLiteral9432.isLeapYear(dateCurrent.getFullYear());
			if (isLeap)
			{
				daysOffset = 366;
			}
			if ( scriptLiteral9432.daysAdd(dateCurrent, daysOffset ) > dateTo )
			{
				break;
			}
			dateCurrent = scriptLiteral9432.daysAdd( dateCurrent, daysOffset );
			++years;
		}
		
		while ( dateCurrent < dateTo )
		{
			var currentMonth = dateCurrent.getMonth();
			var daysOffset = scriptLiteral9432.daysInMonth[currentMonth];
			var isLeap = scriptLiteral9432.isLeapYear(dateCurrent.getFullYear());
			if (isLeap && currentMonth == 2)
			{
				daysOffset = 29;
			}
			if ( scriptLiteral9432.daysAdd(dateCurrent, daysOffset ) > dateTo )
			{
				break;
			}
			dateCurrent = scriptLiteral9432.daysAdd( dateCurrent, daysOffset );
			++months;
		}

		weekDays = scriptLiteral9432.daysBetween(dateCurrent, dateTo);
	
		weeks = Math.floor(weekDays / 7);

		days = weekDays % 7;
		
		var yearOutput = "";
		
		daysInYears.push(new scriptLiteral9432.DaysInYears("year", years));
		daysInYears.push(new scriptLiteral9432.DaysInYears("month", months));
		daysInYears.push(new scriptLiteral9432.DaysInYears("week", weeks));
		daysInYears.push(new scriptLiteral9432.DaysInYears("day", days));
		
		for (var index = 0, length = daysInYears.length; index < length; ++index)
		{
			if (daysInYears[index].value == 0) { continue; }
			var aShineInTheCloud	=	"";

			aShineInTheCloud = 	((yearOutput.length === 0) ? "" : ", " ) +
								(daysInYears[index].value + " ") +
								daysInYears[index].metric +
								((daysInYears[index].value === 1) ? "" : "s");
			
			yearOutput 			+=	aShineInTheCloud;			
		}
	
		return yearOutput;
	},

	daysIntoYear: function(date)
	{
		date = new Date(date);
		return (Date.UTC(date.getFullYear(), date.getMonth(), date.getDate()) - Date.UTC(date.getFullYear(), 0, 0)) / 24 / 60 / 60 / 1000;
	},
	
	fetchUri: function(uri, callback)
	{
		var myRequest = new Request(uri);
		fetch(myRequest).then(function(response) {
			return response.text().then(function(text) {
				callback(text);
			});
		});
	},

	fileReadErrorHandler:function (evt) {
		if(evt.target.error.name == "NotReadableError") {
			// The file could not be read
		}
	},

	fileReadGetAsText: function(readFile) {
		var reader = new FileReader();

		// Read file into memory as UTF-16
		//reader.readAsText(readFile, "UTF-16");
		reader.readAsText(readFile);

		// Handle progress, success, and errors
		reader.onprogress = scriptLiteral9432.fileReadUpdateProgress;
		reader.onload = scriptLiteral9432.fileReadLoaded;
		reader.onerror = scriptLiteral9432.fileReadErrorHandler;
	},

	fileReadLoaded: function(evt) {
		// Obtain the read file data
		var fileString = evt.target.result;
		submitData(fileString);
	},

	fileReadStartRead: function(file, completedRoutine) {
		// obtain input element through DOM
		var file = file.files[0];
		if(file){
			scriptLiteral9432.fileReadGetAsText(file);
		}
	},

	fileReadUpdateProgress: function(evt) {
	  if (evt.lengthComputable) {
		// evt.loaded and evt.total are ProgressEvent properties
		var loaded = (evt.loaded / evt.total);
		if (loaded < 1) {
		  // Increase the prog bar length
		  // style.width = (loaded * 200) + "px";
		}
	  }
	},

	//2018-06-07	http://stackoverflow.com/questions/19706046/how-to-read-an-external-local-json-file-in-javascript?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
	fileUploadJSON: function(uploadFileID, callback, fileType)
	{
		var currentFiles = document.getElementById(uploadFileID).files;
		var filesContent = "";
		for 
		(
			var fileIndex = 0, fileCount = currentFiles.length;
			fileIndex < fileCount;
			++fileIndex
		)
		{
			console.log(currentFiles[fileIndex].name);
			scriptLiteral9432.webServiceAPIFileRequestJSON
			(
				currentFiles[fileIndex].name,
				function(response) {
					filesContent += response;
					if (fileIndex === fileCount)
					{
						var data = JSON.parse(filesContent);
						callback(data);
					}
				},
				fileType
			);	
		}	
	},
	
	isLeap: function(year)
	{ 
		return year % 4 == 0 && year % 100 != 0 || year % 400 == 0; 
	},
			
	isLeapYear:	function(year)
	{
		var date = new Date(year+"/02/29");
		var leapYear = false;
		if (1 === date.getMonth())
		{
			leapYear = true;
		}	
		return leapYear;
	},	
	
	/*
		2018-04-13
		var links = document.getElementsByTagName('a');
		for (var i = 0; i < links.length; i++) {
			if (link_is_external(links[i])) {
				// External
			}
		}		
	*/
	link_is_external: function(link_element) {
		return (link_element.host !== window.location.host);
	},
	
	daysBetween: function(date1, date2) {
		// The number of milliseconds in one day
		var ONE_DAY = 1000 * 60 * 60 * 24

		// Convert both dates to milliseconds
		var date1_ms = date1.getTime()
		var date2_ms = date2.getTime()

		// Calculate the difference in milliseconds
		var difference_ms = Math.abs(date1_ms - date2_ms)

		// Convert back to days and return
		return Math.round(difference_ms/ONE_DAY)
	},
	
	DaysInYears: function(metric, value){//constructor
		this.metric = metric;
		this.value = value;
	},
	
	//	2017-05-20 DavidFlanagan.com
	debug: function(msg) {
		// Find the debugging section of the document, looking at HTML id attributes
		var log = document.getElementById("debuglog");
		// If no element with the id "debuglog" exists, create one.
		if (!log) {
			log = document.createElement("div");  // Create a new <div> element
			log.id = "debuglog";                  // Set the HTML id attribute on it
			log.innerHTML = "<h1>Debug Log</h1>"; // Define initial content
			document.body.appendChild(log);       // Add it at end of document
		}
		// Now wrap the message in its own <pre> and append it to the log
		var pre = document.createElement("pre");  // Create a <pre> tag
		var text = document.createTextNode(msg);  // Wrap msg in a text node
		pre.appendChild(text);                    // Add text to the <pre>
		log.appendChild(pre);                     // Add <pre> to the log		
	},
	
	decimal2binary: function(dec)
	{
		return (dec >>> 0).toString(2);
	},
	
	decimalToBinaryConversion: function(dec)
	{
		var binaryValue = this.decimal2binary(dec);
		var binaryString = ("0" + binaryValue).slice(-2);
		
		var leftString = binaryString.substring(0, 1);
		var leftDigit = parseInt(leftString);
		
		var rightString = binaryString.slice(-1);
		var rightDigit = parseInt(rightString);
		
		var obj = {
				leftDigit: leftDigit,
				rightDigit: rightDigit
		};

		return obj;
	},
	
	encodeXmlCharacters: function(input) 
	{
		input = input.replace(/&/g, '&amp;');
		input = input.replace(/</g, '&lt;');
		input = input.replace(/>/g, '&gt;');
		return input;
	},				

	Epoch: function(date) {
		return Math.round(new Date(date).getTime() / 1000.0);
	},
	
	epochToDate: function(epoch) {
		if (epoch < 10000000000)
			epoch *= 1000; // convert to milliseconds (Epoch is usually expressed in seconds, but Javascript uses Milliseconds)
		var epoch = epoch + (new Date().getTimezoneOffset() * -1); //for timeZone        
		return new Date(epoch);
	},
	
	//getAbsoluteUrl('/something'); // https://davidwalsh.name/something
	getAbsoluteUrl: (function() {
		var a;

		return function(url) {
			if(!a) a = document.createElement('a');
			a.href = url;

			return a.href;
		};
	})(),
	
	//2017-11-30	https://stackoverflow.com/questions/36280818/how-to-convert-file-to-base64-in-javascript
	//2017-11-30	https://stackoverflow.com/questions/47195119/how-to-capture-filereader-base64-as-variable
	//2017-11-30	https://gist.github.com/sandeep1995/3e9829c276d4e55e5b89ba4d32d0e6a8
	//2017-11-30	https://stackoverflow.com/questions/18299806/how-to-check-file-mime-type-with-javascript-before-upload
	getFileBase64: function(file, onLoadCallback) {
		return new Promise(function(resolve, reject) {
			var reader = new FileReader();
			reader.onload = function() { resolve(reader.result); };
			reader.onerror = reject;
			
			if
			( 
				file.type.match('image.*') ||
				file.type.match('audio.*') ||
				file.type.match('movie.*')
			)	
			{
				reader.readAsDataURL(file);
			}
			else
			{		
				reader.readAsText(file);
			}
		});
	},
	
	getParameterByName: function(name) 
	{
	//2020-12-05T12:30:00 ... 2020-12-05T13:13:00
/*
	const urlParams = new URLSearchParams(window.location.search);
	var wordParam = urlParams.get("word");
*/
		name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
		var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
			results = regex.exec(location.search);
		return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
	},
	
	getRandomIntInclusive: function(min, max) {
	  return Math.floor(Math.random() * (max - min + 1)) + min;
	},
	
	//	2017-05-20 DavidFlanagan.com
	hide: function(e, reflow) { // Hide the element e by scripting its style
		if (reflow) {                      // If 2nd argument is true
			e.style.display = "none";      // hide element and use its space
		}
		else {                             // Otherwise
			e.style.visibility = "hidden"; // make e invisible, but leave its space
		}
	},
	
	//	2017-05-20 DavidFlanagan.com
	highlight: function(e) {    // Highlight e by setting a CSS class
		// Simply define or append to the HTML class attribute.
		// This assumes that a CSS stylesheet already defines the "hilite" class
		if (!e.className) e.className = "hilite";
		else e.className += " hilite";
	},

	/*
	2017-08-01	http://bonsaiden.github.io/JavaScript-Garden/
	is('String', 'test'); // true
	is('String', new String('test')); // true
	typeof foo !== 'undefined'
	*/
	is: function(type, obj) {
		var clas = Object.prototype.toString.call(obj).slice(8, -1);
		return obj !== undefined && obj !== null && clas === type;
	},

	isDate: function(dated) 
	{
		var t = new Date(dated);
		var valid = !isNaN(t.valueOf());
		return valid;
	},

	/*
		isValidEmail("");// -> false
		isValidEmail("asda");// -> false
		isValidEmail("asda@gmail");// -> false
		isValidEmail("asda@gmail.com");// -> true
	*/
	isValidEmail: function(string){
		string = string||'';
		var lastseg = (string.split('@')[1]||'').split('.')[1]||'',
			input = document.createElement('input');
			input.type = "email";
			input.required = true;
			input.value = string;
		return !!(string && (input.validity && input.validity.valid) && lastseg.length);
	},

	/*
		2018-02-15	https://stackoverflow.com/questions/9862761/how-to-check-if-character-is-a-letter-in-javascript
	*/
	isLetter: function(str) {
			return str.length === 1 && str.match(/[a-z]/i);
	},
	
	//2017-06-29 http://speakingjs.com/es5/ch11.html
	myIsNaN: function(value) {
		return typeof value === 'number' && isNaN(value);
	},

	//2017-06-29 http://speakingjs.com/es5/ch11.html
	myIsNaN2: function(value) {
		return value !== value;
	},

	//2018-02-27	https://stackoverflow.com/questions/12409299/how-to-get-current-formatted-date-dd-mm-yyyy-in-javascript-and-append-it-to-an-i
	nowTimezoneOffset: function(now)
	{	
		if (arguments.length === 0)
		{		
			now = new Date();
		}	
		var local = now;
		local.setMinutes(local.getMinutes() - local.getTimezoneOffset());
		var currentTime = local.toJSON();
		return currentTime;
	},
	
	pad: function(num, size) {
		var s = num+"";
		while (s.length < size) s = "0" + s;
		return s;
	},

	
	//	2018-07-07	https://stackoverflow.com/questions/703984/is-there-a-getelementsbytagname-like-function-for-javascript-string-variables
	parseDomHtmlFragment: function(htmlFragment)
	{
		var domParser = new DOMParser();
		var docElement = domParser.parseFromString(htmlFragment, "text/html").documentElement;
		return docElement;
	},
	
	parseScriptureReference: function(scriptureReference)
	{
		var reference = scriptureReference.split(/,|;/);
		for (index = 0; index < reference.length; index++)
		{
			//reference[index] = String.trim(reference[index]);
		}
		return reference;
	},
	
	partsOfSpeechJoined: function()
	{
		wordsJoined = [];
		scriptLiteral9432.partsOfSpeech.forEach(function(parts) {
			wordsApart = parts[1].split(",");
			wordsApart.forEach(function(word) {
				if (wordsJoined.indexOf(word) <= -1)
				{	
					wordsJoined.push(word);
				}	
			});	
		});
		return wordsJoined;
	},	
	
	//http://christianheilmann.com/
	/*
		console.log(rand(2,5)); // float random between 2 and 5 inclusive
		console.log(rand(1,100,true)); // integer random between 1 and 100
	*/
	rand: function(min, max, integer) {
	  var r = Math.random() * (max - min) + min; 
	  return integer ? Math.trunc(r) : r;
	},

	renderBibleBookGroupSelect: function() 
	{
		var select = document.getElementById("bibleBookGroup");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.bibleBookGroups.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.bibleBookGroups[rowIndex][0];
			option.value = scriptLiteral9432.bibleBookGroups[rowIndex][1];
			select.appendChild(option);
		}
	},


	renderBibleBookSelect: function() 
	{
		var select = document.getElementById("bookID");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.bibleBooks.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.bibleBooks[rowIndex];
			option.value = scriptLiteral9432.bibleBooks[rowIndex];
			select.appendChild(option);
		}
	},

	renderBibleUnitSelect: function() 
	{
		var select = document.getElementById("bibleUnit");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.bibleUnits.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.bibleUnits[rowIndex][0];
			option.value = scriptLiteral9432.bibleUnits[rowIndex][1];
			select.appendChild(option);
		}
	},

	renderBibleVersionSelect: function() 
	{
		var select = document.getElementById("bibleVersion");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.bibleVersions.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.bibleVersions[rowIndex][0];
			option.value = scriptLiteral9432.bibleVersions[rowIndex][1];
			select.appendChild(option);
		}
	},

	renderFileTypeSelect: function(select) 
	{
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.fileTypes.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.fileTypes[rowIndex][0];
			option.value = scriptLiteral9432.fileTypes[rowIndex][1];
			select.appendChild(option);
		}
	},

	renderBibleGroupSelect: function() 
	{
		var select = document.getElementById("bibleGroup");
		select.options.length = 0;

		for (var rowIndex = 0, rowCount = scriptLiteral9432.bibleGroups.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.bibleGroups[rowIndex][0];
			option.value = scriptLiteral9432.bibleGroups[rowIndex][1];
			select.appendChild(option);
		}
	},
	
	renderGroupBySelect: function() 
	{
		var select = document.getElementById("groupBy");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.groupBys.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.groupBys[rowIndex];
			option.value = scriptLiteral9432.groupBys[rowIndex];
			select.appendChild(option);
		}
	},
	
	renderOperatorSelect: function() 
	{
		var select = document.getElementById("operator");
		select.options.length = 0;
		
		for (var rowIndex = 0, rowCount = scriptLiteral9432.operators.length; rowIndex < rowCount; ++rowIndex)
		{
			var option = document.createElement("option");
			option.text = scriptLiteral9432.operators[rowIndex];
			select.appendChild(option);
		}
	},
	
	retrieveSelection: function(selectID, defaultSelection, separation)
	{
		var selected = [];
		var selectControl = document.getElementById(selectID);
		var selectValue = null;
		
		if (!defaultSelection)
		{
			defaultSelection = "None";
		}	

		if (!separation)
		{
			separation = ",";
		}	
		
		for (var i = 0; i < selectControl.length; i++) 
		{
			if (selectControl.options[i].selected == true)
			{
				selectValue = selectControl[i].value;
				if (selectValue === defaultSelection)
				{
					return null;
				}	
				selected.push(selectValue);
			}
		}
		return selected.join(separation);
	},

	retrieveSelectionIndex: function(selectID, startValue, separation)
	{
		var selected = [];
		var selectControl = document.getElementById(selectID);
		
		if (!separation)
		{
			separation = ",";
		}	
	
		for (var index = 0; index < selectControl.length; index++) 
		{
			if (selectControl.options[index].selected == true)
			{
				selected.push(startValue + index);
			}
		}
		return selected.join(separation);
	},

	//2017-12-30	https://stackoverflow.com/questions/11821261/how-to-get-all-selected-values-from-select-multiple-multiple
	selectionGet: function(objectId)
	{
		const selected = document.querySelectorAll('#' + objectId + " option:checked");
		const values = Array.from(selected).map((el) => el.value);
		return values.join();
	},
	
	//2017-12-30	https://stackoverflow.com/questions/1295950/javascript-to-select-multiple-options
	selectionSet: function(objectId, values)
	{
		selectMultiObject=document.getElementById(objectId);
		for ( var i = 0, l = selectMultiObject.options.length, o; i < l; i++ )
		{
			o = selectMultiObject.options[i];
			o.selected = (values.indexOf (o.value) != -1);
		}
	},
	
	/*
		2020-01-06	https://stackoverflow.com/questions/24750623/select-a-row-from-html-table-and-send-values-onclick-of-a-button/24750792
		2020-01-06	SelectACode.html
	*/
	selectTableRow: function(tableName)
	{	
		var tableNameTableRow = "#" + tableName + " tr";
		$(tableNameTableRow).click(function(){
		   $(this).addClass('selected').siblings().removeClass('selected');
		   var value=$(this).find('td:first').html();
		   //alert(value);
		});

		$('.ok').on('click', function(e){
			alert($(tableNameTableRow + ".selected td:first").html());
		});
	},	
	
	//2019-12-15 IAmTakingYouOnAJourney.html scriptLiteral9432.renderDataTable(selectWhere(ofAMan.journeys, queryID.value), "resultSet");
	selectWhere: function(dataTable, like) 
	{
		var regexp = new RegExp(like, 'i');
		var dataRecord;
		var found;
		var foundTable = [];
		var keyValue;
		for(var index = 0, length = dataTable.length; index < length; ++index)
		{
			dataRecord = dataTable[index];
			for(var key in dataTable[index])
			{
				keyValue = dataRecord[key];
				found = regexp.test(keyValue);
				if (found)
				{
					foundTable.push(dataRecord); 
					break;
				}
			}
		}
		return(foundTable);
	},
	
	setCellContent: function(tableID, rowIndex, cellIndex, cellContent)
	{
		var tableControl = document.getElementById(tableID);
		tableControl.rows[rowIndex].cells[cellIndex].innerHTML = cellContent;
	},	
	
	setSelectByText: function(selectControl, text)
	{
		var select = document.getElementById(selectControl);
		for (var i = 0; i < select.options.length; i++) {
			if (select.options[i].text === text) {
				select.selectedIndex = i;
				break;
			}
		}
	},
	
	//2019-08-20 https://www.kirupa.com/html5/extending_built_in_objects_javascript.htm
	shuffle: function(input) 
	{
		for (let i = input.length - 1; i >= 0; i--) {

			let randomIndex = Math.floor(Math.random() * (i + 1));
			let itemAtIndex = input[randomIndex];

			input[randomIndex] = input[i];
			input[i] = itemAtIndex;
		}
		return input;
	},
	
	//2019-12-12T21:00
	splitDelimiters: function(word) {
		var words = word.split(/[ ,;.]+/);
		var letter;
		for 
		(
			var index = 0, wordLength = words.length;
			index < words.length;
			++index
		)
		{
			letter = words[index];
			if (letter == '' || letter == ' ' || letter == ',' || letter == ';' || letter == '.')
			{
				words.splice(index, 1);
			}
		}
		return words;
	},	
	//2019-06-22 Json2Html.com.html
	stripFirstJsonObject: function(data) {
		if (data[0] === "{") //An object
		{
			var position = data.indexOf(":");
			data = data.substring(position + 1);
			data = data.substring(0, data.length - 1);
		}
		return data;		
	},
	
	//Joshua Koudys
	stripTags: function(htmlstr) {
		var div = document.createElement('div');
		div.innerHTML = htmlstr;
		return div.textContent;
	},
	
	renderData: function(data, dataID)
	{
		var dataRow = null;
		var dataTable = null;
		var cellContent = null;
		var cellName = null;
		var cells = "";
		var info = "";
		var detailKeys = null;
		var detailRow = null;
		var value = null;
		
		info += "<table id='" + dataID + "'>";

		var occurrences = data.length;
		var caption = "<caption>Occurrences: " + occurrences + "</caption>";
		
		info += caption;
		
		dataTable = data;
		
		if (dataTable.length < 1)
		{
			return "";
		}	

		dataRow = dataTable[0];
		
		dataKeys = Object.keys(dataRow);
		for (var dataIndex = 0, dataCount = dataKeys.length; dataIndex < dataCount; ++dataIndex)
		{
			cells += "<th>" + dataKeys[dataIndex] + "</th>";
		}
		
		info += "<thead><tr>" + cells + "</tr></thead>";
		
		for (var rowIndex = 0, rowCount = dataTable.length; rowIndex < rowCount; ++rowIndex)
		{
			dataRow = dataTable[rowIndex];
			cells = "";
	
			for (var dataIndex = 0, dataCount = dataKeys.length; dataIndex < dataCount; ++dataIndex)
			{
				cellName = dataKeys[dataIndex];
				cellContent = dataRow[cellName];
				
				if (!cellContent)
				{
					cellContent = "";
				}
				
				if (cellName.includes("ContactID"))
				{
					//jsonData = '{"bibleWord":"' + answer + '", "wholeWords":' + true + '}';
					var jsonData = '{"contactID":' + dataRow["ContactID"] + '}';
					cellContent = scriptLiteral9432.buildHyperlinkJSON
					(
						"/WordEngineering/TheSpanishHaveQuitResemblingNow/PaulWhoCouldTalkAboutYouIndividualProsperity.html",
						jsonData
					);

				}
				else if (cellName.includes("ScriptureReference"))
				{
					cellContent = scriptLiteral9432.buildHyperlink("scriptureReference", cellContent);
				}		
				else if (cellName.includes("BibleWord")) //2018-05-06 BodyPart.asmx
				{
					cellContent = scriptLiteral9432.buildHyperlink("bibleWord", cellContent);
				}		
				else if (cellName.includes("URI")) //2018-06-21 ResumeAid.asmx
				{
					
					cellContent = 	"<a href='"  //2018-09-10 prefix http
									+ (cellContent.includes("http") ? cellContent : "http://" + cellContent) 
									+ "'>" + cellContent + "</>";
				}		
				else if (cellName.includes("Actor")) //2021-11-08T13:49:00 DiscoverPowerShell.asmx
				{
					cellContent = scriptLiteral9432.buildHyperlink("bibleWord", cellContent);
				}		
				cells += "<td>" + cellContent + "</td>";
			}

			info += "<tr>" + cells + "</tr>";
		}
			
		info += "</table>";
		
		info += `<button onclick="scriptLiteral9432.exportTableToCSV('${dataID}')">Export to CSV</button>`
	
		info += `<button onclick="scriptLiteral9432.exportTableToJSON('${dataID}')">Export to JSON</button>`

		info += `<button onclick="scriptLiteral9432.exportTableToXML('${dataID}')">Export to XML</button>`
	
		return info;
	},	
	
	
	downloadFile: function(csv, filename, fileType) 
	{
		var csvFile;
		var downloadLink;

		// CSV file
		csvFile = new Blob([csv], {type: "text/" + fileType});

		// Download link
		downloadLink = document.createElement("a");

		// File name
		downloadLink.download = filename  + "." + fileType;

		// Create a link to the file
		downloadLink.href = window.URL.createObjectURL(csvFile);

		// Hide download link
		downloadLink.style.display = "none";

		// Add the link to DOM
		document.body.appendChild(downloadLink);

		// Click download link
		downloadLink.click();
	},
	
	exportTableToCSV: function(tablename) 
	{
		var csv = [];
		var rows = document.querySelectorAll(`#${tablename} tr`);
		
		for (var i = 0; i < rows.length; i++) {
			var row = [], cols = rows[i].querySelectorAll("td, th");
			
			for (var j = 0; j < cols.length; j++) 
				row.push(cols[j].innerText);
			
			csv.push(row.join(","));        
		}

		// Download file
		scriptLiteral9432.downloadFile(csv.join("\n"), tablename, "csv");
	},

	exportTableToJSON: function(tablename) 
	{
		var table = document.getElementById(tablename);
		var data = [];

		// first row needs to be headers
		var headers = [];
		for (var i=0; i<table.rows[0].cells.length; i++) {
			headers[i] = table.rows[0].cells[i].innerHTML.toLowerCase().replace(/ /gi,'');
		}

		// go through cells
		for (var i=1; i<table.rows.length; i++) {

			var tableRow = table.rows[i];
			var rowData = {};

			for (var j=0; j<tableRow.cells.length; j++) {
				rowData[ headers[j] ] = tableRow.cells[j].innerHTML;
			}

			data.push(JSON.stringify(rowData));
		}

		// Download file
		//scriptLiteral9432.downloadFile(encodeURIComponent(data), tablename, "json");
		scriptLiteral9432.downloadFile(data, tablename, "json");

		return data;
	},

	exportTableToXML: function(tablename) 
	{
		var xml = '<?xml version="1.0" encoding="UTF-8"?><Root>';
		var tritem = document.getElementById(tablename).getElementsByTagName("tr");
		var cols = tritem[0].querySelectorAll("td, th");
		celldata = tritem[0];
		var cellNames = [];
		for (var m = 0; m < celldata.cells.length; ++m) {
			cellNames.push(celldata.cells[m].textContent);
		}
		var cols = tritem[0].querySelectorAll("td, th");
		for (i = 1; i < tritem.length; i++) {
			var celldata = tritem[i];
			if (celldata.cells.length > 0) {
				xml += "<TableRow>\n";
				for (var m = 0; m < celldata.cells.length; ++m) {
					xml += `\t<${cellNames[m]}>${celldata.cells[m].textContent}</${cellNames[m]}>\n`;
				}
				xml += "</TableRow>\n";
			}
		}
		xml += '</Root>';

		// Download file
		scriptLiteral9432.downloadFile(xml, tablename, "xml");

		return xml;
    },
	
	renderDataSet: function(data, containerID)
	{
		var	info = "";
		var tableID = "";
		var tableIndex = 0;
		
		//data = data[Object.keys(data)[0]]; //data = data["Table"]; 
		
		for (var table in data) 
		{
			tableID = containerID + tableIndex;
			info += scriptLiteral9432.renderData(data[table], tableID);
			++tableIndex;
		}
		
		document.getElementById(containerID).innerHTML = info;
		
		for 
		(
			tableCounter = 0;
			tableCounter < tableIndex;
			++tableCounter
		)
		{
			var tableID = containerID + tableCounter;
			tsorter.create(tableID);
		}
	},
	
	renderDataTable: function(data, containerID)
	{
		var tableID = containerID + 0;
		//var info = scriptLiteral9432.renderData(data["Table"], tableID);
		var info = scriptLiteral9432.renderData(data, tableID);
		document.getElementById(containerID).innerHTML = info;
		tsorter.create(tableID);
		//scriptLiteral9432.selectTableRow(tableID);
	},

	//2019-10-01 Created.
	renderJsonObject: function(data, caption)
	{
		var tableInfo = `<table><caption>${caption}</caption><tr><th>Key</th><th>Value</th>`;
		for (var key in data) {
			tableInfo += `<tr><td>${key}</td><td>${data[key]}</td></tr>`;	
		}
		tableInfo += "</table>";
		return(tableInfo);
	},

	renderTableColumn: function(data, dataID)
	{
		var dataRow = null;
		var dataTable = null;
		var cellContent = null;
		var cellName = null;
		var cells = "";
		var info = "";
		var detailKeys = null;
		var detailRow = null;
		var value = null;
		
		console.log("info");
		
		info += "<table id='" + dataID + "Table'>";

		var occurrences = data.length;
		var caption = "<caption>Occurrences: " + occurrences + "</caption>";
		
		info += caption;
		
		console.log(info);
		
		for (var rowIndex = 0, rowCount = data.length; rowIndex < rowCount; ++rowIndex)
		{
			dataRow = data[rowIndex];
			dataKeys = Object.keys(dataRow);
			
			cells = "";
	
			console.log(info);
			info += "<tr><td><table><tr><th>Name</th><th>Value</th></tr>";
			
			console.log(info);

			for (var dataIndex = 0, dataCount = dataKeys.length; dataIndex < dataCount; ++dataIndex)
			{
				cellName = dataKeys[dataIndex];
				cellContent = dataRow[cellName];
				
				if (!cellContent)
				{
					cellContent = "";
				}
				
				if (cellName.includes("ContactID"))
				{
					//jsonData = '{"bibleWord":"' + answer + '", "wholeWords":' + true + '}';
					var jsonData = '{"contactID":' + dataRow["ContactID"] + '}';
					cellContent = scriptLiteral9432.buildHyperlinkJSON
					(
						"/WordEngineering/TheSpanishHaveQuitResemblingNow/PaulWhoCouldTalkAboutYouIndividualProsperity.html",
						jsonData
					);

				}
				else if (cellName.includes("ScriptureReference"))
				{
					cellContent = scriptLiteral9432.buildHyperlink("scriptureReference", cellContent);
				}		
				else if (cellName.includes("BibleWord")) //2018-05-06 BodyPart.asmx
				{
					cellContent = scriptLiteral9432.buildHyperlink("bibleWord", cellContent);
				}		
				else if (cellName.includes("URI")) //2018-06-21 ResumeAid.asmx
				{
					
					cellContent = 	"<a href='"  //2018-09-10 prefix http
									+ (cellContent.includes("http") ? cellContent : "http://" + cellContent) 
									+ "'>" + cellContent + "</>";
				}		
				
				cells += "<tr><td>" + cellName + "</td>" + "<td>" + cellContent + "</td>" +
							"</tr>"
			}

			info += "</td>" + cells + "</tr>";
			
			info += "</table>";
		}
			
		info += "</table>";
		
		console.log(info);
		
		return info;
	},	

	renderTableRow: function(data, containerID)
	{
		var	info = "";
		var tableID = "";
		var tableIndex = 0;
		
		info = scriptLiteral9432.renderTableColumn(data, containerID);
		
		document.getElementById(containerID).innerHTML = info;
		
		console.log(info);
		
		for 
		(
			tableCounter = 0;
			tableCounter < tableIndex;
			++tableCounter
		)
		{
			var tableID = containerID + tableCounter;
			tsorter.create(tableID);
		}
	},

	sumFooter: function(tableID, columnsSumIDs)
	{
		var bibleBooksTable = document.getElementById(tableID);
		var rows = bibleBooksTable.getElementsByTagName("tr");
		var rowsLength = rows.length;
		var columnsSumIDsLength = columnsSumIDs.length;
		var columnsTableLength = bibleBooksTable.rows[0].cells.length;
		var columnsSumIDsCompute = new Array(columnsSumIDsLength);
		for 
		(
			var columnsSumIDsIndex = 0;
			columnsSumIDsIndex < columnsSumIDsLength;
			++columnsSumIDsIndex
		)
		{
			columnsSumIDsCompute[columnsSumIDsIndex] = 0;
		}		
		// start with one to skip first row, which is col headers
		for (var rowIndex = 1; rowIndex < rowsLength; ++rowIndex) 
		{
			for 
			(
				var columnsSumIDsIndex = 0, columnsSumIDsCurrent;
				columnsSumIDsIndex < columnsSumIDsLength;
				++columnsSumIDsIndex
			)
			{
				columnsSumIDsCurrent = columnsSumIDs[columnsSumIDsIndex];
				columnsSumIDsCompute[columnsSumIDsIndex] += 
					parseFloat(rows[rowIndex].childNodes[columnsSumIDsCurrent].firstChild.data);
			}		
		}												
		var footer = bibleBooksTable.createTFoot();
		var footerRow = footer.insertRow(0);
		for (var columnsTableIndex = 0;	columnsTableIndex < columnsTableLength; ++columnsTableIndex)
		{
			footerRow.insertCell(-1);
		}		
		for 
		(
			var columnsSumIDsIndex = 0, columnsSumIDsCurrent;
			columnsSumIDsIndex < columnsSumIDsLength;
			++columnsSumIDsIndex
		)
		{
			columnsSumIDsCurrent = columnsSumIDs[columnsSumIDsIndex];
			footerRow.childNodes[columnsSumIDsCurrent].innerHTML = columnsSumIDsCompute[columnsSumIDsIndex];
		}		
	},

	//2018-02-06	https://stackoverflow.com/questions/37148452/javascript-function-to-swap-two-variables
	swap: function(left, right)
	{
		return [right, left]	
	},

	//2018-02-07	https://stackoverflow.com/questions/12409299/how-to-get-current-formatted-date-dd-mm-yyyy-in-javascript-and-append-it-to-an-i
	todayTimezoneOffset: function(now)
	{	
		if (arguments.length === 0)
		{		
			now = new Date();
		}	
		var local = now;
		local.setMinutes(local.getMinutes() - local.getTimezoneOffset());
		var today = local.toJSON().slice(0,10);
		return today;
	},
	
	//2018-06-07	https://stackoverflow.com/questions/19706046/how-to-read-an-external-local-json-file-in-javascript?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
	webServiceAPIFileRequestJSON: function(file, callback, fileType) 
	{
		if (!fileType)
		{
			fileType = "application/json";
		}		
		var xobj = new XMLHttpRequest();
		xobj.overrideMimeType(fileType);
		xobj.open('GET', file, true);
		xobj.onreadystatechange = function () {
			  if (xobj.readyState == 4 && xobj.status == "200") {
				// Required use of an anonymous callback as .open will NOT return a value but simply returns undefined in asynchronous mode
				callback(xobj.responseText);
			  }
		};
		xobj.send(null);  
	},

	//2018-06-07	
	webServiceAPIRestRequest: function(url, callback)
	{
		var xhttp = new XMLHttpRequest();
		xhttp.onreadystatechange = function() {
			if (this.readyState == 4 && this.status == 200) {
				var response = xhttp.responseText;
				callback(response);
			}
		}
		xhttp.open("GET", url, true);
		xhttp.send();
	},	
};

/*
	2018-08-18 https://stackoverflow.com/questions/6982692/html5-input-type-date-default-value-to-today
	dated = new Date().toDateInputValue();
*/
Date.prototype.toDateInputValue = (function() {
    var local = new Date(this);
    local.setMinutes(this.getMinutes() - this.getTimezoneOffset());
    return local.toJSON().slice(0,10);
});

//	2020-01-08	https://stackoverflow.com/questions/2140627/how-to-do-case-insensitive-string-comparison
String.equal = function (s1, s2, ignoreCase, useLocale) {
    if (s1 == null || s2 == null)
        return false;

    if (!ignoreCase) {
        if (s1.length !== s2.length)
            return false;

        return s1 === s2;
    }

    if (useLocale) {
        if (useLocale.length)
            return s1.toLocaleLowerCase(useLocale) === s2.toLocaleLowerCase(useLocale)
        else
            return s1.toLocaleLowerCase() === s2.toLocaleLowerCase()
    }
    else {
        if (s1.length !== s2.length)
            return false;

        return s1.toLowerCase() === s2.toLowerCase();
    }
}
