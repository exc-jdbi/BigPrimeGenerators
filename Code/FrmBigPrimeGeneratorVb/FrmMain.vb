'Copyright(c) update 2024 the exc-jdbi
'All rights reserved, see license.
'https://github.com/exc-jdbi/BigPrimeGenerators

Option Strict On
Option Explicit On

Imports System.Text
Imports System.Numerics
Imports System.Drawing
Imports System.Windows.Forms
Imports exc.jdbi.VeryBigPrimes.Generators

Namespace exc.jdbi.VeryBigPrimes.Generators
  Public Class FrmMain

    Private Sub TcMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TcMain.DrawItem
      Try
        Dim forebrush As Brush
        Dim font As Font = e.Font
        font = New Font(font.FontFamily, font.Size - 1.5F)

        If e.Index = Me.TcMain.SelectedIndex Then
          font = New Font(font, FontStyle.Bold Or FontStyle.Italic)
          forebrush = New SolidBrush(SystemColors.WindowText)
        Else forebrush = New SolidBrush(e.ForeColor)
        End If

        Dim tabtext = Me.TcMain.TabPages(e.Index).Text
        Using sf = New StringFormat With {.Alignment = StringAlignment.Center}
          e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), e.Bounds)
          Dim rect = e.Bounds
          Using fb = forebrush
            rect = New Rectangle(rect.X, rect.Y + 3, rect.Width, rect.Height - 3)
            e.Graphics.DrawString(tabtext, font, fb, rect, sf)
          End Using
        End Using
      Catch Ex As Exception
        MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
    End Sub

    Private Sub Buttons_Click(sender As Object, e As EventArgs)
      Select Case True
        Case sender Is Me.BtIsPrime : Me.PcIsPrimeAsync()
        Case sender Is Me.BtPcClipBoard : Me.PcClipBoard()

        Case sender Is Me.BtLpgGenerate : Me.LpgGenerateAsync()
        Case sender Is Me.BtLpgClipBoard : Me.LpgClipBoard()

        Case sender Is Me.BtPgSave : Me.SaveData()
        Case sender Is Me.BtPgLaod : Me.LoadData()

        Case sender Is Me.BtPgClipBoard : Me.PgClipBoard()
        Case sender Is Me.BtPgGeneratePrimes : Me.PgGeneratePrimesAsync()

        Case sender Is Me.TcMain : Me.TabControlSelectedIndexChangedAsync()
      End Select
    End Sub

    Private Async Sub TabControlSelectedIndexChangedAsync()
      Me.TbPcPrime.Clear()
      Me.TbLpgPrime.Clear()
      Me.TbPgPrimes.Clear()
      Me.LbBits.Text = String.Empty
      Me.TbLpgLength.Text = 100.ToString()
      Me.BtPgClipBoard.Enabled = False
      Me.BtPgClipBoard.Enabled = False
      Me.BtLpgClipBoard.Enabled = False
      Dim sb = New StringBuilder()

      If Me.TcMain.SelectedIndex = 3 Then
        sb.AppendLine((Await BigPrimeGenerator.RngBigPrimesAsync(50, 1))(0).ToString())
        sb.AppendLine()
        sb.AppendLine((Await BigPrimeGenerator.RngBigPrimesAsync(50, 1))(0).ToString())
        Me.TbPcPrime.Text = sb.ToString()
      End If
    End Sub

    Private Sub SaveData()
      SaveDataSFD(Me.TbPgPrimes.Text)
    End Sub

    Private Sub LoadData()
      Me.TbPgPrimes.Text = LoadDataOFD()
      Me.BtPgClipBoard.Enabled = True
    End Sub

    Private Sub PgClipBoard()
      Dim txt = Me.TbPgPrimes.Text
      If Not String.IsNullOrEmpty(txt) Then SetClipBoard(txt)
    End Sub

    Private Async Sub PgGeneratePrimesAsync()
      Me.BtPgClipBoard.Enabled = False

      If Not Await BigPrimeGenerator.IsNumericAsync(Me.TbPgMin.Text) Then
        Message(0, "MIN")
        Return
      End If

      If Not Await BigPrimeGenerator.IsNumericAsync(Me.TbPgMax.Text) Then
        Message(0, "MAX")
        Return
      End If

      If Not Await BigPrimeGenerator.IsNumericAsync(Me.TbPgCount.Text) Then
        Message(0, "COUNT")
        Return
      End If

      Dim cnt As Int32 = Nothing
      If Int32.TryParse(Me.TbPgCount.Text, cnt) Then
        Me.BtPgGeneratePrimes.Enabled = False
        Dim min = BigInteger.Parse(Me.TbPgMin.Text)
        Dim max = BigInteger.Parse(Me.TbPgMax.Text)
        Dim sb = New StringBuilder()
        Dim result = Await BigPrimeGenerator.RngBigPrimesAsync(min, max, cnt)
        sb.Append(String.Join(Environment.NewLine, result))
        Me.TbPgPrimes.Text = sb.ToString()
        Me.BtPgClipBoard.Enabled = True
      End If

      Me.BtPgGeneratePrimes.Enabled = True
    End Sub

    Private Async Sub LpgGenerateAsync()
      Me.LbBits.Text = String.Empty
      Me.BtLpgClipBoard.Enabled = False

      If Not BigPrimeGenerator.IsNumeric(Me.TbLpgLength.Text) Then
        Message(0, "LENGTH")
        Return
      End If

      Dim cnt As Int32 = Nothing
      If Integer.TryParse(Me.TbLpgLength.Text, cnt) Then
        Me.BtLpgGenerate.Enabled = False
        Dim prime = (Await BigPrimeGenerator.RngBigPrimesAsync(cnt, 1))(0)
        If prime < 2 Then Throw New ArgumentException($"An error has occurred.", NameOf(prime))
        Me.LbBits.Text = $"{BigInteger.Log2(prime) + 1} bits"
        Me.TbLpgPrime.Text = prime.ToString()
        Me.BtLpgGenerate.Enabled = True
        Me.BtLpgClipBoard.Enabled = True
        If Integer.Parse(Me.TbLpgLength.Text) > 100 Then Me.TbLpgLength.Text = "100"
        Return
      End If

      Throw New NotImplementedException()
    End Sub

    Private Sub LpgClipBoard()
      Me.LbBits.Text = String.Empty
      Dim txt = Me.TbLpgPrime.Text
      If Not String.IsNullOrEmpty(txt) Then SetClipBoard(txt)
    End Sub

    Private Sub PrintMsg(msg As String)
      MessageBox.Show(msg, "Info PFPG System")
    End Sub

    Private Async Sub PcIsPrimeAsync()
      Dim txt = Me.TbPcPrime.Lines
      txt = txt.Where(Function(line) Not String.IsNullOrEmpty(line)).ToArray()
      Me.BtIsPrime.Enabled = False
      Me.BtPcClipBoard.Enabled = False
      Dim iter = 0

      For Each line In txt
        iter += 1

        If Not Await BigPrimeGenerator.IsNumericAsync(line.Trim()) Then
          Me.PrintMsg($"index: {iter} is not a Number")
          Me.BtIsPrime.Enabled = True
          Me.BtPcClipBoard.Enabled = True
          Return
        End If

        Dim is_prime = Await Task.Run(Function() BigPrimeGenerator.IsMRPrime(BigInteger.Parse(line.Trim())))

        If Not is_prime Then
          Me.PrintMsg($"index: {iter} is not a Prime")
          Me.BtIsPrime.Enabled = True
          Me.BtPcClipBoard.Enabled = True
          Return
        End If
      Next

      Me.BtIsPrime.Enabled = True
      Me.BtPcClipBoard.Enabled = True
      Me.PrintMsg(True.ToString())
    End Sub

    Private Sub PcClipBoard()
      Dim txt = Me.TbPcPrime.Text
      If Not String.IsNullOrEmpty(txt) Then SetClipBoard(txt)
    End Sub

    Private Shared Sub SetClipBoard(number As String)
      Clipboard.Clear()
      If Not String.IsNullOrEmpty(number) Then Clipboard.SetText(number)
    End Sub

    Private Shared Sub Message(id As Integer, Optional message As String = "")
      Dim msg = String.Empty

      Select Case id
        Case 0 : msg = $"Please enter a number. in [{message}]"
        Case 1 : msg = $"Cannot read file from disk"
      End Select

      If Not String.IsNullOrEmpty(msg) Then MessageBox.Show(msg, "Info PFPG System")
    End Sub


    Public Sub New()

      Me.InitializeComponent()
      Me.TcMain.BackColor = Color.Transparent
      Me.TcMain.DrawMode = TabDrawMode.OwnerDrawFixed
      'AddHandler Me.TcMain.DrawItem, New DrawItemEventHandler(AddressOf Me.TcMain_DrawItem)

      Me.TcMain.SelectedIndex = 0
    End Sub
  End Class
End Namespace