<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LogInForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogInForm))
        Me.LogInTitleLabel = New System.Windows.Forms.Label()
        Me.UsernameLogInLabel = New System.Windows.Forms.Label()
        Me.PasswordLogInLabel = New System.Windows.Forms.Label()
        Me.txbUsernameLogin = New System.Windows.Forms.TextBox()
        Me.txbPasswordLogin = New System.Windows.Forms.TextBox()
        Me.btnSubmitLoginDetails = New System.Windows.Forms.Button()
        Me.pbBackToMenu = New System.Windows.Forms.PictureBox()
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogInTitleLabel
        '
        Me.LogInTitleLabel.AutoSize = True
        Me.LogInTitleLabel.Font = New System.Drawing.Font("Garamond", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInTitleLabel.Location = New System.Drawing.Point(275, 32)
        Me.LogInTitleLabel.Name = "LogInTitleLabel"
        Me.LogInTitleLabel.Size = New System.Drawing.Size(231, 63)
        Me.LogInTitleLabel.TabIndex = 0
        Me.LogInTitleLabel.Text = "LOG IN"
        '
        'UsernameLogInLabel
        '
        Me.UsernameLogInLabel.AutoSize = True
        Me.UsernameLogInLabel.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLogInLabel.Location = New System.Drawing.Point(332, 130)
        Me.UsernameLogInLabel.Name = "UsernameLogInLabel"
        Me.UsernameLogInLabel.Size = New System.Drawing.Size(115, 27)
        Me.UsernameLogInLabel.TabIndex = 1
        Me.UsernameLogInLabel.Text = "Username"
        '
        'PasswordLogInLabel
        '
        Me.PasswordLogInLabel.AutoSize = True
        Me.PasswordLogInLabel.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLogInLabel.Location = New System.Drawing.Point(332, 252)
        Me.PasswordLogInLabel.Name = "PasswordLogInLabel"
        Me.PasswordLogInLabel.Size = New System.Drawing.Size(110, 27)
        Me.PasswordLogInLabel.TabIndex = 2
        Me.PasswordLogInLabel.Text = "Password"
        '
        'txbUsernameLogin
        '
        Me.txbUsernameLogin.Location = New System.Drawing.Point(254, 176)
        Me.txbUsernameLogin.Name = "txbUsernameLogin"
        Me.txbUsernameLogin.Size = New System.Drawing.Size(264, 26)
        Me.txbUsernameLogin.TabIndex = 3
        '
        'txbPasswordLogin
        '
        Me.txbPasswordLogin.HideSelection = False
        Me.txbPasswordLogin.Location = New System.Drawing.Point(254, 295)
        Me.txbPasswordLogin.Name = "txbPasswordLogin"
        Me.txbPasswordLogin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txbPasswordLogin.Size = New System.Drawing.Size(264, 26)
        Me.txbPasswordLogin.TabIndex = 4
        '
        'btnSubmitLoginDetails
        '
        Me.btnSubmitLoginDetails.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSubmitLoginDetails.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitLoginDetails.Location = New System.Drawing.Point(326, 370)
        Me.btnSubmitLoginDetails.Name = "btnSubmitLoginDetails"
        Me.btnSubmitLoginDetails.Size = New System.Drawing.Size(121, 45)
        Me.btnSubmitLoginDetails.TabIndex = 5
        Me.btnSubmitLoginDetails.Text = "SUBMIT"
        Me.btnSubmitLoginDetails.UseVisualStyleBackColor = False
        '
        'pbBackToMenu
        '
        Me.pbBackToMenu.Image = CType(resources.GetObject("pbBackToMenu.Image"), System.Drawing.Image)
        Me.pbBackToMenu.Location = New System.Drawing.Point(23, 18)
        Me.pbBackToMenu.Name = "pbBackToMenu"
        Me.pbBackToMenu.Size = New System.Drawing.Size(85, 77)
        Me.pbBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBackToMenu.TabIndex = 24
        Me.pbBackToMenu.TabStop = False
        '
        'LogInForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pbBackToMenu)
        Me.Controls.Add(Me.btnSubmitLoginDetails)
        Me.Controls.Add(Me.txbPasswordLogin)
        Me.Controls.Add(Me.txbUsernameLogin)
        Me.Controls.Add(Me.PasswordLogInLabel)
        Me.Controls.Add(Me.UsernameLogInLabel)
        Me.Controls.Add(Me.LogInTitleLabel)
        Me.Name = "LogInForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogInForm"
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LogInTitleLabel As Label
    Friend WithEvents UsernameLogInLabel As Label
    Friend WithEvents PasswordLogInLabel As Label
    Friend WithEvents txbUsernameLogin As TextBox
    Friend WithEvents txbPasswordLogin As TextBox
    Friend WithEvents btnSubmitLoginDetails As Button
    Friend WithEvents pbBackToMenu As PictureBox
End Class
