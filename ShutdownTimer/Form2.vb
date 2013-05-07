Public Class Form2
    Private myAnimator As New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 400)

    Dim max As Integer = 5 * 60
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(New Object() {"10m", "30m", "1h"})
        ComboBox1.SelectedIndex = 0
        Button1.Text = Main.cbSelect.Text
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100



    End Sub
    Public Sub changeTime(ByVal remain As Integer)
        If Not Me.Visible Then
           Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, _
                                Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 5)
            Me.Show()
            Me.TopMost = True
        End If
        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(remain)
        Label1.Text = "Залишилось часу " + iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & _
                    iSpan.Seconds.ToString.PadLeft(2, "0"c)
        ProgressBar1.Value = 100 - remain / max * 100
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Main.ExitWindows()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim increment As Integer
        Select Case ComboBox1.SelectedIndex
            Case 0
                increment = 10
            Case 1
                increment = 30
            Case 2
                increment = 60
        End Select
        Main.increment(increment)
        Main.refreshTimer()
        Me.Hide()
    End Sub

End Class