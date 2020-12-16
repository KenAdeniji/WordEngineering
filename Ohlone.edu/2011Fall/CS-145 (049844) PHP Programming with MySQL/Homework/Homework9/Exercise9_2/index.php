<?php
if (isset($_POST['action'])) {
    $action =  $_POST['action'];
} else {
    $action =  'start_app';
}

switch ($action) {
    case 'start_app':
        $number1 = 78;
        $number2 = -105.33;
        $number3 = 0.0049;

        $message = 'Enter some numbers and click on the Submit button.';
        break;
    case 'process_data':
        $number1 = $_POST['number1'];
        $number2 = $_POST['number2'];
        $number3 = $_POST['number3'];

        // make sure the user enters three numbers
		$number1 = trim($number1);
		if (strlen($number1) == 0)
		{
			echo "Please enter Number 1.";
			return;
		}
		
		$number2 = trim($number2);
		if (strlen($number2) == 0)
		{
			echo "Please enter Number 2.";
			return;
		}
		
		$number3 = trim($number3);
		if (strlen($number3) == 0)
		{
			echo "Please enter Number 3.";
			return;
		}
        // make sure the numbers are valid
		$number1 = floatval($number1);
		$number2 = floatval($number2);
		$number3 = floatval($number3);
		
		if ($number1 < 78)
		{
			echo "Number 1 is less than 78";
			return;
		}

		if ($number2 < -105.33)
		{
			echo "Number 2 is less than -105.33";
			return;
		}

		if ($number3 < .0049)
		{
			echo "Number 3 is less than .0049";
			return;
		}

        // get the ceiling and floor for $number2
		$number2_ceil = ceil($number2);
		$number2_floor = floor($number2);
        // round $number3 to 3 decimal places
		$number3_rounded = round($number3, 3);
        // get the max and min values of all three numbers
		$min = min($number1, $number2, $number3);
		$max = max($number1, $number2, $number3);
        // generate a random integer between 1 and 100
		$random = mt_rand(1, 100);
        // format the message
        $message =
            "Number 1: $number1\n" .
            "Number 2: $number2\n" .
            "Number 3: $number3\n" .
            "\n" .
            "Number 2 ceiling: $number2_ceil\n" .
            "Number 2 floor: $number2_floor\n" .
            "Number 3 rounded: $number3_rounded\n" .
            "\n" .
            "Min: $min\n" .
            "Max: $max\n" .
            "\n" .
            "Random: $random\n";
        break;
}
include 'number_tester.php';
?>