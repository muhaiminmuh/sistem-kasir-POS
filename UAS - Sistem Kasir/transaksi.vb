Imports System.Data.Odbc

Public Class transaksi
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
        Dim sql As String = "insert into tbtransaksi values('" & tkodetransaksi.Text & "','" & ttanggal.Text & "','" & cbadmin.Text & "','" & cbkodebarang.Text & "','" & tnamabrg.Text & "','" & tjumlah.Text & "','" & ttotal.Text & "','" & tuang.Text & "','" & tkembali.Text & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub

    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbtransaksi order by kode_transaksi asc",
                con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8))
            Next
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Sub tampiladmin()
        cmd = New OdbcCommand("select id_admin from tbadmin", con)
        dr = cmd.ExecuteReader
        cbadmin.Items.Clear()
        Do While dr.Read
            cbadmin.Items.Add(dr.Item("id_admin"))
        Loop
    End Sub

    Sub tampilbarang()
        cmd = New OdbcCommand("select kode_barang from tbbarang", con)
        dr = cmd.ExecuteReader
        cbkodebarang.Items.Clear()
        Do While dr.Read
            cbkodebarang.Items.Add(dr.Item("kode_barang"))
        Loop
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        tampiladmin()
        tampilbarang()
    End Sub

    Private Sub cbadmin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbadmin.SelectedIndexChanged
        cmd = New OdbcCommand("select *from tbadmin where id_admin='" & cbadmin.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            tnama.Text = dr.Item("nama_admin")
            talamat.Text = dr.Item("alamat_admin")
            tno.Text = dr.Item("no")
        Else
            MsgBox("ID Admin Tidak Ditemukan")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        simpan()
    End Sub


    Private Sub cbkodebarang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbkodebarang.SelectedIndexChanged
        cmd = New OdbcCommand("select *from tbbarang where kode_barang='" & cbkodebarang.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            tnamabrg.Text = dr.Item("nama_barang")
            tharga.Text = dr.Item("harga")
        Else
            MsgBox("Kode Barang Tidak Ditemukan")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tampil()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Data Transaksi yang dihapus belum DIPILIH")
        Else
            If (MessageBox.Show("Anda yakin menghapus data dengan Kode Transaksi=" & a &
            "...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) =
            Windows.Forms.DialogResult.OK) Then
                koneksi()
                cmd = New OdbcCommand("delete from tbtransaksi where kode_transaksi='" & a &
                "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Menghapus data BERHASIL", vbInformation, "INFORMASI")
                con.Close()
                tampil()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cbadmin.Text = ""
        tnama.Text = ""
        talamat.Text = ""
        tno.Text = ""
        cbkodebarang.Text = ""
        tnamabrg.Text = ""
        tharga.Text = 0
        tkodetransaksi.Text = ""
        ttanggal.Text = ""
        ttotal.Text = 0
        tuang.Text = 0
        tkembali.Text = 0
        tjumlah.Text = 0
    End Sub

    Private Sub tjumlah_TextChanged(sender As Object, e As EventArgs) Handles tjumlah.TextChanged
        Dim harga As Integer
        Dim jumlah As Integer
        Dim total As Single

        harga = CInt(tharga.Text)
        jumlah = CInt(tjumlah.Text)

        total = CSng((harga * jumlah))
        ttotal.Text = total
    End Sub

    Private Sub tuang_TextChanged(sender As Object, e As EventArgs) Handles tuang.TextChanged
        Dim uang As Integer
        Dim total As Single
        Dim kembali As Single

        total = CInt(ttotal.Text)
        uang = CInt(tuang.Text)

        kembali = CSng((uang - total))
        tkembali.Text = kembali
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        LapTransaksiALL.Show()
    End Sub
End Class