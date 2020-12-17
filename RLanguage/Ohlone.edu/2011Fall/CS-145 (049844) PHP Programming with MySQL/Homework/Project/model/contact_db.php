<?php

function refreshContact
(
	$task,
	$contactID,
	$dated,
	$firstName,
	$lastName,
	$nickName,
	$birthday,
	$note,
	
	$homeAddress,
	$homeCity,
	$homeState,
	$homePostCode,
	$homeCountry,
	
	$company,
	
	$workAddress,
	$workCity,
	$workState,
	$workPostCode,
	$workCountry,

	$personalEmail,
	$workEmail,
	$otherEmail,
	$preferredEmail,

	$homePhone,
	$mobilePhone,
	$workPhone,
	$pager,
	$fax,
	$otherPhone,
	
	$website
) 
{
    global $db;
	
	if ($birthday == "") {$birthday = null;}
	
	try {
	
		$stmt = $db->prepare("CALL RefreshContact(? ,?,?,?,?,?,?,?,? ,?,?,?,?,? ,? ,?,?,?,?,? ,?,?,?,? ,?,?,?,?,?,? ,?)");

		$stmt->bindParam(1, $task, PDO::PARAM_STR, 6);
		
		//$stmt->bindParam(2, $contactID, PDO::PARAM_INT|PDO::PARAM_INPUT_OUTPUT, 11); 
		$stmt->bindParam(2, $contactID, PDO::PARAM_INT, 11); 		
		$stmt->bindParam(3, $dated, PDO::PARAM_STR);
		$stmt->bindParam(4, $_SESSION["loginId"], PDO::PARAM_INT, 11); //$userId
		$stmt->bindParam(5, $firstName, PDO::PARAM_STR, 50);
		$stmt->bindParam(6, $lastName, PDO::PARAM_STR, 50);
		$stmt->bindParam(7, $nickName, PDO::PARAM_STR, 50);
		$stmt->bindParam(8, $birthday, PDO::PARAM_STR);
		$stmt->bindParam(9, $note, PDO::PARAM_STR, 50000);

		$stmt->bindParam(10, $homeAddress, PDO::PARAM_STR, 200);
		$stmt->bindParam(11, $homeCity, PDO::PARAM_STR, 100);
		$stmt->bindParam(12, $homeState, PDO::PARAM_STR, 100);
		$stmt->bindParam(13, $homePostCode, PDO::PARAM_STR, 50);
		$stmt->bindParam(14, $homeCountry, PDO::PARAM_STR, 100);
		
		$stmt->bindParam(15, $company, PDO::PARAM_STR, 100);
		
		$stmt->bindParam(16, $workAddress, PDO::PARAM_STR, 200);
		$stmt->bindParam(17, $workCity, PDO::PARAM_STR, 100);
		$stmt->bindParam(18, $workState, PDO::PARAM_STR, 100);
		$stmt->bindParam(19, $workPostCode, PDO::PARAM_STR, 50);
		$stmt->bindParam(20, $workCountry, PDO::PARAM_STR, 100);
		
		$stmt->bindParam(21, $personalEmail, PDO::PARAM_STR, 100);
		$stmt->bindParam(22, $workEmail, PDO::PARAM_STR, 100);
		$stmt->bindParam(23, $otherEmail, PDO::PARAM_STR, 100);
		$stmt->bindParam(24, $preferredEmailID, PDO::PARAM_INT, 2);

		$stmt->bindParam(25, $homePhone, PDO::PARAM_STR, 100);
		$stmt->bindParam(26, $mobilePhone, PDO::PARAM_STR, 100);
		$stmt->bindParam(27, $workPhone, PDO::PARAM_STR, 100);
		$stmt->bindParam(28, $pager, PDO::PARAM_STR, 100);
		$stmt->bindParam(29, $fax, PDO::PARAM_STR, 100);
		$stmt->bindParam(30, $otherPhone, PDO::PARAM_STR, 100);
		
		$stmt->bindParam(31, $website, PDO::PARAM_STR, 300);
		
		$passed = $stmt->execute();
		
		if($passed)
		{
			//echo "Contact ID: $contactID ";
		} 
		else 
		{
			echo "failed";
			
			echo "\nPDOStatement::errorInfo():\n";
			$arr = $stmt->errorInfo();
			print_r($arr);
			
		}
	}
	catch (PDOException $e) {
        $error_message = $e->getMessage();
        include('../errors/database_error.php');
        exit();
    }
	
	catch (Exception $e) {
        $error_message = $e->getMessage();
        include('../errors/database_error.php');
        exit();
    }
}

function get_contacts() {
    global $db;
    $query = 'SELECT * FROM Contact ORDER BY FirstName, Lastname, ContactID';
    $contacts = $db->query($query);
    return $contacts;
}

function get_contact($contactID) {
    global $db;
    $query = "SELECT * FROM Contact WHERE ContactID = $contactID";
    $contacts = $db->query($query);
    $contact = $contacts->fetch();
    return $contact;
}

function get_viewcontact($contactID) {
    global $db;
    $query = "SELECT * FROM ViewContact WHERE Contact_ContactID = $contactID";
    $contacts = $db->query($query);
    $contact = $contacts->fetch();
    return $contact;
}

function delete_contact($contactID) {
    global $db;
    $query = "DELETE FROM Contact
              WHERE contactID = '$contactID'";
    $db->exec($query);
}
?>
