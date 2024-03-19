'Copyright(c) update 2024 the exc-jdbi
'All rights reserved, see license.
'https://github.com/exc-jdbi/BigPrimeGenerators

Option Strict On
Option Explicit On

Imports System.Text
Imports System.Windows.Forms

Namespace exc.jdbi.VeryBigPrimes.Generators
  Friend Module ServicesUtils
    Public Sub SaveDataSFD(savetxt As String)
      Using sfd = New SaveFileDialog()

        If True Then
          sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
          sfd.FilterIndex = 2
          sfd.InitialDirectory = Application.StartupPath
          sfd.RestoreDirectory = True
          If sfd.ShowDialog() = DialogResult.OK Then
            Using mystream = sfd.OpenFile()
              If mystream IsNot Nothing Then
                Dim buffer = Encoding.UTF8.GetBytes(savetxt)
                mystream.Write(buffer, 0, buffer.Length)
                mystream.Close()
              End If
            End Using
          End If
        End If
      End Using
    End Sub

    Public Function LoadDataOFD() As String
      Dim result = String.Empty
      If True Then
        Using ofd = New OpenFileDialog()
          ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
          ofd.FilterIndex = 2
          ofd.InitialDirectory = Application.StartupPath
          ofd.RestoreDirectory = True
          Try
            If ofd.ShowDialog() = DialogResult.OK Then
              Using mystream = ofd.OpenFile()
                If mystream IsNot Nothing Then
                  Dim len = Convert.ToInt32(mystream.Length)
                  Dim buffer = New Byte(len - 1 + 1 - 1) {}
                  mystream.Read(buffer, 0, buffer.Length)
                  result = Encoding.UTF8.GetString(buffer)
                End If
              End Using
            End If
          Catch ex As Exception
            MessageBox.Show($"Can not read file: {ex}", "Info PFPG System")
          End Try
        End Using
      End If
      Return result
    End Function
  End Module
End Namespace
