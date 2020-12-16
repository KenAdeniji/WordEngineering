alter procedure usp_UpdateBibleScripture
AS
BEGIN
	--Create 2018-11-22
	select count(*) from Scripture
	select count(*) from t_bbe
	UPDATE scripture 
		set BibleInBasicEnglish = t_bbe.t
		from t_bbe
		where scripture.bookId = t_bbe.b 
		and scripture.chapterId = t_bbe.c
		and scripture.verseId = t_bbe.v
	UPDATE scripture 
		set DarbyEnglishBible = t_dby.t
		from t_dby
		where scripture.bookId = t_dby.b 
		and scripture.chapterId = t_dby.c
		and scripture.verseId = t_dby.v
	UPDATE scripture 
		set WebsterBible = t_wbt.t
		from t_wbt
		where scripture.bookId = t_wbt.b 
		and scripture.chapterId = t_wbt.c
		and scripture.verseId = t_wbt.v
	UPDATE scripture 
		set WorldEnglishBible = t_wbt.t
		from t_wbt
		where scripture.bookId = t_wbt.b 
		and scripture.chapterId = t_wbt.c
		and scripture.verseId = t_wbt.v
END
GO


	 	 

