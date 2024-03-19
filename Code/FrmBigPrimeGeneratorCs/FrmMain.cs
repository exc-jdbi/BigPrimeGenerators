//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators

using System.Text;
using System.Numerics;

namespace exc.jdbi.VeryBigPrimes.Generators;
 
public partial class FrmMain : Form
{
  public FrmMain()
  {
    this.InitializeComponent();
    this.TcMain.BackColor = Color.Transparent;
    this.TcMain.DrawMode = TabDrawMode.OwnerDrawFixed;
    this.TcMain.DrawItem += new DrawItemEventHandler(this.TcMain_DrawItem!);

    this.TcMain.SelectedIndex = 0;
  }

  private void TcMain_DrawItem(object sender, DrawItemEventArgs e)
  {
    try
    {
      //Brush backbrush;
      Brush forebrush;
      Font font = e.Font!;
      font = new Font(font.FontFamily, font.Size - 1.5f);

      if (e.Index == this.TcMain.SelectedIndex)
      {
        font = new Font(font, FontStyle.Bold | FontStyle.Italic);
        //backbrush = new SolidBrush(e.BackColor);
        forebrush = new SolidBrush(SystemColors.WindowText);
      }
      else
      {
        //backbrush = new SolidBrush(e.BackColor);
        forebrush = new SolidBrush(e.ForeColor);
      }
      var tabtext = this.TcMain.TabPages[e.Index].Text;
      using var sf = new StringFormat
      {
        Alignment = StringAlignment.Center
      };

      e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), e.Bounds);

      var rect = e.Bounds;
      using var fb = forebrush;
      rect = new Rectangle(rect.X, rect.Y + 3, rect.Width, rect.Height - 3);
      e.Graphics.DrawString(tabtext, font, fb, rect, sf);

    }
    catch (Exception Ex)
    {
      MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }

  private void Buttons_Click(object sender, EventArgs e)
  {
    switch (sender)
    {
      //Prime Check
      case Button obj when obj == BtIsPrime: PcIsPrimeAsync(); break;
      case Button obj when obj == BtPcClipBoard: PcClipBoard(); break;

      //Long Prime Generator
      case Button obj when obj == BtLpgGenerate: LpgGenerateAsync(); break;
      case Button obj when obj == BtLpgClipBoard: LpgClipBoard(); break;

      //Prime Generator
      case Button obj when obj == BtPgSave: SaveData(); break;
      case Button obj when obj == BtPgLaod: LoadData(); break;
      case Button obj when obj == BtPgClipBoard:      PgClipBoard(); break;
      case Button obj when obj == BtPgGeneratePrimes: PgGeneratePrimesAsync(); break;

      case TabControl obj when obj == TcMain: TabControlSelectedIndexChangedAsync(); break;
    }
  }

  private async void TabControlSelectedIndexChangedAsync()
  {
    this.TbPcPrime.Clear();
    this.TbLpgPrime.Clear();
    this.TbPgPrimes.Clear();
    this.LbBits.Text = string.Empty;
    this.TbLpgLength.Text = 100.ToString();

    this.BtPgClipBoard.Enabled = false;
    this.BtPgClipBoard.Enabled = false;
    this.BtLpgClipBoard.Enabled = false;

    var sb = new StringBuilder();
    if (TcMain.SelectedIndex == 3)
    { 
      sb.AppendLine((await BigPrimeGenerator.RngBigPrimesAsync(50, 1))[0].ToString());
      sb.AppendLine();
      sb.AppendLine((await BigPrimeGenerator.RngBigPrimesAsync(50, 1))[0].ToString());
      this.TbPcPrime.Text = sb.ToString();
    }
    
  }

  private void SaveData() =>
    ServicesUtils.SaveDataSFD(this.TbPgPrimes.Text);

  private void LoadData()
  {
    this.TbPgPrimes.Text = ServicesUtils.LoadDataOFD();
    this.BtPgClipBoard.Enabled = true;
  }

  private void PgClipBoard()
  {
    var txt = this.TbPgPrimes.Text;
    if (!string.IsNullOrEmpty(txt))
      SetClipBoard(txt);
  }

  private async void PgGeneratePrimesAsync()
  {
    this.BtPgClipBoard.Enabled = false;
    if (!await BigPrimeGenerator.IsNumericAsync(TbPgMin.Text))
    { Message(0, "MIN"); return; }
    if (!await BigPrimeGenerator.IsNumericAsync(TbPgMax.Text))
    { Message(0, "MAX"); return; }
    if (!await BigPrimeGenerator.IsNumericAsync(TbPgCount.Text))
    { Message(0, "COUNT"); return; }

    if (int.TryParse(this.TbPgCount.Text, out var cnt))
    {
      this.BtPgGeneratePrimes.Enabled = false;
      var min = BigInteger.Parse(this.TbPgMin.Text);
      var max = BigInteger.Parse(this.TbPgMax.Text);

      var sb = new StringBuilder();

      //Ist genau so schnell wie die Einzelberechnung
      var result = await BigPrimeGenerator.RngBigPrimesAsync(min, max, cnt);
      sb.Append(string.Join(Environment.NewLine, result));

      ////Auch die Einzelberechnung ist schnell
      //for (var i = 0; i < cnt; i++)
      //  sb.AppendLine((await BigPrimeGenerator.ToRngPrimeAsync(min, max)).ToString());

      this.TbPgPrimes.Text = sb.ToString();

      this.BtPgClipBoard.Enabled = true;
    }
    this.BtPgGeneratePrimes.Enabled = true;
  }

  private async void LpgGenerateAsync()
  {
    this.LbBits.Text = string.Empty;
    this.BtLpgClipBoard.Enabled = false;
    if (!BigPrimeGenerator.IsNumeric(this.TbLpgLength.Text))
    { Message(0, "LENGTH"); return; }

    if (int.TryParse(this.TbLpgLength.Text, out var cnt))
    {
      this.BtLpgGenerate.Enabled = false;
      var prime = (await BigPrimeGenerator.RngBigPrimesAsync(cnt, 1))[0];
      if (prime < 2) throw new ArgumentException(
        $"An error has occurred.", nameof(prime));
      this.LbBits.Text = $"{BigInteger.Log2(prime) + 1} bits";
      this.TbLpgPrime.Text = prime.ToString();
      this.BtLpgGenerate.Enabled = true;
      this.BtLpgClipBoard.Enabled = true;

      if (int.Parse(this.TbLpgLength.Text) > 100)
        this.TbLpgLength.Text = "100";
      return;
    }
    throw new NotImplementedException();
  }

  private void LpgClipBoard()
  {
    this.LbBits.Text = string.Empty;
    var txt = this.TbLpgPrime.Text;
    if (!string.IsNullOrEmpty(txt))
      SetClipBoard(txt);
  }

  private async void PcIsPrimeAsync()
  {
    static void PrintMsg(string msg) =>
      MessageBox.Show(msg, "Info PFPG System");

    var txt = this.TbPcPrime.Lines;
    txt = txt.Where(line => !string.IsNullOrEmpty(line)).ToArray();
    this.BtIsPrime.Enabled = false;
    this.BtPcClipBoard.Enabled = false;

    var iter = 0;
    foreach (var line in txt)
    {
      iter++;
      if (!await BigPrimeGenerator.IsNumericAsync(line.Trim()))
      {
        PrintMsg($"index: {iter} is not a Number");
        this.BtIsPrime.Enabled = true;
        this.BtPcClipBoard.Enabled = true;
        return;
      }
      var is_prime = await Task.Run(() => BigPrimeGenerator.IsMRPrime(BigInteger.Parse(line.Trim())));
      if (!is_prime)
      {
        PrintMsg($"index: {iter} is not a Prime");
        this.BtIsPrime.Enabled = true;
        this.BtPcClipBoard.Enabled = true;
        return;
      }
    }

    this.BtIsPrime.Enabled = true;
    this.BtPcClipBoard.Enabled = true;
    PrintMsg(true.ToString());
  }

  private void PcClipBoard()
  {
    var txt = this.TbPcPrime.Text;
    if (!string.IsNullOrEmpty(txt))
      SetClipBoard(txt);
  }

  private static void SetClipBoard(string number)
  {
    Clipboard.Clear();
    if (!string.IsNullOrEmpty(number))
      Clipboard.SetText(number);
  }

  private static void Message(int id, string message = "")
  {
    string? msg = null;
    switch (id)
    {
      case 0: msg = $"Please enter a number. in [{message}]"; break;
      case 1: msg = $"Cannot read file from disk"; break;
    }
    if (!string.IsNullOrEmpty(msg))
      MessageBox.Show(msg, "Info PFPG System");
  }
}


