<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADBox2
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Me.components = New System.ComponentModel.Container()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.dateBox = New System.Windows.Forms.TextBox()
        Me.monthBox = New System.Windows.Forms.TextBox()
        Me.yearBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnDown
        '
        Me.btnDown.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDown.Location = New System.Drawing.Point(168, 26)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(15, 17)
        Me.btnDown.TabIndex = 9
        Me.btnDown.Text = "▼"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Font = New System.Drawing.Font("MS UI Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUp.Location = New System.Drawing.Point(168, 10)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(15, 17)
        Me.btnUp.TabIndex = 8
        Me.btnUp.Text = "▲"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'dateBox
        '
        Me.dateBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dateBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.dateBox.Location = New System.Drawing.Point(120, 17)
        Me.dateBox.MaxLength = 2
        Me.dateBox.Name = "dateBox"
        Me.dateBox.Size = New System.Drawing.Size(22, 22)
        Me.dateBox.TabIndex = 2
        '
        'monthBox
        '
        Me.monthBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.monthBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.monthBox.Location = New System.Drawing.Point(76, 17)
        Me.monthBox.MaxLength = 2
        Me.monthBox.Name = "monthBox"
        Me.monthBox.Size = New System.Drawing.Size(22, 22)
        Me.monthBox.TabIndex = 1
        '
        'yearBox
        '
        Me.yearBox.Font = New System.Drawing.Font("MS UI Gothic", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.yearBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.yearBox.Location = New System.Drawing.Point(14, 17)
        Me.yearBox.MaxLength = 4
        Me.yearBox.Name = "yearBox"
        Me.yearBox.Size = New System.Drawing.Size(39, 22)
        Me.yearBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "年"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(99, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "月"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(142, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "日"
        '
        'ADBox2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.dateBox)
        Me.Controls.Add(Me.monthBox)
        Me.Controls.Add(Me.yearBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Name = "ADBox2"
        Me.Size = New System.Drawing.Size(196, 53)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents dateBox As System.Windows.Forms.TextBox
    Friend WithEvents monthBox As System.Windows.Forms.TextBox
    Friend WithEvents yearBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer

End Class
