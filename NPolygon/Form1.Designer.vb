<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.oPlot = New OxyPlot.WindowsForms.PlotView()
        Me.ctrlPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxResolution = New System.Windows.Forms.TextBox()
        Me.tbxN = New System.Windows.Forms.TextBox()
        Me.btnDraw = New System.Windows.Forms.Button()
        Me._cbxParametricPlot = New System.Windows.Forms.CheckBox()
        Me.ctrlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'oPlot
        '
        Me.oPlot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.oPlot.Location = New System.Drawing.Point(0, 0)
        Me.oPlot.Name = "oPlot"
        Me.oPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.oPlot.Size = New System.Drawing.Size(684, 661)
        Me.oPlot.TabIndex = 0
        Me.oPlot.Text = "plot"
        Me.oPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.oPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.oPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'ctrlPanel
        '
        Me.ctrlPanel.Controls.Add(Me._cbxParametricPlot)
        Me.ctrlPanel.Controls.Add(Me.Label1)
        Me.ctrlPanel.Controls.Add(Me.tbxResolution)
        Me.ctrlPanel.Controls.Add(Me.tbxN)
        Me.ctrlPanel.Controls.Add(Me.btnDraw)
        Me.ctrlPanel.Location = New System.Drawing.Point(12, 12)
        Me.ctrlPanel.Name = "ctrlPanel"
        Me.ctrlPanel.Size = New System.Drawing.Size(412, 31)
        Me.ctrlPanel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(268, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Resolution"
        '
        'tbxResolution
        '
        Me.tbxResolution.Location = New System.Drawing.Point(333, 5)
        Me.tbxResolution.Name = "tbxResolution"
        Me.tbxResolution.Size = New System.Drawing.Size(70, 19)
        Me.tbxResolution.TabIndex = 1
        Me.tbxResolution.Text = "0.002"
        '
        'tbxN
        '
        Me.tbxN.Location = New System.Drawing.Point(84, 5)
        Me.tbxN.Name = "tbxN"
        Me.tbxN.Size = New System.Drawing.Size(73, 19)
        Me.tbxN.TabIndex = 1
        Me.tbxN.Text = "3"
        '
        'btnDraw
        '
        Me.btnDraw.Location = New System.Drawing.Point(3, 3)
        Me.btnDraw.Name = "btnDraw"
        Me.btnDraw.Size = New System.Drawing.Size(75, 23)
        Me.btnDraw.TabIndex = 0
        Me.btnDraw.Text = "Draw"
        Me.btnDraw.UseVisualStyleBackColor = True
        '
        '_cbxParametricPlot
        '
        Me._cbxParametricPlot.AutoSize = True
        Me._cbxParametricPlot.Checked = True
        Me._cbxParametricPlot.CheckState = System.Windows.Forms.CheckState.Checked
        Me._cbxParametricPlot.Location = New System.Drawing.Point(163, 7)
        Me._cbxParametricPlot.Name = "_cbxParametricPlot"
        Me._cbxParametricPlot.Size = New System.Drawing.Size(99, 16)
        Me._cbxParametricPlot.TabIndex = 3
        Me._cbxParametricPlot.Text = "ParametricPlot"
        Me._cbxParametricPlot.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 661)
        Me.Controls.Add(Me.ctrlPanel)
        Me.Controls.Add(Me.oPlot)
        Me.Name = "Form1"
        Me.Text = "Draw N Polygon"
        Me.ctrlPanel.ResumeLayout(False)
        Me.ctrlPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents oPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents ctrlPanel As Panel
    Friend WithEvents btnDraw As Button
    Friend WithEvents tbxN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbxResolution As TextBox
    Friend WithEvents _cbxParametricPlot As CheckBox
End Class
