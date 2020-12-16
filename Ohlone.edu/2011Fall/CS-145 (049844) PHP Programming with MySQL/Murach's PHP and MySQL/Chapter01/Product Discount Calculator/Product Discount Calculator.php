<?php
	//get the data from the form
	$product_description = $_POST['product_description'];
	$list_price = $_POST['list_price'];
	$discount_percent = $_POST['discount_percent'];
	
	//Calculate the discount
	$discount = $list_price * $discount_percent * .01;
	$discount_price = $list_price - $discount;
	
	//Apply currency formatting to the dollar and percent amounts
	$list_price_formatted = "$".number_format($list_price, 2);
	$discount_percent_formatted = $discount_percent."%";
	$discount_formatted = "$".number_format($discount, 2);
	$discount_price_formatted = "$".number_format($discount_price, 2);
?>

<html>
	<head>
		<title>Product Discount Calculator</title>
		<link rel="stylesheet" type="text/css" href="Product Discount Calculator.css" />
	</head>
	<body>
		<div id="content">
			<h1>Product Discount Calculator</h1>
			
			<label>Product Description:</label>
			<span><?php echo $product_description; ?></span><br/>

			<label>Standard Discount:</label>
			<span><?php echo $discount_percent_formatted; ?></span><br/>

			<label>Discount Amount:</label>
			<span><?php echo $discount_formatted; ?></span><br/>

			<label>Discount Price:</label>
			<span><?php echo $discount_price_formatted; ?></span><br/>
			
		</div>
	</body>
</html>	