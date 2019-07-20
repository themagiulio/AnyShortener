<?php
$url = $_GET["url"];
if ((!(substr($url, 0, 7) == 'http://')) && (!(substr($url, 0, 8) == 'https://'))) {
    $url = 'http://' . $url;
}
$service = $_GET["service"];
$msg = "Your shortened url is: ";

// Apis
$rebrandlyapi = "";
$bitly_login = "";
$bitly_apikey = "";
$seventhapi = "";
$cuttlyapi = "";
$shortestapi = "";

// Check if url field is blank
if($url == ""){
    // Url field is blank, display an error
    $msg = "There was an error, you can't leave the url field blank.";
    $shortened = "";
}else{
    // Do nothing
}

// Services
if($service == "rebrandly"){
    $domain_data["fullName"] = "rebrand.ly";
    $post_data["destination"] = $url;
    $post_data["domain"] = $domain_data;
    //$post_data["slashtag"] = "A_NEW_SLASHTAG";
    //$post_data["title"] = "Rebrandly YouTube channel";
    $ch = curl_init("https://api.rebrandly.com/v1/links");
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(
      "apikey: $rebrandlyapi",
      "Content-Type: application/json"
    ));
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($post_data));
    $result = curl_exec($ch);
    curl_close($ch);
    $response = json_decode($result, true);
    $shortened = "https://".$response["shortUrl"];
}elseif($service == "isgd"){
    $shortener = "https://is.gd/create.php?format=simple&url=$url";
    $shortened = file($shortener)[0];
}elseif($service == "tk"){
    $array = file("http://api.dot.tk/tweak/shorten?long=".$url);
    $shortened = $array[0];
}elseif($service == "vgd"){
    $shortener = "https://v.gd/create.php?format=simple&url=".$url;
    $shortened = file($shortener)[0];
}elseif($service == "bitly"){
    $long_url = urlencode($url);
    $bitly_response = json_decode(file_get_contents("http://api.bit.ly/v3/shorten?login={$bitly_login}&apiKey={$bitly_apikey}&longUrl={$long_url}&format=json"));
    $shortened = $bitly_response->data->url;
}elseif($service == "7th"){
    $urlencoded = base64_encode($url);
    $shortener = "http://www.7th.it/auth.php?apikey=".$seventhapi."&link=$urlencoded";
    $shortened = file($shortener)[0];
}elseif($service == "cuttly"){
    $json = file_get_contents("https://cutt.ly/api/api.php?key=".$cuttlyapi."&short=$url");
    $data = json_decode ($json, true);
    $shortened = $data["url"]["shortLink"];
}elseif($service == "shortest"){
    $curl_url = "https://api.shorte.st/s/".$shortestapi."/".$url;
    $ch = curl_init(); 
    curl_setopt($ch, CURLOPT_URL, $curl_url); 
    curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false); 
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true); 
    $result = curl_exec($ch); 
    curl_close($ch); 
    $array = json_decode($result);
    $shortened = $array->shortenedUrl;
}else{
	// Display an error
    $msg = "Error.";
	$shortened = "";
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
	<p><a href="https://dev.bitly.com/" target="_blank">bitly's apis</a></p>
        <p><a href="https://developers.rebrandly.com/docs" target="_blank">rebrandly's apis</a></p>
        <p><a href="http://7th.it/static.php?api" target="_blank">7th's apis</a></p>
        <p><a href="https://cutt.ly/cuttly-api" target="_blank">cuttly's apis</a></p>
	<p><a href="https://shorte.st" target="_blank">shortest's apis</a></p>
	<p><a href="http://my.dot.tk/tweak/?show=technical" target="_blank">dot.tk's apis</a></p>
	<br><br>
    <a class="github-button" href="https://github.com/themagiulio" data-size="large" aria-label="Follow @themagiulio on GitHub">Follow @themagiulio</a>
    <a class="github-button" href="https://github.com/themagiulio/AnyShortener/fork" data-icon="octicon-repo-forked" data-size="large" aria-label="Fork themagiulio/AnyShortener on GitHub">Fork</a>
    <a class="github-button" href="https://github.com/themagiulio/AnyShortener/archive/master.zip" data-icon="octicon-cloud-download" data-size="large" aria-label="Download themagiulio/AnyShortener on GitHub">Download</a>
	<p>&copy; 2019 <a href="https://giulio.top" target="_blank">Giulio De Matteis</a></p>
	</center>
	<script async defer src="https://buttons.github.io/buttons.js"></script>
	</body>
</html>
