<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:output method="html" indent="no" />

 <xsl:template match="/">
  
  <html>
   <body>
    <p align="center">
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/PersonName/FormattedName" /><br />
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/Telephone/FormattedNumber" /><br />
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/InternetEmailAddress" /><br />
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/PostalAddress/DeliveryAddress/AddressLine" /> &#32;
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/PostalAddress/DeliveryAddress/StreetName" /> &#32;
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/PostalAddress/Municipality" /> &#32;
     <xsl:value-of select="//Resume/StructuredXMLResume/ContactInfo/ContactMethod/PostalAddress/Region" />
     <br />     
    </p> 

    <p align="center">
     <xsl:value-of select="//Resume/StructuredXMLResume/Objective" />
    </p>
    
    <xsl:if test="count(//Competency) > 0">
     <table align="center" border="1">
      <theader><tr align="center"><th colspan="1">Competency</th></tr></theader>
      <tbody>
       <tr align="center"><td>
        <xsl:for-each select="//Competency">
         <xsl:value-of select="@name"/>
         <xsl:if test="not(position()=last())">, </xsl:if>
         <xsl:if test="position()=last()">.</xsl:if>
        </xsl:for-each>
       </td></tr>
      </tbody>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//EmployerOrg) > 0">
     <table align="center" border="1">
      <theader>
       <tr align="center"><th colspan="5">Employment History</th></tr>
       <tr align="center">
        <th colspan="1">Start Date</th>
        <th colspan="1">End Date</th>
        <th colspan="1">Role</th>
        <th colspan="1">Organization</th>
        <th colspan="1">Commentary</th>
       </tr>
      </theader>
      <tbody>
       <xsl:apply-templates select="//EmployerOrg" />  
      </tbody>
     </table>
     <br/><br/>
    </xsl:if> 

    <xsl:if test="count(//SchoolOrInstitution) > 0">
     <table align="center" border="1">
      <theader>
       <tr align="center"><th colspan="4">Education History</th></tr>
       <tr align="center">
        <th colspan="1">School Name</th>
        <th colspan="1">Degree</th>
        <th colspan="1">Major</th>
        <th colspan="1">Minor</th>        
       </tr>
      </theader>
      <tbody>
       <xsl:apply-templates select="//SchoolOrInstitution" />
      </tbody>
     </table>
     <br/><br/>
    </xsl:if> 
 
  </body>
 </html>
 </xsl:template>
 
 <xsl:template match="//EmployerOrg">
  <tr align="center">
   <td><xsl:value-of select="PositionHistory/StartDate/AnyDate" /></td>   
   <td><xsl:value-of select="PositionHistory/EndDate/AnyDate" /></td>      
   <td><xsl:value-of select="PositionHistory/Title" /></td>
   <td><xsl:value-of select="PositionHistory/OrgName/OrganizationName" /></td>
   <td><xsl:value-of select="PositionHistory/Description" /></td>
  </tr>
 </xsl:template>

 <xsl:template match="//SchoolOrInstitution">
  <tr align="center">
   <td><xsl:value-of select="SchoolName" /></td>
   <td>
    <xsl:for-each select="Degree">
     <xsl:value-of select="DegreeName"/>
     <xsl:if test="not(position()=last())"> <br/> </xsl:if>
    </xsl:for-each>
   </td>
   <td><xsl:value-of select="Major" /></td>
   <td><xsl:value-of select="Minor" /></td>   
  </tr>
 </xsl:template>
    
</xsl:stylesheet>