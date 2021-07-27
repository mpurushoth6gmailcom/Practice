using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SampleCodes : Form
    {
        public SampleCodes()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var reversedstring = StringReversal("HelloWold");
            var removedString = DuplicateRemoval("HelloWold");
            int[] arr = new int[] { 1, 9, 6, 7, 5, 9 };
            arr = sortingArrayAsc(arr);
            arr = sortingArrayDesc(arr);
            ReverseWords("cake pound steal");
            var s = DuplicateCharacters("Hello world");
            AnagramString();
            containsDigits("12ghjjjj");
            DuplicateWords("Helloworld");
            QuestionsMarks("arrb6 ??? 4xxbl5 ??? eee5");
        }

        public string StringReversal(string strToreverse)
        {
            
            string reversed = string.Empty;
            char[] vs = strToreverse.ToArray();
            for (int i = vs.Length-1; i >= 0; i--)
            {
                reversed += vs[i];
            }
            return reversed;
        }

        public string DuplicateRemoval(string strToreverse)
        {
            char[] vs = strToreverse.ToArray();
            string removed = string.Empty;
            for (int i=0; i< vs.Length; i++)
            {
                if (!removed.Contains(vs[i]))
                {
                    removed += vs[i];
                }
            }
            return removed;
        }

        public int[] sortingArrayAsc(int[] arr)
        {
            for(int i= 0; i < arr.Length-1; i++)
            {
                for(int j=i+1; j < arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }

        public int[] sortingArrayDesc(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }


        public string ReverseWords(string msg)
        {
            string reversedWords = string.Empty;
            char[] message = msg.ToArray();
            for (int i = 0; i < message.Length; i++)
            {
                if(message[i] != ' ')
                {
                    reversedWords += message[i];
                }
                else
                {
                    reversedWords += ' ';
                }
            }

            return reversedWords;
        }

        public string DuplicateCharacters(string originalstring)
        {
            string unduplicatedstring = string.Empty;
            string duplicatedstring = string.Empty;
            char[] str = originalstring.ToArray();
            for(int i = 0; i < str.Length; i++)
            {
                if (!unduplicatedstring.Contains(str[i]))
                {
                    unduplicatedstring += str[i];
                }
                else
                {
                    duplicatedstring += str[i];
                }
            }
            return duplicatedstring;
        }

        public bool AnagramString()
        {
            bool isAnagram = false;
            string anagramString = "Heater";
            string anagramString1 = "reheat";
            char[] ch1 = anagramString.ToLower().ToArray();
            char[] ch2 = anagramString1.ToLower().ToArray();
            Array.Sort(ch1);
            Array.Sort(ch2);
            string val1 = new string(ch1);
            string val2 = new string(ch2);
            if (val1 == val2)
            {
                return isAnagram = true;
            }
            return isAnagram;
        }
        
        public bool containsDigits(string charactersWithDigits)
        {
            bool isContainDigits = false;
            foreach(char c in charactersWithDigits)
            {
                if (char.IsDigit(c))
                {
                    isContainDigits = true;
                }
            }
            return isContainDigits;
        }

        public string DuplicateWords(string WordstoFindDuplicates)
        {
            char[] vs = WordstoFindDuplicates.ToArray();
            string duplicatedWords = string.Empty;
            for (int i = 0; i < vs.Length; i++)
            {
                if (!WordstoFindDuplicates.Contains(vs[i]))
                {
                    WordstoFindDuplicates += vs[i];
                }
                else
                {
                    duplicatedWords += vs[i];
                }
            }
            return duplicatedWords;
        }

        public static bool QuestionsMarks(string str)
        {

            if (str.Contains("???"))
            {
                 int n = (str.IndexOf("???")) + 3;
                //var n = 8;
                var ns = str.IndexOf("???") - 1;
                //Console.WriteLine(str[n]);
                //Console.WriteLine(str[ns]);
                if(Char.IsDigit(str[n]) && Char.IsDigit(str[ns])){
                //Console.WriteLine(Convert.ToInt64(str[n]) + Convert.ToInt64(str[ns]));
                if ((Convert.ToInt64(str[n]) + Convert.ToInt64(str[ns])) == 10)
                {
                    return true;
                }
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
            return false;
        }

        public void ExcelToDataTable()
        {
            int nOutputRow;
            string sSheetName = null;
            string sConnection = null;
            DataTable dtTablesList = default(DataTable);
            OleDbCommand oleExcelCommand = default(OleDbCommand);
            OleDbDataReader oleExcelReader = default(OleDbDataReader);
            OleDbConnection oleExcelConnection = default(OleDbConnection);

            sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mpurushothaman\\Downloads\\Data_Country.xlsx;Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";
           // "C:\Users\mpurushothaman\Downloads\Data_Country.xlsx"

            oleExcelConnection = new OleDbConnection(sConnection);
            oleExcelConnection.Open();

            dtTablesList = oleExcelConnection.GetSchema("Tables");

            if (dtTablesList.Rows.Count > 0)
            {
                sSheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
            }

            dtTablesList.Clear();
            dtTablesList.Dispose();


            if (!string.IsNullOrEmpty(sSheetName))
            {
                var conn = string.Format("Server = INLBCPLT18; Database = Master_Data; Trusted_Connection = True; MultipleActiveResultSets = true;User ID=;Password=;");
                oleExcelCommand = oleExcelConnection.CreateCommand();
                oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                oleExcelCommand.CommandType = CommandType.Text;
               // oleExcelConnection.Open();
                oleExcelReader = oleExcelCommand.ExecuteReader();
                SqlConnection SQLconn = new SqlConnection();
                OleDbDataReader objDR = null;
                SQLconn.ConnectionString = conn;
                SQLconn.Open();
                OleDbCommand objCmdSelect = new OleDbCommand(oleExcelCommand.CommandText, oleExcelConnection);
                nOutputRow = 0;

                while (oleExcelReader.Read())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(SQLconn))
                    {

                        bulkCopy.DestinationTableName = "tblTest";

                        try
                        {
                            objDR = objCmdSelect.ExecuteReader();
                            bulkCopy.WriteToServer(objDR);
                            oleExcelConnection.Close();

                            //objDR.Close()
                            SQLconn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                oleExcelReader.Close();
            }
            oleExcelConnection.Close();

        }
    }
}
