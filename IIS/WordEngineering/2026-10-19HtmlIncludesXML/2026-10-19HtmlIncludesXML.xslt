<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
	2026-10-19 Created.
-->

<xsl:output method="html" indent="no" />
<xsl:template match="/">
	<html>
		<body>
		
			<xsl:apply-templates select="//html"/>
		
			<table align="center" border="1">
				<tr align="center"><th>a</th></tr> 
				<xsl:apply-templates select="//a">
				</xsl:apply-templates>
			</table>

			<xsl:template match="a">
				<tr>
					<td><xsl:value-of select="href"/></td>
					<td><xsl:value-of select="dated"/></td>
				</tr>
			</xsl:template>
			
		</body>
	</html>
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
