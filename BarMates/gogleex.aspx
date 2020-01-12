<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gogleex.aspx.cs" Inherits="gogleex" %>

<!DOCTYPE html>
<html>
  <head>
    <title>Simple Map</title>
    <meta name="viewport" content="initial-scale=1.0">
    <meta charset="utf-8">
    <style>
    
      /* Optional: Makes the sample page fill the window. */
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
    </style>
  </head>
  <body>
    <script>        
        const url = 'https://api.foursquare.com/v2/venues/search?client_id=0FKKD0AE1ISLEO0VFRKGFEFMMHZWF21VRS14KQYHOYLQ4ZVA&client_secret=GJRRCIVBBXDZTYDPH4LHCP01JNXC4GNIZYSMXIHNL2A2ZOIB&ll=32.109333, 34.855499&categoryId= 4bf58dd8d48988d116941735&v=20191228';
        fetch(url)
            .then(function (data) {
                var jsonStr = JSON.stringify(data.json);
                document.body.innerHTML = jsonStr;
                console.log(data);
            })
            .catch(function (error) {
                console.log(error);
            });   
    </script>
   
  </body>
</html>