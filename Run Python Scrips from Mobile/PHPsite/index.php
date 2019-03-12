<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<?php
if (isset($_GET['Name'])){
	$mName = $_GET['Name'];
	echo shell_exec('python H:\Arbeid\Fritid\Pythonfiles\CNN.py '.$mName); /* Python command and sys.args at end*/
}

	
?>


</head>
<body>
</body>
</html>
