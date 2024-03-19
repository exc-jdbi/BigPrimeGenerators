'Copyright(c) update 2024 the exc-jdbi
'All rights reserved, see license.
'https://github.com/exc-jdbi/BigPrimeGenerators

Option Strict On
Option Explicit On


Imports System.Windows.Forms

Namespace exc.jdbi.VeryBigPrimes.Generators
  Public Module Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Public Sub Main()

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      Application.Run(New FrmMain())
    End Sub
  End Module
End Namespace
