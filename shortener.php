<?php
$url = $_GET["url"];;
$service = $_GET["service"];
$msg = "Your shortened url is: ";

if($url == ""){
    $msg = "There was an error, you can't leave the url field blank.";
    $shortened = "";
}else{
    // Do nothing
}
if($service == "rebrandly"){
  $domain_data["fullName"] = "rebrand.ly";
  $post_data["destination"] = $url;
  $post_data["domain"] = $domain_data;
  //$post_data["slashtag"] = "A_NEW_SLASHTAG";
  //$post_data["title"] = "Rebrandly YouTube channel";
  $ch = curl_init("https://api.rebrandly.com/v1/links");
  curl_setopt($ch, CURLOPT_HTTPHEADER, array(
      "apikey: 210bd6f9826b42b9bc335e133195779a",
      "Content-Type: application/json"
  ));
  curl_setopt($ch, CURLOPT_POST, 1);
  curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
  curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($post_data));
  $result = curl_exec($ch);
  curl_close($ch);
  $response = json_decode($result, true);
  $shortened = $response["shortUrl"];
}elseif($service == "isgd"){
    $shortener = "https://is.gd/create.php?format=simple&url=$url";
    $shortened = file($shortener)[0];
}elseif($service == "tk"){
    $array = file("http://api.dot.tk/tweak/shorten?long=".$url);
    $shortened = $array[0];
}elseif($service == "vgd"){
    $shortener = "https://v.gd/create.php?format=simple&url=$url";
    $shortened = file($shortener)[0];
}else{

}
?>

<html>
	<head>
	<title>Any Shortener</title>
	<link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Lato" />
		<style>
		.txt,p { 
		font-family: Lato; 
                }
		a{
        text-decoration: none;
		}
		</style>
	</head>
	<body>
	<center>
	<h1 class="txt">Any Shortener</h1>
	<br><br>
	<p><?php echo $msg; ?> <a href="<?php echo $shortened; ?>" target="_blank"><?php echo $shortened; ?></a></p>
        <?php 
    if($service == "tk"){
        echo "<br><br><p>Your .tk domain will work in a few seconds...</p>";
    }else{
    }
    ?>
	<br><br><a href="https://themagiulio.github.io/AnyShortener/"><button>Shorten another url</button></a><br><br>
	<p>Any Shortener uses:</p>
	<p><a href="https://is.gd/apishorteningreference.php" target="_blank">is.gd's apis</a></p>
	<p><a href="https://v.gd/apishorteningreference.php" target="_blank">v.gd's apis</a></p>
    <p><a href="https://developers.rebrandly.com/docs" target="_blank">rebrandly's apis</a></p>
    <p><a href="http://my.dot.tk/tweak/?show=technical" target="_blank">dot.tk's apis</a></p>
	<br><br>
	<p>&copy; 2019 <a href="https://giulio.top" target="_blank">Giulio De Matteis</a></p>
	</center>
	</body>
</html>
