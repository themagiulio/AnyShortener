<?php
$url = $_GET["url"];
$service = $_GET["service"];

// Check if $url is an url string
if ((!(substr($url, 0, 7) == 'http://')) && (!(substr($url, 0, 8) == 'https://'))) {
    $url = 'http://' . $url;
}

// Api Keys
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

// QR Code
$qrcode = "<img src='https://chart.googleapis.com/chart?chs=200x200&cht=qr&chl=".$url."'/>";

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
}elseif($service == "vgd"){
    $shortener = "https://v.gd/create.php?format=simple&url=".$url;
    $shortened = file($shortener)[0];
}elseif($service == "bitly"){
    $long_url = urlencode($url);
    $bitly_response = json_decode(file_get_contents("http://api.bit.ly/v3/shorten?login={$bitly_login}&apiKey={$bitly_apikey}&longUrl={$long_url}&format=json"));
    $shortened = $bitly_response->data->url;
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
	  $shortened = "Error";
}

// $shortened is the shortened urlencode
// $qrcode is the qrcode that redirects on $url
?>
