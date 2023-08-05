Imports System.ComponentModel
Public Class Form1
    Dim v0x, v0y, t As Double
    Dim g As Double = 9.81
    Dim velocidadInicial As Double = 50
    Dim x, y As Double
    Dim gBmp As Graphics
    Dim bmp As Bitmap
    Dim anguloActual As Double = 30
    Dim prevX, prevY As Double
    Dim circleX, circleY As Integer
    Dim AlturaMaxima, TiempoVuelo, distanciaMaximaX As Double
    Dim cantidadInterseccion As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        circleX = New Random().Next(200, 501) ' Entre 200 y 500
        circleY = PictureBox1.Height - New Random().Next(100, 300) ' Entre 100 y 300, invertido
        Console.WriteLine("X circulo: " & circleX & " Y circulo: " & circleY)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Inicia la simulación en un hilo de fondo usando BackgroundWorker
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub InicializarSimulacion()
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gBmp = Graphics.FromImage(bmp)
        PictureBox1.Image = bmp
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        SimularProyectil(anguloActual)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' Simulación completada, aquí puedes realizar acciones posteriores
        MessageBox.Show($"Simulación ha terminado. Cantidad de intersecciones: {cantidadInterseccion}")
        DetenerSimulacion()
    End Sub
    Private Sub DetenerSimulacion()
        PictureBox1.Image = Nothing
        gBmp = Nothing
    End Sub

    Private Sub SimularProyectil(angulo As Double)

        Dim v0x, v0y, t As Double
        Dim x, y As Double

        InicializarSimulacion()

        v0x = velocidadInicial * Math.Cos(angulo * Math.PI / 180)
        v0y = velocidadInicial * Math.Sin(angulo * Math.PI / 180)
        t = 0
        x = 0
        y = PictureBox1.Height

        Dim prevPoint As Point = New Point(CInt(x), CInt(y))
        distanciaMaximaX = (Math.Pow(velocidadInicial, 2) * Math.Sin((angulo * 2) * Math.PI / 180)) / g
        Do While x >= 0
            t += 0.9
            x = v0x * t
            y = PictureBox1.Height - (v0y * t - 0.5 * g * t ^ 2)

            If (((Math.Round(x) - circleX) <= 10 And (Math.Round(x) - circleX) >= -10) And (Math.Round(y) - circleY) <= 10 And (Math.Round(y) - circleY) >= -10) Then
                ' Validar que el valor del angulo y la velocidad no existan en la tabla
                Dim filaExistente As DataGridViewRow = BuscarFilaExistente(anguloActual, velocidadInicial)
                If filaExistente Is Nothing Then
                    ' Agregar ek valor a la tabla
                    Console.WriteLine("Intersecta en " & x & ", " & y)
                    Me.BeginInvoke(Sub()
                                       DataGridView2.Rows.Add(anguloActual, velocidadInicial)
                                   End Sub)
                    ' Aumentar la cantidad de intersecciones
                    cantidadInterseccion += 1
                End If
            End If
            If y >= 0 Then
                PictureBox1.Invoke(Sub()
                                       Dim currentPoint As Point = New Point(CInt(x), CInt(y))
                                       gBmp.DrawLine(Pens.Black, prevPoint, currentPoint)
                                       prevPoint = currentPoint
                                       PictureBox1.Refresh()
                                   End Sub)
                If x >= distanciaMaximaX OrElse anguloActual > 60 Then
                    If anguloActual > 60 And velocidadInicial >= 100 Then
                        PictureBox1.Invoke(Sub()
                                               Label3.Text = cantidadInterseccion
                                           End Sub)

                        PictureBox1.Invoke(Sub()
                                               Form2.Show()
                                           End Sub)
                        MessageBox.Show($"Simulación ha terminado. Cantidad de intersecciones: {cantidadInterseccion}")

                        Exit Sub
                    Else
                        If anguloActual > 60 And velocidadInicial < 100 Then
                            anguloActual = 30
                            velocidadInicial += 1
                            SimularProyectil(anguloActual)
                        End If
                        ' Incrementar el ángulo actual y reiniciar la simulación

                        anguloActual += 1
                        SimularProyectil(anguloActual)
                    End If



                End If
            End If
        Loop


        DetenerSimulacion()
    End Sub

    Private Function BuscarFilaExistente(angulo As Double, velocidad As Double) As DataGridViewRow
        For Each fila As DataGridViewRow In DataGridView2.Rows
            If fila.Cells("Angulo").Value = anguloActual AndAlso fila.Cells("Velocidad").Value = velocidadInicial Then
                Return fila
            End If
        Next
        Return Nothing
    End Function

    Public Function ObtenerDatosDataGridView2() As DataTable
        Dim dt As New DataTable()

        ' Agregar las columnas del DataGridView2
        For Each columna As DataGridViewColumn In DataGridView2.Columns
            dt.Columns.Add(columna.HeaderText)
        Next

        ' Agregar columnas adicionales
        dt.Columns.Add("AlturaMaxima")
        dt.Columns.Add("TiempoVuelo")
        dt.Columns.Add("DistanciaMax")

        Dim filaMayorAltura As DataRow = Nothing
        Dim mayorAltura As Double = Double.MinValue

        For Each fila As DataGridViewRow In DataGridView2.Rows
            Dim row As DataRow = dt.NewRow()
            For Each celda As DataGridViewCell In fila.Cells
                row(celda.ColumnIndex) = celda.Value
            Next

            ' Calcular las propiedades adicionales
            AlturaMaxima = (Math.Pow(v0y, 2) * Math.Pow(Math.Sin(anguloActual * Math.PI / 180), 2)) / (2 * g)
            TiempoVuelo = (2 * v0x * Math.Sin(anguloActual * Math.PI / 180)) / g

            row("AlturaMaxima") = AlturaMaxima
            row("TiempoVuelo") = TiempoVuelo
            row("DistanciaMax") = distanciaMaximaX
            dt.Rows.Add(row)

            ' Comparar y actualizar la fila con la mayor altura
            If AlturaMaxima > mayorAltura Then
                mayorAltura = AlturaMaxima
                filaMayorAltura = row
            End If
        Next

        If filaMayorAltura IsNot Nothing Then
            Dim dtFilaMayor As New DataTable()
            For Each columna As DataColumn In dt.Columns
                dtFilaMayor.Columns.Add(columna.ColumnName)
            Next
            dtFilaMayor.Rows.Add(filaMayorAltura.ItemArray)
            Return dtFilaMayor
        End If

        Return dt
    End Function

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        ' Dibujar el circulo en la posicion aleatoria
        e.Graphics.FillEllipse(Brushes.Black, circleX, circleY - 10, 10, 10)
    End Sub
End Class
