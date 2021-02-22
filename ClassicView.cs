using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;
using System.Data.SQLite;

namespace cadino_trade
{
    public partial class FormFluction : Form
    {
        SQLiteConnection sc = new SQLiteConnection(@"Data Source=" + Application.StartupPath + @"\DataID.db; Version=3");
        SQLiteCommand scm = new SQLiteCommand();
        SQLiteDataAdapter sda = new SQLiteDataAdapter();
        DataSet ds = new DataSet();
        public FormFluction()
        {
            InitializeComponent();
        }
        private void FormFluction_Load(object sender, EventArgs e)
        {
            scm.CommandText = "select StockName,StockID,RangeUp,RaneDown from PanelInfo";
            scm.Connection = sc;
            sda.SelectCommand = scm;
            ds.Clear();
            sda.Fill(ds, "T1");
            ds.Tables[0].Columns[0].ColumnName = "نام سهم";
            ds.Tables[0].Columns[1].ColumnName = "شناسه";
            ds.Tables[0].Columns[2].ColumnName = "حد سود";
            ds.Tables[0].Columns[3].ColumnName = "حد ضرر";

            //String name = "دیده بان بازار";
            //String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            //                @"D:\Cadino_trade_App\cadino_trade\bin\Debug\Datafilelist.xlsx" +
            //                ";Extended Properties='Excel 8.0;HDR=YES;';";

            //OleDbConnection con = new OleDbConnection(constr);
            //OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            //con.Open();

            //OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            //DataTable data = new DataTable();
            //sda.Fill(data);
            //grid_items.DataSource = data;
            //-----------------FileStream stream = File.Open(@"D:\Cadino_trade_App\cadino_trade\bin\Debug\Datafilelist.xls", FileMode.Open, FileAccess.Read);
            for (int p = 0; p <= 100; p++)
            {
                System.Threading.Thread.Sleep(20);
                prbLoading.Value = p;
                
            }
            System.Threading.Thread.Sleep(200);
            prbLoading.Visible = false;
            bunifuDataGridView1.Visible = true;
            bunifuDataGridView1.DataBindings.Clear();
            bunifuDataGridView1.DataBindings.Add("datasource", ds, "T1");
            
            //////////string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", @"D:\Cadino_trade_App\cadino_trade\bin\Debug\Datafilelist.xls");
            //////////string query = String.Format("select * from [دیده بان بازار$]");
            //-------
            //////OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
            //////DataSet dataSet = new DataSet();
            //////dataAdapter.Fill(dataSet);
            //////DataRow datarowdelete = dataSet.Tables[0].Rows[0];
            //////datarowdelete.Delete();
            //////dataSet.Tables[0].AcceptChanges();
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[1]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[2]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[7]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[7]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[9]);
            //////dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[9]);
            //-------
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[2]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[3]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[4]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[5]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[6]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[7]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[8]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[9]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[10]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[11]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[14]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[15]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[18]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[19]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[22]);
            //dataSet.Tables[0].Columns.Remove(dataSet.Tables[0].Columns[23]);
            //--------
            //////dataSet.Tables[0].Columns[0].ColumnName = "نماد";
            //////dataSet.Tables[0].Columns[1].ColumnName = "ق پایانی-مقدار";
            //////dataSet.Tables[0].Columns[2].ColumnName = "ق پایانی-درصد";
            //////dataSet.Tables[0].Columns[3].ColumnName = "کمترین";
            //////dataSet.Tables[0].Columns[4].ColumnName = "بیشترین";
            //////dataSet.Tables[0].Columns[5].ColumnName = "EPS";
            //////dataSet.Tables[0].Columns[6].ColumnName = "P/E";
            //////dataSet.Tables[0].Columns[7].ColumnName = "خرید قیمت";
            //////dataSet.Tables[0].Columns[8].ColumnName = "فروش قیمت";
            //////dataSet.Tables[0].AcceptChanges();
            //----------
            ////string secondquery = String.Format("select * from [دیده بان بازار$]");
            ////OleDbDataAdapter seconddataAdapter = new OleDbDataAdapter(secondquery, connectionString);
            ////DataSet seconddataset = new DataSet();
            ////seconddataAdapter.Fill(seconddataset);
            ////bunifuDataGridView1.DataSource = seconddataset.Tables[0];
            //dataSet.Tables[0].Columns[2].ColumnName = "aba";
            //-------------
            //dataAdapter.Update(dataSet.Tables[0]);
            //dataAdapter.UpdateCommand = new OleDbCommand("select * from [دیده بان بازار$A:C]");
            //dataSet.Clear();
            //dataAdapter.Fill(dataSet);
            //-------------

            //bunifuDataGridView1.DataSource = dataSet.Tables[0];
            //bunifuDataGridView1.ColumnHeadersVisible = false;
            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            //-----------------IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            ////////////////////IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //-----------------DataSet result = excelReader.AsDataSet();

            ////////////////////var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            ////////////////////{
            ////////////////////    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
            ////////////////////    {
            ////////////////////        UseHeaderRow = true,

            ////////////////////        FilterColumn = (columnReader, columnIndex) =>
            ////////////////////        {
            ////////////////////            string header = columnReader.GetString(columnIndex);
            ////////////////////            return (header == "" ||
            ////////////////////                    header == "" ||
            ////////////////////                    header == ""
            ////////////////////                   );
            ////////////////////        }
            ////////////////////    }
            ////////////////////});
            //...
            //4. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = true;
            //DataSet result = excelReader.AsDataSet();
            //--------------bunifuDataGridView1.DataSource = result.Tables[0];
            //grid_items.ForeColor = Color.red;
            //grid_items.GridColor = Color.Aqua;

            //5. Data Reader methods
            //while (excelReader.Read())
            //{
            //    //excelReader.GetInt32(0);
            //}

            ////6. Free resources (IExcelDataReader is IDisposable)
            //excelReader.Close();
        }
    }
}
