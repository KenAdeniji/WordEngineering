<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created: 20040415
-->
<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center">
       <th colspan="7">Reference</th>
      </tr>
      <tr align="center">
       <th>Author</th>
       <th>Year</th>
       <th>Title</th>
       <th>Source</th>
       <th>Volume</th>
       <th>PageFrom</th>
       <th>PageUntil</th>       
      </tr>
     </theader>
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
  <xsl:if test="keyword!='' ">
   <tr align="center">
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="author" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="author" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="year" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="year" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="title" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="title" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="source" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="source" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="volume" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="volume" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="pageFrom" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="pageFrom" />
      </a>
     </xsl:if>
    </td>
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="pageUntil" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="pageUntil" />
      </a>
     </xsl:if>
    </td>
    <!--
    <td>
     <xsl:if test="uri=''">
      <xsl:value-of select="concat(author, ' (', year, '). ', title, ' ', source, ' ', volume, ' ', pageFrom, pageUntil )" />
     </xsl:if>
     <xsl:if test="uri!='' ">
      <a target="_blank" href="{uri}">
      <xsl:value-of select="concat(author, ' (', year, '). ', title, source, volume, pageFrom, pageUntil )" />
      </a>
     </xsl:if>
    </td>
    -->
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