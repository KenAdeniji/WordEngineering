<?php
	require('../model/database.php');
	require_once('../model/contact_db.php');

	$contactID = 1;
	parse_str($_SERVER['QUERY_STRING']);
	$contact = get_viewcontact($contactID);	
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Contact View</title>
        <link rel="stylesheet" type="text/css" href="main.css"/>
    </head>
    <body onload="load()">
        <div id="page">
			<a href="./contact_add.php">Add</a>
			<div id="header">
                <h1>Contact</h1>
            </div>
            <div id="main">

            <h1>View</h1>
            
            <form action="refreshContact.php" method="post" id="contact_view" class="aligned">
				<h2>Contact Details</h2>
				
				<input type="hidden" name="task" value="Update" />
				<input type="hidden" name="contactID" value="<?php echo $contact['Contact_ContactID'] ?>" />
				
				<input type="hidden" name="dated" value="<?php echo date('Y-m-d') ?>" />
				
                <label>First Name:</label>
                <input type="text" class="text" name="firstName" value="<?php echo $contact['FirstName'] ?>" />
                <br />

                <label>Last Name:</label>
                <input type="text" class="text" name="lastName" value="<?php echo $contact['LastName'] ?>" />
                <br />

                <label>Nick Name:</label>
                <input type="text" class="text" name="nickName" value="<?php echo $contact['NickName'] ?>" />
                <br />
				
				<h2>Personal Information</h2>
                <label>Personal e-mail:</label>
                <input type="text" class="text" name="personalEmail" value="<?php echo $contact['PersonalEmail'] ?>" />
                <br />
				
                <label>Home phone:</label>
                <input type="text" class="text" name="homePhone" value="<?php echo $contact['HomePhone'] ?>" />
                <br />

                <label>Mobile phone:</label>
                <input type="text" class="text" name="mobilePhone" value="<?php echo $contact['MobilePhone'] ?>" />
                <br />

                <label>Home address:</label>
                <input type="text" class="text" name="homeAddress" value="<?php echo $contact['HomeAddress'] ?>"/>
                <br />

                <label>City:</label>
                <input type="text" class="text" name="homeCity" value="<?php echo $contact['HomeCity'] ?>"/>
                <br />

                <label>State:</label>
                <input type="text" class="text" name="homeState" value="<?php echo $contact['HomeState'] ?>"/>
                <br />

                <label>ZIP/Postal code:</label>
                <input type="text" class="text" name="homePostCode" value="<?php echo $contact['HomePostCode'] ?>"/>
                <br />
				
                <label>Country:</label>
                <input type="text" class="text" name="homeCountry" value="<?php echo $contact['HomeCountry'] ?>"/>
                <br />

				<h2>Business Information</h2>
                <label>Company:</label>
                <input type="text" class="text" name="company" value="<?php echo $contact['Company'] ?>"/>
                <br />

				<label>Work e-mail</label>
				<input type="text" class="text" name="workEmail" value="<?php echo $contact['WorkEmail'] ?>" />
				<br />

				<label>Work phone</label>
				<input type="text" class="text" name="workPhone" value="<?php echo $contact['WorkPhone'] ?>" />
				<br />

				<label>Pager</label>
				<input type="text" class="text" name="pager"  value="<?php echo $contact['Pager'] ?>" />
				<br />
				
				<label>Fax</label>
				<input type="text" class="text" name="fax" value="<?php echo $contact['Fax'] ?>" />
				<br />
				
                <label>Work address:</label>
                <input type="text" class="text" name="workAddress" value="<?php echo $contact['WorkAddress'] ?>"/>
                <br />

                <label>City:</label>
                <input type="text" class="text" name="workCity" value="<?php echo $contact['WorkCity'] ?>"/>
                <br />

                <label>State:</label>
                <input type="text" class="text" name="workState" value="<?php echo $contact['WorkState'] ?>"/>
                <br />

                <label>ZIP/Postal code:</label>
                <input type="text" class="text" name="workPostCode" value="<?php echo $contact['WorkPostCode'] ?>"/>
                <br />
				
                <label>Country:</label>
                <input type="text" class="text" name="workCountry" value="<?php echo $contact['WorkCountry'] ?>"/>
                <br />
				
				<h2>Other Information</h2>
                <label>Other e-mail:</label>
                <input type="text" class="text" name="otherEmail" value="<?php echo $contact['OtherEmail'] ?>" />
                <br />
				
                <label>Preferred e-mail:</label>
				<select name="preferredEmail" value="<?php echo $contact['PreferredEmailID'] ?>" />
					<option value="1">Personal</option>
					<option value="2">Work</option>
					<option value="3">IM</option>
					<option value="4">Other</option>
				</select>
                <br />

                <label>Other phone:</label>
                <input type="text" class="text" name="otherPhone" value="<?php echo $contact['OtherPhone'] ?>" />
                <br />
				
                <label>Website:</label>
                <input type="text" class="text" name="website" value="<?php echo $contact['Website'] ?>" />
                <br />

				<label>Birthday:</label>
				<input type="date" class="text" name="birthday" value="<?php echo $contact['Birthday'] ?>" />
				<br />
				
				<label>Note:</label>
				<textarea name="note" rows="5" cols="35" class="text" />
					<?php echo $contact['Note'] ?>
				</textarea>
				<br />

                <label>&nbsp;</label>
                <input type="submit" />
            </form>
                             
            </div><!-- end main -->
        </div><!-- end page -->
    </body>
</html>
