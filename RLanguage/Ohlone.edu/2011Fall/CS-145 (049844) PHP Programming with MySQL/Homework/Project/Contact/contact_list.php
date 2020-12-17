<?php
	require('../model/database.php');
	require_once('../model/contact_db.php');
	$contacts = get_contacts();
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
		<script type="text/javascript">
			var ContactViewSource = "contact_view.php?contactID=";
			function iframeSource(contactID)
			{
				//if (contactID == "" || contactID == null) { contactID = 1; }
				document.getElementById("contactView").src=ContactViewSource + contactID;
			}
		</script>
        <title>Contact List</title>
        <link rel="stylesheet" type="text/css" href="main.css"/>
    </head>
    <body>
        <div id="page">
            <div id="header">
                <h1>Contact</h1>
            </div>

            <form method="post" id="contact_list" class="aligned">
				<select id="contactList" size="20" style="float:left;" 
					onchange="iframeSource(this.value);">
					<?php
						foreach ($contacts as $contact)
						{
							$contactID = $contact['ContactID'];
							$name = $contact['FirstName'] . ' ' . $contact['LastName'];
							echo "<option value='$contactID'>$name</option>";
						}
					?>	
				</select>
				<iframe id="contactView" src="contact_view.php" style="float:left;" height="500" width="70%">
					<p>Your browser does not support iframes.</p>
				</iframe>
				<br style="clear:both;" />
            </form>
                             
            </div><!-- end main -->
        </div><!-- end page -->
    </body>
</html>
