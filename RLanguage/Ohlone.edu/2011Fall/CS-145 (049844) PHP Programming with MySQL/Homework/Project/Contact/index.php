<?php
require('../model/database.php');

if (!isset($_SESSION["email"]) == false) {
	$login_message = "Please kindly login";
    require_once('login.php');
}

if (isset($_POST['action'])) {
    $action = $_POST['action'];
} else if (isset($_GET['action'])) {
    $action = $_GET['action'];
} else {
    $action = 'list_contacts';
}

if ($action == 'list_contacts') {
    include('contact_list.php');
}
?>