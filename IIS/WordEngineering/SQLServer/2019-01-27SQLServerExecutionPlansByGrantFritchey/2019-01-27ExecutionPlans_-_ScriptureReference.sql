--http://localhost/WordEngineering/WordUnion/ScriptureReference.html?scriptureReference=Genesis%2022,%20Daniel%209:24-27,%20John%201:1,%20Jude
SELECT bookId, chapterId, verseId,  verseText = KingJamesVersion  FROM Bible..Scripture WHERE BookId = 1 AND ChapterId = 22 ORDER BY bookId, chapterId, verseId;
SELECT bookId, chapterId, verseId,  verseText = KingJamesVersion  FROM Bible..Scripture WHERE verseIdSequence BETWEEN 22013 AND 22016 ORDER BY bookId, chapterId, verseId;
SELECT bookId, chapterId, verseId,  verseText = KingJamesVersion  FROM Bible..Scripture WHERE BookId = 43 AND ChapterId = 1 AND VerseId = 1 ORDER BY bookId, chapterId, verseId;
SELECT bookId, chapterId, verseId,  verseText = KingJamesVersion  FROM Bible..Scripture WHERE BookId = 65 ORDER BY bookId, chapterId, verseId;