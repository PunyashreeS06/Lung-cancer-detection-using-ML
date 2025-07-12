﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace diseasePrediction.Member
{
    public partial class LungPrediction : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();
        DataTable dt_Vectors = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();
                TestingDS();
            }
            catch
            {

            }
        }

        private void TestingDS()
        {
            string FileName = "TestingDataset1.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TestingDataset1";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTestingDS(FilePath, Extension, _Location);
        }

        private void ImportTestingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();



            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {

                //Bind Data to GridView

                GridView1.Caption = Path.GetFileName(FilePath);

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Testing Dataset Found!!!')</script>");
            }



            connExcel.Close();





        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset1.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset1";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbCommand cmdDistinct = new OleDbCommand();
            OleDbCommand cmdPatientsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdPatientsCnt.Connection = connExcel;
            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdDistinct.CommandText = "SELECT DISTINCT(result) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                //if (dtDistinct.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dtDistinct.Rows.Count; i++)
                //    {
                //        cmdPatientsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where RESULT=" + dtDistinct.Rows[i]["RESULT"].ToString() + "";
                //        _arrayPatientsCnt.Add(cmdPatientsCnt.ExecuteScalar());
                //    }
                //}

                connExcel.Close();

            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        protected void btnPrediction_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "TestingDataset1.xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "TestingDataset1";

                string FilePath = Server.MapPath(FolderPath + FileName);

                string conStr = "";

                switch (Extension)
                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, _Location);

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable tabData = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(tabData);

                //BLL obj = new BLL();

                int slNo = 1;

                if (tabData.Rows.Count > 0)
                {
                    Session["Output"] = null;
                    string _Predictedoutput = null;
                    string _timeNB = null;

                    tablePrediction.Rows.Clear();

                    tablePrediction.BorderStyle = BorderStyle.Double;
                    tablePrediction.GridLines = GridLines.Both;
                    tablePrediction.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell0 = new TableCell();
                    cell0.Width = 100;
                    cell0.Text = "<b>SlNo</b>";
                    mainrow.Controls.Add(cell0);

                    TableCell cell1 = new TableCell();
                    cell1.Width = 100;
                    cell1.Text = "<b>Age</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell12 = new TableCell();
                    cell12.Width = 100;
                    cell12.Text = "<b>Gender</b>";
                    mainrow.Controls.Add(cell12);

                    TableCell cell13 = new TableCell();
                    cell13.Width = 100;
                    cell13.Text = "<b>BP</b>";
                    mainrow.Controls.Add(cell13);

                    TableCell cell4 = new TableCell();
                    cell4.Width = 100;
                    cell4.Text = "<b>Weight</b>";
                    mainrow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    cell5.Width = 100;
                    cell5.Text = "<b>SugarTested</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Width = 100;
                    cell6.Text = "<b>FamilyHistory</b>";
                    mainrow.Controls.Add(cell6);

                    TableCell cell7 = new TableCell();
                    cell7.Width = 100;
                    cell7.Text = "<b>Smokes</b>";
                    mainrow.Controls.Add(cell7);

                    TableCell cell8 = new TableCell();
                    cell8.Width = 100;
                    cell8.Text = "<b>Alcohol</b>";
                    mainrow.Controls.Add(cell8);

                    TableCell cell9 = new TableCell();
                    cell9.Width = 100;
                    cell9.Text = "<b>Anemia</b>";
                    mainrow.Controls.Add(cell9);

                    TableCell cell10 = new TableCell();
                    cell10.Width = 100;
                    cell10.Text = "<b>Heart Disease</b>";
                    mainrow.Controls.Add(cell10);

                    TableCell cell11 = new TableCell();
                    cell11.Width = 100;
                    cell11.Text = "<b>Diabetes</b>";
                    mainrow.Controls.Add(cell11);

                    TableCell cell121 = new TableCell();
                    cell121.Width = 100;
                    cell121.Text = "<b>Cholesterol</b>";
                    mainrow.Controls.Add(cell121);

                    TableCell cell25 = new TableCell();
                    cell25.Text = "<b>Result</b>";
                    mainrow.Controls.Add(cell25);

                    tablePrediction.Controls.Add(mainrow);

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 0; i < tabData.Rows.Count; i++)
                    {

                        string _data = tabData.Rows[i]["age"].ToString() + "," + tabData.Rows[i]["gender"].ToString() + "," +
                              tabData.Rows[i]["bp"].ToString() + "," + tabData.Rows[i]["weight"].ToString() + "," +
                              tabData.Rows[i]["sugartested"].ToString() + "," + tabData.Rows[i]["familyhistory"].ToString() + "," +
                              tabData.Rows[i]["smokes"].ToString() + "," + tabData.Rows[i]["alcohol"].ToString()
                              + "," + tabData.Rows[i]["anemia"].ToString()
                              + "," + tabData.Rows[i]["heart_disease"].ToString()
                              + "," + tabData.Rows[i]["diabetes"].ToString()
                              + "," + tabData.Rows[i]["cholesterol"].ToString();



                        string[] values = _data.Split(',');

                        string _output = NaiveBayes(values);

                        TableRow row = new TableRow();

                        TableCell _cell0 = new TableCell();
                        _cell0.Text = slNo + i + ".";
                        row.Controls.Add(_cell0);

                        TableCell _cell1 = new TableCell();
                        _cell1.Text = tabData.Rows[i]["age"].ToString();
                        row.Controls.Add(_cell1);

                        TableCell _cell2 = new TableCell();
                        _cell2.Text = tabData.Rows[i]["gender"].ToString();
                        row.Controls.Add(_cell2);

                        TableCell _cell3 = new TableCell();
                        _cell3.Text = tabData.Rows[i]["bp"].ToString();
                        row.Controls.Add(_cell3);

                        TableCell _cell4 = new TableCell();
                        _cell4.Text = tabData.Rows[i]["weight"].ToString();
                        row.Controls.Add(_cell4);


                        TableCell _cell5 = new TableCell();
                        _cell5.Text = tabData.Rows[i]["sugartested"].ToString();
                        row.Controls.Add(_cell5);

                        TableCell _cell6 = new TableCell();
                        _cell6.Text = tabData.Rows[i]["familyhistory"].ToString();
                        row.Controls.Add(_cell6);

                        TableCell _cell7 = new TableCell();
                        _cell7.Text = tabData.Rows[i]["smokes"].ToString();
                        row.Controls.Add(_cell7);

                        TableCell _cell8 = new TableCell();
                        _cell8.Text = tabData.Rows[i]["alcohol"].ToString();
                        row.Controls.Add(_cell8);

                        TableCell _cell9 = new TableCell();
                        _cell9.Text = tabData.Rows[i]["anemia"].ToString();
                        row.Controls.Add(_cell9);

                        TableCell _cell10 = new TableCell();
                        _cell10.Text = tabData.Rows[i]["heart_disease"].ToString();
                        row.Controls.Add(_cell10);

                        TableCell _cell11 = new TableCell();
                        _cell11.Text = tabData.Rows[i]["diabetes"].ToString();
                        row.Controls.Add(_cell11);

                        TableCell _cell12 = new TableCell();
                        _cell12.Text = tabData.Rows[i]["cholesterol"].ToString();
                        row.Controls.Add(_cell12);


                        TableCell cellResult = new TableCell();
                        cellResult.Width = 250;


                        cellResult.Text = _output;


                        row.Controls.Add(cellResult);

                        tablePrediction.Controls.Add(row);

                        //if (_output.Equals("0"))
                        //{
                        //    ++_array0Res;
                        //}
                        //else if (_output.Equals("1"))
                        //{
                        //    ++_array1Res;
                        //}         

                        _Predictedoutput += _output + ",";
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();

                    Session["NBOutput"] = _timeNB + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);
                }
            }
            catch
            {

            }
        }

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function which contains binning coding
        private void binningMethod()
        {
            try
            {

                Class1 obj = new Class1();
                DataTable tabDataset = new DataTable();
                ArrayList _mising = new ArrayList();

                tabDataset.Rows.Clear();
                //fetch the training dataset 
                //tabDataset = dt;

                if (dt.Rows.Count > 0)
                {
                    //code of binning method
                    for (int i = 0; i < tabDataset.Rows.Count; i++)
                    {
                        string _data = tabDataset.Rows[i]["age"].ToString() + "," + tabDataset.Rows[i]["gender"].ToString() + "," +
                            tabDataset.Rows[i]["bp"].ToString() + "," + tabDataset.Rows[i]["weight"].ToString() + "," +
                            tabDataset.Rows[i]["sugartested"].ToString() + "," + tabDataset.Rows[i]["familyhistory"].ToString() + "," +
                            tabDataset.Rows[i]["smokes"].ToString() + "," + tabDataset.Rows[i]["alcohol"].ToString();


                        string[] parameter = _data.Split(',');

                        for (int j = 0; j < parameter.Length; j++)
                        {
                            if (parameter[j].Equals("") || parameter.Equals("?"))
                            {
                                for (int k = 0; k < tabDataset.Rows.Count; k++)
                                {
                                    int id = 0;
                                    Random r = new Random();

                                    for (int x = 1; x <= 2; x++)
                                    {
                                        id = r.Next(9);
                                    }

                                    //setting value for ? and null value
                                    string _value = tabDataset.Rows[id][parameter[j]].ToString();
                                    _mising.Add(_value);
                                }
                            }

                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }


        // algorithm steps
        //function which contains the algorithm steps
        private string NaiveBayes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 12;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;

            string[] features = { "age", "gender", "bp", "weight", "sugartested", "familyhistory", "smokes", "alcohol", "anemia", "heart_disease", "diabetes", "cholesterol" };

            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < features.Length; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][j].ToString().Equals(values[j]))
                        {
                            ++n;

                            if (dt.Rows[d][m].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            string _output = null;

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();

                    //if (_output.Equals("0"))
                    //{
                    //    _output = "No";
                    //}
                    //else
                    //{
                    //    _output = "Yes";
                    //}

                    return _output;
                }
            }
            //}
            //catch
            //{

            //}

            return _output;
        }


        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    if (dtDistinct.Rows[i]["result"].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        s.Add(dtDistinct.Rows[i]["result"].ToString());
                    }
                }
            }

            return s;
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            btnPrediction_Click(sender, e);
            Response.Redirect(string.Format("Results.aspx"));
        }
    }
}