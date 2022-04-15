<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateTeacherAccount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateTeacherAccount))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConfirmCreateTeacherAccount = New System.Windows.Forms.Button()
        Me.txbConfirmPasswordCreateTeacherAccount = New System.Windows.Forms.TextBox()
        Me.txbPasswordCreateTeacherAccount = New System.Windows.Forms.TextBox()
        Me.txbSurnameCreateTeacherAccount = New System.Windows.Forms.TextBox()
        Me.txbFirstNameCreateTeacherAccount = New System.Windows.Forms.TextBox()
        Me.txbTeacherIDCreateTeacherAccount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbBackToMenu = New System.Windows.Forms.PictureBox()
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(183, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(426, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CREATE TEACHER ACCOUNT"
        '
        'btnConfirmCreateTeacherAccount
        '
        Me.btnConfirmCreateTeacherAccount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnConfirmCreateTeacherAccount.Font = New System.Drawing.Font("Garamond", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmCreateTeacherAccount.Location = New System.Drawing.Point(630, 365)
        Me.btnConfirmCreateTeacherAccount.Name = "btnConfirmCreateTeacherAccount"
        Me.btnConfirmCreateTeacherAccount.Size = New System.Drawing.Size(141, 55)
        Me.btnConfirmCreateTeacherAccount.TabIndex = 22
        Me.btnConfirmCreateTeacherAccount.Text = "CREATE ACCOUNT"
        Me.btnConfirmCreateTeacherAccount.UseVisualStyleBackColor = False
        '
        'txbConfirmPasswordCreateTeacherAccount
        '
        Me.txbConfirmPasswordCreateTeacherAccount.Location = New System.Drawing.Point(342, 365)
        Me.txbConfirmPasswordCreateTeacherAccount.Name = "txbConfirmPasswordCreateTeacherAccount"
        Me.txbConfirmPasswordCreateTeacherAccount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbConfirmPasswordCreateTeacherAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbConfirmPasswordCreateTeacherAccount.TabIndex = 21
        '
        'txbPasswordCreateTeacherAccount
        '
        Me.txbPasswordCreateTeacherAccount.Location = New System.Drawing.Point(342, 298)
        Me.txbPasswordCreateTeacherAccount.Name = "txbPasswordCreateTeacherAccount"
        Me.txbPasswordCreateTeacherAccount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbPasswordCreateTeacherAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbPasswordCreateTeacherAccount.TabIndex = 20
        '
        'txbSurnameCreateTeacherAccount
        '
        Me.txbSurnameCreateTeacherAccount.Location = New System.Drawing.Point(342, 234)
        Me.txbSurnameCreateTeacherAccount.Name = "txbSurnameCreateTeacherAccount"
        Me.txbSurnameCreateTeacherAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbSurnameCreateTeacherAccount.TabIndex = 19
        '
        'txbFirstNameCreateTeacherAccount
        '
        Me.txbFirstNameCreateTeacherAccount.Location = New System.Drawing.Point(342, 175)
        Me.txbFirstNameCreateTeacherAccount.Name = "txbFirstNameCreateTeacherAccount"
        Me.txbFirstNameCreateTeacherAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbFirstNameCreateTeacherAccount.TabIndex = 18
        '
        'txbTeacherIDCreateTeacherAccount
        '
        Me.txbTeacherIDCreateTeacherAccount.Location = New System.Drawing.Point(342, 113)
        Me.txbTeacherIDCreateTeacherAccount.Name = "txbTeacherIDCreateTeacherAccount"
        Me.txbTeacherIDCreateTeacherAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbTeacherIDCreateTeacherAccount.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(216, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 22)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(141, 365)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 22)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Confirm Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(222, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 22)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Surname"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(200, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 22)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "First Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 22)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Teacher ID"
        '
        'pbBackToMenu
        '
        Me.pbBackToMenu.Image = CType(resources.GetObject("pbBackToMenu.Image"), System.Drawing.Image)
        Me.pbBackToMenu.Location = New System.Drawing.Point(30, 22)
        Me.pbBackToMenu.Name = "pbBackToMenu"
        Me.pbBackToMenu.Size = New System.Drawing.Size(85, 77)
        Me.pbBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBackToMenu.TabIndex = 23
        Me.pbBackToMenu.TabStop = False
        '
        'CreateTeacherAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pbBackToMenu)
        Me.Controls.Add(Me.btnConfirmCreateTeacherAccount)
        Me.Controls.Add(Me.txbConfirmPasswordCreateTeacherAccount)
        Me.Controls.Add(Me.txbPasswordCreateTeacherAccount)
        Me.Controls.Add(Me.txbSurnameCreateTeacherAccount)
        Me.Controls.Add(Me.txbFirstNameCreateTeacherAccount)
        Me.Controls.Add(Me.txbTeacherIDCreateTeacherAccount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CreateTeacherAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateTeacherAccount"
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnConfirmCreateTeacherAccount As Button
    Friend WithEvents txbConfirmPasswordCreateTeacherAccount As TextBox
    Friend WithEvents txbPasswordCreateTeacherAccount As TextBox
    Friend WithEvents txbSurnameCreateTeacherAccount As TextBox
    Friend WithEvents txbFirstNameCreateTeacherAccount As TextBox
    Friend WithEvents txbTeacherIDCreateTeacherAccount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents pbBackToMenu As PictureBox
End Class
