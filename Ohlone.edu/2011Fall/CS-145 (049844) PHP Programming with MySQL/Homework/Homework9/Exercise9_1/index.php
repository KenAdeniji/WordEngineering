<?php
if (isset($_POST['action'])) {
    $action =  $_POST['action'];
} else {
    $action =  'start_app';
}

switch ($action) {
    case 'start_app':
        $message = 'Enter some data and click on the Submit button.';
        break;
    case 'process_data':
        $name = $_POST['name'];
        $email = $_POST['email'];
        $phone = $_POST['phone'];

        /*************************************************
         * validate and process the name
         ************************************************/
        // 1. make sure the user enters a name
        // 2. display the name with only the first letter capitalized
		
		$name = htmlspecialchars($name);
		
		$name = trim($name);
		$nameLength = strlen($name);
		if ($nameLength == 0)
		{
			echo "Please enter the name.";
			return;
		}	
		
		$spaceIndex = strpos($name, " ");
		
		$firstName = substr($name, 0, $spaceIndex);
		$firstName = ucfirst($firstName);
		
		$lastName = substr($name, $spaceIndex + 1);
		$lastName = ucfirst($lastName);
		
		/*************************************************
         * validate and process the email address
         ************************************************/
        // 1. make sure the user enters an email
        // 2. make sure the email address has at least one @ sign and one dot character

		$email = htmlspecialchars($email);
		
		$email = trim($email);
		$emailLength = strlen($email);
		if ($emailLength == 0)
		{
			echo "Please enter the e-mail.";
			return;
		}	
		
		$atIndex = strpos($email, "@");
		$dotIndex = strpos($email, ".");
		
		if ($atIndex < 0 || $dotIndex < 0)
		{
			echo "Please make sure that the e-mail address contains at least one @ sign and one dot character (.).";
			return;
		}
		
        /*************************************************
         * validate and process the phone number
         ************************************************/
        // 1. make sure the user enters at least seven digits, not including formatting characters
        // 2. format the phone number like this 123-4567 or this 123-456-7890
		
		$phone = htmlspecialchars($phone);
		
		$phone = trim($phone);
		$phoneLength = strlen($phone);
		if ($phoneLength == 0)
		{
			echo "Please enter the phone.";
			return;
		}	
		$phoneParse = "";
		for ($phoneIndex = 0; $phoneIndex < $phoneLength; ++$phoneIndex)
		{
			$phoneCurrentDigit = substr($phone, $phoneIndex, 1);
			if 
			(
				($phoneCurrentDigit >= '0' && $phoneCurrentDigit <= '9') ||
				($phoneCurrentDigit >= 'A' && $phoneCurrentDigit <= 'Z') ||
				($phoneCurrentDigit >= 'a' && $phoneCurrentDigit <= 'z')
			)
			{
				$phoneParse .= $phoneCurrentDigit;
			}
			else if (strpos("- ().", $phoneCurrentDigit) >= 0)
			{
				//Formatting characters.
			}			
			else
			{
				echo "Phone contains, invalid character, $phoneCurrentDigit";
				return;
			}		
		}
		
		$phoneParseLength = strlen($phoneParse);
		if ($phoneParseLength < 7)
		{
			echo "The phone number must contain at least seven digits, not including formatting characters such as dashes, spaces, and parenthesis.";
			return;
		}
		$phoneFormatted = "";
		if ($phoneParseLength == 7)
		{
			$phoneFormatted = substr($phoneParse, 0, 3) . '-' . substr($phoneParse, 3, 4);
		}
		else
		{
			$phoneFormatted = substr($phoneParse, 0, $phoneParseLength - 7) . '-' . substr($phoneParse, -7, 3) . '-' . substr($phoneParse, -4);
		}
        /*************************************************
         * Display the validation message
         ************************************************/
        $message = 	"This page is under construction.\n" .
					"Please write the code that process the data.";
		$message = 	"Hello $firstName,\n\n" .
					"Thank you for entering this data:\n\n" .
					"Name: $firstName $lastName\n" .
					"Email: $email\n" .
					"Phone: $phoneFormatted";
        break;
}
include 'string_tester.php';
?>