<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IntervalData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IntervalData))
        Me.dgvIntervalData = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbBackToMenu = New System.Windows.Forms.PictureBox()
        CType(Me.dgvIntervalData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvIntervalData
        '
        Me.dgvIntervalData.AllowUserToAddRows = False
        Me.dgvIntervalData.AllowUserToDeleteRows = False
        Me.dgvIntervalData.AllowUserToResizeColumns = False
        Me.dgvIntervalData.AllowUserToResizeRows = False
        Me.dgvIntervalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIntervalData.Location = New System.Drawing.Point(43, 81)
        Me.dgvIntervalData.Name = "dgvIntervalData"
        Me.dgvIntervalData.ReadOnly = True
        Me.dgvIntervalData.RowHeadersVisible = False
        Me.dgvIntervalData.RowTemplate.Height = 28
        Me.dgvIntervalData.Size = New System.Drawing.Size(781, 407)
        Me.dgvIntervalData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Garamond", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(299, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INTERVAL DATA"
        '
        'pbBackToMenu
        '
        Me.pbBackToMenu.Image = CType(resources.GetObject("pbBackToMenu.Image"), System.Drawing.Image)
        Me.pbBackToMenu.Location = New System.Drawing.Point(43, 12)
        Me.pbBackToMenu.Name = "pbBackToMenu"
        Me.pbBackToMenu.Size = New System.Drawing.Size(73, 63)
        Me.pbBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBackToMenu.TabIndex = 26
        Me.pbBackToMenu.TabStop = False
        '
        'IntervalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 506)
        Me.Controls.Add(Me.pbBackToMenu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvIntervalData)
        Me.Name = "IntervalData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IntervalData"
        CType(Me.dgvIntervalData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBackToMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvIntervalData As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pbBackToMenu As PictureBox
End Class
