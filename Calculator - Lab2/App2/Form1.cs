using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace App2
{
    public partial class Form1 : Form
    {
        private bool number1Set = false;

        private float result = 0;

        public void init() {
            DataTable d = new DataTable();
            d.Columns.Add("Number one");
            d.Columns.Add("Operation");
            d.Columns.Add("Number two");
            d.Columns.Add("Result");
            dataGridViewHistory.DataSource = d;
        }

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            float f;

            if (!float.TryParse(textBoxNrTwo.Text, out f))
            {
                MessageBox.Show("Number 2 must be a number");
                textBoxNrTwo.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float f;

            if (!float.TryParse(textBoxNrOne.Text, out f))
            {
                MessageBox.Show("Number 1 must be a number");
                textBoxNrOne.Text = "";
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            plus();
        }

        private void plus() {
            labOperation.Text = "+";
            result = float.Parse(textBoxNrOne.Text, CultureInfo.InvariantCulture.NumberFormat) + float.Parse(textBoxNrTwo.Text, CultureInfo.InvariantCulture.NumberFormat);
            equal();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            minus();
        }

        private void minus() {
            labOperation.Text = "-";
            result = float.Parse(textBoxNrOne.Text, CultureInfo.InvariantCulture.NumberFormat) - float.Parse(textBoxNrTwo.Text, CultureInfo.InvariantCulture.NumberFormat);
            equal();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            multiply();
        }

        private void multiply() {
            labOperation.Text = "*";
            result = float.Parse(textBoxNrOne.Text, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(textBoxNrTwo.Text, CultureInfo.InvariantCulture.NumberFormat);
            equal();
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            substract();
        }

        private void substract() {
            labOperation.Text = "/";
            result = float.Parse(textBoxNrOne.Text, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(textBoxNrTwo.Text, CultureInfo.InvariantCulture.NumberFormat);
            equal();
        }

        private void equal()
        {
            DataTable d = (DataTable)dataGridViewHistory.DataSource;
            d.Rows.Add();
            d.Rows[d.Rows.Count - 1][0] = textBoxNrOne.Text;
            d.Rows[d.Rows.Count - 1][1] = labOperation.Text;
            d.Rows[d.Rows.Count - 1][2] = textBoxNrTwo.Text;
            d.Rows[d.Rows.Count - 1][3] = result;

            dataGridViewHistory.DataSource = d;
        }

        private void dataGridViewHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataTable d = (DataTable)dataGridViewHistory.DataSource;
            float res = 0;

            for (int i = 0; i <= e.RowIndex; i++) {
                res = res + float.Parse((string)d.Rows[i][3]);
            }
            

            labelResult.Text = res.ToString();
        }

        private void addToNr(float val) {
            if (!number1Set)
            {
                textBoxNrOne.Text = textBoxNrOne.Text + val.ToString();
            }
            else
            {
                textBoxNrTwo.Text = textBoxNrTwo.Text + val.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addToNr(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addToNr(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addToNr(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addToNr(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addToNr(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addToNr(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addToNr(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addToNr(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addToNr(9);
        }

        private void ClickTextBoxNrOne(object sender, MouseEventArgs e)
        {
            number1Set = false;
        }

        private void ClickTextBoxNrTwo(object sender, EventArgs e)
        {
            number1Set = true;
        }

        private void textBoxValidate_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { '+', '-', '*', '/'};

            string text = textBoxValidate.Text;

            string[] words = text.Split(delimiterChars);

            try {

                if (words.Length != 2)
                {
                    MessageBox.Show("Please provide correct input");
                    textBoxValidate.Text = "";
                    textBoxNrOne.Text = "";
                    textBoxNrTwo.Text = "";
                }
                else
                {

                    textBoxNrOne.Text = words[0].Trim();
                    textBoxNrTwo.Text = words[1].Trim();

                    if (text.Contains("+"))
                        plus();
                    else if (text.Contains("-"))
                        minus();
                    else if (text.Contains("*"))
                        multiply();
                    else if (text.Contains("/"))
                        substract();
                }
            }
            catch{
                MessageBox.Show("Please provide correct input");
                textBoxValidate.Text = "";
                textBoxNrOne.Text = "";
                textBoxNrTwo.Text = "";
            }

        }
    }
}
