<?php
// Get IDs
$category_id = $_GET['category_id'];

// Delete the product from the database
require_once('database.php');
$query = "DELETE FROM categories
          WHERE categoryID = '$category_id'";
$db->exec($query);

// display the Product List page
//include('category_list.php');
header( 'Location: category_list.php' ) ;
echo $category_id;
?>