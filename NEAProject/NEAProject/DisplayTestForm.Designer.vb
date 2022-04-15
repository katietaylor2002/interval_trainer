<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DisplayTestForm
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
        Me.btnPlayInterval = New System.Windows.Forms.Button()
        Me.btnConfirmAnswer = New System.Windows.Forms.Button()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'btnPlayInterval
        '
        Me.btnPlayInterval.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnPlayInterval.Font = New System.Drawing.Font("Garamond", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlayInterval.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnPlayInterval.Location = New System.Drawing.Point(557, 84)
        Me.btnPlayInterval.Name = "btnPlayInterval"
        Me.btnPlayInterval.Size = New System.Drawing.Size(198, 65)
        Me.btnPlayInterval.TabIndex = 0
        Me.btnPlayInterval.Text = "PLAY INTERVAL"
        Me.btnPlayInterval.UseVisualStyleBackColor = False
        '
        'btnConfirmAnswer
        '
        Me.btnConfirmAnswer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnConfirmAnswer.Font = New System.Drawing.Font("Garamond", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmAnswer.Location = New System.Drawing.Point(557, 282)
        Me.btnConfirmAnswer.Name = "btnConfirmAnswer"
        Me.btnConfirmAnswer.Size = New System.Drawing.Size(206, 69)
        Me.btnConfirmAnswer.TabIndex = 1
        Me.btnConfirmAnswer.Text = "SUBMIT ANSWER"
        Me.btnConfirmAnswer.UseVisualStyleBackColor = False
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Garamond", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.Location = New System.Drawing.Point(139, 22)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(0, 25)
        Me.lblQuestion.TabIndex = 2
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Major", "Minor", "Perfect", "Augmented"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(21, 63)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(194, 304)
        Me.CheckedListBox1.TabIndex = 3
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.Font = New System.Drawing.Font("Garamond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", "14th", "15th"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(281, 63)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(194, 304)
        Me.CheckedListBox2.TabIndex = 4
        '
        'DisplayTestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckedListBox2)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.btnConfirmAnswer)
        Me.Controls.Add(Me.btnPlayInterval)
        Me.Name = "DisplayTestForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DisplayTestForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPlayInterval As Button
    Friend WithEvents btnConfirmAnswer As Button
    Friend WithEvents lblQuestion As Label
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents CheckedListBox2 As CheckedListBox
End Class
