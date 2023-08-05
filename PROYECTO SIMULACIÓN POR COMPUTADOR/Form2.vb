Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim form1 As Form1 = CType(Application.OpenForms("Form1"), Form1)
        If form1 IsNot Nothing Then
            Dim resultTuple As Tuple(Of DataTable, Double, Double) = form1.ObtenerDatosDataGridView2()
            Dim datosDataTable As DataTable = resultTuple.Item1
            Dim alturaMaxima As Double = resultTuple.Item2
            Dim alturaMinima As Double = resultTuple.Item3

            DataGridView1.DataSource = datosDataTable.Clone() ' Clonar la estructura de columnas
            DataGridView1.Rows.Add(alturaMaxima)

            DataGridView2.DataSource = datosDataTable.Clone() ' Clonar la estructura de columnas
            DataGridView2.Rows.Add(alturaMinima)
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class