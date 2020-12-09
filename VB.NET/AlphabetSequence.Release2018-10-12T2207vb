'	2018-10-12	https://stackoverflow.com/questions/20826999/can-c-sharp-compiler-compile-a-vb-net-cod
'	2018-10-12	https://social.msdn.microsoft.com/Forums/vstudio/en-US/1ba54461-94ae-47d1-a7ec-07c6f438f88d/cannot-access-myapplicationcommandlineargs?forum=vbgeneral
Imports System
Module Module1
    Sub Main(ByVal args As String())
		AlphabetSequence(args)
    End Sub
	Sub AlphabetSequence(words() As String)
		Dim word As String
		Dim currentCharacter As Char
		Dim alphabetSequenceIndex As Integer
		Dim sum As Integer
		For wordIndex As Integer = 0 To words.Count - 1
			alphabetSequenceIndex = 0
			word = UCase(words(wordIndex))
			For characterPosition As Integer = 0 To word.Length - 1
				currentCharacter = word.Chars(characterPosition)
				If (currentCharacter >= "A" AND currentCharacter <= "Z")
					alphabetSequenceIndex += Asc(currentCharacter) - 64
				End If
			Next
			sum += alphabetSequenceIndex
			Console.WriteLine("[{0}]: {1} {2}", wordIndex, words(wordIndex), alphabetSequenceIndex)
		Next
		Console.WriteLine("{0} {1}", String.Join(" ", words), sum)
	End Sub
End Module
