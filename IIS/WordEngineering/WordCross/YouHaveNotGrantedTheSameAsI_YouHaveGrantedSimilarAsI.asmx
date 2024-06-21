<%@ WebService Language="C#" Class="YouHaveNotGrantedTheSameAsI_YouHaveGrantedSimilarAsIWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

/*
Amanda Cheng
Company	DentoAI
Website	sfbay.craigslist.org/sfc/sof/d/san-francisco-full-stack-developer/7758222873.html
Notes	2024-06-18T20:43:00 ... 2024-06-18T21:28:00 Full Stack Developer (SOMA / south beach) Dento AI © craigslist - Map data © OpenStreetMap compensation: Market salary with equity. 100k+ based on experience, equity 0.25%-1.5% employment type: full-time job title: Full Stack Engineer Job Title: Full Stack Developer Location: San Francisco, CA (Hybrid) Job Type: Full-time About Us: DentoAI is an AI platform that automates staffing and administrative functions for the $150B dental industry. This platform automates patient onboarding, transcription, billing, scheduling, and more. An average clinic can likely reduce staff by 2-3 headcount, with an equivalent savings of $200-300K per year. DentoAI has a unique data moat, given its proprietary access to dental data and distribution channels, which no other competitor currently possesses. Amanda Cheng, the cofounder/CEO (Harvard doctorate), previously bootstrapped an orthodontic clinic network with 30+ locations and 400+ staff. She recently had a large exit to a PE firm. Amanda's cofounder Ryan Brandt and chief AI officer Arun Saigal are serial founders with deep AI experience in Langchain, AutoGPT, and cybersecurity. Job Overview: We are seeking a Full Stack Developer with strong expertise in Django and React. The ideal candidate will be comfortable working independently, communicating effectively, and being responsive on Slack during working hours. This role involves developing and implementing features across the backend and frontend, ensuring seamless integration and high-quality user experiences. While we prefer in-person collaboration in our San Francisco office, hybrid work arrangements are available. Key Responsibilities: - Develop and implement authentication and user management features, including HIPAA-compliant access and audit logging. - Develop and manage the organization model and user associations using Django REST Framework (DRF). - Design and implement CRUD operations for managing email types and tracking email statistics. - Build and integrate frontend components using React, ensuring seamless interaction with backend APIs. - Design and implement UI components for displaying email statistics, time savings, and other metrics on a dashboard. - Develop a guided setup process and onboarding flow for new users, ensuring a smooth user experience. - Collaborate with the design team to create and implement user-friendly interfaces. Preferred Skills and Experience: - Backend Development: - Proficiency in Django and Django REST Framework (DRF). - Experience with implementing OAuth2 authentication. - Knowledge of developing and managing databases using SQL. - Familiarity with creating and managing API endpoints. - Frontend Development: - Expertise in React and modern JavaScript frameworks. - Experience with frontend design and UI/UX principles. - Ability to integrate frontend components with backend APIs. - Familiarity with state management libraries (e.g., Redux). - DevOps and Security: - Experience with setting up and maintaining logging frameworks. - Knowledge of secure storage and retention of logs. - Understanding of encryption, access control, and secure data handling. - Email Automation: - Experience with developing webhooks - Familiarity with creating and publishing add-ons for email clients. - Knowledge of email statistics tracking and management. - Collaboration and Communication: - Excellent communication skills in English. - Experience working with teams. - Responsiveness and reliability on Slack during working hours. - Other Skills: - Ability to work independently and manage time effectively. - Willingness to move quickly and adapt to changing requirements. - Experience with HIPAA compliance is a plus but not required. - Experience with test coverage and using testing frameworks (e.g., pytest for Django, React Testing Library). Tech Stack: - Django, Django REST Framework (DRF) - React - OAuth2 for authentication - Logging frameworks - Email clients and add-ons - SQS for message queuing Application Process: Candidates must pass a code screen and a culture fit screen. Experience working with teams in the US and proficiency in English are essential. Principals only. Recruiters, please don't contact this job poster. post id: 7758222873 posted: about 7 hours ago ? best of [?]
*/	
///<summary>
///	2024-06-19T08:04:00 You have not granted the same as I... You have granted similar as I.
///		Rate URIs by soundex, like, Internet Country Code Top Level Domain (ccTLD), domain name, directory or file extension, argument? Issue a select query and compare the 1st column, URI.
///	2024-06-21T13:43:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouHaveNotGrantedTheSameAsI_YouHaveGrantedSimilarAsIWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	word
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryStatement,
				word
			),	
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
	}	

	public const string QueryStatement = @"
	SELECT
		URI,
		DIFFERENCE('{0}', URI) / 4 SoundexDifference,
		IIF(CHARINDEX('{0}', URI) = 0, 0, 1) CHARINDEXComparison,
		DIFFERENCE('{0}', URI) / 4 
		+	IIF(CHARINDEX('{0}', URI) = 0, 0, 1)
		Ranked
	FROM
		URI..MyURI
	WHERE
	(		
		DIFFERENCE('{0}', URI) / 4 
		+	IIF(CHARINDEX('{0}', URI) = 0, 0, 1)
	) >	0
	ORDER BY
		Ranked DESC, 
		URI
	";
}


