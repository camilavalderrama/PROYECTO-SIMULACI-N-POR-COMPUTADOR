Public Class Form2
    Dim AlturaMaxima As Double
    Dim alturaMaximaTem As Double = 0
    Dim alturaMinTem As Double = Double.MaxValue
    Dim TiempoVueloMax, TiempoVueloMin As Double
    Dim DisMax, DisMin As Double
    Dim angulo1, velocidad1, anguloTem, velTem, anguloTemMin, velTemMin As Double
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim form1 As Form1 = CType(Application.OpenForms("Form1"), Form1)
        If form1 IsNot Nothing Then
            Dim datos As List(Of Tuple(Of Double, Double)) = form1.ObtenerDatosDataGridView2Form1()
            ' Ahora puedes trabajar con los datos obtenidos
            For Each dato As Tuple(Of Double, Double) In datos
                angulo1 = dato.Item1
                velocidad1 = dato.Item2
                'AlturaMaxima = (Math.Pow(1, 2) * Math.Pow(Math.Sin(angulo * Math.PI / 180), 2)) / (2 * 9, 81)
                alturaMaxima = ((Math.Pow(velocidad1, 2) * Math.Pow(Math.Sin(angulo1 * Math.PI / 180), 2)) / (2 * 9.81))
                If alturaMaximaTem < AlturaMaxima And angulo1 > 0 And velocidad1 > 0 Then

                    alturaMaximaTem = AlturaMaxima
                    anguloTem = angulo1
                    velTem = velocidad1
                    TiempoVueloMax = (2 * velTem * Math.Sin(anguloTem * Math.PI / 180)) / 9.81
                    DisMin = velTem * Math.Cos(anguloTem * Math.PI / 180) * TiempoVueloMax
                End If
                If AlturaMaxima < alturaMinTem And angulo1 > 0 And velocidad1 > 0 Then
                    alturaMinTem = AlturaMaxima
                    anguloTemMin = angulo1
                    velTemMin = velocidad1
                    TiempoVueloMin = (2 * velTemMin * Math.Sin(anguloTemMin * Math.PI / 180)) / 9.81
                    DisMin = velTemMin * Math.Cos(anguloTemMin * Math.PI / 180) * TiempoVueloMin
                End If
            Next
            DataGridView1.Rows.Add(anguloTem, velTem, Math.Round(alturaMaximaTem, 2), Math.Round(TiempoVueloMax, 2), Math.Round(DisMax, 2))
            Chart1.Series(0).Points.Clear()
            Chart2.Series(0).Points.Clear()

            For t As Double = 0 To TiempoVueloMax Step 0.1
                Dim yt As Double = velTem * Math.Sin(anguloTem * Math.PI / 180) * t - 0.5 * 9.81 * t ^ 2
                Chart1.Series(0).Points.AddXY(t, yt)

            Next
            Chart1.Titles.Add("Gráfico del Movimiento Parabólico Máximo")
            Chart1.ChartAreas(0).AxisX.Title = "Tiempo (s)"
            Chart1.ChartAreas(0).AxisY.Title = "Altura (m)"
            Chart1.Series(0).Name = "Movimiento Parabólico"
            For t1 As Double = 0 To TiempoVueloMin Step 0.1
                Dim yt As Double = velTemMin * Math.Sin(anguloTemMin * Math.PI / 180) * t1 - 0.5 * 9.81 * t1 ^ 2
                Chart2.Series(0).Points.AddXY(t1, yt)
            Next
            Chart2.Titles.Add("Gráfico del Movimiento Parabólico Mínimo")
            Chart2.ChartAreas(0).AxisX.Title = "Tiempo (s)"
            Chart2.ChartAreas(0).AxisY.Title = "Altura (m)"
            Chart2.Series(0).Name = "Movimiento Parabólico"
            DataGridView2.Rows.Add(anguloTemMin, velTemMin, Math.Round(alturaMinTem, 2), Math.Round(TiempoVueloMin, 2), Math.Round(DisMin, 2))
        End If
    End Sub
End Class