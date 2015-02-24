using System;
using System.Data;
using System.Data.Entity;
using System.Data.Odbc;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using QMaoPetSalon.DbContexts;
using QMaoPetSalon.Models;
using DataTable = System.Data.DataTable;
using UserControl = System.Windows.Controls.UserControl;

namespace QMaoPetSalon.Content
{
    /// <summary>
    /// Interaction logic for ImportExcelView.xaml
    /// </summary>
    public partial class ImportExcelView : UserControl
    {
        Customer mCustomer = new Customer();

        public ImportExcelView()
        {
            InitializeComponent();

        }

        private void Button_Click(object aSender, RoutedEventArgs aArgs)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //LoadPath(dialog.SelectedPath);
                // await t;
                Task.Run(() => LoadPath(dialog.SelectedPath));
            }
        }

        private Task LoadPath(string aPath)
        {
            var dirInfo = new DirectoryInfo(aPath);

            var subDirectories = dirInfo.GetDirectories();

            foreach (var directory in subDirectories)
            {
                var dirInfo1 = new DirectoryInfo(aPath + "\\" + directory.Name);

                var info1 = dirInfo1.GetFiles("*.*");

                foreach (var fileInfo in info1)
                {
                    var dt = LoadExcel(aPath + "\\" + dirInfo1.Name + "\\" + fileInfo.Name);
                    if (dt != null)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            Parse(row);
                        }
                        AddCustoms();
                    }
                }
            }

            return null;
        }

        private void AddCustoms()
        {
            using (var db = new QMaoPetSalonDataBase())
            {
                // var per1 = new Customer { id = 1, OwnerName = "123", DateTime = DateTime.Now };
                db.Customers.Add(mCustomer);
                int recordsAffected = db.SaveChanges();
            }
            //  var context = new QMaoPetSalonDataBase();
            // context.Customers.Load();
            mCustomer = null;
            mCustomer = new Customer();
        }

        private void Parse(DataRow aDataRow)
        {
            switch (aDataRow.ItemArray[0].ToString())
            {
                case "聯絡電話":
                    mCustomer.OwnerPhone = aDataRow.ItemArray[1].ToString();
                    break;
                case "飼主姓名":
                    mCustomer.OwnerName = aDataRow.ItemArray[1].ToString();
                    break;
                case "地址":
                    mCustomer.OwnerAddress = aDataRow.ItemArray[1].ToString();
                    break;
                case "寵物名":
                    mCustomer.PetName = aDataRow.ItemArray[1].ToString();
                    break;
                case "品種":
                    mCustomer.PetVariety = Convert.ToInt32(aDataRow.ItemArray[1].ToString());
                    break;
                case "注意事項":
                    //mCustomer.Note = aDataRow.ItemArray[1].ToString();
                    break;
                case "美容消費":
                    ParseNote(aDataRow);
                    break;
                case "年齡":
                    mCustomer.PetAge = aDataRow.ItemArray[1].ToString();
                    break;
                default:
                    if (string.IsNullOrEmpty(aDataRow.ItemArray[1].ToString()))
                    {

                    }
                    else
                    {
                        ParseNote(aDataRow);
                    }
                    break;
            }
        }

        private void ParseNote(DataRow aDataRow)
        {
            if (aDataRow.ItemArray[1].ToString().Length == 0)
                return;

            var date = aDataRow.ItemArray[1].ToString().Substring(0, 10);
            //mCustomer.DateTime = Convert.ToDateTime(date);

            var startIndex = aDataRow.ItemArray[1].ToString().IndexOf("$", System.StringComparison.Ordinal) + 1;
            var endIndex = aDataRow.ItemArray[1].ToString().IndexOf(" ", startIndex, System.StringComparison.Ordinal);

            var price = aDataRow.ItemArray[1].ToString().Substring(startIndex, endIndex - startIndex);
           // mCustomer.Price = Convert.ToInt32(price);
        }

        //open an excel
        static readonly Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        readonly Workbooks mBooks = ExcelApp.Workbooks;
        private string GetExcelSheetName(string aPath)
        {
            //open currently book
            var book = mBooks.Add(aPath);
            var sheets = book.Sheets;
            //chiose first sheet
            var sheet = (Worksheet)sheets.Item[1];
            var sheetName = sheet.Name;
            return sheetName;
        }

        private void Write(string aPath)
        {
            PathTextBlock.Text += aPath + "\r\n";
        }

        public DataTable LoadExcel(string aPath)
        {
            var connString = "Driver={Driver do Microsoft Excel(*.xls)};DriverId=790;SafeTransactions=0;ReadOnly=1;MaxScanRows=16;Threads=3;MaxBufferSize=2024;UserCommitSync=Yes;FIL=excel 8.0;PageTimeout=5;";

            connString += "DBQ=" + aPath;
            var conn = new OdbcConnection(connString);
            var cmd = new OdbcCommand { Connection = conn };

            System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action<string>(Write), aPath);

            var sheetName = this.GetExcelSheetName(aPath);
            var sql = "select * from [" + sheetName.Replace('.', '#') + "$]";
            cmd.CommandText = sql;
            var da = new OdbcDataAdapter(cmd);
            var ds = new DataSet();

            try
            {
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception x)
            {
                ds = null;
                return null;
            }
            finally
            {
                cmd.Dispose();
                cmd = null;
                da.Dispose();
                da = null;
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn = null;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<QMaoPetSalonDataBase>());
        }
    }
}
