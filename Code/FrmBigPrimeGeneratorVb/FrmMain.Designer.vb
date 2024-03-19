'Copyright(c) update 2024 the exc-jdbi
'All rights reserved, see license.
'https://github.com/exc-jdbi/BigPrimeGenerators

Option Strict On
Option Explicit On

Imports System.Drawing
Imports System.Windows.Forms

Namespace exc.jdbi.VeryBigPrimes.Generators

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
  Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
        If disposing AndAlso components IsNot Nothing Then
          components.Dispose()
        End If
      Finally
        MyBase.Dispose(disposing)
      End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Me.TcMain = New TabControl()
      Me.TpHome = New TabPage()
      Me.PbHomeMain = New PictureBox()
      Me.TpPG = New TabPage()
      Me.TlpPgMain = New TableLayoutPanel()
      Me.TbPgPrimes = New TextBox()
      Me.TlpPgInputs = New TableLayoutPanel()
      Me.TlpPgButtons = New TableLayoutPanel()
      Me.BtPgGeneratePrimes = New Button()
      Me.BtPgClipBoard = New Button()
      Me.BtPgLaod = New Button()
      Me.BtPgSave = New Button()
      Me.LbMax = New Label()
      Me.TbPgMax = New TextBox()
      Me.TbPgMin = New TextBox()
      Me.LbMin = New Label()
      Me.label1 = New Label()
      Me.TbPgCount = New TextBox()
      Me.TpLPG = New TabPage()
      Me.TlpLpgMain = New TableLayoutPanel()
      Me.TbLpgPrime = New TextBox()
      Me.TlpLpgInputButtons = New TableLayoutPanel()
      Me.LbLpgLength = New Label()
      Me.TbLpgLength = New TextBox()
      Me.BtLpgGenerate = New Button()
      Me.BtLpgClipBoard = New Button()
      Me.LbBits = New Label()
      Me.TpPC = New TabPage()
      Me.TplPcMain = New TableLayoutPanel()
      Me.TbPcPrime = New TextBox()
      Me.tableLayoutPanel3 = New TableLayoutPanel()
      Me.BtIsPrime = New Button()
      Me.BtPcClipBoard = New Button()
      Me.TcMain.SuspendLayout()
      Me.TpHome.SuspendLayout()
      CType(Me.PbHomeMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TpPG.SuspendLayout()
      Me.TlpPgMain.SuspendLayout()
      Me.TlpPgInputs.SuspendLayout()
      Me.TlpPgButtons.SuspendLayout()
      Me.TpLPG.SuspendLayout()
      Me.TlpLpgMain.SuspendLayout()
      Me.TlpLpgInputButtons.SuspendLayout()
      Me.TpPC.SuspendLayout()
      Me.TplPcMain.SuspendLayout()
      Me.tableLayoutPanel3.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' TcMain
      ' 
      Me.TcMain.Controls.Add(Me.TpHome)
      Me.TcMain.Controls.Add(Me.TpPG)
      Me.TcMain.Controls.Add(Me.TpLPG)
      Me.TcMain.Controls.Add(Me.TpPC)
      Me.TcMain.Dock = DockStyle.Fill
      Me.TcMain.Location = New Point(0, 0)
      Me.TcMain.Name = "TcMain"
      Me.TcMain.SelectedIndex = 0
      Me.TcMain.Size = New Size(883, 637)
      Me.TcMain.TabIndex = 0
      AddHandler Me.TcMain.SelectedIndexChanged, AddressOf Me.Buttons_Click
      ' 
      ' TpHome
      ' 
      Me.TpHome.Controls.Add(Me.PbHomeMain)
      Me.TpHome.Location = New Point(4, 35)
      Me.TpHome.Name = "TpHome"
      Me.TpHome.Padding = New Padding(3)
      Me.TpHome.Size = New Size(875, 598)
      Me.TpHome.TabIndex = 0
      Me.TpHome.Text = "Home"
      Me.TpHome.UseVisualStyleBackColor = True
      ' 
      ' PbHomeMain
      ' 
      Me.PbHomeMain.BackColor = Color.White
      Me.PbHomeMain.Dock = DockStyle.Fill
      Me.PbHomeMain.Image = My.Resources.Resources.resp
      Me.PbHomeMain.Location = New Point(3, 3)
      Me.PbHomeMain.Name = "PbHomeMain"
      Me.PbHomeMain.Size = New Size(869, 592)
      Me.PbHomeMain.SizeMode = PictureBoxSizeMode.CenterImage
      Me.PbHomeMain.TabIndex = 0
      Me.PbHomeMain.TabStop = False
      ' 
      ' TpPG
      ' 
      Me.TpPG.Controls.Add(Me.TlpPgMain)
      Me.TpPG.Location = New Point(4, 35)
      Me.TpPG.Name = "TpPG"
      Me.TpPG.Padding = New Padding(3)
      Me.TpPG.Size = New Size(875, 598)
      Me.TpPG.TabIndex = 1
      Me.TpPG.Text = "Primes Generator"
      Me.TpPG.UseVisualStyleBackColor = True
      ' 
      ' TlpPgMain
      ' 
      Me.TlpPgMain.ColumnCount = 1
      Me.TlpPgMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.TlpPgMain.Controls.Add(Me.TbPgPrimes, 0, 0)
      Me.TlpPgMain.Controls.Add(Me.TlpPgInputs, 0, 1)
      Me.TlpPgMain.Dock = DockStyle.Fill
      Me.TlpPgMain.Location = New Point(3, 3)
      Me.TlpPgMain.Name = "TlpPgMain"
      Me.TlpPgMain.RowCount = 2
      Me.TlpPgMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.TlpPgMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 235.0F))
      Me.TlpPgMain.Size = New Size(869, 592)
      Me.TlpPgMain.TabIndex = 0
      ' 
      ' TbPgPrimes
      ' 
      Me.TbPgPrimes.Dock = DockStyle.Fill
      Me.TbPgPrimes.Location = New Point(3, 3)
      Me.TbPgPrimes.Multiline = True
      Me.TbPgPrimes.Name = "TbPgPrimes"
      Me.TbPgPrimes.ScrollBars = ScrollBars.Vertical
      Me.TbPgPrimes.Size = New Size(863, 351)
      Me.TbPgPrimes.TabIndex = 0
      ' 
      ' TlpPgInputs
      ' 
      Me.TlpPgInputs.ColumnCount = 4
      Me.TlpPgInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.TlpPgInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 109.0F))
      Me.TlpPgInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.TlpPgInputs.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.TlpPgInputs.Controls.Add(Me.TlpPgButtons, 1, 3)
      Me.TlpPgInputs.Controls.Add(Me.LbMax, 1, 2)
      Me.TlpPgInputs.Controls.Add(Me.TbPgMax, 2, 2)
      Me.TlpPgInputs.Controls.Add(Me.TbPgMin, 2, 1)
      Me.TlpPgInputs.Controls.Add(Me.LbMin, 1, 1)
      Me.TlpPgInputs.Controls.Add(Me.label1, 1, 0)
      Me.TlpPgInputs.Controls.Add(Me.TbPgCount, 2, 0)
      Me.TlpPgInputs.Dock = DockStyle.Fill
      Me.TlpPgInputs.Location = New Point(3, 360)
      Me.TlpPgInputs.Name = "TlpPgInputs"
      Me.TlpPgInputs.RowCount = 4
      Me.TlpPgInputs.RowStyles.Add(New RowStyle(SizeType.Absolute, 42.0F))
      Me.TlpPgInputs.RowStyles.Add(New RowStyle(SizeType.Absolute, 42.0F))
      Me.TlpPgInputs.RowStyles.Add(New RowStyle(SizeType.Absolute, 42.0F))
      Me.TlpPgInputs.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.TlpPgInputs.Size = New Size(863, 229)
      Me.TlpPgInputs.TabIndex = 1
      ' 
      ' TlpPgButtons
      ' 
      Me.TlpPgButtons.ColumnCount = 3
      Me.TlpPgInputs.SetColumnSpan(Me.TlpPgButtons, 2)
      Me.TlpPgButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333359F))
      Me.TlpPgButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
      Me.TlpPgButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
      Me.TlpPgButtons.Controls.Add(Me.BtPgGeneratePrimes, 2, 0)
      Me.TlpPgButtons.Controls.Add(Me.BtPgClipBoard, 0, 1)
      Me.TlpPgButtons.Controls.Add(Me.BtPgLaod, 1, 1)
      Me.TlpPgButtons.Controls.Add(Me.BtPgSave, 2, 1)
      Me.TlpPgButtons.Dock = DockStyle.Fill
      Me.TlpPgButtons.Location = New Point(23, 129)
      Me.TlpPgButtons.Name = "TlpPgButtons"
      Me.TlpPgButtons.RowCount = 2
      Me.TlpPgButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
      Me.TlpPgButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
      Me.TlpPgButtons.Size = New Size(817, 97)
      Me.TlpPgButtons.TabIndex = 4
      ' 
      ' BtPgGeneratePrimes
      ' 
      Me.BtPgGeneratePrimes.Anchor = AnchorStyles.Right
      Me.BtPgGeneratePrimes.Location = New Point(622, 3)
      Me.BtPgGeneratePrimes.Name = "BtPgGeneratePrimes"
      Me.BtPgGeneratePrimes.Size = New Size(192, 42)
      Me.BtPgGeneratePrimes.TabIndex = 0
      Me.BtPgGeneratePrimes.Text = "Generate"
      Me.BtPgGeneratePrimes.UseVisualStyleBackColor = True
      AddHandler Me.BtPgGeneratePrimes.Click, AddressOf Me.Buttons_Click
      ' 
      ' BtPgClipBoard
      ' 
      Me.BtPgClipBoard.Anchor = AnchorStyles.Left
      Me.BtPgClipBoard.Enabled = False
      Me.BtPgClipBoard.Location = New Point(3, 51)
      Me.BtPgClipBoard.Name = "BtPgClipBoard"
      Me.BtPgClipBoard.Size = New Size(192, 43)
      Me.BtPgClipBoard.TabIndex = 0
      Me.BtPgClipBoard.Text = "ClipBoard"
      Me.BtPgClipBoard.UseVisualStyleBackColor = True
      AddHandler Me.BtPgClipBoard.Click, AddressOf Me.Buttons_Click
      ' 
      ' BtPgLaod
      ' 
      Me.BtPgLaod.Anchor = AnchorStyles.None
      Me.BtPgLaod.Location = New Point(312, 51)
      Me.BtPgLaod.Name = "BtPgLaod"
      Me.BtPgLaod.Size = New Size(192, 43)
      Me.BtPgLaod.TabIndex = 0
      Me.BtPgLaod.Text = "Load"
      Me.BtPgLaod.UseVisualStyleBackColor = True
      AddHandler Me.BtPgLaod.Click, AddressOf Me.Buttons_Click
      ' 
      ' BtPgSave
      ' 
      Me.BtPgSave.Anchor = AnchorStyles.Right
      Me.BtPgSave.Location = New Point(622, 51)
      Me.BtPgSave.Name = "BtPgSave"
      Me.BtPgSave.Size = New Size(192, 43)
      Me.BtPgSave.TabIndex = 0
      Me.BtPgSave.Text = "Save"
      Me.BtPgSave.UseVisualStyleBackColor = True
      AddHandler Me.BtPgSave.Click, AddressOf Me.Buttons_Click
      ' 
      ' LbMax
      ' 
      Me.LbMax.Anchor = AnchorStyles.Left
      Me.LbMax.AutoSize = True
      Me.LbMax.Location = New Point(23, 91)
      Me.LbMax.Name = "LbMax"
      Me.LbMax.Size = New Size(63, 27)
      Me.LbMax.TabIndex = 2
      Me.LbMax.Text = "max:"
      ' 
      ' TbPgMax
      ' 
      Me.TbPgMax.Anchor = AnchorStyles.Left
      Me.TbPgMax.Location = New Point(132, 88)
      Me.TbPgMax.Name = "TbPgMax"
      Me.TbPgMax.Size = New Size(690, 34)
      Me.TbPgMax.TabIndex = 3
      Me.TbPgMax.Text = "5000000000000000000000000000000000000"
      Me.TbPgMax.TextAlign = HorizontalAlignment.Right
      ' 
      ' TbPgMin
      ' 
      Me.TbPgMin.Anchor = AnchorStyles.Left
      Me.TbPgMin.Location = New Point(132, 46)
      Me.TbPgMin.Name = "TbPgMin"
      Me.TbPgMin.Size = New Size(690, 34)
      Me.TbPgMin.TabIndex = 3
      Me.TbPgMin.Text = "1000000000000000000000000000000000000"
      Me.TbPgMin.TextAlign = HorizontalAlignment.Right
      ' 
      ' LbMin
      ' 
      Me.LbMin.Anchor = AnchorStyles.Left
      Me.LbMin.AutoSize = True
      Me.LbMin.Location = New Point(23, 49)
      Me.LbMin.Name = "LbMin"
      Me.LbMin.Size = New Size(58, 27)
      Me.LbMin.TabIndex = 2
      Me.LbMin.Text = "min:"
      ' 
      ' label1
      ' 
      Me.label1.Anchor = AnchorStyles.Left
      Me.label1.AutoSize = True
      Me.label1.Location = New Point(23, 7)
      Me.label1.Name = "label1"
      Me.label1.Size = New Size(79, 27)
      Me.label1.TabIndex = 2
      Me.label1.Text = "count:"
      ' 
      ' TbPgCount
      ' 
      Me.TbPgCount.Anchor = AnchorStyles.Left
      Me.TbPgCount.Location = New Point(132, 4)
      Me.TbPgCount.Name = "TbPgCount"
      Me.TbPgCount.Size = New Size(168, 34)
      Me.TbPgCount.TabIndex = 3
      Me.TbPgCount.Text = "100"
      Me.TbPgCount.TextAlign = HorizontalAlignment.Right
      ' 
      ' TpLPG
      ' 
      Me.TpLPG.Controls.Add(Me.TlpLpgMain)
      Me.TpLPG.Location = New Point(4, 35)
      Me.TpLPG.Name = "TpLPG"
      Me.TpLPG.Padding = New Padding(3)
      Me.TpLPG.Size = New Size(875, 598)
      Me.TpLPG.TabIndex = 2
      Me.TpLPG.Text = "Long Prime Generator"
      Me.TpLPG.UseVisualStyleBackColor = True
      ' 
      ' TlpLpgMain
      ' 
      Me.TlpLpgMain.ColumnCount = 1
      Me.TlpLpgMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.TlpLpgMain.Controls.Add(Me.TbLpgPrime, 0, 0)
      Me.TlpLpgMain.Controls.Add(Me.TlpLpgInputButtons, 0, 1)
      Me.TlpLpgMain.Dock = DockStyle.Fill
      Me.TlpLpgMain.Location = New Point(3, 3)
      Me.TlpLpgMain.Name = "TlpLpgMain"
      Me.TlpLpgMain.RowCount = 2
      Me.TlpLpgMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.TlpLpgMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 110.0F))
      Me.TlpLpgMain.Size = New Size(869, 592)
      Me.TlpLpgMain.TabIndex = 1
      ' 
      ' TbLpgPrime
      ' 
      Me.TbLpgPrime.Dock = DockStyle.Fill
      Me.TbLpgPrime.Location = New Point(3, 3)
      Me.TbLpgPrime.Multiline = True
      Me.TbLpgPrime.Name = "TbLpgPrime"
      Me.TbLpgPrime.ScrollBars = ScrollBars.Vertical
      Me.TbLpgPrime.Size = New Size(863, 476)
      Me.TbLpgPrime.TabIndex = 0
      ' 
      ' TlpLpgInputButtons
      ' 
      Me.TlpLpgInputButtons.ColumnCount = 7
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 109.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 109.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 210.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 210.0F))
      Me.TlpLpgInputButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.TlpLpgInputButtons.Controls.Add(Me.LbLpgLength, 1, 0)
      Me.TlpLpgInputButtons.Controls.Add(Me.TbLpgLength, 2, 0)
      Me.TlpLpgInputButtons.Controls.Add(Me.BtLpgGenerate, 5, 0)
      Me.TlpLpgInputButtons.Controls.Add(Me.BtLpgClipBoard, 4, 0)
      Me.TlpLpgInputButtons.Controls.Add(Me.LbBits, 3, 0)
      Me.TlpLpgInputButtons.Dock = DockStyle.Fill
      Me.TlpLpgInputButtons.Location = New Point(3, 485)
      Me.TlpLpgInputButtons.Name = "TlpLpgInputButtons"
      Me.TlpLpgInputButtons.RowCount = 1
      Me.TlpLpgInputButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.TlpLpgInputButtons.Size = New Size(863, 104)
      Me.TlpLpgInputButtons.TabIndex = 1
      ' 
      ' LbLpgLength
      ' 
      Me.LbLpgLength.Anchor = AnchorStyles.Left
      Me.LbLpgLength.AutoSize = True
      Me.LbLpgLength.Location = New Point(23, 38)
      Me.LbLpgLength.Name = "LbLpgLength"
      Me.LbLpgLength.Size = New Size(87, 27)
      Me.LbLpgLength.TabIndex = 2
      Me.LbLpgLength.Text = "length:"
      ' 
      ' TbLpgLength
      ' 
      Me.TbLpgLength.Anchor = AnchorStyles.Left
      Me.TbLpgLength.Location = New Point(132, 35)
      Me.TbLpgLength.Name = "TbLpgLength"
      Me.TbLpgLength.Size = New Size(80, 34)
      Me.TbLpgLength.TabIndex = 3
      Me.TbLpgLength.Text = "100"
      Me.TbLpgLength.TextAlign = HorizontalAlignment.Right
      ' 
      ' BtLpgGenerate
      ' 
      Me.BtLpgGenerate.Anchor = AnchorStyles.Right
      Me.BtLpgGenerate.Location = New Point(648, 31)
      Me.BtLpgGenerate.Name = "BtLpgGenerate"
      Me.BtLpgGenerate.Size = New Size(192, 42)
      Me.BtLpgGenerate.TabIndex = 0
      Me.BtLpgGenerate.Text = "Generate"
      Me.BtLpgGenerate.UseVisualStyleBackColor = True
      AddHandler Me.BtLpgGenerate.Click, AddressOf Me.Buttons_Click
      ' 
      ' BtLpgClipBoard
      ' 
      Me.BtLpgClipBoard.Anchor = AnchorStyles.Right
      Me.BtLpgClipBoard.Enabled = False
      Me.BtLpgClipBoard.Location = New Point(438, 30)
      Me.BtLpgClipBoard.Name = "BtLpgClipBoard"
      Me.BtLpgClipBoard.Size = New Size(192, 43)
      Me.BtLpgClipBoard.TabIndex = 0
      Me.BtLpgClipBoard.Text = "ClipBoard"
      Me.BtLpgClipBoard.UseVisualStyleBackColor = True
      AddHandler Me.BtLpgClipBoard.Click, AddressOf Me.Buttons_Click
      ' 
      ' LbBits
      ' 
      Me.LbBits.Anchor = AnchorStyles.Left
      Me.LbBits.AutoSize = True
      Me.LbBits.Location = New Point(241, 38)
      Me.LbBits.Name = "LbBits"
      Me.LbBits.Size = New Size(19, 27)
      Me.LbBits.TabIndex = 4
      Me.LbBits.Text = " "
      ' 
      ' TpPC
      ' 
      Me.TpPC.Controls.Add(Me.TplPcMain)
      Me.TpPC.Location = New Point(4, 35)
      Me.TpPC.Name = "TpPC"
      Me.TpPC.Size = New Size(875, 598)
      Me.TpPC.TabIndex = 3
      Me.TpPC.Text = "Prime Checker"
      Me.TpPC.UseVisualStyleBackColor = True
      ' 
      ' TplPcMain
      ' 
      Me.TplPcMain.ColumnCount = 1
      Me.TplPcMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.TplPcMain.Controls.Add(Me.TbPcPrime, 0, 0)
      Me.TplPcMain.Controls.Add(Me.tableLayoutPanel3, 0, 1)
      Me.TplPcMain.Dock = DockStyle.Fill
      Me.TplPcMain.Location = New Point(0, 0)
      Me.TplPcMain.Name = "TplPcMain"
      Me.TplPcMain.RowCount = 2
      Me.TplPcMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.TplPcMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 110.0F))
      Me.TplPcMain.Size = New Size(875, 598)
      Me.TplPcMain.TabIndex = 2
      ' 
      ' TbPcPrime
      ' 
      Me.TbPcPrime.Dock = DockStyle.Fill
      Me.TbPcPrime.Location = New Point(3, 3)
      Me.TbPcPrime.Multiline = True
      Me.TbPcPrime.Name = "TbPcPrime"
      Me.TbPcPrime.ScrollBars = ScrollBars.Vertical
      Me.TbPcPrime.Size = New Size(869, 482)
      Me.TbPcPrime.TabIndex = 0
      ' 
      ' tableLayoutPanel3
      ' 
      Me.tableLayoutPanel3.ColumnCount = 5
      Me.tableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 109.0F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 210.0F))
      Me.tableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
      Me.tableLayoutPanel3.Controls.Add(Me.BtIsPrime, 3, 0)
      Me.tableLayoutPanel3.Controls.Add(Me.BtPcClipBoard, 2, 0)
      Me.tableLayoutPanel3.Dock = DockStyle.Fill
      Me.tableLayoutPanel3.Location = New Point(3, 491)
      Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
      Me.tableLayoutPanel3.RowCount = 1
      Me.tableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
      Me.tableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
      Me.tableLayoutPanel3.Size = New Size(869, 104)
      Me.tableLayoutPanel3.TabIndex = 1
      ' 
      ' BtIsPrime
      ' 
      Me.BtIsPrime.Anchor = AnchorStyles.Right
      Me.BtIsPrime.Location = New Point(654, 31)
      Me.BtIsPrime.Name = "BtIsPrime"
      Me.BtIsPrime.Size = New Size(192, 42)
      Me.BtIsPrime.TabIndex = 0
      Me.BtIsPrime.Text = "IsPrime"
      Me.BtIsPrime.UseVisualStyleBackColor = True
      AddHandler Me.BtIsPrime.Click, AddressOf Me.Buttons_Click
      ' 
      ' BtPcClipBoard
      ' 
      Me.BtPcClipBoard.Anchor = AnchorStyles.Right
      Me.BtPcClipBoard.Enabled = False
      Me.BtPcClipBoard.Location = New Point(444, 31)
      Me.BtPcClipBoard.Name = "BtPcClipBoard"
      Me.BtPcClipBoard.Size = New Size(192, 42)
      Me.BtPcClipBoard.TabIndex = 0
      Me.BtPcClipBoard.Text = "ClipBoard"
      Me.BtPcClipBoard.UseVisualStyleBackColor = True
      AddHandler Me.BtPcClipBoard.Click, AddressOf Me.Buttons_Click
      ' 
      ' FrmMain
      ' 
      Me.AutoScaleDimensions = New SizeF(13.0F, 26.0F)
      Me.AutoScaleMode = AutoScaleMode.Font
      Me.BackColor = Color.White
      Me.ClientSize = New Size(883, 637)
      Me.Controls.Add(Me.TcMain)
      Me.Font = New Font("Arial", 14.0F)
      Me.Margin = New Padding(5, 3, 5, 3)
      Me.Name = "FrmMain"
      Me.StartPosition = FormStartPosition.CenterScreen
      Me.Text = "© BigPrimeGenerator created by © exc-jdbi 2024"
      Me.TcMain.ResumeLayout(False)
      Me.TpHome.ResumeLayout(False)
      CType(Me.PbHomeMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TpPG.ResumeLayout(False)
      Me.TlpPgMain.ResumeLayout(False)
      Me.TlpPgMain.PerformLayout()
      Me.TlpPgInputs.ResumeLayout(False)
      Me.TlpPgInputs.PerformLayout()
      Me.TlpPgButtons.ResumeLayout(False)
      Me.TpLPG.ResumeLayout(False)
      Me.TlpLpgMain.ResumeLayout(False)
      Me.TlpLpgMain.PerformLayout()
      Me.TlpLpgInputButtons.ResumeLayout(False)
      Me.TlpLpgInputButtons.PerformLayout()
      Me.TpPC.ResumeLayout(False)
      Me.TplPcMain.ResumeLayout(False)
      Me.TplPcMain.PerformLayout()
      Me.tableLayoutPanel3.ResumeLayout(False)
      Me.ResumeLayout(False)
    End Sub

    Private WithEvents TcMain As TabControl
    Private TpHome As TabPage
    Private TpPG As TabPage
    Private TpLPG As TabPage
    Private TpPC As TabPage
    Private PbHomeMain As PictureBox
    Private TlpPgMain As TableLayoutPanel
    Private TbPgPrimes As TextBox
    Private TlpPgInputs As TableLayoutPanel
    Private LbMin As Label
    Private TbPgMin As TextBox
    Private LbMax As Label
    Private TbPgMax As TextBox
    Private TlpPgButtons As TableLayoutPanel
    Private BtPgGeneratePrimes As Button
    Private BtPgClipBoard As Button
    Private BtPgLaod As Button
    Private BtPgSave As Button
    Private label1 As Label
    Private TbPgCount As TextBox
    Private TlpLpgMain As TableLayoutPanel
    Private TbLpgPrime As TextBox
    Private TlpLpgInputButtons As TableLayoutPanel
    Private LbLpgLength As Label
    Private TbLpgLength As TextBox
    Private BtLpgGenerate As Button
    Private BtLpgClipBoard As Button
    Private TplPcMain As TableLayoutPanel
    Private TbPcPrime As TextBox
    Private tableLayoutPanel3 As TableLayoutPanel
    Private BtIsPrime As Button
    Private BtPcClipBoard As Button
    Private LbBits As Label
  End Class

End Namespace
