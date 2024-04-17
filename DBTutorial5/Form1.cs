using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTutorial5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            using (var classicContext = new classicmodelsEntities())
            {
                /***** Do the following program yourself *****/
                var offCode = from list in classicContext.offices

                              select list.officeCode;
;

                foreach (var offCode2 in offCode.ToList())
                {
                    comboBox1.Items.Add(offCode2);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            String temp = Convert.ToString(comboBox1.SelectedItem);
            using (var classicContext = new classicmodelsEntities())
            {
                //========== Display Office Information ============
                var offInfo = from list in classicContext.offices
                              where list.officeCode.Contains(temp)
                              select list;

                foreach (var offInfo2 in offInfo.ToList())
                {
                    textBox2.Text = "Phone Number: " + offInfo2.phone + "\r\nAddress: " + offInfo2.addressLine1 + ", " + offInfo2.addressLine2 + "\r\nCity: " + offInfo2.city + "\r\nCountry: " + offInfo2.country;
                }

                comboBox2.Items.Clear();
                textBox1.Clear();

                var staffName = from list in classicContext.employees
                                where list.officeCode == temp
                                select new { list.firstName, list.lastName };


                foreach (var staffName2 in staffName.ToList())
                {
                    comboBox2.Items.Add(staffName2.firstName + " " +staffName2.lastName);
                }

                textBox3.Clear();

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String temp = Convert.ToString(comboBox2.SelectedItem);

            using (var classicContext = new classicmodelsEntities())
            {
                var staffInfo = from sInfo in classicContext.employees
                                where (sInfo.firstName + " " + sInfo.lastName) == temp
                       select new { sInfo.email, sInfo.extension, sInfo.jobTitle };

                foreach (var staffInfo2 in staffInfo.ToList())
                {
                    textBox3.Text = "Email: " + staffInfo2.email + "\r\nExtension: " + staffInfo2.extension + "\r\nJob Title: " + staffInfo2.jobTitle;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            using (var classicContext = new classicmodelsEntities())
            {
                String temp = Convert.ToString(comboBox1.SelectedItem);
                comboBox2.Items.Clear();
                textBox3.Clear();

                /* Do the following program youself */
                var staffName = from list in classicContext.employees
                                where list.officeCode == comboBox1.SelectedItem && list.firstName.Contains(textBox1.Text)
                                select new { list.firstName, list.lastName };
                    /* SELECT firstName, lastName FROM employees */
  /* WHERE …… [Tips] - (comboBox1 selectd item = office code 
                          && firstName conatains textbox3.text) */

                foreach (var staffName2 in staffName.ToList())
                {
                    comboBox2.Items.Add(staffName2.firstName + " " + staffName2.lastName);
                }
            }

        }
    }
}
