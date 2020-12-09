<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:    200212150124
 Revision 1: 20030521     If the title node is empty, suppress the table row.
-->
<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
      <table align="center" border="1">
        <tbody>
          <xsl:apply-templates select="/addresses/address">
             <xsl:sort select="title" data-type="text" 
                  order="ascending" case-order="lower-first"/>
             <xsl:sort select="position()" data-type="number" 
                  order="ascending" case-order="lower-first"/> 
          </xsl:apply-templates>
         </tbody>
      </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/addresses/address">
  <xsl:if test="title!='' ">
   <tr align="center">
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="title"/>
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
       <xsl:value-of select="title"/>
      </a>
     </xsl:if>
    </td>
   </tr>
  </xsl:if> 
 </xsl:template>

</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater tdan
-->

<!--
HTML Special Entities
Character   Meaning        Entity   Numeric
<           Less Than      &lt;     &#60;
>           Greater Than   &gt;     &#62;
&           Ampersand      &amp;    &#38;
'           Apostrophe     &apos;   &#39;
"           Quote          &quot;   &#34;
-->