<!DOCTYPE html>
<html>
	<!--
		2018-10-07	https://stackoverflow.com/questions/4720494/javascript-libraries-that-allow-for-sql-like-queries-on-json-data
		2018-10-07	https://github.com/agershun/alasql
		2018-10-07	http://alasql.org

		2018-10-11	Created.	
		2018-10-11	https://stackoverflow.com/questions/43348729/html-table-with-250-000-rows-a-better-way
		2018-10-12	http://github.com/KenAdeniji/WordEngineering/blob/master/IIS/WordEngineering/alasql.org/AlaSQL.js_-_OnlyRefuseSubstainTheLine.html
		2018-10-12	https://stackoverflow.com/questions/52787978/datatable-jquery-plug-in-dynamic-table-creation-and-data
					I am using Ajax to retrieve the entire Bible from the database. 
					I am using AlaSql.js to extract the sacred text for each scripture reference.
					I will like to use DataTables.net to display the sacred text for each scripture reference.
	-->
	<head>
		<title>AlaSQL.js Only refuse; substain the line.</title>
		<link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css">
		<link rel="stylesheet" type="text/css" href="/WordEngineering/WordUnion/9432.css">
	</head>
	<body>
		<div align="center">
			<table>
				<tr>
					<td><label for="scriptureReference">Scripture Reference</td>
					<td><input id="scriptureReference" type="text"/></td>
				</tr>
				<tr>
					<td><label for="bibleVersion">Version</td>
					<td><select id="bibleVersion"> </select></td>
				</tr>
				<tr>
					<td colspan="2" align="center"><input id="submitQuery" type="submit"></td>
				</tr>
			</table>
			<div id="resultSet"></div>
		</div>	
		<script src="http://code.jquery.com/jquery-latest.js"></script>	
		<script src="//cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>	
		<script src="//cdn.jsdelivr.net/alasql/latest/alasql.min.js"></script>
		
<link href="https://unpkg.com/tabulator-tables@4.0.4/dist/css/tabulator.min.css" rel="stylesheet">
<script type="text/javascript" src="https://unpkg.com/tabulator-tables@4.0.4/dist/js/tabulator.min.js"></script>		
		<script>
			var isPostBack = false;
			var	dataSet = null;
			
			function dataParse()
			{
				document.getElementById("resultSet").innerHTML = "";

				scriptureReferenceParse
				(
					document.getElementById("scriptureReference").value
				);
				
				sqlStatements = 
				[
					`SELECT * FROM ? WHERE chapterIdSequence = 22`,
					`SELECT * FROM ? WHERE bookId = 43 AND chapterId = 1`
				];
				
				for
				(
					var sqlStatementId = 0, 
						sqlStatementIdCount = sqlStatements.length;
					sqlStatementId < sqlStatementIdCount;
					++sqlStatementId
				)
				{
					var alasResult = alasql
					(
						sqlStatements[sqlStatementId], [dataSet]
					);
					
					/*
					var resultTable = document.createElement("table");
					resultTable.id = "resultTable" + sqlStatementId;
					let myTable = $('#' + resultTable.id).DataTable
					( 
						{
							"data": alasResult,
							"columns": [
								{ "data": "verseIdSequence" },
								{ "data": "scriptureReference" },
								{ "data": "KingJamesVersion" }
							],
							destroy: true
						}
					);
					//document.getElementById("resultSet").appendChild(myTable);
					$("#resultSet").append(myTable);
					//scriptLiteral9432.renderDataTable(alasResult, "resultSet");
					*/
					
					var resultDiv = document.createElement("div");
					resultDiv.id = "resultDiv" + sqlStatementId;
					document.getElementById("resultSet").appendChild(resultDiv);
var table = new Tabulator("#" + resultDiv.id, {
 	height:205, // set height of table (in CSS or here), this enables the Virtual DOM and improves render speed dramatically (can be any valid css height value)
 	layout:"fitColumns", //fit columns to width of table (optional)
 	columns:[ //Define Table Columns
	 	{title:"VerseIdSequence", field:"verseIdSequence"},
	 	{title:"Scripture Reference", field:"scriptureReference"},
	 	{title:"KingJamesVersion", field:bibleVersion.value},
 	],
 	rowClick:function(e, row){ //trigger an alert message when the row is clicked
 		alert("Row " + row.getData().id + " Clicked!!!!");
 	},
});

table.setData(alasResult);
				}
			}
	
			function querySubmit()
			{
				if (dataSet) { dataParse(); return; }
				var request = {};
				//request["scriptureReference"] = scriptureReference;
				var requestJson = JSON.stringify(request);
				
				$.ajax
				({
					type: "POST",
					contentType: "application/json; charset=utf-8",
					url: 
						"/WordEngineering//AlaSQL.js/AlaSQL.js_-_OnlyRefuseSubstainTheLine.asmx/Query",
					data: requestJson,
					dataType: "json",
					success: function(data) 
					{
						dataSet = JSON.parse(data.d);
						dataParse();
					},
					error: function(xhr)
					{ 
						$("#resultSet").html
						(
							'Status: ' + xhr.status + " | " + 
							'StatusText: ' + xhr.statusText + " | " +
							'ResponseText: ' + xhr.responseText
						);
					} 
				});
			}

			function pageLoad()
			{
				if (isPostBack === false)
				{
					$.getScript
					( 
						"/WordEngineering/WordUnion/9432.js", 
						function( data, textStatus, jqxhr ) 
					{
						var scriptureReference = 
							scriptLiteral9432.getParameterByName
							(
								"scriptureReference"
							);
						if (scriptureReference)
						{
							document.getElementById
							(
								"scriptureReference"
							).value = scriptureReference;
						}	
						scriptLiteral9432.renderBibleVersionSelect();
						var bibleVersion = 
							scriptLiteral9432.getParameterByName
							(
								"bibleVersion"
							);
						if (bibleVersion)
						{
							document.getElementById
							(
								"bibleVersion"
							).value = bibleVersion;
						}	
						querySubmit();
						isPostBack = true;	
					});
				}
				else
				{
					querySubmit();
				}
			}
			
			var BibleBooks = ["Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"];
			var SongOfSolomonBookID = 21;
			
			function scriptureReferenceParse
			(
				scriptureReferenceEntry
			)
			{
				var BookTitleChapterSeparator = " ";
				var ChapterVerseSeparator = ':';
				var PrePostSeparator = '-';
				
				var scriptureReferences = 
					scriptureReferenceEntry.split(/[,;]/);
				ScriptureReference previousReference = null;
				var scriptureReferenceSubsets = null;
				var	tryParseFlag;
				var numericFlag;
				const Pre = 0;
				
				scriptureReferences.forEach
				(
					function(element) 
					{
						//console.log(element);
						prePost = element.split(PrePostSeparator);
						for 
						(
							var prePostIndex = 0,
								prePostLength = prePost.length
						)
						{
							var currentReference = 
								prePost[prePostIndex].trim();
							if(typeof currentReference == 'number')
							{
								var prePostValue = 
									parseInt(currentReference);
								scriptureReference = previousReference;
								if (!previousReference.verse)
								{
									scriptureReference.chapter = 
										prePostValue;
								}
								else
								{
									scriptureReference.verse = 
										prePostValue;
								}
							}
							else
							{
								var chapterVerseSeparatorPosition = 
									currentReference.lastIndexOf
									(
										ChapterVerseSeparator
									);
								if (chapterVerseSeparatorPosition > 0)
								{
									if 
									( 
										typeof 
											currentReference.substring
											(
												chapterVerseSeparatorPosition + 1
											)
										!= 'number'
									)
									{
										return scriptureReferenceSubsets;
									}
									else
									{
										var verse = parseInt
										(
											currentReference.substring
											(
												chapterVerseSeparatorPosition + 1
											)
										);
										scriptureReference.verse = verse;
										currentReference = 
											currentReference.substring
											(
												0,
												chapterVerseSeparatorPosition
											);
									}
								}
								else
								{
									scriptureReference.verse = null;
								}
								var bookTitleChapterSeparatorPosition = 
									currentReference.lastIndexOf
									(
										BookTitleChapterSeparator
									);
								if (bookTitleChapterSeparatorPosition > -1)
								{
									var isBookTitle = CheckForBookTitle
									(
										currentReference,
										bookTitleChapterSeparatorPosition
									);
									if (isBookTitle === true)
									{
										scriptureReference = 
											new ScriptureReference
											(
												currentReference,
												null,
												null
											);
									}
									else
									{
										if 
										(
											typeof currentReference.substring
											(
												bookTitleChapterSeparatorPosition + 1
											)
											!= 'number'
										)
										{
											return 
												scriptureReferenceSubsets;
										}
										scriptureReference.chapterID = 
											parseInt
											(
												currentReference.substring
												(
													bookTitleChapterSeparatorPosition + 1
												)
											);
										scriptureReference.bookTitle = 
											currentReference.substring
											(
												0,
												bookTitleChapterSeparatorPosition
											);	
									}	
								}
								else
								{
									numericFlag = 
										typeof currentReference 
										== 'number';
									if (numericFlag)
									{
										scriptureReference.chapterID = 
											parseInt(currentReference);  
										scriptureReference.bookTitle = 
											previousReference.bookTitle;
									}
									else
									{
										scriptureReference.bookTitle
											= currentReference;
										scriptureReference.chapterID 
											= null;	
										scriptureReference.verseID 
											= null;	
									}	
								}
							}
							if ( prePostIndex === Pre)
							{
								scriptureReferenceSubset.Pre =
									scriptureReference;
							}
							else
							{
								scriptureReferenceSubset.Post =
									scriptureReference;
							}
							previousReference = scriptureReference;
						}
						scriptureReferenceSubsets.push
						(
							scriptureReferenceSubset
						);
					}
				);
				return scriptureReferenceSubsets;
			}

			function checkForBookTitle(currentReference, bookTitleChapterSeparatorPosition)
			{
				int number = -1;
				
				if 
				(
					currentReference.toLowerCase() ===
					BibleBooks[SongOfSolomonBookID].toLowerCase() 
				)
				{
					return true;
				}	
				var leftOfSeparator = currentReference.substring
				(
					0,
					bookTitleChapterSeparatorPosition
				).trim();
				var isBookTitle = (typeof leftOfSeparator == 'number');
				return isBookTitle;
			}
			
			class ScriptureReference 
			{
				constructor(bookTitle, chapterID, verseID) 
				{
					this.bookTitle = bookTitle;
					this.chapterID = chapterID;
					this.verseID = verseID;
				}
			}
			
			window.addEventListener("load", pageLoad, false);
			
			document.getElementById
			(
				"submitQuery"
			).addEventListener
			(
				"click",
				querySubmit,
				false
			);
		</script>
	</body>
</html>
