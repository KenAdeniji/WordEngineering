<%@ WebService Language="C#" Class="UntilAmericaComeToItsForeigners_IfYouKnowYourPartAsPeopleYouWillKnowYourFactAsDeedWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2022-01-19T14:44:00 Created.	https://stackoverflow.com/questions/64836985/how-to-get-the-number-of-child-nodes-in-a-tree-in-sql
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class UntilAmericaComeToItsForeigners_IfYouKnowYourPartAsPeopleYouWillKnowYourFactAsDeedWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
with cte as (
      select FullName, ParentID, AdewoleOmotoshoEbenezerAdenijiID
      from AdewoleOmotoshoEbenezerAdeniji AS ParentTree
      union all
      select cte.FullName, cte.ParentID, ChildTree.AdewoleOmotoshoEbenezerAdenijiID
      from cte join
           AdewoleOmotoshoEbenezerAdeniji AS ChildTree
           on ChildTree.ParentID = cte.AdewoleOmotoshoEbenezerAdenijiID
    )
select FullName, ParentID, count(*) - 1 AS ChildrenCount 
from cte
group by FullName, ParentID;
";	
}
