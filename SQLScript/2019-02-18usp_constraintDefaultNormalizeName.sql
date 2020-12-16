--use [master]
go

if object_id('[dbo].[usp_constraintDefaultNormalizeName]') is null
begin

	exec('create procedure [dbo].[usp_constraintDefaultNormalizeName] as ')

end
go

alter procedure [dbo].[usp_constraintDefaultNormalizeName]
(
	@displayGUI bit = 0
)
with encryption 
as
begin

	set nocount on;
	set XACT_ABORT on;

	--declare @id int
	declare @idMax int

	declare @tbl TABLE
	(
		  [id]                  int not null identity(1,1)
		, [table]				sysname
		, [column]				sysname
		, [constraintCurrent]	sysname
		, [constraintNew]		sysname
		, [definition]			nvarchar(max)
		, [sqlDrop]				nvarchar(max)
		, [sqlAdd]				nvarchar(max)
	)

	declare
		  @id                   int 
		, @table				sysname
		, @column				sysname
		, @constraintCurrent	sysname
		, @constraintNew		sysname
		, @definition			nvarchar(max)
		, @sqlDrop				nvarchar(max)
		, @sqlAdd				nvarchar(max)

	declare @sql nvarchar(max);

	declare @sqlHeader nvarchar(max);
	declare @sqlFooter nvarchar(max);

	declare @CHAR_SEMICOLON char(1);

	declare @CHAR_TAB char(1);

	declare @CHAR_NEWLINE varchar(10);

	set @CHAR_SEMICOLON = ';'
	set @CHAR_TAB = char(9);

	set @CHAR_NEWLINE= char(13) + char(10);

	set @sqlHeader = 
						    'SET NOCOUNT ON; '
						  + @CHAR_NEWLINE
						  + 'SET XACT_ABORT ON; '
						  + @CHAR_NEWLINE
						  + @CHAR_NEWLINE
						  + 'declare @commit bit; '
						  + @CHAR_NEWLINE
						  + @CHAR_NEWLINE
						  + 'set @commit = 0; '
						  + @CHAR_NEWLINE
						  + @CHAR_NEWLINE
						  + 'BEGIN TRAN '
						  + @CHAR_NEWLINE
						  + @CHAR_NEWLINE
						;


	set @sqlFooter = 
							''
						  + 'while (@@trancount > 0) '
						  + @CHAR_NEWLINE
						  + 'BEGIN '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB
	
						  + 'if @commit = 1 '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB
						  + 'BEGIN '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB + @CHAR_TAB
						  + 'print ''commit;'' '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB + @CHAR_TAB
						  + 'COMMIT TRAN; '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB --+ @CHAR_TAB
						  + 'END '
						  + @CHAR_NEWLINE

						  + @CHAR_TAB
						  + 'else '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB
						  + 'BEGIN '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB + @CHAR_TAB
						  + 'print ''rollback;'' '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB + @CHAR_TAB
						  + 'ROLLBACK TRAN; '
						  + @CHAR_NEWLINE
						  + @CHAR_TAB --+ @CHAR_TAB
						  + 'END '
						  + @CHAR_NEWLINE


						  + 'END '
						  + @CHAR_NEWLINE

						;

	-- exec sp_help 'sys.default_constraints'
	;with cteConstraintDefault
	(
		  [table]
		, [column] 
		, [constraintCurrent] 
		, [constraintNew]
		, [definition]
		, [sqlDrop]	
		, [sqlAdd]	

	)
	as
	(

		select 
		 
			  [table] 
				= quoteName(tblSS.name) + '.' + quoteName(tblSO.name)
			
			, [column] 
				= quoteName(tblSC.name) 
			
			, [constraintCurrent] 
				= tblSDC.[name]
			
			, [constraintNew]
				= 'DF_'
					+ tblSS.[name]
					+ '.'
					+ tblSO.[name]
					+ '.'
					+ tblSC.[name]
			
			, tblSDC.[definition]

			, [sqlDrop]	
				= 'ALTER TABLE '
					+ quoteName(tblSS.[name])
					+ '.'
					+ quoteName(tblSO.[name])
					+ @CHAR_NEWLINE
					+ @CHAR_TAB + @CHAR_TAB
					+ ' DROP CONSTRAINT '
					+ quoteName(tblSDC.[name])

			, [sqlAdd]	
				= 
					
					'ALTER TABLE '
					+ quoteName(tblSS.[name])
					+ '.'
					+ quoteName(tblSO.[name])
					+ @CHAR_NEWLINE
					+ @CHAR_TAB + @CHAR_TAB
					+ ' ADD CONSTRAINT '
					+ quoteName
						(

							 'DF_'
							+ tblSS.[name]
							+ '.'
							+ tblSO.[name]
							+ '.'
							+ tblSC.[name]
						)
					+ @CHAR_NEWLINE
					+ @CHAR_TAB + @CHAR_TAB
					+ ' default '
					+ tblSDC.[definition]
					+ @CHAR_NEWLINE
					+ @CHAR_TAB + @CHAR_TAB
					+ ' for '
					+ quoteName(tblSC.[name])
					

		from   sys.default_constraints tblSDC

		inner join sys.objects tblSO

				on tblSDC.[parent_object_id] = tblSO.[object_id]

		inner join sys.schemas tblSS

				on tblSO.[schema_id] = tblSS.[schema_id]

		
		inner join sys.columns tblSC

				on tblSDC.[parent_object_id] = tblSC.[object_id]
				and tblSDC.parent_column_id = tblSC.column_id

		where tblSO.type = 'U'

		and   tblSDC.is_system_named =1

	)
	insert into @tbl
	(
		  [table]	
		, [column]				
		, [constraintCurrent]	
		, [constraintNew]		
		, [definition]			
		, [sqlDrop]				
		, [sqlAdd]				
	)

	select 
			  [table] 
			, [column] 
			, [constraintCurrent]
				= [constraintCurrent]
			, [constraintNew]
				= [constraintNew]

			, [definition]

			, [sqlDrop]	
				= [sqlDrop]

			, [sqlAdd]	
				= [sqlAdd]

	from  cteConstraintDefault

	order by
			  [table] 
			, [column] 

	set @idMax = ( 
					select max([id]) 
				
					from @tbl
				)

	set @id = 1

	if (@displayGUI = 1)
	begin

		select 
				  [source] = '@tbl'
				, tbl.*

		from   @tbl tbl

	end

	print @sqlHeader

	while (@id <= @idMax)
	begin

		select
			  @table				= [table]	
			, @column				= [column]				
			, @constraintCurrent	= [constraintCurrent]	
			, @constraintNew		= [constraintNew]		
			, @definition			= [definition]			
			, @sqlDrop				= [sqlDrop]				
			, @sqlAdd				= [sqlAdd]				

		from  @tbl tbl

		where tbl.[id] = @id

		set @sql = @CHAR_TAB + @sqlDrop + @CHAR_SEMICOLON

		set @sql = @sql + @CHAR_NEWLINE
		set @sql = @sql + @CHAR_NEWLINE

		set @sql = @sql + @CHAR_TAB + @sqlAdd  + @CHAR_SEMICOLON

		set @sql = @sql + @CHAR_NEWLINE + @CHAR_NEWLINE

		print @sql

		set @id = @id +1

	end

	print @sqlFooter

end
go


exec sp_MS_marksystemobject 'dbo.usp_constraintDefaultNormalizeName'
go


/*

	use [DBDiag]
	go

	exec dbo.usp_constraintDefaultNormalizeName
			@displayGUI = 1


*/