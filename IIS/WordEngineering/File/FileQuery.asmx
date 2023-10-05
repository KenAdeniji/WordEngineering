<%@ WebService Language="C#" Class="FileQueryWebService" %>

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

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2018-12-17	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FileQueryWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 		startFolder,
		String		filenameLike,
		String		searchTerm,
		bool		subdirectory,
		long		fileLengthBytesFrom,
		long		fileLengthBytesUntil,
		DateTime	datedCreatedFrom,
		DateTime	datedCreatedUntil,
		DateTime	datedLastWriteFrom,
		DateTime	datedLastWriteUntil
	)	
    {
		List<FileQueryHelper.FileInfoRecord> fileList = FileQueryHelper.Query
		(
			startFolder,
			filenameLike,
			searchTerm,
			subdirectory,
			fileLengthBytesFrom,
			fileLengthBytesUntil,
			datedCreatedFrom,
			datedCreatedUntil,
			datedLastWriteFrom,
			datedLastWriteUntil
		);
		string json = JsonConvert.SerializeObject(fileList, Formatting.Indented);
		return json;
	}
}
