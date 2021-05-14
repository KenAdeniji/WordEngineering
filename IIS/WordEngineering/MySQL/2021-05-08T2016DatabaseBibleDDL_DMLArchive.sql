--downloads.mysql.com/docs/mysql-tutorial-excerpt-5.7-en.pdf

mysql -h host -u user -p

SELECT
	VERSION(),
	CURDATE(),
	CURRENT_DATE,
	NOW(),
	CURRENT_USER(),
	TIMESTAMPDIFF(YEAR, CURDATE(), CURDATE()),
	YEAR(CURRENT_DATE), 
	MONTH(CURRENT_DATE), 
	DAYOFMONTH(CURRENT_DATE),
	MONTH(DATE_ADD(CURRENT_DATE, INTERVAL 1 MONTH));
;

SHOW DATABASES;

DROP DATABASE IF EXISTS Bible;

CREATE DATABASE IF NOT EXISTS Bible;

USE Bible;

SHOW TABLES;

DROP TABLE IF EXISTS BibleBook;

CREATE TABLE BibleBook
(
	BookID INT NOT NULL,
	BookTitle VARCHAR(50) NOT NULL,
	Chapters INT NOT NULL,
	ChapterLastVerseLast INT NOT NULL,
	VerseIDSequenceFirst INT NOT NULL,
	VerseIDSequenceLast INT NOT NULL,
    Testament VARCHAR(3) AS (case when BookID <= (39) then 'Old' else 'New' end),
    PRIMARY KEY PK_BibleBook ( BookID ASC ),
	UNIQUE INDEX IX_BibleBook_BookTitle ( BookTitle	)     
);

DESCRIBE BibleBook;

SELECT DATABASE();

SELECT @currentDatabase:=DATABASE(); SELECT @currentDatabase;