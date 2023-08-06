Imports System.ComponentModel
Public Class Form1
    Dim v0x, v0y, t As Double
    Dim g As Double = 9.81
    Dim velocidadInicial As Double = 50
    Dim x, y As Double
    Dim gBmp As Graphics
    Dim bmp As Bitmap
    Dim anguloActual As Double = 30
    Dim circleX, circleY As Integer
    Dim AlturaMaxima, TiempoVuelo, distanciaMaximaX As Double
    Dim cantidadInterseccion As Integer
    Dim trayectorias As New List(Of List(Of Point))()
    Dim filaMayorAltura As DataRow = Nothing
    Dim mayorAltura As Double = Double.MinValue
    Dim alturaMinima As Double = Double.MaxValue

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
        Console.WriteLine(angulo & " Angulo")
        Console.WriteLine(velocidadInicial & " velocidad")
        Dim v0x, v0y, t As Double
        Dim x, y As Double

        InicializarSimulacion()

        v0x = velocidadInicial * Math.Cos(angulo * Math.PI / 180)
        v0y = velocidadInicial * Math.Sin(angulo * Math.PI / 180)
        t = 0
        x = 0
        y = PictureBox1.Height
        Dim trayectoriaActual As New List(Of Point)()

        distanciaMaximaX = (Math.Pow(velocidadInicial, 2) * Math.Sin((angulo * 2) * Math.PI / 180)) / g
        Do While x >= 0
            t += 0.9
            x = v0x * t
            y = PictureBox1.Height - (v0y * t - 0.5 * g * t ^ 2)
            Dim currentPoint As Point = New Point(CInt(x), CInt(y))
            trayectoriaActual.Add(currentPoint)
            trayectorias.Add(New List(Of Point)(trayectoriaActual))

            PictureBox1.Invoke(Sub()
                                   DibujarTrayectorias(trayectorias)
                               End Sub)

            If ((((Math.Round(x) - circleX) <= 10 And (Math.Round(x) - circleX) >= -1) And (Math.Round(y) - circleY) <= 10 And (Math.Round(y) - circleY) >= -10)) Then
                ' Validar que el valor del angulo y la velocidad no existan en la tabla
                Dim filaExistente As DataGridViewRow = BuscarFilaExistente(anguloActual, velocidadInicial)
                If filaExistente Is Nothing Then
                    ' Agregar ek valor a la tabla
                    Console.WriteLine("Intersecta en " & x & ", " & y)
                    AlturaMaxima = (Math.Pow(v0y, 2) * Math.Pow(Math.Sin(anguloActual * Math.PI / 180), 2)) / (2 * g)

                    Me.BeginInvoke(Sub()
                                       DataGridView2.Rows.Add(anguloActual, velocidadInicial, x, y)
                                   End Sub)
                    ' Aumentar la cantidad de intersecciones
                    anguloActual += 1
                    velocidadInicial = velocidadInicial
                    cantidadInterseccion += 1
                    SimularProyectil(anguloActual)
                End If
            End If
            If y >= 0 Then

                If x >= distanciaMaximaX OrElse anguloActual > 60 Then
                    If anguloActual > 60 And velocidadInicial > 100 Then
                        PictureBox1.Invoke(Sub()
                                               Label3.Text = cantidadInterseccion
                                           End Sub)

                        PictureBox1.Invoke(Sub()
                                               Form2.Show()
                                           End Sub)
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




    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        ' Dibujar el circulo en la posicion aleatoria
        e.Graphics.FillEllipse(Brushes.Black, circleX, circleY - 10, 10, 10)
    End Sub

    Private Sub DibujarTrayectorias(trayectorias As List(Of List(Of Point)))
        For Each trayectoria As List(Of Point) In trayectorias
            If trayectoria.Count > 1 Then
                Dim pen As New Pen(Color.Red)
                Dim prevPoint As Point = trayectoria(0)

                For i As Integer = 1 To trayectoria.Count - 1
                    gBmp.DrawLine(pen, prevPoint, trayectoria(i))
                    prevPoint = trayectoria(i)
                Next
            End If
        Next

        PictureBox1.Refresh()
    End Sub

    Public Function ObtenerDatosDataGridView2Form1() As List(Of Tuple(Of Double, Double))
        Dim datos As New List(Of Tuple(Of Double, Double))

        For Each fila As DataGridViewRow In DataGridView2.Rows
            Dim angulo As Double = Convert.ToDouble(fila.Cells("Angulo").Value)
            Dim velocidad As Double = Convert.ToDouble(fila.Cells("Velocidad").Value)
            datos.Add(New Tuple(Of Double, Double)(angulo, velocidad))
        Next

        Return datos
    End Function


End Class
