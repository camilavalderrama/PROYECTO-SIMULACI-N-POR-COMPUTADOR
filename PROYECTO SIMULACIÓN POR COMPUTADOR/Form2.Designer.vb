<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Angulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Velocidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlturaMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TiempoVuelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnguloMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VelocidadMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlturaMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TvMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Xmin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(249, 72)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(460, 280)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(249, 437)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(460, 280)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart2"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Angulo, Me.Velocidad, Me.AlturaMax, Me.TiempoVuelo, Me.DisX})
        Me.DataGridView1.Location = New System.Drawing.Point(740, 72)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(460, 280)
        Me.DataGridView1.TabIndex = 2
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AnguloMin, Me.VelocidadMin, Me.AlturaMin, Me.TvMin, Me.Xmin})
        Me.DataGridView2.Location = New System.Drawing.Point(740, 437)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(460, 280)
        Me.DataGridView2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(481, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(614, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = " Trayectoria que interseca con la máxima altura" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Maiandra GD", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(486, 380)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(609, 32)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = " Trayectoria que interseca con la mínima altura"
        '
        'Angulo
        '
        Me.Angulo.HeaderText = "Angulo"
        Me.Angulo.Name = "Angulo"
        '
        'Velocidad
        '
        Me.Velocidad.HeaderText = "Velocidad"
        Me.Velocidad.Name = "Velocidad"
        '
        'AlturaMax
        '
        Me.AlturaMax.HeaderText = "AlturaMax"
        Me.AlturaMax.Name = "AlturaMax"
        '
        'TiempoVuelo
        '
        Me.TiempoVuelo.HeaderText = "Tv"
        Me.TiempoVuelo.Name = "TiempoVuelo"
        '
        'DisX
        '
        Me.DisX.HeaderText = "DisX"
        Me.DisX.Name = "DisX"
        '
        'AnguloMin
        '
        Me.AnguloMin.HeaderText = "AnguloMin"
        Me.AnguloMin.Name = "AnguloMin"
        Me.AnguloMin.Width = 40
        '
        'VelocidadMin
        '
        Me.VelocidadMin.HeaderText = "VelocidadMin"
        Me.VelocidadMin.Name = "VelocidadMin"
        Me.VelocidadMin.Width = 40
        '
        'AlturaMin
        '
        Me.AlturaMin.HeaderText = "AlturaMin"
        Me.AlturaMin.Name = "AlturaMin"
        Me.AlturaMin.Width = 40
        '
        'TvMin
        '
        Me.TvMin.HeaderText = "TvMin"
        Me.TvMin.Name = "TvMin"
        Me.TvMin.Width = 40
        '
        'Xmin
        '
        Me.Xmin.HeaderText = "DxMin"
        Me.Xmin.Name = "Xmin"
        Me.Xmin.Width = 40
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GrayText
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Angulo As DataGridViewTextBoxColumn
    Friend WithEvents Velocidad As DataGridViewTextBoxColumn
    Friend WithEvents AlturaMax As DataGridViewTextBoxColumn
    Friend WithEvents TiempoVuelo As DataGridViewTextBoxColumn
    Friend WithEvents DisX As DataGridViewTextBoxColumn
    Friend WithEvents AnguloMin As DataGridViewTextBoxColumn
    Friend WithEvents VelocidadMin As DataGridViewTextBoxColumn
    Friend WithEvents AlturaMin As DataGridViewTextBoxColumn
    Friend WithEvents TvMin As DataGridViewTextBoxColumn
    Friend WithEvents Xmin As DataGridViewTextBoxColumn
End Class
