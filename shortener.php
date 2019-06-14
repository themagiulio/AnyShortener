<?php
$url = $_GET["url"];
$service = $_GET["service"];

if($service == "googl"){
  
}elseif($service == "isgd"){
  $shortener = "https://is.gd/create.php?format=simple&url=".$longUrl;
  $reader = fopen($shortener, 'r');
while (!feof($fr)) {
    $row = fgets($reader); 
}
fclose($reader);
  echo $row;
}elseif($service == "vgd"){
  
  
}else{
 echo "There was an error."; 
}

?>
