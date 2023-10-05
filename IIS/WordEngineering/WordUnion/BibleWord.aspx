<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BibleWord.aspx.cs" Inherits="BibleWordPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Bible Word</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:TextBox 
            ID="question"
            runat="server"
			columns="50"
        />
	
		<select id="andOrPhrase" runat="server">
		  <option value="and">And</option>		
		  <option value="or">Or</option>
		  <option value="phrase">Phrase</option>
		</select>

		<label for="wholeWords">Whole Words
			<checkbox id="wholeWords1" runat="server" />
			<input type=checkbox id="wholeWords" checked runat="server"/>
		</label>	

		<select id="limit" runat="server" multiple>
			<option value="all">All</option>		
			<option value="old">Old Testament</option>
			<option value="new">New Testament</option>
			<option value="pentateuch">Pentateuch</option>
			<option value="major prophets">Major Prophets</option>
			<option value="minor prophets">Minor Prophets</option>
			<option value="gospel">Gospel</option>
		</select>

        <asp:TextBox id="limitChosen" runat="server" style="display: none;" />
		
		<asp:Button
            ID="submit"
			runat="server"
			OnClick="Submit_Click"
			Text="Submit"
			OnClientClick="determineLimit()"
		/>
		<br />
		<label for="versesCount">Verse(s) count:</label>
		<label id="versesCount"></label>
		<br />
		<label for="collate">Scripture reference concatenate visible:</label>		
		<input type="checkbox" id="collate" onclick="combine();"/>
 		<br />
	</div>	
	<div align="center">	
		<asp:Literal
			id="sacredText" 
			runat="server"
		/>
	</div>	
	<div
		id="scriptureReferenceCollate"
		align="center"
	>
    </form>

	<script>
		function combine()
		{
			var collate = document.getElementById('collate').checked;
			var scriptureReferenceCollate = document.getElementById('scriptureReferenceCollate');
			
			var concatenate="";
					
			if (collate === true)
			{
				var table=document.getElementById("resultSet");
				var r=0;
				
				while(row=table.rows[r++])
				{
					var scriptureReference = row.cells[0].innerHTML;
					if (concatenate != "")
					{
						concatenate += ", ";
					}
					concatenate += scriptureReference;
				}
				scriptureReferenceCollate.innerHTML = concatenate;
				scriptureReferenceCollate.style.visibility='visible';
			}
			else
			{
				scriptureReferenceCollate.innerHTML = "";
				scriptureReferenceCollate.style.visibility='hidden';
			}
		}
		
		function determineLimit() {
			var selected = [];
			var checkboxArray = document.getElementById('limit');
			for (var i = 0; i < checkboxArray.length; i++) {
			  if (checkboxArray.options[i].selected == true) {
				selected.push(checkboxArray[i].value);
			  }
			}
			
			var limitChosen = document.getElementById('limitChosen');
			limitChosen.value = selected.join();
		}
		
		function pageLoad()
		{
			var versesCount = document.getElementById('versesCount');
			var resultSet = document.getElementById('resultSet');
			if (resultSet)
			{
				versesCount.innerHTML = resultSet.rows.length;
			}
			combine();	
		}
		
		window.addEventListener("load", pageLoad, false);   
	</script>
</body>
</html>
