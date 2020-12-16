Select TOP 1 * FROM Contact WHERE LastName LIKE '%Morabito%'

INSERT Contact (Dated, FirstName, LastName, Company ) VALUES ( '20050524', 'Diane', 'Morabito', 'San Francisco General Hospital Surgery' )

INSERT TELEPHONE ( Dated, ContactId, TelephoneNo ) VALUES ( '20050525', 1257, '415/206-4638')

INSERT TELEPHONE ( Dated, ContactId, TelephoneNo, TelephoneLocation ) VALUES ( '20050525', 1257, '415/206-5484', 'F')

SELECT TOP 1 * FROM ContactEmail

INSERT ContactEmail ( Dated, ContactId, EmailAddress ) VALUES ( '20050525', 1257, 'dmorabito@sfghsurg.ucsf.edu' )

SELECT TOP 1 * FROM StreetAddress

INSERT StreetAddress ( Dated, ContactId, AddressLine1, City, State, ZipCode, Country ) VALUES ( '20050525', 1257, '1001 Potrero Avenue, Box 0807', 'San Francisco', 'CA', '94110', 'USA' )
