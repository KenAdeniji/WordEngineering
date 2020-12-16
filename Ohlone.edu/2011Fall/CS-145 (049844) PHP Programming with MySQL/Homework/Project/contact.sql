CREATE DATABASE contact;
USE contact;

CREATE TABLE Contact(
	ContactID INT(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	UserId int(11) NULL,
	FirstName varchar(50) NULL,
	MiddleName varchar(50) NULL,
	LastName varchar(50) NULL,
	NickName varchar(50) NULL,
	LeadId int(11) NULL,
	Birthday datetime NULL,
	Anniversary datetime NULL,
	Note varchar(50000) NULL,
	PRIMARY KEY (ContactID)
);

CREATE TABLE EmailAddress(
	EmailAddressID int(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	ContactID int(11) NOT NULL,
	PersonalEmail varchar(100) NULL,
	WorkEmail varchar(100) NULL,
	OtherEmail varchar(100) NULL,
	PreferredEmailID int(2) NULL,
	PRIMARY KEY (EmailAddressID)
);

CREATE TABLE StreetAddress(
	StreetAddressID int(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	ContactID int(2) NULL,
	InformationTypeId int(2) NULL,
	Address varchar(200) NULL,
	Suburb varchar(100) NULL,
	State varchar(100) NULL,
	PostCode varchar(50) NULL,
	Country varchar(100) NULL,
	PRIMARY KEY (StreetAddressID)
);

CREATE TABLE Organization(
	OrganizationId int(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	ContactId int(11) NOT NULL,
	OrganizationName varchar(100) NULL,
	Title varchar(100) NULL,
	PRIMARY KEY (OrganizationId)
);

CREATE TABLE PhoneNumber(
	PhoneNumberId int(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	ContactId int(11) NOT NULL,
	HomePhone varchar(50) NULL,
	MobilePhone varchar(50) NULL,
	WorkPhone varchar(50) NULL,
	Pager varchar(50) NULL,
	Fax varchar(50) NULL,
	OtherPhone varchar(50) NULL,
	PRIMARY KEY (PhoneNumberId)
);

CREATE TABLE UriAddress(
	UriAddressId int(11) NOT NULL AUTO_INCREMENT,
	Dated datetime NOT NULL,
	ContactId int(11) NOT NULL,
	Website varchar(300) NULL,
	PRIMARY KEY (UriAddressId)
);

CREATE TABLE Login(
	LoginId int(11) NOT NULL AUTO_INCREMENT,
	email varchar(100) NOT NULL,
	Password varchar(100) NOT NULL,
	PRIMARY KEY (LoginId)
);

CREATE VIEW ViewContact AS SELECT 
	Contact.ContactID AS Contact_ContactID,
	Contact.Dated AS Contact_Dated,
	Contact.FirstName AS FirstName,
	Contact.LastName AS LastName,
	Contact.NickName AS NickName,
	Contact.Birthday AS Birthday,
	Contact.Note AS Note,
	EmailAddress.PersonalEmail AS PersonalEmail,
	EmailAddress.WorkEmail AS WorkEmail,
	EmailAddress.OtherEmail AS OtherEmail,
	EmailAddress.PreferredEmailID AS PreferredEmailID,
	HomeStreetAddress.Address AS HomeAddress,
	HomeStreetAddress.Suburb AS HomeCity,	
	HomeStreetAddress.State AS HomeState,
	HomeStreetAddress.PostCode AS HomePostCode,
	HomeStreetAddress.Country AS HomeCountry,
	Organization.OrganizationName AS Company,
	PhoneNumber.HomePhone AS HomePhone,
	PhoneNumber.MobilePhone AS MobilePhone,
	PhoneNumber.WorkPhone AS WorkPhone,
	PhoneNumber.Pager AS Pager,
	PhoneNumber.Fax AS Fax,
	PhoneNumber.OtherPhone AS OtherPhone,
	UriAddress.Website AS Website,
	WorkStreetAddress.Address AS WorkAddress,
	WorkStreetAddress.Suburb AS WorkCity,
	WorkStreetAddress.State AS WorkState,
	WorkStreetAddress.PostCode AS WorkPostCode,
	WorkStreetAddress.Country AS WorkCountry
FROM
	Contact
	INNER JOIN EmailAddress ON Contact.ContactID = EmailAddress.ContactID
	INNER JOIN Organization ON Contact.ContactID = Organization.ContactID
	INNER JOIN PhoneNumber ON Contact.ContactID = PhoneNumber.ContactID
	INNER JOIN StreetAddress AS WorkStreetAddress ON Contact.ContactID = WorkStreetAddress.ContactID AND WorkStreetAddress.InformationTypeId = 1
	INNER JOIN StreetAddress AS HomeStreetAddress ON Contact.ContactID = HomeStreetAddress.ContactID AND HomeStreetAddress.InformationTypeId = 2
	INNER JOIN UriAddress ON Contact.ContactID = UriAddress.ContactID
;

DELIMITER $$

CREATE PROCEDURE RefreshContact
(
	  task VARCHAR(6)	
	, contactId INT(11)
    , dated DateTime
    , userId INT(11)
    , firstName VARCHAR(50)
    , lastName VARCHAR(50)
    , nickName VARCHAR(50)
    , birthday DateTime
    , note VARCHAR(5000)
	
	, homeAddress VARCHAR(200)
	, homeCity VARCHAR(100)
	, homeState VARCHAR(100)
	, homePostCode VARCHAR(50)
	, homeCountry VARCHAR(100)

	, company VARCHAR(100)
	
	, workAddress VARCHAR(200)
	, workCity VARCHAR(100)
	, workState VARCHAR(100)
	, workPostCode VARCHAR(50)
	, workCountry VARCHAR(100)
	
	, personalEmail VARCHAR(100)
	, workEmail VARCHAR(100)
	, otherEmail VARCHAR(100)
	, preferredEmailID INT(2)

	, homePhone varchar(50)
	, mobilePhone varchar(50)
	, workPhone varchar(50)
	, pager varchar(50)
	, fax varchar(50)
	, otherPhone varchar(50)
	
	, website  varchar(100)
)
BEGIN
	IF (task = 'Insert') THEN
	SET Dated = Now();
   
    INSERT INTO Contact (Dated, UserId, FirstName, LastName, NickName, Birthday, Note) 
    VALUES (Dated, UserId, FirstName, LastName, NickName, Birthday, Note);
    
    SET ContactId = LAST_INSERT_ID();
    
	INSERT INTO StreetAddress (Dated, ContactId, InformationTypeId, Address, Suburb, State, PostCode, Country)
	VALUES (Dated, ContactId, 1, workAddress, workCity, workState, workPostCode, workCountry);
	
	INSERT INTO StreetAddress (Dated, ContactId, InformationTypeId, Address, Suburb, State, PostCode, Country)
	VALUES (Dated, ContactId, 2, homeAddress, homeCity, homeState, homePostCode, homeCountry);

	INSERT INTO Organization (Dated, ContactId, OrganizationName)
	VALUES (Dated, ContactId, company);

	INSERT INTO EmailAddress (Dated, ContactId, personalEmail, workEmail, otherEmail, preferredEmailID)
	VALUES (Dated, ContactId, personalEmail, workEmail, otherEmail, preferredEmailID);
	
	INSERT INTO PhoneNumber (Dated, ContactId, homePhone, mobilePhone, workPhone, pager, fax, otherPhone)
	VALUES (Dated, ContactId, homePhone, mobilePhone, workPhone, pager, fax, otherPhone);

	INSERT INTO UriAddress (Dated, ContactId, website)
	VALUES (Dated, ContactId, website);
	
	ELSEIF (task = 'Update') THEN
    
	UPDATE Contact SET
	FirstName = FirstName, LastName = LastName, NickName = NickName, Birthday = Birthday, Note = Note
    WHERE ContactID = ContactID;
    
	UPDATE StreetAddress 
	SET 
		Address = workAddress,
		Suburb = workCity,
		State = workState,
		PostCode = workPostCode,
		Country = workCountry
	WHERE ContactID = ContactID AND InformationTypeId = 1;
	
	UPDATE StreetAddress 
	SET 
		Address = homeAddress,
		Suburb = homeCity,
		State = homeState,
		PostCode = homePostCode,
		Country = homeCountry
	WHERE ContactID = ContactID AND InformationTypeId = 2;
	
	UPDATE Organization
	SET 
		OrganizationName = Company
	WHERE ContactId = ContactId;

	UPDATE EmailAddress
	SET
		personalEmail = personalEmail,
		workEmail = workEmail,
		otherEmail = otherEmail,
		preferredEmailID = preferredEmailID
	WHERE ContactId = ContactId;
	
	UPDATE PhoneNumber 
	SET
		homePhone = homePhone,
		mobilePhone = mobilePhone,
		workPhone = workPhone,
		pager = pager,
		fax = fax,
		otherPhone = otherPhone
	WHERE ContactId = ContactId;

	UPDATE UriAddress
		SET website = website
	WHERE ContactId = ContactId;
	
	END IF;
END
$$

DELIMITER ;

CALL RefreshContact(1,'2011-10-20',3,4,5,6,'2011-10-20',8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30); 