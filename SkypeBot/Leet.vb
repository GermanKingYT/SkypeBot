Imports System.Text

Public NotInheritable Class Leet
    Public Shared Function ToLeet(text As String, Optional degree As Integer = 30) As String
        Return Translate(text, degree)
    End Function
    Public Shared Function Translate(text As String, Optional degree As Integer = 30) As String
        ' Adjust degree between 0 - 100
        degree = If(degree >= 100, 100, If(degree <= 0, 0, degree))
        ' No Leet Translator
        If degree = 0 Then
            Return text
        End If
        ' StringBuilder to store result.
        Dim sb As New StringBuilder(text.Length)
        For Each c As Char In text
            '#Region "Degree > 0 and < 17"
            If degree < 17 AndAlso degree > 0 Then
                Select Case c
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree > 16 and < 33"
            ElseIf degree < 33 AndAlso degree > 16 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree > 32 and < 49"
            ElseIf degree < 49 AndAlso degree > 32 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case "s"c
                        sb.Append("$")
                        Exit Select
                    Case "S"c
                        sb.Append("$")
                        Exit Select
                    Case "l"c
                        sb.Append("£")
                        Exit Select
                    Case "L"c
                        sb.Append("£")
                        Exit Select
                    Case "c"c
                        sb.Append("(")
                        Exit Select
                    Case "C"c
                        sb.Append("(")
                        Exit Select
                    Case "y"c
                        sb.Append("¥")
                        Exit Select
                    Case "Y"c
                        sb.Append("¥")
                        Exit Select
                    Case "u"c
                        sb.Append("µ")
                        Exit Select
                    Case "U"c
                        sb.Append("µ")
                        Exit Select
                    Case "d"c
                        sb.Append("Ð")
                        Exit Select
                    Case "D"c
                        sb.Append("Ð")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree > 48 and < 65"
            ElseIf degree < 65 AndAlso degree > 48 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case "k"c
                        sb.Append("|{")
                        Exit Select
                    Case "K"c
                        sb.Append("|{")
                        Exit Select
                    Case "s"c
                        sb.Append("$")
                        Exit Select
                    Case "S"c
                        sb.Append("$")
                        Exit Select
                    Case "g"c
                        sb.Append("9")
                        Exit Select
                    Case "G"c
                        sb.Append("9")
                        Exit Select
                    Case "l"c
                        sb.Append("£")
                        Exit Select
                    Case "L"c
                        sb.Append("£")
                        Exit Select
                    Case "c"c
                        sb.Append("(")
                        Exit Select
                    Case "C"c
                        sb.Append("(")
                        Exit Select
                    Case "t"c
                        sb.Append("7")
                        Exit Select
                    Case "T"c
                        sb.Append("7")
                        Exit Select
                    Case "z"c
                        sb.Append("2")
                        Exit Select
                    Case "Z"c
                        sb.Append("2")
                        Exit Select
                    Case "y"c
                        sb.Append("¥")
                        Exit Select
                    Case "Y"c
                        sb.Append("¥")
                        Exit Select
                    Case "u"c
                        sb.Append("µ")
                        Exit Select
                    Case "U"c
                        sb.Append("µ")
                        Exit Select
                    Case "f"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "F"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "d"c
                        sb.Append("Ð")
                        Exit Select
                    Case "D"c
                        sb.Append("Ð")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree > 64 and < 81"
            ElseIf degree < 81 AndAlso degree > 64 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case "k"c
                        sb.Append("|{")
                        Exit Select
                    Case "K"c
                        sb.Append("|{")
                        Exit Select
                    Case "s"c
                        sb.Append("$")
                        Exit Select
                    Case "S"c
                        sb.Append("$")
                        Exit Select
                    Case "g"c
                        sb.Append("9")
                        Exit Select
                    Case "G"c
                        sb.Append("9")
                        Exit Select
                    Case "l"c
                        sb.Append("£")
                        Exit Select
                    Case "L"c
                        sb.Append("£")
                        Exit Select
                    Case "c"c
                        sb.Append("(")
                        Exit Select
                    Case "C"c
                        sb.Append("(")
                        Exit Select
                    Case "t"c
                        sb.Append("7")
                        Exit Select
                    Case "T"c
                        sb.Append("7")
                        Exit Select
                    Case "z"c
                        sb.Append("2")
                        Exit Select
                    Case "Z"c
                        sb.Append("2")
                        Exit Select
                    Case "y"c
                        sb.Append("¥")
                        Exit Select
                    Case "Y"c
                        sb.Append("¥")
                        Exit Select
                    Case "u"c
                        sb.Append("µ")
                        Exit Select
                    Case "U"c
                        sb.Append("µ")
                        Exit Select
                    Case "f"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "F"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "d"c
                        sb.Append("Ð")
                        Exit Select
                    Case "D"c
                        sb.Append("Ð")
                        Exit Select
                    Case "n"c
                        sb.Append("|\|")
                        Exit Select
                    Case "N"c
                        sb.Append("|\|")
                        Exit Select
                    Case "w"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "W"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "h"c
                        sb.Append("|-|")
                        Exit Select
                    Case "H"c
                        sb.Append("|-|")
                        Exit Select
                    Case "v"c
                        sb.Append("\/")
                        Exit Select
                    Case "V"c
                        sb.Append("\/")
                        Exit Select
                    Case "m"c
                        sb.Append("|\/|")
                        Exit Select
                    Case "M"c
                        sb.Append("|\/|")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree < 100 and > 80"
            ElseIf degree > 80 AndAlso degree < 100 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case "s"c
                        sb.Append("$")
                        Exit Select
                    Case "S"c
                        sb.Append("$")
                        Exit Select
                    Case "g"c
                        sb.Append("9")
                        Exit Select
                    Case "G"c
                        sb.Append("9")
                        Exit Select
                    Case "l"c
                        sb.Append("£")
                        Exit Select
                    Case "L"c
                        sb.Append("£")
                        Exit Select
                    Case "c"c
                        sb.Append("(")
                        Exit Select
                    Case "C"c
                        sb.Append("(")
                        Exit Select
                    Case "t"c
                        sb.Append("7")
                        Exit Select
                    Case "T"c
                        sb.Append("7")
                        Exit Select
                    Case "z"c
                        sb.Append("2")
                        Exit Select
                    Case "Z"c
                        sb.Append("2")
                        Exit Select
                    Case "y"c
                        sb.Append("¥")
                        Exit Select
                    Case "Y"c
                        sb.Append("¥")
                        Exit Select
                    Case "u"c
                        sb.Append("µ")
                        Exit Select
                    Case "U"c
                        sb.Append("µ")
                        Exit Select
                    Case "f"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "F"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "d"c
                        sb.Append("Ð")
                        Exit Select
                    Case "D"c
                        sb.Append("Ð")
                        Exit Select
                    Case "n"c
                        sb.Append("|\|")
                        Exit Select
                    Case "N"c
                        sb.Append("|\|")
                        Exit Select
                    Case "w"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "W"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "h"c
                        sb.Append("|-|")
                        Exit Select
                    Case "H"c
                        sb.Append("|-|")
                        Exit Select
                    Case "v"c
                        sb.Append("\/")
                        Exit Select
                    Case "V"c
                        sb.Append("\/")
                        Exit Select
                    Case "k"c
                        sb.Append("|{")
                        Exit Select
                    Case "K"c
                        sb.Append("|{")
                        Exit Select
                    Case "r"c
                        sb.Append("®")
                        Exit Select
                    Case "R"c
                        sb.Append("®")
                        Exit Select
                    Case "m"c
                        sb.Append("|\/|")
                        Exit Select
                    Case "M"c
                        sb.Append("|\/|")
                        Exit Select
                    Case "b"c
                        sb.Append("ß")
                        Exit Select
                    Case "B"c
                        sb.Append("ß")
                        Exit Select
                    Case "q"c
                        sb.Append("Q")
                        Exit Select
                    Case "Q"c
                        sb.Append("Q¸")
                        Exit Select
                    Case "x"c
                        sb.Append(")(")
                        Exit Select
                    Case "X"c
                        sb.Append(")(")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
                '#Region "Degree 100"
            ElseIf degree > 99 Then
                Select Case c
                    Case "a"c
                        sb.Append("4")
                        Exit Select
                    Case "e"c
                        sb.Append("3")
                        Exit Select
                    Case "i"c
                        sb.Append("1")
                        Exit Select
                    Case "o"c
                        sb.Append("0")
                        Exit Select
                    Case "A"c
                        sb.Append("4")
                        Exit Select
                    Case "E"c
                        sb.Append("3")
                        Exit Select
                    Case "I"c
                        sb.Append("1")
                        Exit Select
                    Case "O"c
                        sb.Append("0")
                        Exit Select
                    Case "s"c
                        sb.Append("$")
                        Exit Select
                    Case "S"c
                        sb.Append("$")
                        Exit Select
                    Case "g"c
                        sb.Append("9")
                        Exit Select
                    Case "G"c
                        sb.Append("9")
                        Exit Select
                    Case "l"c
                        sb.Append("£")
                        Exit Select
                    Case "L"c
                        sb.Append("£")
                        Exit Select
                    Case "c"c
                        sb.Append("(")
                        Exit Select
                    Case "C"c
                        sb.Append("(")
                        Exit Select
                    Case "t"c
                        sb.Append("7")
                        Exit Select
                    Case "T"c
                        sb.Append("7")
                        Exit Select
                    Case "z"c
                        sb.Append("2")
                        Exit Select
                    Case "Z"c
                        sb.Append("2")
                        Exit Select
                    Case "y"c
                        sb.Append("¥")
                        Exit Select
                    Case "Y"c
                        sb.Append("¥")
                        Exit Select
                    Case "u"c
                        sb.Append("µ")
                        Exit Select
                    Case "U"c
                        sb.Append("µ")
                        Exit Select
                    Case "f"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "F"c
                        sb.Append("ƒ")
                        Exit Select
                    Case "d"c
                        sb.Append("Ð")
                        Exit Select
                    Case "D"c
                        sb.Append("Ð")
                        Exit Select
                    Case "n"c
                        sb.Append("|\|")
                        Exit Select
                    Case "N"c
                        sb.Append("|\|")
                        Exit Select
                    Case "w"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "W"c
                        sb.Append("\/\/")
                        Exit Select
                    Case "h"c
                        sb.Append("|-|")
                        Exit Select
                    Case "H"c
                        sb.Append("|-|")
                        Exit Select
                    Case "v"c
                        sb.Append("\/")
                        Exit Select
                    Case "V"c
                        sb.Append("\/")
                        Exit Select
                    Case "k"c
                        sb.Append("|{")
                        Exit Select
                    Case "K"c
                        sb.Append("|{")
                        Exit Select
                    Case "r"c
                        sb.Append("®")
                        Exit Select
                    Case "R"c
                        sb.Append("®")
                        Exit Select
                    Case "m"c
                        sb.Append("|\/|")
                        Exit Select
                    Case "M"c
                        sb.Append("|\/|")
                        Exit Select
                    Case "b"c
                        sb.Append("ß")
                        Exit Select
                    Case "B"c
                        sb.Append("ß")
                        Exit Select
                    Case "j"c
                        sb.Append("_|")
                        Exit Select
                    Case "J"c
                        sb.Append("_|")
                        Exit Select
                    Case "P"c
                        sb.Append("|°")
                        Exit Select
                    Case "q"c
                        sb.Append("¶")
                        Exit Select
                    Case "Q"c
                        sb.Append("¶¸")
                        Exit Select
                    Case "x"c
                        sb.Append(")(")
                        Exit Select
                    Case "X"c
                        sb.Append(")(")
                        Exit Select
                    Case Else
                        sb.Append(c)
                        Exit Select
                End Select
                '#End Region
            End If
        Next
        Return sb.ToString()
        ' Return result.
    End Function
End Class