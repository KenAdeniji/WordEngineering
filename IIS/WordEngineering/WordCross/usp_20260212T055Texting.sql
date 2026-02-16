CREATE OR ALTER PROCEDURE usp_20260215T0555Texting
(
	@word    NVARCHAR(MAX)
)
AS
	/*
		Created	2025-12-27T21:56:00	http://csharpdeveloper.wordpress.com/2019/08/18/sql-servers-sp_executesql-does-not-protect-you-from-sql-injection
		2026-02-14	http://sfbay.craigslist.org/eby/cpg/d/walnut-creek-walnut-creek-petition/7915226685.html
		2026-02-15T04:12:00 A person has song lyrics talent, and their 1st release garnered much funfare, acclaim, reception in market numbers. Buki also came to me, and he told me his success, and an intruder almost shot Buki. You have to always find... something you have in common.
			What relation is He permanent?
		2026-02-15T04:29:00 12, 24? Twelve, twenty-four?
		2026-02-15T04:32:00 How does this number... apply to Him?
			12? 12 years old, temple worship in Jerusalem. 12 disciples, 12 tribes of Israel.
			24? Out of Egypt have I called My Son. 2 years and under. 2 years=24 months.
		2 Kings 2:6, 2 Timothy 3:15
		2026-02-15T08:36:00	To have... observe... the same as I.
Zay
Company	The State Property Organization
Work e-mail	info@state-property.org
Work phone	(855) 681-5287
Other e-mail	Adan@state-property.org,Invest@state-property.org,Info@mysite.com
Other phone	(323) 497-1085
Website	sfbay.craigslist.org/eby/cpg/d/walnut-creek-walnut-creek-petition/7915226685.html
Notes	2026-02-14T21:33:00 http://www.state-property.org 2026-02-14T21:31:00 (Walnut Creek) Petition Validator Urgently Needed (walnut creek) © craigslist - Map data © OpenStreetMap compensation: $20/hr The State Property Organization is seeking a reliable and detail-oriented Petition Validator to assist with reviewing and verifying petition signatures in the Walnut Creek area. This is a straightforward role ideal for individuals who are organized, focused, and comfortable handling paperwork and basic compliance checks. What You’ll Be Doing: Reviewing petition sheets for accuracy and voter validation Verifying signatures meet basic guidelines Flagging incomplete or incorrect entries Organizing and tracking validated sheets Requirements: Strong attention to detail Dependable and punctual Ability to follow simple verification guidelines Prior canvassing, admin, or compliance experience is a plus (not required) Ideal For: Students Admin assistants Detail-oriented workers Anyone with validation, data review, or petition experience Location: Walnut Creek Schedule: Flexible / Immediate Start Work Type: Contract / Part-Time or Full-Time Available We are looking to fill this position quickly, so priority will be given to applicants who can start immediately. To Apply: Text “VALIDATOR – WALNUT CREEK” with your name, availability and if you have a vehicle to get to and from work to Zay the hiring manager (323) 497-1085 post id: 7915226685 posted: about 5 hours ago ? best of [?] help safety privacy terms about app			
	*/	
    SET NOCOUNT ON
    DECLARE @sql nvarchar(MAX)
    DECLARE @dated datetime2

	DECLARE @isDateTime BIT 

	DECLARE @wordDateTime DateTime 

    /*
        determine if @word is date
    */
    set @isDateTime = ISDATE(@word)

    IF (@isDateTime = 1)
    BEGIN

        SET @wordDateTime = CONVERT( Date, @word )

    END
    else
    begin

          SET @wordDateTime = null

    end


    SET @sql =  N'SELECT *' +

                +   ' FROM WordEngineering.dbo.Texting '

                +   ' WHERE 1=0 '
                
                +   ' OR PhoneNumber LIKE @p1 '
                +   ' OR PhoneType LIKE @p1 '
                +   ' OR Email LIKE @p1 '
                +   ' OR URI LIKE @p1 '
                +   ' OR Requirement LIKE @p1 '
                +   ' OR Fulfillment LIKE @p1 '
                +   ' OR Titled LIKE @p1 '
                +   ' OR OrganizationName LIKE @p1 '
                +   ' OR ContactName LIKE @p1 '				
                +   ' OR SourceURI LIKE @p1 '

                ;


        if ( @isDateTime = 1 )
        begin

                SET @sql = @sql  

                             +   ' OR Dated BETWEEN @p2 AND DATEADD(DAY, 1, @p2) '

                             +   ' OR Requested BETWEEN @p2 AND DATEADD(DAY, 1, @p2) '

        end 

        SET @sql = @sql  
        
                +   ' ORDER By TextingID DESC '
        ;

    EXEC sp_executesql 
          @sql
        , N'@p1 nvarchar(MAX)
        , @p2 DATETIME2'
        , @word
        , @wordDateTime


GO

/*

    exec usp_20260215T0555Texting 'Zay'

    exec usp_20260215T0555Texting '2026-02-15'

    exec usp_20260215T0555Texting '2026-02-15 02:01'

    exec usp_20260215T0555Texting '2026-02-01'

    exec usp_20260215T0555Texting 'BOOLEAN'


*/