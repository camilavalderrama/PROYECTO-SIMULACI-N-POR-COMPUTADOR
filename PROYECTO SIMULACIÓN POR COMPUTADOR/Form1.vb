Public Class Form1
    Dim v0x, v0y, t As Double
    Dim g As Double = 9.81
    Dim velocidadInicial As Double = 50
    Dim x, y As Double
    Dim gBmp As Graphics
    Dim bmp As Bitmap
    Dim anguloActual As Double = 30 ' Ángulo inicial
    Dim prevX, prevY As Double ' Coordenadas del punto anterior
    Dim circleX, circleY As Integer ' Coordenadas del círculo



    Dim cantidadInterseccion As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarSimulacion()
        circleX = New Random().Next(200, 501) ' Entre 200 y 500
        circleY = PictureBox1.Height - New Random().Next(10, 30) ' Entre 100 y 300, invertido
        Console.WriteLine("X circulo: " & circleX & " Y circulo: " & circleY)
    End Sub

    Private Sub InicializarSimulacion()
        Timer1.Interval = 1 ' Intervalo de actualización en milisegundos
        Timer1.Start() 'Iniciar el timer      
        ' Crear un bitmap para dibujar la trayectoria
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        gBmp = Graphics.FromImage(bmp)
        PictureBox1.Image = bmp
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        v0x = velocidadInicial * Math.Cos(anguloActual * Math.PI / 180) ' Formula para la velocidad inicial en X
        v0y = velocidadInicial * Math.Sin(anguloActual * Math.PI / 180) ' Formula para la velocidad inicial en Y
        t += 0.05 ' Incrementar el tiempo

        ' Calcular nuevas coordenadas x e y
        x = v0x * t
        y = PictureBox1.Height - (v0y * t - 0.5 * g * t ^ 2) ' Ajustar la coordenada Y para que inicie en la parte de abajo del PICTUREBOX


        Dim tiempoMaximo As Double = v0y / g ' Formula para encontrar el tiempo máximo
        Dim distanciaMaximaX As Double = (Math.Pow(velocidadInicial, 2) * Math.Sin((anguloActual * 2) * Math.PI / 180)) / g ' Formula para saber la distancia maxima que se puede recorrer

        ' Condicional para saber si se interseca con el circulo, sabiendo que, se debe poner un limite de 10 pixeles, por el tamaño del circulo
        If (((Math.Round(x) - circleX) <= 2 And (Math.Round(x) - circleX) >= 0) And (Math.Round(y) - circleY) <= 2 And (Math.Round(y) - circleY) >= -10) Then
            ' Validar que el valor del angulo y la velocidad no existan en la tabla
            Dim filaExistente As DataGridViewRow = BuscarFilaExistente(anguloActual, velocidadInicial)
            If filaExistente Is Nothing Then
                ' Agregar ek valor a la tabla

                DataGridView2.Rows.Add(anguloActual, velocidadInicial)
                ' Aumentar la cantidad de intersecciones
                cantidadInterseccion += 1
            End If
        End If

        If x >= distanciaMaximaX OrElse anguloActual > 61 Then
            PictureBox1.Refresh()
            Console.WriteLine("Angulo: " & anguloActual & " velocidad: " & velocidadInicial)
            If anguloActual > 60 And velocidadInicial >= 100 Then
                Console.WriteLine("Hola")
                Label3.Text = cantidadInterseccion
                Form2.Show()
                Timer1.Enabled = False
            Else
                If anguloActual > 60 And velocidadInicial < 100 Then
                    anguloActual = 30
                    velocidadInicial += 1
                End If
                ' Incrementar el ángulo actual y reiniciar la simulación
                anguloActual += 1
                prevX = -1 ' Reiniciar la coordenada X anterior
                prevY = -1 ' Reiniciar la coordenada Y anterior
                ReiniciarSimulacion()
            End If
        Else
            ' Dibujar una línea desde el punto anterior al actual
            If prevX <> -1 AndAlso prevY <> -1 Then
                gBmp.DrawLine(Pens.Black, CInt(prevX), CInt(prevY), CInt(x), CInt(y))
            End If
            prevX = x ' Almacenar la coordenada X actual como previa
            prevY = y ' Almacenar la coordenada Y actual como previa
            PictureBox1.Refresh()
        End If
    End Sub

    Private Sub ReiniciarSimulacion()
        t = 0 ' Reiniciar el tiempo
        x = 0 ' Reiniciar las coordenadas
        y = 0
        gBmp.Clear(Color.Transparent) ' Limpiar el gráfico actual, pero mantén la gráfica existente
        Timer1.Start()
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        ' Dibujar el circulo en la posicion aleatoria
        e.Graphics.FillEllipse(Brushes.Black, circleX, circleY - 10, 10, 10)
    End Sub

    Private Function BuscarFilaExistente(angulo As Double, velocidad As Double) As DataGridViewRow
        For Each fila As DataGridViewRow In DataGridView2.Rows
            If fila.Cells("Angulo").Value = anguloActual AndAlso fila.Cells("Velocidad").Value = velocidadInicial Then
                Return fila
            End If
        Next
        Return Nothing
    End Function
End Class
