//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators

namespace exc.jdbi.VeryBigPrimes.Generators;

partial class FrmMain
{
  /// <summary>
  ///  Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  ///  Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing)
  {
    if (disposing && (components != null))
    {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  ///  Required method for Designer support - do not modify
  ///  the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent()
  {
    this.TcMain = new TabControl();
    this.TpHome = new TabPage();
    this.PbHomeMain = new PictureBox();
    this.TpPG = new TabPage();
    this.TlpPgMain = new TableLayoutPanel();
    this.TbPgPrimes = new TextBox();
    this.TlpPgInputs = new TableLayoutPanel();
    this.TlpPgButtons = new TableLayoutPanel();
    this.BtPgGeneratePrimes = new Button();
    this.BtPgClipBoard = new Button();
    this.BtPgLaod = new Button();
    this.BtPgSave = new Button();
    this.LbMax = new Label();
    this.TbPgMax = new TextBox();
    this.TbPgMin = new TextBox();
    this.LbMin = new Label();
    this.label1 = new Label();
    this.TbPgCount = new TextBox();
    this.TpLPG = new TabPage();
    this.TlpLpgMain = new TableLayoutPanel();
    this.TbLpgPrime = new TextBox();
    this.TlpLpgInputButtons = new TableLayoutPanel();
    this.LbLpgLength = new Label();
    this.TbLpgLength = new TextBox();
    this.BtLpgGenerate = new Button();
    this.BtLpgClipBoard = new Button();
    this.LbBits = new Label();
    this.TpPC = new TabPage();
    this.TplPcMain = new TableLayoutPanel();
    this.TbPcPrime = new TextBox();
    this.tableLayoutPanel3 = new TableLayoutPanel();
    this.BtIsPrime = new Button();
    this.BtPcClipBoard = new Button();
    this.TcMain.SuspendLayout();
    this.TpHome.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)this.PbHomeMain).BeginInit();
    this.TpPG.SuspendLayout();
    this.TlpPgMain.SuspendLayout();
    this.TlpPgInputs.SuspendLayout();
    this.TlpPgButtons.SuspendLayout();
    this.TpLPG.SuspendLayout();
    this.TlpLpgMain.SuspendLayout();
    this.TlpLpgInputButtons.SuspendLayout();
    this.TpPC.SuspendLayout();
    this.TplPcMain.SuspendLayout();
    this.tableLayoutPanel3.SuspendLayout();
    this.SuspendLayout();
    // 
    // TcMain
    // 
    this.TcMain.Controls.Add(this.TpHome);
    this.TcMain.Controls.Add(this.TpPG);
    this.TcMain.Controls.Add(this.TpLPG);
    this.TcMain.Controls.Add(this.TpPC);
    this.TcMain.Dock = DockStyle.Fill;
    this.TcMain.Location = new Point(0, 0);
    this.TcMain.Name = "TcMain";
    this.TcMain.SelectedIndex = 0;
    this.TcMain.Size = new Size(883, 637);
    this.TcMain.TabIndex = 0;
    this.TcMain.SelectedIndexChanged += this.Buttons_Click;
    // 
    // TpHome
    // 
    this.TpHome.Controls.Add(this.PbHomeMain);
    this.TpHome.Location = new Point(4, 35);
    this.TpHome.Name = "TpHome";
    this.TpHome.Padding = new Padding(3);
    this.TpHome.Size = new Size(875, 598);
    this.TpHome.TabIndex = 0;
    this.TpHome.Text = "Home";
    this.TpHome.UseVisualStyleBackColor = true;
    // 
    // PbHomeMain
    // 
    this.PbHomeMain.BackColor = Color.White;
    this.PbHomeMain.Dock = DockStyle.Fill;
    this.PbHomeMain.Image = FrmBigPrimeGeneratorCs.Properties.Resources.resp;
    this.PbHomeMain.Location = new Point(3, 3);
    this.PbHomeMain.Name = "PbHomeMain";
    this.PbHomeMain.Size = new Size(869, 592);
    this.PbHomeMain.SizeMode = PictureBoxSizeMode.CenterImage;
    this.PbHomeMain.TabIndex = 0;
    this.PbHomeMain.TabStop = false;
    // 
    // TpPG
    // 
    this.TpPG.Controls.Add(this.TlpPgMain);
    this.TpPG.Location = new Point(4, 29);
    this.TpPG.Name = "TpPG";
    this.TpPG.Padding = new Padding(3);
    this.TpPG.Size = new Size(875, 604);
    this.TpPG.TabIndex = 1;
    this.TpPG.Text = "Primes Generator";
    this.TpPG.UseVisualStyleBackColor = true;
    // 
    // TlpPgMain
    // 
    this.TlpPgMain.ColumnCount = 1;
    this.TlpPgMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.TlpPgMain.Controls.Add(this.TbPgPrimes, 0, 0);
    this.TlpPgMain.Controls.Add(this.TlpPgInputs, 0, 1);
    this.TlpPgMain.Dock = DockStyle.Fill;
    this.TlpPgMain.Location = new Point(3, 3);
    this.TlpPgMain.Name = "TlpPgMain";
    this.TlpPgMain.RowCount = 2;
    this.TlpPgMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.TlpPgMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 235F));
    this.TlpPgMain.Size = new Size(869, 598);
    this.TlpPgMain.TabIndex = 0;
    // 
    // TbPgPrimes
    // 
    this.TbPgPrimes.Dock = DockStyle.Fill;
    this.TbPgPrimes.Location = new Point(3, 3);
    this.TbPgPrimes.Multiline = true;
    this.TbPgPrimes.Name = "TbPgPrimes";
    this.TbPgPrimes.ScrollBars = ScrollBars.Vertical;
    this.TbPgPrimes.Size = new Size(863, 357);
    this.TbPgPrimes.TabIndex = 0;
    // 
    // TlpPgInputs
    // 
    this.TlpPgInputs.ColumnCount = 4;
    this.TlpPgInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.TlpPgInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
    this.TlpPgInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.TlpPgInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.TlpPgInputs.Controls.Add(this.TlpPgButtons, 1, 3);
    this.TlpPgInputs.Controls.Add(this.LbMax, 1, 2);
    this.TlpPgInputs.Controls.Add(this.TbPgMax, 2, 2);
    this.TlpPgInputs.Controls.Add(this.TbPgMin, 2, 1);
    this.TlpPgInputs.Controls.Add(this.LbMin, 1, 1);
    this.TlpPgInputs.Controls.Add(this.label1, 1, 0);
    this.TlpPgInputs.Controls.Add(this.TbPgCount, 2, 0);
    this.TlpPgInputs.Dock = DockStyle.Fill;
    this.TlpPgInputs.Location = new Point(3, 366);
    this.TlpPgInputs.Name = "TlpPgInputs";
    this.TlpPgInputs.RowCount = 4;
    this.TlpPgInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
    this.TlpPgInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
    this.TlpPgInputs.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
    this.TlpPgInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.TlpPgInputs.Size = new Size(863, 229);
    this.TlpPgInputs.TabIndex = 1;
    // 
    // TlpPgButtons
    // 
    this.TlpPgButtons.ColumnCount = 3;
    this.TlpPgInputs.SetColumnSpan(this.TlpPgButtons, 2);
    this.TlpPgButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
    this.TlpPgButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
    this.TlpPgButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
    this.TlpPgButtons.Controls.Add(this.BtPgGeneratePrimes, 2, 0);
    this.TlpPgButtons.Controls.Add(this.BtPgClipBoard, 0, 1);
    this.TlpPgButtons.Controls.Add(this.BtPgLaod, 1, 1);
    this.TlpPgButtons.Controls.Add(this.BtPgSave, 2, 1);
    this.TlpPgButtons.Dock = DockStyle.Fill;
    this.TlpPgButtons.Location = new Point(23, 129);
    this.TlpPgButtons.Name = "TlpPgButtons";
    this.TlpPgButtons.RowCount = 2;
    this.TlpPgButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
    this.TlpPgButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
    this.TlpPgButtons.Size = new Size(817, 97);
    this.TlpPgButtons.TabIndex = 4;
    // 
    // BtPgGeneratePrimes
    // 
    this.BtPgGeneratePrimes.Anchor = AnchorStyles.Right;
    this.BtPgGeneratePrimes.Location = new Point(622, 3);
    this.BtPgGeneratePrimes.Name = "BtPgGeneratePrimes";
    this.BtPgGeneratePrimes.Size = new Size(192, 42);
    this.BtPgGeneratePrimes.TabIndex = 0;
    this.BtPgGeneratePrimes.Text = "Generate";
    this.BtPgGeneratePrimes.UseVisualStyleBackColor = true;
    this.BtPgGeneratePrimes.Click += this.Buttons_Click;
    // 
    // BtPgClipBoard
    // 
    this.BtPgClipBoard.Anchor = AnchorStyles.Left;
    this.BtPgClipBoard.Enabled = false;
    this.BtPgClipBoard.Location = new Point(3, 51);
    this.BtPgClipBoard.Name = "BtPgClipBoard";
    this.BtPgClipBoard.Size = new Size(192, 43);
    this.BtPgClipBoard.TabIndex = 0;
    this.BtPgClipBoard.Text = "ClipBoard";
    this.BtPgClipBoard.UseVisualStyleBackColor = true;
    this.BtPgClipBoard.Click += this.Buttons_Click;
    // 
    // BtPgLaod
    // 
    this.BtPgLaod.Anchor = AnchorStyles.None;
    this.BtPgLaod.Location = new Point(312, 51);
    this.BtPgLaod.Name = "BtPgLaod";
    this.BtPgLaod.Size = new Size(192, 43);
    this.BtPgLaod.TabIndex = 0;
    this.BtPgLaod.Text = "Load";
    this.BtPgLaod.UseVisualStyleBackColor = true;
    this.BtPgLaod.Click += this.Buttons_Click;
    // 
    // BtPgSave
    // 
    this.BtPgSave.Anchor = AnchorStyles.Right;
    this.BtPgSave.Location = new Point(622, 51);
    this.BtPgSave.Name = "BtPgSave";
    this.BtPgSave.Size = new Size(192, 43);
    this.BtPgSave.TabIndex = 0;
    this.BtPgSave.Text = "Save";
    this.BtPgSave.UseVisualStyleBackColor = true;
    this.BtPgSave.Click += this.Buttons_Click;
    // 
    // LbMax
    // 
    this.LbMax.Anchor = AnchorStyles.Left;
    this.LbMax.AutoSize = true;
    this.LbMax.Location = new Point(23, 91);
    this.LbMax.Name = "LbMax";
    this.LbMax.Size = new Size(63, 27);
    this.LbMax.TabIndex = 2;
    this.LbMax.Text = "max:";
    // 
    // TbPgMax
    // 
    this.TbPgMax.Anchor = AnchorStyles.Left;
    this.TbPgMax.Location = new Point(132, 88);
    this.TbPgMax.Name = "TbPgMax";
    this.TbPgMax.Size = new Size(690, 34);
    this.TbPgMax.TabIndex = 3;
    this.TbPgMax.Text = "5000000000000000000000000000000000000";
    this.TbPgMax.TextAlign = HorizontalAlignment.Right;
    // 
    // TbPgMin
    // 
    this.TbPgMin.Anchor = AnchorStyles.Left;
    this.TbPgMin.Location = new Point(132, 46);
    this.TbPgMin.Name = "TbPgMin";
    this.TbPgMin.Size = new Size(690, 34);
    this.TbPgMin.TabIndex = 3;
    this.TbPgMin.Text = "1000000000000000000000000000000000000";
    this.TbPgMin.TextAlign = HorizontalAlignment.Right;
    // 
    // LbMin
    // 
    this.LbMin.Anchor = AnchorStyles.Left;
    this.LbMin.AutoSize = true;
    this.LbMin.Location = new Point(23, 49);
    this.LbMin.Name = "LbMin";
    this.LbMin.Size = new Size(58, 27);
    this.LbMin.TabIndex = 2;
    this.LbMin.Text = "min:";
    // 
    // label1
    // 
    this.label1.Anchor = AnchorStyles.Left;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(23, 7);
    this.label1.Name = "label1";
    this.label1.Size = new Size(79, 27);
    this.label1.TabIndex = 2;
    this.label1.Text = "count:";
    // 
    // TbPgCount
    // 
    this.TbPgCount.Anchor = AnchorStyles.Left;
    this.TbPgCount.Location = new Point(132, 4);
    this.TbPgCount.Name = "TbPgCount";
    this.TbPgCount.Size = new Size(168, 34);
    this.TbPgCount.TabIndex = 3;
    this.TbPgCount.Text = "100";
    this.TbPgCount.TextAlign = HorizontalAlignment.Right;
    // 
    // TpLPG
    // 
    this.TpLPG.Controls.Add(this.TlpLpgMain);
    this.TpLPG.Location = new Point(4, 35);
    this.TpLPG.Name = "TpLPG";
    this.TpLPG.Padding = new Padding(3);
    this.TpLPG.Size = new Size(875, 598);
    this.TpLPG.TabIndex = 2;
    this.TpLPG.Text = "Long Prime Generator";
    this.TpLPG.UseVisualStyleBackColor = true;
    // 
    // TlpLpgMain
    // 
    this.TlpLpgMain.ColumnCount = 1;
    this.TlpLpgMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.TlpLpgMain.Controls.Add(this.TbLpgPrime, 0, 0);
    this.TlpLpgMain.Controls.Add(this.TlpLpgInputButtons, 0, 1);
    this.TlpLpgMain.Dock = DockStyle.Fill;
    this.TlpLpgMain.Location = new Point(3, 3);
    this.TlpLpgMain.Name = "TlpLpgMain";
    this.TlpLpgMain.RowCount = 2;
    this.TlpLpgMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.TlpLpgMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
    this.TlpLpgMain.Size = new Size(869, 592);
    this.TlpLpgMain.TabIndex = 1;
    // 
    // TbLpgPrime
    // 
    this.TbLpgPrime.Dock = DockStyle.Fill;
    this.TbLpgPrime.Location = new Point(3, 3);
    this.TbLpgPrime.Multiline = true;
    this.TbLpgPrime.Name = "TbLpgPrime";
    this.TbLpgPrime.ScrollBars = ScrollBars.Vertical;
    this.TbLpgPrime.Size = new Size(863, 476);
    this.TbLpgPrime.TabIndex = 0;
    // 
    // TlpLpgInputButtons
    // 
    this.TlpLpgInputButtons.ColumnCount = 7;
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
    this.TlpLpgInputButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.TlpLpgInputButtons.Controls.Add(this.LbLpgLength, 1, 0);
    this.TlpLpgInputButtons.Controls.Add(this.TbLpgLength, 2, 0);
    this.TlpLpgInputButtons.Controls.Add(this.BtLpgGenerate, 5, 0);
    this.TlpLpgInputButtons.Controls.Add(this.BtLpgClipBoard, 4, 0);
    this.TlpLpgInputButtons.Controls.Add(this.LbBits, 3, 0);
    this.TlpLpgInputButtons.Dock = DockStyle.Fill;
    this.TlpLpgInputButtons.Location = new Point(3, 485);
    this.TlpLpgInputButtons.Name = "TlpLpgInputButtons";
    this.TlpLpgInputButtons.RowCount = 1;
    this.TlpLpgInputButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.TlpLpgInputButtons.Size = new Size(863, 104);
    this.TlpLpgInputButtons.TabIndex = 1;
    // 
    // LbLpgLength
    // 
    this.LbLpgLength.Anchor = AnchorStyles.Left;
    this.LbLpgLength.AutoSize = true;
    this.LbLpgLength.Location = new Point(23, 38);
    this.LbLpgLength.Name = "LbLpgLength";
    this.LbLpgLength.Size = new Size(87, 27);
    this.LbLpgLength.TabIndex = 2;
    this.LbLpgLength.Text = "length:";
    // 
    // TbLpgLength
    // 
    this.TbLpgLength.Anchor = AnchorStyles.Left;
    this.TbLpgLength.Location = new Point(132, 35);
    this.TbLpgLength.Name = "TbLpgLength";
    this.TbLpgLength.Size = new Size(80, 34);
    this.TbLpgLength.TabIndex = 3;
    this.TbLpgLength.Text = "100";
    this.TbLpgLength.TextAlign = HorizontalAlignment.Right;
    // 
    // BtLpgGenerate
    // 
    this.BtLpgGenerate.Anchor = AnchorStyles.Right;
    this.BtLpgGenerate.Location = new Point(648, 31);
    this.BtLpgGenerate.Name = "BtLpgGenerate";
    this.BtLpgGenerate.Size = new Size(192, 42);
    this.BtLpgGenerate.TabIndex = 0;
    this.BtLpgGenerate.Text = "Generate";
    this.BtLpgGenerate.UseVisualStyleBackColor = true;
    this.BtLpgGenerate.Click += this.Buttons_Click;
    // 
    // BtLpgClipBoard
    // 
    this.BtLpgClipBoard.Anchor = AnchorStyles.Right;
    this.BtLpgClipBoard.Enabled = false;
    this.BtLpgClipBoard.Location = new Point(438, 30);
    this.BtLpgClipBoard.Name = "BtLpgClipBoard";
    this.BtLpgClipBoard.Size = new Size(192, 43);
    this.BtLpgClipBoard.TabIndex = 0;
    this.BtLpgClipBoard.Text = "ClipBoard";
    this.BtLpgClipBoard.UseVisualStyleBackColor = true;
    this.BtLpgClipBoard.Click += this.Buttons_Click;
    // 
    // LbBits
    // 
    this.LbBits.Anchor = AnchorStyles.Left;
    this.LbBits.AutoSize = true;
    this.LbBits.Location = new Point(241, 38);
    this.LbBits.Name = "LbBits";
    this.LbBits.Size = new Size(19, 27);
    this.LbBits.TabIndex = 4;
    this.LbBits.Text = " ";
    // 
    // TpPC
    // 
    this.TpPC.Controls.Add(this.TplPcMain);
    this.TpPC.Location = new Point(4, 29);
    this.TpPC.Name = "TpPC";
    this.TpPC.Size = new Size(875, 604);
    this.TpPC.TabIndex = 3;
    this.TpPC.Text = "Prime Checker";
    this.TpPC.UseVisualStyleBackColor = true;
    // 
    // TplPcMain
    // 
    this.TplPcMain.ColumnCount = 1;
    this.TplPcMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.TplPcMain.Controls.Add(this.TbPcPrime, 0, 0);
    this.TplPcMain.Controls.Add(this.tableLayoutPanel3, 0, 1);
    this.TplPcMain.Dock = DockStyle.Fill;
    this.TplPcMain.Location = new Point(0, 0);
    this.TplPcMain.Name = "TplPcMain";
    this.TplPcMain.RowCount = 2;
    this.TplPcMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.TplPcMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
    this.TplPcMain.Size = new Size(875, 604);
    this.TplPcMain.TabIndex = 2;
    // 
    // TbPcPrime
    // 
    this.TbPcPrime.Dock = DockStyle.Fill;
    this.TbPcPrime.Location = new Point(3, 3);
    this.TbPcPrime.Multiline = true;
    this.TbPcPrime.Name = "TbPcPrime";
    this.TbPcPrime.ScrollBars = ScrollBars.Vertical;
    this.TbPcPrime.Size = new Size(869, 488);
    this.TbPcPrime.TabIndex = 0;
    // 
    // tableLayoutPanel3
    // 
    this.tableLayoutPanel3.ColumnCount = 5;
    this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 109F));
    this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
    this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
    this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
    this.tableLayoutPanel3.Controls.Add(this.BtIsPrime, 3, 0);
    this.tableLayoutPanel3.Controls.Add(this.BtPcClipBoard, 2, 0);
    this.tableLayoutPanel3.Dock = DockStyle.Fill;
    this.tableLayoutPanel3.Location = new Point(3, 497);
    this.tableLayoutPanel3.Name = "tableLayoutPanel3";
    this.tableLayoutPanel3.RowCount = 1;
    this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
    this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
    this.tableLayoutPanel3.Size = new Size(869, 104);
    this.tableLayoutPanel3.TabIndex = 1;
    // 
    // BtIsPrime
    // 
    this.BtIsPrime.Anchor = AnchorStyles.Right;
    this.BtIsPrime.Location = new Point(654, 31);
    this.BtIsPrime.Name = "BtIsPrime";
    this.BtIsPrime.Size = new Size(192, 42);
    this.BtIsPrime.TabIndex = 0;
    this.BtIsPrime.Text = "IsPrime";
    this.BtIsPrime.UseVisualStyleBackColor = true;
    this.BtIsPrime.Click += this.Buttons_Click;
    // 
    // BtPcClipBoard
    // 
    this.BtPcClipBoard.Anchor = AnchorStyles.Right;
    this.BtPcClipBoard.Enabled = false;
    this.BtPcClipBoard.Location = new Point(444, 31);
    this.BtPcClipBoard.Name = "BtPcClipBoard";
    this.BtPcClipBoard.Size = new Size(192, 42);
    this.BtPcClipBoard.TabIndex = 0;
    this.BtPcClipBoard.Text = "ClipBoard";
    this.BtPcClipBoard.UseVisualStyleBackColor = true;
    this.BtPcClipBoard.Click += this.Buttons_Click;
    // 
    // FrmMain
    // 
    this.AutoScaleDimensions = new SizeF(13F, 26F);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.White;
    this.ClientSize = new Size(883, 637);
    this.Controls.Add(this.TcMain);
    this.Font = new Font("Arial", 14F);
    this.Margin = new Padding(5, 3, 5, 3);
    this.Name = "FrmMain";
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "© BigPrimeGenerator created by © exc-jdbi 2024";
    this.TcMain.ResumeLayout(false);
    this.TpHome.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)this.PbHomeMain).EndInit();
    this.TpPG.ResumeLayout(false);
    this.TlpPgMain.ResumeLayout(false);
    this.TlpPgMain.PerformLayout();
    this.TlpPgInputs.ResumeLayout(false);
    this.TlpPgInputs.PerformLayout();
    this.TlpPgButtons.ResumeLayout(false);
    this.TpLPG.ResumeLayout(false);
    this.TlpLpgMain.ResumeLayout(false);
    this.TlpLpgMain.PerformLayout();
    this.TlpLpgInputButtons.ResumeLayout(false);
    this.TlpLpgInputButtons.PerformLayout();
    this.TpPC.ResumeLayout(false);
    this.TplPcMain.ResumeLayout(false);
    this.TplPcMain.PerformLayout();
    this.tableLayoutPanel3.ResumeLayout(false);
    this.ResumeLayout(false);
  }

  #endregion

  private TabControl TcMain;
  private TabPage TpHome;
  private TabPage TpPG;
  private TabPage TpLPG;
  private TabPage TpPC;
  private PictureBox PbHomeMain;
  private TableLayoutPanel TlpPgMain;
  private TextBox TbPgPrimes;
  private TableLayoutPanel TlpPgInputs;
  private Label LbMin;
  private TextBox TbPgMin;
  private Label LbMax;
  private TextBox TbPgMax;
  private TableLayoutPanel TlpPgButtons;
  private Button BtPgGeneratePrimes;
  private Button BtPgClipBoard;
  private Button BtPgLaod;
  private Button BtPgSave;
  private Label label1;
  private TextBox TbPgCount;
  private TableLayoutPanel TlpLpgMain;
  private TextBox TbLpgPrime;
  private TableLayoutPanel TlpLpgInputButtons;
  private Label LbLpgLength;
  private TextBox TbLpgLength;
  private Button BtLpgGenerate;
  private Button BtLpgClipBoard;
  private TableLayoutPanel TplPcMain;
  private TextBox TbPcPrime;
  private TableLayoutPanel tableLayoutPanel3;
  private Button BtIsPrime;
  private Button BtPcClipBoard;
  private Label LbBits;
}
