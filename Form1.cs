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
        private ArrayList Output = new ArrayList();
        private ArrayList sourceStrings = new ArrayList();
        //private ArrayList splitText = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

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

        private bool OpenFile()
        {
            OpenFileDialog openDiag = new OpenFileDialog();
            openDiag.Filter = "Text File | *.txt | All Files | *.*";
            openDiag.FilterIndex = 2;
            openDiag.Title = "Open source files";
            openDiag.RestoreDirectory = true;
            openDiag.CheckFileExists = true;
            openDiag.CheckPathExists = true;
            openDiag.Multiselect = true;

            if (openDiag.ShowDialog() == DialogResult.OK)
            {
                //foreach (string sN in openDiag.FileNames)
                //{
                //    textBox1.AppendText(sN);
                //}

                foreach (string f in openDiag.FileNames)
                {
                    sourceStrings.AddRange(File.ReadAllLines(f));
                    textBox1.AppendText(string.Join(Environment.NewLine, sourceStrings.ToArray()));

                    /*
                    using (StreamReader sr = new StreamReader(f))
                    {
                        sourceStrings.AddRange(sr.ReadToEnd().ToList());
                        textBox1.AppendText(string.Join(Environment.NewLine, sourceStrings.ToArray()));

                        
                         * string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            sourceStrings.Add(line);
                            textBox1.AppendText(line + "\n");
                        }
                        
                }
                */
                }

            }

            return true;
        }

        private bool processText()
        {
            List<string> str;
            str = string.Join(":", sourceStrings.ToArray()).Split(":".ToCharArray()).Distinct().ToList();
            for (int i = 0; i < str.Count; i++) 
            {
                str[i] = str[i] + ":" + str[i];
            }
            //Output.AddRange(str);
            Output.AddRange((string.Join("1;", str.ToArray()) + "1").Split(";".ToCharArray()).ToList());
            Output.AddRange((string.Join("12;", str.ToArray()) + "12").Split(";".ToCharArray()).ToList());
            Output.AddRange((string.Join("123;", str.ToArray()) + "123").Split(";".ToCharArray()).ToList());
            Output.AddRange((string.Join("1234;", str.ToArray()) + "1234").Split(";".ToCharArray()).ToList());
            Output.AddRange((string.Join("12345;", str.ToArray()) + "12345").Split(";".ToCharArray()).ToList());
            Output.Sort();
            textBox2.AppendText(string.Join(Environment.NewLine, Output.ToArray()));


            /*
            foreach (string s1 in sourceStrings)
            {
                Output.Add(s1.Split(":".ToCharArray())[1] + "1");
                Output.Add(s1.Split(":".ToCharArray())[1] + "12");
                Output.Add(s1.Split(":".ToCharArray())[1] + "123");
                Output.Add(s1.Split(":".ToCharArray())[1] + "1234");
                Output.Add(s1.Split(":".ToCharArray())[1] + "12345");
                textBox2.AppendText(s1.Split(":".ToCharArray())[1] + "1\n");
                textBox2.AppendText(s1.Split(":".ToCharArray())[1] + "12\n");
                textBox2.AppendText(s1.Split(":".ToCharArray())[1] + "123\n");
                textBox2.AppendText(s1.Split(":".ToCharArray())[1] + "1234\n");
                textBox2.AppendText(s1.Split(":".ToCharArray())[1] + "12345\n");
            }
            */

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OpenFile())
            {
                MessageBox.Show("Loaded file(s)!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (processText())
            {
                MessageBox.Show("Finished combining!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WriteToFile(Output))
            {
                MessageBox.Show("File saved!");
            }
        }
    }

    public abstract class ArList : ICollection<string>
    {
        public abstract int Count { get; }

        public abstract bool IsReadOnly { get; }

        public abstract void Add(string item);

        public void Clear()
        {
            this.ToList().Clear();
        }

        public bool Contains(string item)
        {
            return this.ToList().Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            this.ToList().CopyTo(array, arrayIndex);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this.ToList().GetEnumerator();
        }

        public bool Remove(string item)
        {
            return this.ToList().Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ToList().GetEnumerator();
        }

        public List<string> Combine(string str, List<string> l)
        {
            if (this.Count() != l.Count())
                return null;

            List<string> output = new List<string>();
            foreach (string s in this)
            {
                output.Add(s + str + l.ElementAt(this.ToList().IndexOf(s)));
            }

            return output;

        }
    }
}
