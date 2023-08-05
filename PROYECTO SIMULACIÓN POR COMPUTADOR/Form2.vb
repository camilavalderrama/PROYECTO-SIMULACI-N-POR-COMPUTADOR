Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim form1 As Form1 = CType(Application.OpenForms("Form1"), Form1)
        If form1 IsNot Nothing Then
            Dim datosDataGridView2 As DataTable = form1.ObtenerDatosDataGridView2()
            DataGridView2.DataSource = datosDataGridView2
        End If
    End Sub
End Class