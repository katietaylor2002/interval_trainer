<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateAccountForm
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
        Me.LogInTitleLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStudentAccount = New System.Windows.Forms.Button()
        Me.btnTeacherAccount = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LogInTitleLabel
        '
        Me.LogInTitleLabel.AutoSize = True
        Me.LogInTitleLabel.Font = New System.Drawing.Font("Garamond", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogInTitleLabel.Location = New System.Drawing.Point(110, 56)
        Me.LogInTitleLabel.Name = "LogInTitleLabel"
        Me.LogInTitleLabel.Size = New System.Drawing.Size(560, 63)
        Me.LogInTitleLabel.TabIndex = 1
        Me.LogInTitleLabel.Text = "CREATE ACCOUNT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(224, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(309, 27)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Are You a Student Or Teacher?"
        '
        'btnStudentAccount
        '
        Me.btnStudentAccount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnStudentAccount.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStudentAccount.Location = New System.Drawing.Point(84, 240)
        Me.btnStudentAccount.Name = "btnStudentAccount"
        Me.btnStudentAccount.Size = New System.Drawing.Size(241, 86)
        Me.btnStudentAccount.TabIndex = 3
        Me.btnStudentAccount.Text = "STUDENT"
        Me.btnStudentAccount.UseVisualStyleBackColor = False
        '
        'btnTeacherAccount
        '
        Me.btnTeacherAccount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnTeacherAccount.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTeacherAccount.Location = New System.Drawing.Point(441, 240)
        Me.btnTeacherAccount.Name = "btnTeacherAccount"
        Me.btnTeacherAccount.Size = New System.Drawing.Size(241, 86)
        Me.btnTeacherAccount.TabIndex = 4
        Me.btnTeacherAccount.Text = "TEACHER"
        Me.btnTeacherAccount.UseVisualStyleBackColor = False
        '
        'CreateAccountForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnTeacherAccount)
        Me.Controls.Add(Me.btnStudentAccount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LogInTitleLabel)
        Me.Name = "CreateAccountForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateAccountForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LogInTitleLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnStudentAccount As Button
    Friend WithEvents btnTeacherAccount As Button
End Class
