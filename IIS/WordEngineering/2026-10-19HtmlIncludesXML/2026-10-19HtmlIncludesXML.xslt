<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" indent="no"/>
<xsl:template match="/">
	<html>
		<body>
			<table align="center" border="1">
				<caption>Anchors</caption> 
				<thead>
					<tr>
						<th>href</th>
						<th>data-dated</th>
					</tr>
				</thead>
				<xsl:apply-templates select="//a">
				</xsl:apply-templates>
			</table>
		</body>
	</html>
</xsl:template>	
<xsl:template match="a">
	<tr>
		<td><xsl:value-of select="@href"/></td>
		<td><xsl:value-of select="@data-dated"/></td>
	</tr>	
</xsl:template>
</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater than
-->

<!--
HTML Special Entities
Character   Meaning        Entity   Numeric
<           Less than      &lt;     &#60;
>           Greater than   &gt;     &#62;
&           Ampersand      &amp;    &#38;
'           Apostrophe     &apos;   &#39;
"           Quote          &quot;   &#34;
-->
