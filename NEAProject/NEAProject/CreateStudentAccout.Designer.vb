<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreateStudentAccout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateStudentAccout))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txbStudentNumberCreateStudentAccount = New System.Windows.Forms.TextBox()
        Me.txbFirstNameCreateStudentAccount = New System.Windows.Forms.TextBox()
        Me.txbSurnameCreateStudentAccount = New System.Windows.Forms.TextBox()
        Me.txbPasswordCreateStudentAccount = New System.Windows.Forms.TextBox()
        Me.txbConfirmPasswordCreateStudentAccount = New System.Windows.Forms.TextBox()
        Me.btnConfirmCreateStudentAccount = New System.Windows.Forms.Button()
        Me.pbBackToMenu = New System.Windows.Forms.PictureBox()
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(178, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CREATE STUDENT ACCOUNT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(147, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Student Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(191, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "First Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(213, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Surname"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(132, 366)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Confirm Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Garamond", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(207, 299)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 22)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Password"
        '
        'txbStudentNumberCreateStudentAccount
        '
        Me.txbStudentNumberCreateStudentAccount.Location = New System.Drawing.Point(336, 97)
        Me.txbStudentNumberCreateStudentAccount.Name = "txbStudentNumberCreateStudentAccount"
        Me.txbStudentNumberCreateStudentAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbStudentNumberCreateStudentAccount.TabIndex = 6
        '
        'txbFirstNameCreateStudentAccount
        '
        Me.txbFirstNameCreateStudentAccount.Location = New System.Drawing.Point(336, 164)
        Me.txbFirstNameCreateStudentAccount.Name = "txbFirstNameCreateStudentAccount"
        Me.txbFirstNameCreateStudentAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbFirstNameCreateStudentAccount.TabIndex = 7
        '
        'txbSurnameCreateStudentAccount
        '
        Me.txbSurnameCreateStudentAccount.Location = New System.Drawing.Point(336, 233)
        Me.txbSurnameCreateStudentAccount.Name = "txbSurnameCreateStudentAccount"
        Me.txbSurnameCreateStudentAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbSurnameCreateStudentAccount.TabIndex = 8
        '
        'txbPasswordCreateStudentAccount
        '
        Me.txbPasswordCreateStudentAccount.Location = New System.Drawing.Point(336, 299)
        Me.txbPasswordCreateStudentAccount.Name = "txbPasswordCreateStudentAccount"
        Me.txbPasswordCreateStudentAccount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbPasswordCreateStudentAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbPasswordCreateStudentAccount.TabIndex = 9
        '
        'txbConfirmPasswordCreateStudentAccount
        '
        Me.txbConfirmPasswordCreateStudentAccount.Location = New System.Drawing.Point(336, 366)
        Me.txbConfirmPasswordCreateStudentAccount.Name = "txbConfirmPasswordCreateStudentAccount"
        Me.txbConfirmPasswordCreateStudentAccount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbConfirmPasswordCreateStudentAccount.Size = New System.Drawing.Size(267, 26)
        Me.txbConfirmPasswordCreateStudentAccount.TabIndex = 10
        '
        'btnConfirmCreateStudentAccount
        '
        Me.btnConfirmCreateStudentAccount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnConfirmCreateStudentAccount.Font = New System.Drawing.Font("Garamond", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmCreateStudentAccount.Location = New System.Drawing.Point(633, 366)
        Me.btnConfirmCreateStudentAccount.Name = "btnConfirmCreateStudentAccount"
        Me.btnConfirmCreateStudentAccount.Size = New System.Drawing.Size(141, 55)
        Me.btnConfirmCreateStudentAccount.TabIndex = 11
        Me.btnConfirmCreateStudentAccount.Text = "CREATE ACCOUNT"
        Me.btnConfirmCreateStudentAccount.UseVisualStyleBackColor = False
        '
        'pbBackToMenu
        '
        Me.pbBackToMenu.Image = CType(resources.GetObject("pbBackToMenu.Image"), System.Drawing.Image)
        Me.pbBackToMenu.Location = New System.Drawing.Point(24, 12)
        Me.pbBackToMenu.Name = "pbBackToMenu"
        Me.pbBackToMenu.Size = New System.Drawing.Size(85, 77)
        Me.pbBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBackToMenu.TabIndex = 12
        Me.pbBackToMenu.TabStop = False
        '
        'CreateStudentAccout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pbBackToMenu)
        Me.Controls.Add(Me.btnConfirmCreateStudentAccount)
        Me.Controls.Add(Me.txbConfirmPasswordCreateStudentAccount)
        Me.Controls.Add(Me.txbPasswordCreateStudentAccount)
        Me.Controls.Add(Me.txbSurnameCreateStudentAccount)
        Me.Controls.Add(Me.txbFirstNameCreateStudentAccount)
        Me.Controls.Add(Me.txbStudentNumberCreateStudentAccount)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CreateStudentAccout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateStudentAccout"
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txbStudentNumberCreateStudentAccount As TextBox
    Friend WithEvents txbFirstNameCreateStudentAccount As TextBox
    Friend WithEvents txbSurnameCreateStudentAccount As TextBox
    Friend WithEvents txbPasswordCreateStudentAccount As TextBox
    Friend WithEvents txbConfirmPasswordCreateStudentAccount As TextBox
    Friend WithEvents btnConfirmCreateStudentAccount As Button
    Friend WithEvents pbBackToMenu As PictureBox
End Class
