SELECT 
	(SELECT TOP 1 ScriptureReference FROM Bible..Scripture WHERE VerseIDSequence >= 31102 * 2 / 13 ORDER BY VerseIDSequence) AS VerseForward,
	(SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) FROM Bible..Scripture WHERE ChapterIDSequence >= 1189 * 2 / 13  ORDER BY ChapterIDSequence) AS ChapterForward,
	(SELECT TOP 1 BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) FROM Bible..Scripture WHERE 31102 - VerseIDSequence >= 31102 * 2 / 13  ORDER BY ChapterIDSequence DESC) AS ChapterBackward,
	(SELECT TOP 1 ScriptureReference FROM Bible..Scripture WHERE 31102 - VerseIDSequence >= 31102 * 2 / 13 ORDER BY VerseIDSequence DESC) AS VerseBackward