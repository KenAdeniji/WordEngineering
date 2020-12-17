<?php
	require('../model/database.php');
	require_once('../model/contact_db.php');
	
	add_contact
	(
		$_POST["contactId"],
		$_POST["dated"],
		$_POST["userId"],
		$_POST["firstName"],
		$_POST["lastName"], 
		$_POST["nickName"],
		$_POST["birthday"],
		$_POST["note"],
		
		$_POST['homeAddress'],
		$_POST['homeCity'],
		$_POST['homeState'],
		$_POST['homePostCode'],
		$_POST['homeCountry'],
		
		$_POST['company'],
		
		$_POST['workAddress'],
		$_POST['workCity'],
		$_POST['workState'],
		$_POST['workPostCode'],
		$_POST['workCountry'],
		
		$_POST['personalEmail'],
		$_POST['workEmail'],
		$_POST['otherEmail'],
		$_POST['preferredEmail'],
		
		$_POST['homePhone'],
		$_POST['mobilePhone'],
		$_POST['workPhone'],
		$_POST['pager'],
		$_POST['fax'],
		$_POST['otherPhone'],
	
		$_POST['website']
	);

?>