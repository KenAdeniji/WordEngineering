<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Contact Add</title>
        <link rel="stylesheet" type="text/css" href="main.css"/>
    </head>
    <body>
        <div id="page">
            <div id="header">
                <h1>Contact</h1>
            </div>
            <div id="main">

            <h1>Add</h1>
            
            <form action="refreshContact.php" method="post" id="contact_insert" class="aligned">
				<h2>Contact Details</h2>
				<input type="hidden" name="task" value="Insert" />
				<input type="hidden" name="contactID" value="<?php echo -1 ?>" />
				
				<input type="hidden" name="dated" value="<?php echo date('Y-m-d') ?>" />

                <label>First Name:</label>
                <input type="text" class="text" name="firstName" />
                <br />

                <label>Last Name:</label>
                <input type="text" class="text" name="lastName" />
                <br />

                <label>Nick Name:</label>
                <input type="text" class="text" name="nickName" />
                <br />
				
				<h2>Personal Information</h2>
                <label>Personal e-mail:</label>
                <input type="text" class="text" name="personalEmail" />
                <br />
				
                <label>Home phone:</label>
                <input type="text" class="text" name="homePhone" />
                <br />

                <label>Mobile phone:</label>
                <input type="text" class="text" name="mobilePhone" />
                <br />

                <label>Home address:</label>
                <input type="text" class="text" name="homeAddress" />
                <br />

                <label>City:</label>
                <input type="text" class="text" name="homeCity" />
                <br />

                <label>State:</label>
                <input type="text" class="text" name="homeState" />
                <br />

                <label>ZIP/Postal code:</label>
                <input type="text" class="text" name="homePostCode" />
                <br />
				
                <label>Country:</label>
                <input type="text" class="text" name="homeCountry" />
                <br />

				<h2>Business Information</h2>
                <label>Company:</label>
                <input type="text" class="text" name="company" />
                <br />

				<label>Work e-mail</label>
				<input type="text" class="text" name="workEmail" />
				<br />

				<label>Work phone</label>
				<input type="text" class="text" name="workPhone" />
				<br />

				<label>Pager</label>
				<input type="text" class="text" name="pager" />
				<br />
				
				<label>Fax</label>
				<input type="text" class="text" name="fax" />
				<br />
				
                <label>Work address:</label>
                <input type="text" class="text" name="workAddress" />
                <br />

                <label>City:</label>
                <input type="text" class="text" name="workCity" />
                <br />

                <label>State:</label>
                <input type="text" class="text" name="workState" />
                <br />

                <label>ZIP/Postal code:</label>
                <input type="text" class="text" name="workPostCode" />
                <br />
				
                <label>Country:</label>
                <input type="text" class="text" name="workCountry" />
                <br />
				
				<h2>Other Information</h2>
                <label>Other e-mail:</label>
                <input type="text" class="text" name="otherEmail" />
                <br />
				
                <label>Preferred e-mail:</label>
				<select name="preferredEmail">
					<option value="1">Personal</option>
					<option value="2">Work</option>
					<option value="3">IM</option>
					<option value="4">Other</option>
				</select>
                <br />

                <label>Other phone:</label>
                <input type="text" class="text" name="otherPhone" />
                <br />
				
                <label>Website:</label>
                <input type="text" class="text" name="website" />
                <br />

				<label>Birthday:</label>
				<input type="date" class="text" name="birthday" />
				<br />
				
				<label>Note:</label>
				<textarea name="note" rows="5" cols="35" class="text">
				</textarea>
				<br />

                <label>&nbsp;</label>
                <input type="submit" />
            </form>
                             
            </div><!-- end main -->
        </div><!-- end page -->
    </body>
</html>