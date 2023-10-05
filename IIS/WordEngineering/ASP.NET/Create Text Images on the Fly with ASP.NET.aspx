<%@ Page Language="VB" ContentType="image/gif" Debug="true" Explicit="true" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

  '---------------------------------------------------
  ' 2014-08-01 http://salman-w.blogspot.com/2009/02/create-text-images-on-fly-with-aspnet.html
  ' ASP.NET Text to Images Script
  ' Revision 2 [2010-03-01]
  ' Revised the transparency hack to use heuristics
  '---------------------------------------------------

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    '
    ' Capture and sanitize querystring parameters
    '

    Dim qText As String
    qText = Request.QueryString("text")
    If qText = String.Empty Then
      qText = "-"
    End If

    Dim qSize As Integer
    Try
      qSize = Request.QueryString("size")
    Catch
      qSize = 0
    End Try
    If qSize < 8 Then
      qSize = 8
    End If

    Dim qColor As String
    qColor = Request.QueryString("color")
    If qColor = String.Empty OrElse Regex.IsMatch(qColor, "^[0-9A-F]{6}$", RegexOptions.IgnoreCase) = False Then
      qColor = "000000"
    End If

    '
    ' Call the function
    '

    RenderGraphic(qText, qSize, qColor)

  End Sub

  Private Sub RenderGraphic(ByVal pText As String, ByVal pSize As Integer, ByVal pColor As String)

    '
    ' Declare and pre-calculate the variables
    '

    Dim b As Bitmap = New Bitmap(1, 1)
    Dim g As Graphics = Graphics.FromImage(b)
    Dim f As Font = New Font("Arial", pSize)
    Dim w As Integer = g.MeasureString(pText, f).Width
    Dim h As Integer = g.MeasureString(pText, f).Height
    Dim c1 As Color = ColorTranslator.FromHtml("#" & pColor)
    Dim c2 As Color = IIf(c1.GetBrightness < 0.5, Color.FromArgb(&HFF00FFFF), Color.FromArgb(&HFF330000))

    '
    ' Render drawing
    '

    b = New Bitmap(w, h)
    g = Graphics.FromImage(b)
    g.Clear(c2)
    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
    g.DrawString(pText, f, New SolidBrush(c1), 0, 0)
    g.Flush()

    '
    ' Save in memory
    '

    Dim m As New MemoryStream
    b.Save(m, ImageFormat.Gif)

    '
    ' Apply transparency hack
    '
    ' For the background, we choose one of these two colors from the stubborn GIF
    ' palette: #00FFFF (@75) for dark text or #330000 (@76) for bright text
    ' We then set this color as transparent by hacking into the GIF palette
    '

    Dim n As Byte()
    n = m.ToArray()
    n(787) = IIf(c1.GetBrightness < 0.5, 75, 76)

    '
    ' Send to browser
    '

    Dim o As New BinaryWriter(Response.OutputStream)
    o.Write(n)
    o.Close()

  End Sub

</script>
