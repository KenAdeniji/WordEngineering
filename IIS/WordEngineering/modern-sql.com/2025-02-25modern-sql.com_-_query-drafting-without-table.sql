/*
	2025-02-25T19:41:00	http://modern-sql.com/use-case/query-drafting-without-table
		SELECT COUNT(c1)
			 , COUNT(*)
		  FROM (VALUES (1)
					 , (NULL)
			   ) t1(c1)
	2025-02-25T20:03:00	http://modern-sql.com/feature/values
		values
		Create Rows out of Nothing
		The values keyword is probably as old as SQL itself and is pretty well-known for its use with the insert statement. This is, however, just the functionality required by entry-level SQL-92. With full SQL-92,0 values has a richer semantic: it becomes valid wherever select is valid and can produce multiple rows.
		Usage with Full SQL-92
		With full SQL-92, values is generally1 followed by a comma separated list of rows that are in turn column lists enclosed in parentheses. Each row must have the same number of columns2 and the corresponding columns should have the same data type in all rows3—very much like union.
		VALUES [ROW]('row 1 column 1', 'row 1 column 2')
			 , [ROW]('row 2 column 1', 'row 2 column 2')
		The optional keyword row is not widely supported but required by some products (see Compatibility).
		The result of this example is a 2×2 table holding the values as suggested by the data. The column names are implementation-defined but can be renamed in the from clause.
		This code can be put everywhere where select is allowed.4 That is, to provide data to insert (multiple rows), in subqueries, and even as statements of its own.
	2025-02-25T19:56:00	http://modern-sql.com/feature/table-column-aliases
		Aliasing Table And Column Names in the FROM Clause
		You might already know how to alias0 column names and tables names. But chances are you don’t know how to alias the column names of a table in the from clause.
		As usual, the syntax is quite simple: table aliases can be followed by an optional column list in parentheses:
		FROM … [AS] alias [(<derived column list>)]
	2025-02-25T20:12:00	http://modern-sql.com/use-case/naming-unnamed-columns#with
		Common table expression (CTE)
		Option 2: Using Common-Table-Expressions (with)
		Starting with SQL:1999 the with clause can also be used to rename columns based on their position—i.e., without knowing their original name:
		WITH t1 (c1) AS (
			 VALUES (1)
				  , (NULL)
		)
		SELECT COUNT(c1)
			 , COUNT(*)
		  FROM t1
	2025-02-25T20:19:00
		SELECT 	
			1	BookID, 'Genesis' BookTitle
		UNION	SELECT
			2,	'Exodus'
	2025-02-25T20:24:00
		Specifies a temporary named result set, known as a common table expression (CTE).
		This is derived from a simple query and defined within the execution scope of a single SELECT, INSERT, UPDATE, DELETE, or MERGE statement.
		This clause can also be used in a CREATE VIEW statement as part of its defining SELECT statement.
		A common table expression can include references to itself. 
		This is referred to as a recursive common table expression.
*/
SELECT
	BookID,
	BookTitle
FROM
	(
		VALUES	--values clause
			(1, 'Genesis'),
			(2, 'Exodus')
	)	
	BibleBook	--Aliasing Table And Column Names in the FROM Clause
	(
		BookID,
		BookTitle
	)
GO
