<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>
<xsl:template match="/">
  <html>
  <head>
    <style>
  .ccmtable {
			 font: normal 12px/150% Arial, Helvetica, sans-serif; 
			 background: #fff; 
			 overflow: hidden; 
			 border: 2px solid #2C4699; 
			 border-radius: 1px; 
   }

  .ccmtable td, .ccmtable th { 
			padding: 5px 4px; 
   }
  .ccmtable thead th {
		color-stop(1, #00557F) );
		background-color:#346D99; 
		color:#FFFFFF; 
		font-size: 15px; 
		font-weight: bold; 
		border-left: 1px solid #3269A8; 
   }
  </style>
  <script type="text/javascript" 
    src="https://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.js"></script>
  <script type='text/javascript'>
  
  <![CDATA[
  $(document).ready(function(){
        // Iterates through each of the rows in your customers <table>
        // $('.ccmtable tbody tr').each(function(){
        $('.ccmtable tbody tr td').each(function(){
		  var val=$(this).text().trim();
          if(val === "very high risk"){
              $(this).parent().css('background','#f28b68');
          }
		  else if(val === "high risk"){
              $(this).parent().css('background','#f2cd68');
          }
		  else if(val === "moderate risk"){
              $(this).parent().css('background','#eef268');
          }
		  else if(val === "without much risk"){
              $(this).parent().css('background','#b4f268');
          }
        });
    });
  ]]>
    
</script>
  </head>
  <body>
  <h2>Code Complexity by CCM</h2>
  <table class="ccmtable">
    <thead>
      <th>Complexity</th>
      <th>Function</th>
	  <th>Testability</th>
      <th>Classification</th>
      <th>File</th>
      <th>Start</th>
      <th>End</th>
      <th>SLOC</th>
	</thead>
	<tbody>
    <xsl:for-each select="ccm/metric">
    <tr>
      <td><xsl:value-of select="complexity"/></td>
      <td><xsl:value-of select="unit"/></td>
	  <td><xsl:value-of select="testability"/></td>
      <td><xsl:value-of select="classification"/></td>
      <td><xsl:value-of select="file"/></td>
      <td><xsl:value-of select="startLineNumber"/></td>
      <td><xsl:value-of select="endLineNumber"/></td>
      <td><xsl:value-of select="SLOC"/></td>
    </tr>
    </xsl:for-each>
	</tbody>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>
