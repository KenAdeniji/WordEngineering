use master
go

--does not work
--exec sp_grantlogin 'ephWebUser@ephraimtech.com'
--go

exec sp_grantlogin 'ephraimtech\harvest$'
go

use security
go

exec sp_grantdbaccess 'ephraimtech\harvest$', harvest$
go

grant exec on usp_getMemberID to harvest$
go

use remindme
go

exec sp_grantdbaccess 'ephraimtech\harvest$', harvest$
go

exec sp_addrole roleFullUsage
go

exec sp_addrolemember roleFullUsage, harvest$
go

--select name, crdate from sysobjects where type = 'P' and crdate > '3/1/2006' and name not like 'dt_%' order by 1 asc

--select 'grant exec on ' + rtrim(name) + ' to roleFullUsage'  from sysobjects where type = 'P' and name not like 'dt_%' order by 1 asc


grant exec on getContactAddressInfo to roleFullUsage
grant exec on getContactAddressRecord to roleFullUsage
grant exec on getContactCommentInfo to roleFullUsage
grant exec on getContactCommentRecord to roleFullUsage
grant exec on getContactCommunicationRecord to roleFullUsage
grant exec on getContactEventInfo to roleFullUsage
grant exec on getContactEventRecord to roleFullUsage
grant exec on getContactInfo to roleFullUsage
grant exec on getContactRecord to roleFullUsage
grant exec on getEntriesInCity to roleFullUsage
grant exec on getPublicCommData to roleFullUsage
grant exec on getReportContactCommunicationInfo to roleFullUsage
grant exec on getReportContactCommunicationUsernamePassword to roleFullUsage
grant exec on getReportDateMet to roleFullUsage
grant exec on getReportDateofBirth to roleFullUsage
grant exec on getReportDateofBirthForAdeniji to roleFullUsage
grant exec on getReportInfo to roleFullUsage
grant exec on getReports to roleFullUsage
grant exec on listDatesWithEventsForMonth to roleFullUsage
grant exec on pssp_African to roleFullUsage
grant exec on pssp_African2 to roleFullUsage
grant exec on renderCalendar to roleFullUsage
grant exec on renderDayCalendar to roleFullUsage
grant exec on sp_ContactAddressInsert to roleFullUsage
grant exec on sp_ContactAddressUpdate to roleFullUsage
grant exec on sp_ContactCommentInsert to roleFullUsage
grant exec on sp_ContactCommentUpdate to roleFullUsage
grant exec on sp_ContactCommunicationInsert to roleFullUsage
grant exec on sp_ContactCommunicationUpdate to roleFullUsage
grant exec on sp_ContactEventInsert to roleFullUsage
grant exec on sp_ContactEventUpdate to roleFullUsage
grant exec on sp_ContactInsert to roleFullUsage
grant exec on sp_ContactUpdate to roleFullUsage
grant exec on sp_EPHGetDefragInfo to roleFullUsage
grant exec on sp_getNetworkBoundProcesses to roleFullUsage
grant exec on spInsertListofNameReferences to roleFullUsage
grant exec on usp_AffliateDelete to roleFullUsage
grant exec on usp_AffliateInsert to roleFullUsage
grant exec on usp_AffliateUpdate to roleFullUsage
grant exec on usp_CommunicationTypeDelete to roleFullUsage
grant exec on usp_CommunicationTypeGet to roleFullUsage
grant exec on usp_CommunicationTypeSave to roleFullUsage
grant exec on usp_ContactAddressDelete to roleFullUsage
grant exec on usp_ContactAttachmentItemDelete to roleFullUsage
grant exec on usp_ContactAttachmentUpdate to roleFullUsage
grant exec on usp_ContactCommentDelete to roleFullUsage
grant exec on usp_ContactCommunicationActivateToggle to roleFullUsage
grant exec on usp_ContactCommunicationDelete to roleFullUsage
grant exec on usp_ContactDelete to roleFullUsage
grant exec on usp_ContactEventDelete to roleFullUsage
grant exec on usp_FileIO_WhichObjectsAreInFile to roleFullUsage
grant exec on usp_FileIO_WhichObjectsAreInFileGroup to roleFullUsage
grant exec on usp_getAffiliateCodes to roleFullUsage
grant exec on usp_getCompanySerialNumbers to roleFullUsage
grant exec on usp_getContactAttachments to roleFullUsage
grant exec on usp_GetContactCommunicationInfo to roleFullUsage
grant exec on usp_getContactNames to roleFullUsage
grant exec on usp_getContactProfessions to roleFullUsage
grant exec on usp_getContactProfessions_filtered_on_profession to roleFullUsage
grant exec on usp_GetContactsForMember to roleFullUsage
grant exec on usp_getDateMetReport to roleFullUsage
grant exec on usp_getProfessionCodes to roleFullUsage
grant exec on usp_getReportAffliations to roleFullUsage
grant exec on usp_getReportAffliations_filtered_on_Affiliate to roleFullUsage
grant exec on usp_GetReportContactCommunicationInfoFilteredOnNumber to roleFullUsage
grant exec on usp_GetReportParameters to roleFullUsage
grant exec on usp_GetReports to roleFullUsage
grant exec on usp_ProfessionDelete to roleFullUsage
grant exec on usp_ProfessionInsert to roleFullUsage
grant exec on usp_ProfessionUpdate to roleFullUsage
grant exec on usp_reportSoftwareSerialNumbers to roleFullUsage
grant exec on usp_reportSoftwareSerialNumbers_Filtered_OnCompany to roleFullUsage
grant exec on usp_WhichObjectsAreInFileGroup to roleFullUsage
go

grant select on dbo.v_reports to roleFullUsage
go