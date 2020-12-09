<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
version="1.0">
<xsl:template match="/">
<html>
<body>
<table border="1">
<tr>
<th>Id</th>
<th>Title</th>
<th>Chapter(s)</th>
</tr>
<xsl:for-each select="Bible/BibleBook">
<tr>
<td>
<xsl:value-of select="bookId" />
</td>
<td>
<xsl:value-of select="bookTitle" />
</td>
<td>
<xsl:value-of select="chapters" />
</td>
</tr>
</xsl:for-each>
</table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
