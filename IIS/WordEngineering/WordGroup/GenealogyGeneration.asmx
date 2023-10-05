 <%@ WebService Language="C#" Class="GenealogyGenerationWebService" %>
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
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2019-06-03	Created.	EssentialSQL.com/recursive-ctes-explained
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GenealogyGenerationWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			SelectQuery,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SelectQuery = @"
WITH cte_FamilyTree (id, text, generation, parentID)
AS  
(
	SELECT	lineage.GenealogyGenerationID,
            lineage.BibleWord,
            1,
            NULL
     FROM   WordEngineering..GenealogyGeneration AS lineage
	 WHERE	ParentID IS NULL
     UNION ALL
     SELECT lineage.GenealogyGenerationID AS id,
			lineage.BibleWord,
            cte_FamilyTree.generation + 1,
            cte_FamilyTree.id
     FROM   cte_FamilyTree
     INNER JOIN WordEngineering..GenealogyGeneration AS lineage
		ON	lineage.ParentId = cte_FamilyTree.id
    )
SELECT   id, ISNULL(CONVERT(VARCHAR, ParentId), '#') AS parent, text
FROM     cte_FamilyTree
ORDER BY parent, id
";	
}
