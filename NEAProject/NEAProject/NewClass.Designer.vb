<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewClass
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxCreateNewClassName = New System.Windows.Forms.TextBox()
        Me.btnCreateNewClass = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Class Name:"
        '
        'tbxCreateNewClassName
        '
        Me.tbxCreateNewClassName.Location = New System.Drawing.Point(248, 138)
        Me.tbxCreateNewClassName.Name = "tbxCreateNewClassName"
        Me.tbxCreateNewClassName.Size = New System.Drawing.Size(448, 26)
        Me.tbxCreateNewClassName.TabIndex = 1
        '
        'btnCreateNewClass
        '
        Me.btnCreateNewClass.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnCreateNewClass.Font = New System.Drawing.Font("Garamond", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateNewClass.Location = New System.Drawing.Point(283, 265)
        Me.btnCreateNewClass.Name = "btnCreateNewClass"
        Me.btnCreateNewClass.Size = New System.Drawing.Size(215, 76)
        Me.btnCreateNewClass.TabIndex = 2
        Me.btnCreateNewClass.Text = "CREATE CLASS"
        Me.btnCreateNewClass.UseVisualStyleBackColor = False
        '
        'NewClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCreateNewClass)
        Me.Controls.Add(Me.tbxCreateNewClassName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NewClass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NewClass"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbxCreateNewClassName As TextBox
    Friend WithEvents btnCreateNewClass As Button
End Class
