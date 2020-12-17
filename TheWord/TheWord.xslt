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
 20040504 AlphabetSequence include the position() column, extend the column header from 7 to 8, proof of concept.
 20041011 Benny Hinn: The Anointing ISBN 0-7852-7168-6. Greek. Language: Arabic, Yiddish, French, English. Wife: Suzanne. Children: Jessica, Natasha, Eleasha, Joshua. Anointing: Leper's, priestly, Rhema kingly Thus saith the LORD supercedes Logos written word bible.
 20041102 Comforter_-_20041102MichaelPitts_OtiSo_BiIwo_SeRi_AroundTheWorld.xml Comforter_-_20041102DDLNameIdentityAlterTableAddColumnScriptureReference.sql.
 20041111 KaiserPermanente.org KP.org 5600 Stoneridge Mall Pleasanton 94583 CA.
 20041122 TAGHeuer.com extend the TheWord by including the CommandmentId. 
 20041129 Church of the Living God Pastor Val Reyes Jr. ContactId 1127. Suffix.
 20041213 Greek Orthodox Church of the Ascension AscensionCathedral.org 4700 Lincoln Avenue Oakland 94602 CA USA Tel: (510) 531-3400. ContactId 25. AlphabetSequence include the URI column, extend the column header from 8 to 9.
 20041214 Svenhards.comSvenhard'sSwedishBakeryOakland94607-2596CAUSA800705-3379_Ajax.nl_-_20041214ItIsOnlyAvailableInTheLastCenturyAndSoIDoNeedYouLeadingInWhoseJetInYardageDash.xml integrate the commentary and the URI column, extend the column header from 9 to 8.
 20041216 Baxter_-_20041216TrendYearTwoFourThreeHeWasTheMatronInTheOverseaHanger.xml Extend the Remember column header from 7 to 10.
 20041218 AsianJournal.com CaseBasedReasoning include the URI column.
 20041218 Joshua Kadison Joshua-Kadison.com Send me picture postcards from LA, cut face, blood. ClassAssociates include the URI column.
 20041220 SpunkMeyer.comOtisSpunkmeyerSanLeandro94577CAUSA15106231183_-_20041220DoYouHaveABusinessCardWhatDoYouMeanByBusinessCardIDoHaveLunchWithMe.xml TheWord, Remember include the URI column.
 20041221 SpunkMeyer.comOtisSpunkmeyerSanLeandro94577CAUSA15106231183_-_20041220DoYouHaveABusinessCardWhatDoYouMeanByBusinessCardIDoHaveLunchWithMe.xml Separate the commentary and URI column. 
 20041221 Todai.com NameIdentity include the URI column.
-->

<xsl:output method="html" indent="no" />

 <xsl:template match="/">
  <html>
   <body>
   
    <xsl:apply-templates select="//TheWord"/>

    <xsl:if test="count(//Anointing) > 0">
     <table align="center" border="1">
      <tr align="center">
       <td colspan="5">
        <a target="_blank" href="http://www.BennyHinn.org" >
         BennyHinn.org Anointing: Leper, priestly, kingly. Rhema Word of the LORD, Thus saith the LORD, supercedes Logos written word bible
        </a>
        <br/>
        <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Psalms+63%2C+Leviticus+14&amp;section=0&amp;version=nkj&amp;language=en" >
         (Psalms 63, Leviticus 14)
        </a>
       </td>
      </tr>
      <xsl:apply-templates select="//Anointing">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

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
      <tr align="center"><td colspan="11">Remember</td></tr> 
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

    <xsl:if test="count(//NameIdentity) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="9">NameIdentity</td></tr> 
      <xsl:apply-templates select="//NameIdentity">
       <xsl:sort select="SequenceOrderId" data-type="number" 
        order="ascending" case-order="lower-first"/>
       <xsl:sort select="Dated" data-type="text" 
        order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//KaiserPermanenteBloodPressure) > 0">
     <table align="center" border="1">
      <tr align="center"><td colspan="9">Kaiser Permanente KP.org Blood Pressure</td></tr> 
      <xsl:apply-templates select="//KaiserPermanenteBloodPressure">
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
      <tr align="center"><td colspan="9">Alphabet Sequence</td></tr> 
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
      <tr align="center"><td colspan="5">Case-Based Reasoning</td></tr> 
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
      <tr align="center"><td colspan="5">Class Associates</td></tr> 
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

   <xsl:choose>
    <xsl:when test="CommandmentId!=''">
     <tr align="center"><td><xsl:value-of select="CommandmentId"/></td></tr> 
    </xsl:when>
   </xsl:choose>  

   <xsl:choose>
    <xsl:when test="URI!=''">
     <tr align="center"><td><a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a></td></tr>
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

 <xsl:template match="Anointing">
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
       <xsl:value-of select="Rhema"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Rhema"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td><xsl:value-of select="Filename"/></td>
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

 <xsl:template match="NameIdentity">
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
       <xsl:value-of select="IssuedAlliance"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="IssuedAlliance"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="InclusiveLiteral"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="InclusiveLiteral"/>
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
   <td>
    <xsl:choose>
     <xsl:when test="URI!=''">
      <a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a>
     </xsl:when>
    </xsl:choose>
   </td>
  </tr> 
 </xsl:template>

 <xsl:template match="KaiserPermanenteBloodPressure">
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
       <xsl:value-of select="Systolic"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Systolic"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Diastolic"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Diastolic"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Pulse"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Pulse"/>
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

   <!--
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="position()"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="position()"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   -->
   
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
   <td>
    <xsl:choose>
     <xsl:when test="URI!=''">
      <a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a>
     </xsl:when>
    </xsl:choose>
   </td>
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
     <xsl:when test="URI!=''">
      <a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a>
     </xsl:when>
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
     <xsl:when test="URI!=''">
      <a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a>
     </xsl:when>
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
 
  <xsl:variable name="biblicalYear"  select="floor( FromUntil div 360)" />
  <xsl:variable name="biblicalMonth" select="floor( ( FromUntil - $biblicalYear * 360 ) div 30 )" />
  <xsl:variable name="biblicalDay"   select="floor( FromUntil - ( $biblicalYear * 360 ) - ( $biblicalMonth * 30 ) )" />  
 
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

   <td><xsl:value-of select="$biblicalYear"/></td>
   <td><xsl:value-of select="$biblicalMonth"/></td>
   <td><xsl:value-of select="$biblicalDay"/></td>   

   <td>
    <xsl:choose>
     <xsl:when test="URI!=''">
      <a target="_blank" href="{URI}"><xsl:value-of select="URI"/></a>
     </xsl:when>
    </xsl:choose>
   </td>

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