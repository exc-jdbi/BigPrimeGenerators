//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators


using System.Text;

namespace exc.jdbi.VeryBigPrimes.Generators;


public class ServicesUtils
{

  //Es macht keinen Sinn OFD und SFD asynchron zu machen.
  //Das Speichern der Daten wie auch das Lesen hingegen schon.

  ////Beide Asynchrone Methoden funktionieren nicht, da der HauptThread
  ////verlassen wird.
  //public async static Task SaveDataAsync(FrmMain frm, string savetxt) =>
  //  await Task.Run(() => SaveData(frm, savetxt));

  //public async static Task<string> LoadDataAsync(OpenFileDialog ofd) =>
  //  await Task.Run(() => LoadData(ofd));

  public static void SaveDataSFD(string savetxt)
  {
    using var sfd = new SaveFileDialog();
    {
      sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      sfd.FilterIndex = 2;
      sfd.InitialDirectory = Application.StartupPath;
      sfd.RestoreDirectory = true;
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        using var mystream = sfd.OpenFile();
        if (mystream != null)
        {
          var buffer = Encoding.UTF8.GetBytes(savetxt);
          mystream.Write(buffer, 0, buffer.Length);
          mystream.Close();
        }
      }
    }
  }

  public static string LoadDataOFD()
  {
    var result = string.Empty;
    {
      using var ofd = new OpenFileDialog();
      ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      ofd.FilterIndex = 2;
      ofd.InitialDirectory = Application.StartupPath;
      ofd.RestoreDirectory = true;
      try
      {
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          using var mystream = ofd.OpenFile();
          if (mystream != null)
          {
            var len = Convert.ToInt32(mystream.Length);
            var buffer = new byte[len - 1 + 1];
            mystream.Read(buffer, 0, buffer.Length);
            result = Encoding.UTF8.GetString(buffer);
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Can not read file: {ex}", "Info PFPG System");
      }
    }
    return result;
  }
}
