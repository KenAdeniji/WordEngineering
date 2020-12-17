<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 20030722 Created.
 20030805 TheWord node, include the SequenceOrderId.
 20030823 Extend the column span for the prophet table header from 3 to 4.
 20030825 Include the commentary entries for AlphabetSequence 546 and 547 ... extend the TheWordRelease20030825.xslt AlphabetSequence node title column space from 4 to 5.
 20030826 Include FromUntil in the TheWord node. ALTER TABLE TheWord ADD FromUntil AS (datediff(day,(convert(varchar,datepart(year,getdate())) + '0101'),getdate())).
 20030908 Include the dream node.
 20030914 Extend the column span for the JehovahRophe table header from 3 to 4, to adjust for the dated column inclusion. Jehovah Rophe: New Mexico. But now he is dead, wherefore should I fast? can I bring him back again? I shall go to him, but he shall not return to me (2 Samuel 12:23).
 20031004 Extend the column span for the AlphabetSequence table header from 5 to 6, to adjust for the ScriptureReferenceAssociates inclusion. TheWord: 183; AlphabetSequence 765: As it was blood falling from his shoulders.
 20031016 Include the dated entries for AlphabetSequence 786 and 788 ... extend the TheWordRelease20031016.xslt AlphabetSequence node title column space from 6 to 7.
 20031016 Include the dated entries for BibleWord 382 ... extend the TheWordRelease20031016.xslt BibleWord node title column space from 4 to 5.
 20031029 Extend the column span for the ClassAssociates, Export, Software from 3 to 4, to adjust for the scripture reference column inclusion.
 20031107 AlphabetSequence Dated only row.
 20031112 Include the dated entries for Export 26.
-->

<xsl:output method="html" indent="no" />


 <xsl:template match="/">
  <html>
   <body>
   
    <xsl:apply-templates select="//TheWord"/>

    <xsl:if test="count(//ScriptureReading) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="3">Scripture Reading</td></tr> 
      <xsl:apply-templates select="//ScriptureReading">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 
    
    <xsl:if test="count(//Remember) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="7">Remember</td></tr> 
      <xsl:apply-templates select="//Remember">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//Sign) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="5">Sign</td></tr> 
      <xsl:apply-templates select="//Sign">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//JehovahRophe) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Jehovah Rophe</td></tr> 
      <xsl:apply-templates select="//JehovahRophe">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//Dream) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Dream</td></tr> 
      <xsl:apply-templates select="//Dream">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//Prophet) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Prophet</td></tr> 
      <xsl:apply-templates select="//Prophet">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//BibleWord) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="5">Bible Word</td></tr> 
      <xsl:apply-templates select="//BibleWord">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//AlphabetSequence) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="7">Alphabet Sequence</td></tr> 
      <xsl:apply-templates select="//AlphabetSequence">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 
    
    <xsl:if test="count(//CaseBasedReasoning) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Case-Based Reasoning</td></tr> 
      <xsl:apply-templates select="//CaseBasedReasoning">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//Export) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Export</td></tr> 
      <xsl:apply-templates select="//Export">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//Software) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Software</td></tr> 
      <xsl:apply-templates select="//Software">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//ClassAssociates) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="4">Class Associates</td></tr> 
      <xsl:apply-templates select="//ClassAssociates">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

  </body>
 </html>
 </xsl:template>

 <xsl:template match="TheWord">
  <table align="center">

   <xsl:choose>
    <xsl:when test="Title!=''">
     <tr align="center"><td><xsl:value-of select="Title"/></td></tr> 
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="ScriptureReference!=''">
     <tr align="center">
      <td>
       <xsl:choose>
        <xsl:when test="ScriptureReferenceURI!=''">
         <a target="_blank" href="{ScriptureReferenceURI}">
          <xsl:value-of select="ScriptureReference"/>
         </a>
        </xsl:when>
        <xsl:otherwise>
         <xsl:value-of select="ScriptureReference"/>
        </xsl:otherwise>
       </xsl:choose>
      </td>
     </tr>
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="Dated!=''">
     <tr align="center"><td>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </td></tr> 
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="SequenceOrderId!=''">
     <tr align="center">
      <td>
       <xsl:choose>
        <xsl:when test="ScriptureReferenceURI!=''">
         <a target="_blank" href="{ScriptureReferenceURI}">
          <xsl:value-of select="SequenceOrderId"/>
         </a>
        </xsl:when>
        <xsl:otherwise>
         <xsl:value-of select="SequenceOrderId"/>
        </xsl:otherwise>
       </xsl:choose>
      </td>
     </tr>
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="FromUntil!=''">
     <tr align="center">
      <td>
       Day of the Year: 
       <xsl:choose>
        <xsl:when test="ScriptureReferenceURI!=''">
         <a target="_blank" href="{ScriptureReferenceURI}">
          <xsl:value-of select="FromUntil"/>
         </a>
        </xsl:when>
        <xsl:otherwise>
         <xsl:value-of select="FromUntil"/>
        </xsl:otherwise>
       </xsl:choose>
      </td>
     </tr>
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="Keyword!=''">
     <tr align="center"><td><xsl:value-of select="Keyword"/></td></tr> 
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="Commentary!=''">
     <tr align="center"><td><xsl:value-of select="Commentary"/></td></tr> 
    </xsl:when>
   </xsl:choose>  

  </table> 
  <br/>
 </xsl:template>

 <xsl:template match="BibleWord">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Word"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Word"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="AlphabetSequence">

  <!--
  <xsl:variable name="dated1" select="Dated" />

  <xsl:if test="dated1 != ''">
   <xsl:variable name="dated2" select="$dated1" />
   <tr align="center">
    <td colspan="7">
     <xsl:value-of select="Dated"/>
    </td>
   </tr> 
   <br/><br/>
  </xsl:if> 
  -->

  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Word"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Word"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="AlphabetSequenceIndex"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="AlphabetSequenceIndex"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceAssociatesURI!=''">
      <a target="_blank" href="{ScriptureReferenceAssociatesURI}">
       <xsl:value-of select="ScriptureReferenceAssociates"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReferenceAssociates"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
  </tr> 
 </xsl:template>

 <xsl:template match="CaseBasedReasoning">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="ClassAssociates">
  <tr align="center">

   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>

   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>

   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="Export">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="JehovahRophe">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Dated"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Dated"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="Remember">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(DatedFrom,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(DatedFrom,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(DatedUntil,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(DatedUntil,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SignIndex"/>
       <xsl:value-of select="FromUntil"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SignIndex"/>
      <xsl:value-of select="FromUntil"/>      
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <a target="_blank" href="{Filename}">
     <xsl:value-of select="Filename"/>
    </a>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
  </tr> 
 </xsl:template>

 <xsl:template match="Dream">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="Prophet">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="ScriptureReading">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
  </tr> 
 </xsl:template>

 <xsl:template match="Sign">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Measure"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Measure"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SignIndex"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SignIndex"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="Software">
  <tr align="center">

   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="SequenceOrderId"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="SequenceOrderId"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>

   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="substring(Dated,1,16)"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="substring(Dated,1,16)"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>

   <td><xsl:value-of select="Commentary"/></td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>

  </tr> 
 </xsl:template>
 
</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less tdan 
 &gt; greater tdan
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
