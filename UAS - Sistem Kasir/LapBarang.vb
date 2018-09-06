Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.Odbc

Public Class LapBarang
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand

    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=kasir"
        con.Open()
    End Sub

    Sub simpan()
        koneksi()
        Dim sql As String = "insert into tbbarang values('" & barang.tkode.Text & "','" & barang.tbarang.Text & "','" & barang.tharga.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")

        End Try
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        koneksi()
        da = New OdbcDataAdapter("select *from tbbarang order by kode_barang asc",
        con)
        dt = New DataTable
        da.Fill(dt)

        Dim report As New ReportDocument
        report.Load("..\..\BarangReport.rpt")

        report.SetParameterValue("KODEBARANG", barang.tkode.Text)
        report.SetParameterValue("NAMABARANG", barang.tbarang.Text)
        report.SetParameterValue("HARGA", barang.tharga.Text)

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        simpan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class