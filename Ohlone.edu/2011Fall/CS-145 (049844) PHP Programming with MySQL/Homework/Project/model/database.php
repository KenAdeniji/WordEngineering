<?php
    $dsn = 'mysql:host=localhost;dbname=contact';
    $username = 'mgs_user';
    $password = 'pa55w0rd';

    try {
        $db = new PDO($dsn, $username, $password);
    } catch (PDOException $e) {
        $error_message = $e->getMessage();
        include('../errors/database_error.php');
        exit();
    }
?>