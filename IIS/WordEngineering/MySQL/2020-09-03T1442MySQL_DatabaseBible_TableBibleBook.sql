-- create database Bible;
-- show databases;
/*
use information_schema;

drop database if exists Bible;

create database Bible;
*/
use Bible;

DROP TABLE IF EXISTS BibleBook
;

CREATE TABLE BibleBook
(
	bookId int NOT NULL,
	bookTitle varchar(50) NOT NULL,
	chapters int NOT NULL,
	chapterLastVerseLast int NOT NULL,
	verseIdSequenceFirst int NOT NULL,
	verseIdSequenceLast int NOT NULL,
	-- testament  AS (case when bookId<=(39) then 'Old' else 'New' end),
    testament VARCHAR(3)  AS
	(
		case 
			when bookId<=(39) then 'Old' else 'New' 
		end
	) ,
	actor varchar(50) NULL,
	author varchar(20) NULL,
	category varchar(20) NULL,
	timeSpan varchar(20) NULL
    
    , primary key pk_BibleBook
    (
		bookId ASC 
	)
     
    , unique index IX_BibleBook_BookTitle
    (
		bookTitle
	)     
)
;


/*
grant select, insert, delete, update
	on BibleBook 
    to 'kadeniji'@'%'
;
*/

/*
show tables;

-- show create table BibleBook;
describe  BibleBook;

-- show status;
select 
	CURRENT_USER();
*/