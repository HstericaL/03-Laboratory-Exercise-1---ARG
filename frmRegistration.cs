using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _03LaboratoryExercise1
{
    public partial class frmRegistration : Form
    {
        //Private Variables
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        /////return methods 
        public long StudentNumber(string studNum)
        {
            //TRY
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                {
                    MessageBox.Show("Message: " + ex.Message);
                }
            }

            return _StudentNo;


        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }
        //End of 03-Method file (txt)

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            //Number 8
            string[] ListOfPrograms = new string[]
            {
                "BS Information Tehnology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hopitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfPrograms[i].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //TRY
            try
            {
                StudentInformationClass.SetFullname = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = Convert.ToInt32(StudentNumber(txtStudentNo.Text));//FIXED
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = Convert.ToInt32(ContactNo(txtContactNo.Text));//FIXED
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Message: " + ex.Message);
            }

            finally 
            {
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();

                txtAge.Clear();
                txtContactNo.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleInitial.Clear();
                txtStudentNo.Clear();

                cbGender.SelectedIndex = -1;
                cbPrograms.SelectedIndex = -1;
            }
            
        }
    }
}
