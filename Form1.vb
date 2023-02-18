Imports System.IO

Public Class Form1

    Private Sub txtFilePath_TextChanged(sender As Object, e As EventArgs) Handles txtFilePath.TextChanged

    End Sub

    Private Sub textContent_TextChanged(sender As Object, e As EventArgs) Handles txtContent.TextChanged

    End Sub

    Private Sub txtCount_TextChanged(sender As Object, e As EventArgs) Handles txtCount.TextChanged

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Menampilkan dialog untuk memillih file
        Dim openFileDialog As New OpenFileDialog()

        'Mengatur filter agar hanya menampilkan file text
        openFileDialog.Filter = "Text (*.txt)|*.txt"

        'Menampilkan dialog dan memeriksa apakah pengguna menekan tombol OK
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            'Menampilkan path file yang dipilih di TextBox
            txtFilePath.Text = openFileDialog.FileName

            'Membaca isi file dan menampilkan di TextBox
            Dim fileReader As StreamReader = New StreamReader(openFileDialog.FileName)
            txtContent.Text = fileReader.ReadToEnd()
            fileReader.Close()
        End If
    End Sub

    Private Sub btnCount_Click(sender As Object, e As EventArgs) Handles btnCount.Click
        'Menghitung jumlah kata dalam teks yang dimasukkan
        Dim text As String = txtContent.Text
        Dim wordCount As Integer = 0

        'Membuat array kata dari teks yang dimasukkan
        Dim words() As String = text.Split(" "c)

        'Menghitung jumlah kata dalam array
        For Each word As String In words
            wordCount += 1
        Next

        'Menampilkan pesan jika teks tidak mengandung kata
        If wordCount = 1 Then
            wordCount = 0
            MessageBox.Show("Teks tidak mengandung kata")
        End If

        'Menampilkan hasil perhitungan di TextBox
        txtCount.Text = wordCount.ToString()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Menghapus isi TextBox
        txtFilePath.Clear()
        txtContent.Clear()
        txtCount.Clear()
    End Sub
End Class
