using System;
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
    public partial class _Single : System.Web.UI.Page
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
                
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
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
        private string _NaiveBayes(string[] values)
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

                    if (_output.Equals("1"))
                    {
                        _output = "YES";
                    }
                    else
                    {
                        _output = "NO";
                    }

                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Output: " + _output;

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string _data = txtAge.Text + "," + DropDownList1.SelectedValue + "," +
                     txtBP.Text + "," + txtWeight.Text + "," +
                     txtsugartested.Text + "," + txtfamilyhistory.Text + "," +
                      txtsmokes.Text + "," + txtalcohol.Text
                      + "," + txtanemia.Text
                      + "," + txtheart_disease.Text
                      + "," + txtdiabetes.Text
                      + "," + txtcholesterol.Text;



                string[] values = _data.Split(',');

                string _output = _NaiveBayes(values);

                lblResult.ForeColor = System.Drawing.Color.Green;
                lblResult.Text = "Output: " + _output;


            }
            catch
            {

            }
        }

       
    }
}