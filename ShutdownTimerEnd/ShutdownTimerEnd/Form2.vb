
Public Class Form2
    Inherits System.Windows.Forms.Form
    Private myAnimator As New FormAnimator(Me, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 400)
    Dim method As Integer
    Dim choices As String() = {"Log Off", "Power Off", "Reboot", "Shutdown", "Suspend", "Hybernate"}
    Dim remain As Integer = 5 * 60
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(New Object() {"10m", "30m", "1h"})
        ComboBox1.SelectedIndex = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        For Each argument As String In My.Application.CommandLineArgs
            method = argument
            Button1.Text = choices(argument)
        Next
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, _
                                Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 5)
        Me.TopMost = True
        Timer1.Start()
        Timer1.Interval = 1000
    End Sub
    Public Sub ExitWindows()
        Timer1.Stop()
        Select Case method
            Case 0
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.LogOff, True)
            Case 1
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.PowerOff, True)
            Case 2
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.Reboot, True)
            Case 3
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.ShutDown, True)
            Case 4
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.Suspend, True)
            Case 5
                Me.Close()
                WindowsController.ExitWindows(RestartOptions.Hibernate, True)
        End Select
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExitWindows()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
        Dim sTarea As String = "schtasks /create /tn ""ShutdownTimer"" /tr ""\""" + Application.ExecutablePath() +
            "\""" + Str(method) + """ /sc once /st "
        Select Case ComboBox1.SelectedIndex
            Case 0
                sTarea = sTarea + Now.AddMinutes(10).ToString("HH:mm")
            Case 1
                sTarea = sTarea + Now.AddMinutes(30).ToString("HH:mm")
            Case 2
                sTarea = sTarea + Now.AddHours(1).ToString("HH:mm")
        End Select
        sTarea = sTarea + " /f"
        Shell(sTarea)
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(remain)
        Label1.Text = "Залишилось часу " + iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & _
                    iSpan.Seconds.ToString.PadLeft(2, "0"c)
        ProgressBar1.Value = 100 - remain / (5 * 60) * 100
        remain -= 1
        If remain = 0 Then
            ExitWindows()
        End If
    End Sub

End Class