<?php
	//namespace WordEngineering;
	define("BibleBook_Size", 66);
	const BibleBook_Size_Old_Testament = 39;
	
	class BibleBook
	{
		protected $commentary, $id, $testament, $title;
		protected static $bibleBooks = array();
		
		public function __construct($id, $title) {
			$this->id = $id;
			$this->testament($id);
			$this->title = $title;
			
			self::$bibleBooks[$id] = $this;
		}
		
		public function display() {
			foreach (self::$bibleBooks as $key => $value) {
				echo $value . "<br/>";
			}
			unset($value); // break the reference with the last element
		}

		public function generateTable() {
			echo "<table border='1'><tbody>";
			foreach (self::$bibleBooks as $key => $value) {
				echo "<tr><td>$value->id</td><td>$value->title</td><td>";
				echo "<input type=\"text\" name=\"commentary$value->id\" />";
				echo "</td></tr>";
			}
			unset($value); // break the reference with the last element
			echo "</tbody></table>";
		}
		
		protected function testament($id) {
			if ($id <= BibleBook_Size_Old_Testament) { $this->testament = "Old"; } else { $this->testament = "New"; }
		}
		
		public function __toString() {
			$toString = "BibleBook Id: " . $this->id . " | Testament: " . $this->testament . " | Title: " . $this->title;  
			return $toString;
		}
	}

	$bibleBooksCommentary = array();
	
	#checking if form has been submitted
	if (isset($_POST['submitted'])){
		#if yes (form is submitted) assign values from POST array to variables
		for ($index = 1; $index <= BibleBook_Size; ++$index)
		{
			$commentaryCurrent = $_POST['commentary'.index];
			$bibleBooksCommentary[index-1] = $commentaryCurrent;
		}
		#set cookies
		setcookie("bibleBooksCommentary[]", $bibleBooksCommentary);
	}
	
	#in case user has come for first time and cookies are not set then
	//if (!isset($_COOKIE[bibleBooksCommentary[]]) ){
		$_Genesis = new BibleBook(1, "Genesis");
		$_Exodus = new BibleBook(2, "Exodus");
		$_Leviticus = new BibleBook(3, "Leviticus");
		$_Numbers = new BibleBook(4, "Numbers");
		$_Deuteronomy = new BibleBook(5, "Deuteronomy");
		$_Joshua = new BibleBook(6, "Joshua");
		$_Judges = new BibleBook(7, "Judges");
		$_Ruth = new BibleBook(8, "Ruth");
		$_1Samuel = new BibleBook(9, "1 Samuel");
		$_2Samuel = new BibleBook(10, "2 Samuel");
		$_1Kings = new BibleBook(11, "1 Kings");
		$_2Kings = new BibleBook(12, "2 Kings");
		$_1Chronicles = new BibleBook(13, "1 Chronicles");
		$_2Chronicles = new BibleBook(14, "2 Chronicles");
		$_Ezra = new BibleBook(15, "Ezra");
		$_Nehemiah = new BibleBook(16, "Nehemiah");
		$_Esther = new BibleBook(17, "Esther");
		$_Job = new BibleBook(18, "Job");
		$_Psalms = new BibleBook(19, "Psalms");
		$_Proverbs = new BibleBook(20, "Proverbs");
		$_Ecclesiastes = new BibleBook(21, "Ecclesiastes");
		$_SongOfSolomon = new BibleBook(22, "Song of Solomon");
		$_Isaiah = new BibleBook(23, "Isaiah");
		$_Jeremiah = new BibleBook(24, "Jeremiah");
		$_Lamentations = new BibleBook(25, "Lamentations");
		$_Ezekiel = new BibleBook(26, "Ezekiel");
		$_Daniel = new BibleBook(27, "Daniel");
		$_Hosea = new BibleBook(28, "Hosea");
		$_Joel = new BibleBook(29, "Joel");
		$_Amos = new BibleBook(30, "Amos");
		$_Obadiah = new BibleBook(31, "Obadiah");
		$_Jonah = new BibleBook(32, "Jonah");
		$_Micah = new BibleBook(33, "Micah");
		$_Nahum = new BibleBook(34, "Nahum");
		$_Habakkuk = new BibleBook(35, "Habakkuk");
		$_Zephaniah = new BibleBook(36, "Zephaniah");
		$_Haggai = new BibleBook(37, "Haggai");
		$_Zechariah = new BibleBook(38, "Zechariah");
		$_Malachi = new BibleBook(39, "Malachi");

		$_Matthew = new BibleBook(40, "Matthew");
		$_Mark = new BibleBook(41, "Mark");
		$_Luke = new BibleBook(42, "Luke");
		$_John = new BibleBook(43, "John");
		$_Acts = new BibleBook(44, "Acts");
		$_Romans = new BibleBook(45, "Romans");
		$_1Corinthians = new BibleBook(46, "1 Corinthians");
		$_2Corinthians = new BibleBook(47, "2 Corinthians");
		$_Galatians = new BibleBook(48, "Galatians");
		$_Ephesians = new BibleBook(49, "Ephesians");
		$_Philippians = new BibleBook(50, "Philippians");
		$_Colossians = new BibleBook(51, "Colossians");
		$_1Thessalonians = new BibleBook(52, "1 Thessalonians");
		$_2Thessalonians = new BibleBook(53, "2 Thessalonians");
		$_1Timothy = new BibleBook(54, "1 Timothy");
		$_2Timothy = new BibleBook(55, "2 Timothy");
		$_Titus = new BibleBook(56, "Titus");
		$_Philemon = new BibleBook(57, "Philemon");
		$_Hebrews = new BibleBook(58, "Hebrews");
		$_James = new BibleBook(59, "James");
		$_1Peter = new BibleBook(60, "1 Peter");
		$_2Peter = new BibleBook(61, "2 Peter");
		$_1John = new BibleBook(62, "1 John");
		$_2John = new BibleBook(63, "2 John");
		$_3John = new BibleBook(64, "3 John");
		$_Jude = new BibleBook(65, "Jude");
		$_Revelation = new BibleBook(66, "Revelation");
	//}	
	#if cookies are set then use them
	/*
	else{
		$bibleBooksCommentary = $_COOKIE['bibleBooksCommentary[]'];
	}
	*/
?>

<!-- HTML Page-->
<html>
<body bgcolor="blue" text="yellow">
<!-- <body bgcolor="<?php echo blue ?>" text="<?php echo yellow ?>"> -->
<form action= "<?php echo $_SERVER['PHP_SELF']; ?>" method ="POST">
<?php BibleBook::generateTable(); ?>
<input type ="hidden" name="submitted" value="true"></br>
<input type="submit" value="remind">
</form>
</body>
</html>