<?php
$url = $_GET["url"];
$service = $_GET["service"];
  echo "test";
if($service == "googl"){
  
}

if($service == "isgd"){
  $shortener = "https://is.gd/create.php?format=simple&url=".$url;
  $read = fopen($shortener, 'r');
  while (!feof($read)) {
  $shorturl = fgets($read); 
}
fclose($read);
  echo $shorturl;
}

if($service == "vgd){
  $shortener = "https://v.gd/create.php?format=simple&url=".$url;
  $read = fopen($shortener, 'r');
  while (!feof($read)) {
  $shorturl = fgets($read); 
}
fclose($read);
  echo $shorturl;
}
?>
