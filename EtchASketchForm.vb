'Justine Hoffa
'RCET0265
'Fall2020
'Etch-A-Sketch 
'https://github.com/justinehoffa/EtchASketch

Option Explicit On
Option Strict On
Option Compare Binary

Public Class EtchASketchForm
    Dim penColor As Color
    Dim myPen As New Pen(Color.Black)
    Dim oldX As Integer
    Dim oldY As Integer
    Dim graph As Graphics

    Private Sub EtchASketchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Hide()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        Me.Text = "x: " & e.X & " y: " & e.Y & " Mouse Button: " & e.Button.ToString
        graph = PictureBox1.CreateGraphics
        If e.Button.ToString <> "None" Then
            graph.DrawLine(myPen, oldX, oldY, e.X, e.Y)
        End If
        oldX = e.X
        oldY = e.Y

    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        penColor = ColorDialog1.Color
        myPen.Color = penColor
    End Sub

    Private Sub ChaneColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        ColorDialog1.ShowDialog()
        penColor = ColorDialog1.Color
        myPen.Color = penColor
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Dim oldTop = Me.Top

        For i = 1 To 3
            For j = 1 To 9000000
                If j < 4500000 Then
                    Me.Top = oldTop - 50
                Else
                    Me.Top = oldTop
                End If
            Next
        Next

        Label1.Hide()
        graph.Clear(BackColor)
    End Sub


    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        Dim oldTop = Me.Top

        For i = 1 To 3
            For j = 1 To 9000000
                If j < 4500000 Then
                    Me.Top = oldTop - 50
                Else
                    Me.Top = oldTop
                End If
            Next
        Next

        Label1.Hide()
        graph.Clear(BackColor)
    End Sub

    Private Sub DrawButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click
        Dim Xvalue As Decimal
        Dim Yvalue As Decimal
        Dim oldY2 = 200
        Dim oldX2 = 0

        myPen.Color = Color.Black
        graph.Clear(BackColor)

        For xVal = 0 To 3000 Step 50
            For yVal = 0 To 800 Step 15
                graph.DrawLine(myPen, xVal, yVal, xVal, yVal + 10)
            Next
        Next

        For yVal = 0 To 3000 Step 50
            For xVal = 0 To 1200 Step 15
                graph.DrawLine(myPen, xVal, yVal, xVal + 10, yVal)
            Next
        Next

        myPen.Color = Color.Red
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Sin(X / 200 * 2 * Math.PI)))
            Xvalue = X
            graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next

        myPen.Color = Color.Blue
        oldX2 = 0
        oldY2 = 200
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Cos(X / 200 * 2 * Math.PI)))
            Xvalue = X
            graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next

        myPen.Color = Color.Green
        oldX2 = 0
        oldY2 = 200
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Tan(X / 200 * 2 * Math.PI)))
            If Yvalue > 500 Then
                Yvalue = 500
            ElseIf Yvalue < -100 Then
                Yvalue = -100
            End If
            Xvalue = X
            If (X > 45 And X < 55) Or
               (X > 145 And X < 155) Or
               (X > 245 And X < 255) Or
               (X > 345 And X < 355) Or
               (X > 445 And X < 455) Or
               (X > 545 And X < 555) Or
               (X > 645 And X < 655) Or
               (X > 745 And X < 755) Or
               (X > 845 And X < 855) Or
               (X > 945 And X < 955) Or
               (X > 1045 And X < 1055) Or
               (X > 1145 And X < 1155) Then
            Else
                graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            End If
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next


        Label1.Text = "Sine: Red" & vbNewLine & "Cosine: Blue" & vbNewLine & "Tangent: Green"
        Label1.Show()
    End Sub


    Private Sub DrawWaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawWaveToolStripMenuItem.Click
        Dim Xvalue As Decimal
        Dim Yvalue As Decimal
        Dim oldY2 = 200
        Dim oldX2 = 0

        myPen.Color = Color.Black
        graph.Clear(BackColor)

        For xVal = 0 To 3000 Step 50
            For yVal = 0 To 800 Step 15
                graph.DrawLine(myPen, xVal, yVal, xVal, yVal + 10)
            Next
        Next

        For yVal = 0 To 3000 Step 50
            For xVal = 0 To 1200 Step 15
                graph.DrawLine(myPen, xVal, yVal, xVal + 10, yVal)
            Next
        Next

        myPen.Color = Color.Red
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Sin(X / 200 * 2 * Math.PI)))
            Xvalue = X
            graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next

        myPen.Color = Color.Blue
        oldX2 = 0
        oldY2 = 200
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Cos(X / 200 * 2 * Math.PI)))
            Xvalue = X
            graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next

        myPen.Color = Color.Green
        oldX2 = 0
        oldY2 = 200
        For X = 1 To 3000
            Yvalue = CDec(150 - (60 * Math.Tan(X / 200 * 2 * Math.PI)))
            If Yvalue > 500 Then
                Yvalue = 500
            ElseIf Yvalue < -100 Then
                Yvalue = -100
            End If
            Xvalue = X
            If (X > 45 And X < 55) Or
               (X > 145 And X < 155) Or
               (X > 245 And X < 255) Or
               (X > 345 And X < 355) Or
               (X > 445 And X < 455) Or
               (X > 545 And X < 555) Or
               (X > 645 And X < 655) Or
               (X > 745 And X < 755) Or
               (X > 845 And X < 855) Or
               (X > 945 And X < 955) Or
               (X > 1045 And X < 1055) Or
               (X > 1145 And X < 1155) Then
            Else
                graph.DrawLine(myPen, oldX2, oldY2, Xvalue, Yvalue)
            End If
            oldX2 = CInt(Xvalue)
            oldY2 = CInt(Yvalue)
        Next


        Label1.Text = "Sine: Red" & vbNewLine & "Cosine: Blue" & vbNewLine & "Tangent: Green"
        Label1.Show()
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim message As String
        Dim title As String

        title = "About"
        message = "Welcome to Etch-A-Sketch!" &
                   vbNewLine & vbNewLine & "To change colors, select ''Change Colors'' Button or press Enter or ''c''." &
                   vbNewLine & "To draw waveforms, select ''Draw Waveforms'' Button or press ''d''." &
                   vbNewLine & "To erase the Etch-A-Sketch, select ''Erase'' Button or press Esc or ''r''." &
                   vbNewLine & "To exit Etch-A-Sketch, select ''Exit'' Button or press ''e''."

        MessageBox.Show(message, title)

    End Sub

End Class
