Imports System.ServiceProcess
Imports System.Threading
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Main
    Inherits System.Windows.Forms.Form
    Dim fileExists = True
    Dim theDate As DateTime
    Dim f As System.IO.FileStream
    Dim file As System.IO.StreamWriter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudMin2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudHours2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbtnIn As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAt As System.Windows.Forms.RadioButton
    Dim notification As Form2 = New Form2()
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        'Skybound.VisualStyles.VisualStyleProvider.EnableVisualStyles()
        InitializeComponent()
        taskbarNotifier1 = New TaskBarNotifier
        taskbarNotifier1.SetBackgroundBitmap(New Bitmap(MyClass.GetType(), "popup.bmp"), Color.FromArgb(255, 0, 255))
        taskbarNotifier1.SetCloseBitmap(New Bitmap(MyClass.GetType(), "close.bmp"), Color.FromArgb(255, 0, 255), New Point(215, 8))
        taskbarNotifier1.TitleRectangle = New Rectangle(60, 20, 180, 25)
        taskbarNotifier1.TextRectangle = New Rectangle(1, 10, 243, 110)
        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblDelay As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents cbSelect As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents nudHours1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSyatemTime As System.Windows.Forms.Label
    Friend WithEvents nudMin1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblShutdownType As System.Windows.Forms.Label
    Friend WithEvents lblTimeTo As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.nudHours1 = New System.Windows.Forms.NumericUpDown()
        Me.lblSyatemTime = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.nudMin1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.cbSelect = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblShutdownType = New System.Windows.Forms.Label()
        Me.lblTimeTo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudMin2 = New System.Windows.Forms.NumericUpDown()
        Me.nudHours2 = New System.Windows.Forms.NumericUpDown()
        Me.rbtnIn = New System.Windows.Forms.RadioButton()
        Me.rbtnAt = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.nudHours1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMin1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudMin2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHours2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDelay
        '
        Me.lblDelay.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblDelay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelay.Location = New System.Drawing.Point(288, 24)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(72, 23)
        Me.lblDelay.TabIndex = 0
        Me.lblDelay.Text = " (HH : MM)"
        '
        'nudHours1
        '
        Me.nudHours1.Enabled = False
        Me.nudHours1.Location = New System.Drawing.Point(168, 24)
        Me.nudHours1.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudHours1.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudHours1.Name = "nudHours1"
        Me.nudHours1.Size = New System.Drawing.Size(48, 22)
        Me.nudHours1.TabIndex = 2
        Me.nudHours1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSyatemTime
        '
        Me.lblSyatemTime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblSyatemTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSyatemTime.Location = New System.Drawing.Point(8, 0)
        Me.lblSyatemTime.Name = "lblSyatemTime"
        Me.lblSyatemTime.Size = New System.Drawing.Size(72, 16)
        Me.lblSyatemTime.TabIndex = 3
        Me.lblSyatemTime.Text = "System Time"
        Me.lblSyatemTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTime
        '
        Me.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(104, 0)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(112, 16)
        Me.lblTime.TabIndex = 4
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMin1
        '
        Me.nudMin1.Enabled = False
        Me.nudMin1.Location = New System.Drawing.Point(232, 24)
        Me.nudMin1.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudMin1.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMin1.Name = "nudMin1"
        Me.nudMin1.Size = New System.Drawing.Size(48, 22)
        Me.nudMin1.TabIndex = 3
        Me.nudMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(32, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "What you want the computer to do?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.RoyalBlue
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(452, 64)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(328, 292)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Enabled = False
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOk.Location = New System.Drawing.Point(232, 292)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(88, 24)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "OK"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ContextMenu1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Auto Shutdown"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Show Window"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "Change Settings"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Exit"
        '
        'cbSelect
        '
        Me.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSelect.Items.AddRange(New Object() {"Log Off", "Power Off", "Reboot", "Shutdown", "Suspend", "Hybernate"})
        Me.cbSelect.Location = New System.Drawing.Point(32, 104)
        Me.cbSelect.Name = "cbSelect"
        Me.cbSelect.Size = New System.Drawing.Size(320, 22)
        Me.cbSelect.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 324)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 16)
        Me.Panel1.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblShutdownType)
        Me.Panel3.Controls.Add(Me.lblTimeTo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(208, 16)
        Me.Panel3.TabIndex = 1
        '
        'lblShutdownType
        '
        Me.lblShutdownType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblShutdownType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShutdownType.Location = New System.Drawing.Point(0, 0)
        Me.lblShutdownType.Name = "lblShutdownType"
        Me.lblShutdownType.Size = New System.Drawing.Size(80, 16)
        Me.lblShutdownType.TabIndex = 5
        Me.lblShutdownType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTimeTo
        '
        Me.lblTimeTo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTimeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeTo.Location = New System.Drawing.Point(104, 0)
        Me.lblTimeTo.Name = "lblTimeTo"
        Me.lblTimeTo.Size = New System.Drawing.Size(104, 16)
        Me.lblTimeTo.TabIndex = 6
        Me.lblTimeTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblSyatemTime)
        Me.Panel2.Controls.Add(Me.lblTime)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(220, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 16)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nudMin2)
        Me.GroupBox1.Controls.Add(Me.nudHours2)
        Me.GroupBox1.Controls.Add(Me.rbtnIn)
        Me.GroupBox1.Controls.Add(Me.rbtnAt)
        Me.GroupBox1.Controls.Add(Me.nudMin1)
        Me.GroupBox1.Controls.Add(Me.nudHours1)
        Me.GroupBox1.Controls.Add(Me.lblDelay)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 100)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shutdown Method"
        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = " (HH : MM)"
        '
        'nudMin2
        '
        Me.nudMin2.Enabled = False
        Me.nudMin2.Location = New System.Drawing.Point(232, 64)
        Me.nudMin2.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudMin2.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudMin2.Name = "nudMin2"
        Me.nudMin2.Size = New System.Drawing.Size(48, 22)
        Me.nudMin2.TabIndex = 5
        Me.nudMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudHours2
        '
        Me.nudHours2.Enabled = False
        Me.nudHours2.Location = New System.Drawing.Point(168, 64)
        Me.nudHours2.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudHours2.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudHours2.Name = "nudHours2"
        Me.nudHours2.Size = New System.Drawing.Size(48, 22)
        Me.nudHours2.TabIndex = 4
        Me.nudHours2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rbtnIn
        '
        Me.rbtnIn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnIn.Location = New System.Drawing.Point(16, 64)
        Me.rbtnIn.Name = "rbtnIn"
        Me.rbtnIn.Size = New System.Drawing.Size(104, 24)
        Me.rbtnIn.TabIndex = 1
        Me.rbtnIn.Text = "Shutdown in"
        '
        'rbtnAt
        '
        Me.rbtnAt.Checked = True
        Me.rbtnAt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.rbtnAt.Location = New System.Drawing.Point(16, 24)
        Me.rbtnAt.Name = "rbtnAt"
        Me.rbtnAt.Size = New System.Drawing.Size(104, 24)
        Me.rbtnAt.TabIndex = 0
        Me.rbtnAt.TabStop = True
        Me.rbtnAt.Text = "Shutdown at"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.RoyalBlue
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(374, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 27
        Me.PictureBox2.TabStop = False
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "StatusBarPanel1"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"ўодн€", "ўотижн€", "ўом≥с€ц€"})
        Me.ComboBox1.Location = New System.Drawing.Point(287, 250)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 22)
        Me.ComboBox1.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Repeat"
        '
        'Main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(452, 340)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSelect)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = "Auto ShutDown"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.nudHours1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMin1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.nudMin2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHours2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim PopHide As Boolean = False
    Dim Notify As Boolean = False
    Private WithEvents taskbarNotifier1 As TaskBarNotifier
    Dim hours, mins, seconds As Integer
    Dim setHours, setMins As Integer



    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        lblTime.Text = Now.Day.ToString + "/" + Now.Month.ToString + "/" + Now.Year.ToString + " " + _
                       formatTo2Digits(Now.Hour) + ":" + formatTo2Digits(Now.Minute) + ":" + formatTo2Digits(Now.Second)

        If rbtnAt.Checked = True Then
            ShutdownAt()
        ElseIf rbtnIn.Checked = True Then
            ShutdownIn()
        End If
    End Sub

    Private Declare Auto Function PlaySound Lib "winmm.dll" (ByVal SoundName As String, _
            ByVal hModule As Integer, ByVal dwFlags As Integer) As Integer

    Private Sub PlayNow()
        Dim fileName As String = String.Concat(Application.StartupPath + "\shutdown.wav")
        Const SND_FILENAME As Integer = &H20000
        PlaySound(fileName, 0, SND_FILENAME)
    End Sub

    Private Sub ShutdownIn()

        If hours > 0 Or mins > 0 Or seconds > 0 Then
            If mins = 0 AndAlso hours > 0 Then _
                mins = 59 : hours = hours - 1

            If seconds = 0 AndAlso mins > 0 Then _
                seconds = 60 : mins = mins - 1

            seconds = seconds - 1
        End If

        lblShutdownType.Text = cbSelect.Text + " in"
        lblTimeTo.Text = formatTo2Digits(hours) + ":" + formatTo2Digits(mins) + ":" + formatTo2Digits(seconds)

        If hours = 0 AndAlso mins < 5 AndAlso seconds < 60 Then
            Dim remain As Integer = mins * 60 + seconds
            If PopHide = False Then showPopup(cbSelect.Text, remain)
            If Notify = False Then
                PlayNow()
                Notify = True
            End If
        End If

        If hours = 0 AndAlso mins = 0 AndAlso seconds = 0 Then
            ExitWindows()
        End If
    End Sub

    Private Function formatTo2Digits(ByVal Val As Integer) As String
        Dim newVal As String
        Dim len As Integer = Val.ToString.Length

        If len = 1 Then
            newVal = "0" + Val.ToString
            Return newVal
        Else
            Return Val.ToString
        End If
    End Function
    Public Sub ExitWindows()
        Me.Show()
        Timer1.Stop()
        Select Case cbSelect.SelectedIndex
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

    Private Sub ShutdownAt()
        lblShutdownType.Text = cbSelect.Text + " at"
        lblTimeTo.Text = formatTo2Digits(nudHours1.Value) + ":" + formatTo2Digits(nudMin1.Value) + ":" + formatTo2Digits(0)
        'special case of set min = 0 and one less is 59
        If compareTime(Now, theDate) Then
            Dim remain As Integer = nudMin1.Value * 60 - Now.Minute * 60 - Now.Second
            If PopHide = False Then showPopup(cbSelect.Text, remain)
            If Notify = False Then
                PlayNow()
                Notify = True
            End If
        End If

        If String.Compare(Now.Hour.ToString, nudHours1.Value.ToString) = 0 Then
            If String.Compare(Now.Minute.ToString, nudMin1.Value.ToString) = 0 Then
                ExitWindows()
            End If
        End If
    End Sub

    Private Sub Notifier_CloseButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles taskbarNotifier1.CloseButtonClick
        taskbarNotifier1.Hide()
        PopHide = True
    End Sub

    Private Sub Notifier_TitleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles taskbarNotifier1.TitleClick
        Timer1.Stop()
    End Sub

    Private Sub Notifier_TextClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles taskbarNotifier1.TextClick
        Timer1.Stop()
    End Sub

    Private Sub showPopup(ByVal shutDownType As String, ByVal remain As Integer)
        notification.changeTime(remain)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        saveFile()
        Me.Hide()
        startTimer()
        btnOk.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Timer1.Stop()
        If f IsNot Nothing Then
            f.Close()
        End If
        If file IsNot Nothing Then
            file.Close()
        End If
        NotifyIcon1.Dispose()
        Application.Exit()
    End Sub

    Private Sub cbSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelect.SelectedIndexChanged
        Timer1.Stop()
        btnOk.Enabled = True
    End Sub

    Public Sub refreshTimer()
        Timer1.Stop()
        startTimer()
    End Sub

    Private Sub nudHours_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHours1.ValueChanged
        Timer1.Stop()
        If nudHours1.Value = nudHours1.Maximum Then
            nudHours1.UpButton()
            nudHours1.Value = nudHours1.Minimum + 1
        End If

        If nudHours1.Value = nudHours1.Minimum Then
            nudHours1.DownButton()
            nudHours1.Value = nudHours1.Maximum - 1
        End If
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If

    End Sub

    Private Sub nudMin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMin1.ValueChanged
        Timer1.Stop()
        If nudMin1.Value = nudMin1.Maximum Then
            nudMin1.UpButton()
            nudMin1.Value = nudMin1.Minimum + 1
        End If

        If nudMin1.Value = nudMin1.Minimum Then
            nudMin1.DownButton()
            nudMin1.Value = nudMin1.Maximum - 1
        End If
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Timer1.Stop()
        Application.Exit()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Show()
        WindowState = FormWindowState.Normal
        Timer1.Stop()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.Show()
        WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        WindowState = FormWindowState.Normal
    End Sub


    Private Sub nudHours2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudHours2.ValueChanged
        Timer1.Stop()
        If nudHours2.Value = nudHours2.Maximum Then
            nudHours2.UpButton()
            nudHours2.Value = nudHours2.Minimum + 1
        End If

        If nudHours2.Value = nudHours2.Minimum Then
            nudHours2.DownButton()
            nudHours2.Value = nudHours2.Maximum - 1
        End If
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub nudMin2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMin2.ValueChanged
        Timer1.Stop()
        If nudMin2.Value = nudMin2.Maximum Then
            nudMin2.UpButton()
            nudMin2.Value = nudMin2.Minimum + 1
        End If

        If nudMin2.Value = nudMin2.Minimum Then
            nudMin2.DownButton()
            nudMin2.Value = nudMin2.Maximum - 1
        End If
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub rbtnAt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAt.CheckedChanged
        nudHours1.Enabled = True
        nudMin1.Enabled = True
        nudHours2.Enabled = False
        nudMin2.Enabled = False
        Timer1.Stop()
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub rbtnIn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnIn.CheckedChanged
        nudHours1.Enabled = False
        nudMin1.Enabled = False
        nudHours2.Enabled = True
        nudMin2.Enabled = True
        Timer1.Stop()
        If Not String.Compare(cbSelect.Text, "") = 0 Then
            btnOk.Enabled = True
        End If
    End Sub

    Public Sub increment(ByVal amm As Integer)
        If amm = 60 Then
            nudHours2.Value = 1
            nudMin2.Value = 0
        Else
            nudHours2.Value = 0
            nudMin2.Value = amm
        End If

        rbtnAt.Checked = False
        rbtnIn.Checked = True
        Timer1.Start()
    End Sub





    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim config As String = IO.Path.GetDirectoryName(Application.ExecutablePath) + "\config.txt"
        fileExists = My.Computer.FileSystem.FileExists(config)
        If My.Computer.FileSystem.FileExists(config) Then
            Dim sr As IO.StreamReader = New IO.StreamReader(config)
            cbSelect.SelectedIndex = sr.ReadLine()
            Dim type As String = sr.ReadLine()
            ComboBox1.SelectedIndex = sr.ReadLine()
            theDate = DateTime.ParseExact(sr.ReadLine(), "HH:mm:ss/MM/dd/yy", Globalization.CultureInfo.CurrentCulture)
            nudHours1.Value = theDate.Hour
            nudMin1.Value = theDate.Minute
            sr.Close()
            startTimer()
            btnOk.Enabled = False
            Me.Hide()
        End If
    End Sub

    Private Sub saveFile()
        Dim config As String = IO.Path.GetDirectoryName(Application.ExecutablePath) + "\config.txt"
        If Not fileExists Then
            f = System.IO.File.Create(config)
            file = New System.IO.StreamWriter(f)
        Else : file = New System.IO.StreamWriter(config, False)
        End If
        file.WriteLine(cbSelect.SelectedIndex)
        theDate = Now
        If rbtnAt.Checked = True Then
            file.WriteLine(0)
            theDate = New Date(theDate.Year, theDate.Month, theDate.Day, nudHours1.Value, nudMin1.Value, 0)
            file.WriteLine(ComboBox1.SelectedIndex.ToString)
        ElseIf rbtnIn.Checked = True Then
            file.WriteLine(1)
            theDate = theDate.AddHours(nudHours2.Value).AddMinutes(nudMin2.Value)
            file.WriteLine(ComboBox1.SelectedIndex.ToString)
        End If
        file.WriteLine(theDate.ToString("HH:mm:ss/MM/dd/yy"))
        file.Close()
    End Sub

    Private Function compareTime(ByVal p1 As Date, ByVal theDate As Date) As Boolean
        Dim time As Integer = nudHours1.Value * 60 + nudMin1.Value
        Dim timeNow As Integer = Now.Hour * 60 + Now.Minute
        If time - timeNow < 0 Then
            Return False
        End If
        Select Case ComboBox1.SelectedIndex
            Case 0
                Return time - timeNow <= 5
            Case 1
                Return p1.DayOfWeek = theDate.DayOfWeek And time - timeNow <= 5
            Case 2
                Return p1.Day = theDate.Day And time - timeNow <= 5
        End Select
    End Function

    Private Sub startTimer()
        Timer1.Enabled = True
        Timer1.Start()
        Notify = False
        lblTime.Visible = True
        lblTime.Visible = True
        setHours = nudHours2.Value
        setMins = nudMin2.Value
        hours = setHours
        mins = setMins
        If nudHours2.Value = 0 AndAlso nudMin2.Value = 0 Then
            seconds = 60
        Else
            seconds = 0
        End If
    End Sub

End Class
