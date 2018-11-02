using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TextTools
{
    public partial class Form1 : Form
    {

        //serials stuff
        private bool running = false;
        private ArrayList serials = new ArrayList();
        private static Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        //General
        private bool WriteToFile(ArrayList lst)
        {
            SaveFileDialog saveDiag = new SaveFileDialog();
            saveDiag.Filter = "Text File | *.txt | All Files | *.*";
            saveDiag.FilterIndex = 2;
            saveDiag.Title = "Save output file";
            saveDiag.RestoreDirectory = true;
            saveDiag.DefaultExt = "txt";
            saveDiag.CheckFileExists = false;
            saveDiag.CheckPathExists = false;

            if (saveDiag.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveDiag.OpenFile()))
                {
                    foreach (string s in lst)
                    {
                        sw.WriteLine(s);
                    }
                }

            }
            return true;
        }

        //serials
        /*
        private void generateSerials()
        {
            string serial1, serial2, serial3, serial4, serial5, serial6;

            int i = 0;
            int max = (int) numericUpDown2.Value;
            while (running && i <= max)
            {
                serial1 = "1603LZ0D" + RandomString(3) + "8"; //M275 mouse
                serial2 = "1552LZ0D" + RandomString(3) + "8"; //M275 mouse
                serial3 = "1503LZ0D" + RandomString(3) + "8"; //B175 mouse
                serial4 = "1546MR0A" + RandomInt(4);
                serial5 = "1809MH00M" + RandomInt(1) + RandomString(1) + RandomInt(1);
                serial6 = "1809MH00" + RandomInt(1) + RandomString(1) + "P9";

                textBox3.AppendText(string.Join(Environment.NewLine, new ArrayList(){serial1, serial2, serial3, serial4, serial5, serial6}.ToArray()));
                textBox3.AppendText(Environment.NewLine);
                i += 1;
            }
            running = false;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomInt(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string CheckSerial(string s)
        {
            const string serialURL = "http://support.logitech.com/apexremote";
            string payload =
                "{\n\t\"action\": \"SupportFindProductRegistrationController\",\n\t\"method\": \"fetchProductFromSerial\",\n\t\"data\": [\n\t\t\"" +
                s +
                "\",\n\t\t\"en_us\"\n\t],\n\t\"type\": \"rpc\",\n\t\"tid\": 5,\n\t\"ctx\": {\n\t\t\"csrf\": \"blah\",\n\t\t\"vid\": \"\",\n\t\t\"ns\": \"\",\n\t\t\"ver\": 30\n\t}\n}";
            string headers = 
            
            return "";
        }
        */

        //Combine Text Files
       

    }
}
