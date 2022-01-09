using ReadWriteFile.Data.Models;
using ReadWriteFile.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace ReadWriteFile
{
    public partial class StudentsForm : Form
    {
        private readonly IStudentService _studentService;
        private readonly _IAppCache _appCache;

        public StudentsForm(
            IStudentService studentService,
            _IAppCache appCache)
        {
            InitializeComponent();
            _studentService = studentService;
            _appCache = appCache;
        }
        private void SecondForm_Load(object sender, EventArgs e)
        {
            RefreshStudents();
            grdStudents.AutoGenerateColumns = false;
            if (grdStudents.SelectedRows.Count > 0)
            {
                ShowRow();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                TeacherId = Guid.Parse(_appCache._ViewBag["TeacherId"].ToString()),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _studentService.Add(student);
            RefreshStudents();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student student = _studentService.Get(Guid.Parse(grdStudents.SelectedRows[0].Cells["Id"].Value.ToString()));
            _studentService.Remove(student);
            RefreshStudents();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = Guid.Parse(lblGuid.Text),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                TeacherId = Guid.Parse(lblTGuid.Text)
            };
            _studentService.Update(student);
            RefreshStudents();
        }
        private void grdStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRow();
        }
        private void SecondForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appCache._ViewBag.Remove("TeacherId");
        }
        private void RefreshStudents()
        {
            DataTable dt = _studentService.GetAllByTeacher(Guid.Parse(_appCache._ViewBag["TeacherId"].ToString()));
            grdStudents.DataSource = dt;
            if (grdStudents.Rows.Count > 0)
            {
                grdStudents.Rows[0].Selected = true;
            }
            ShowRow();
        }
        private void ShowRow()
        {
            if (grdStudents.SelectedRows.Count > 0)
            {
                lblGuid.Visible = true; lblTGuid.Visible = true;
                lblGuid.Text = grdStudents.SelectedRows[0].Cells["Id"].Value.ToString();
                lblTGuid.Text = grdStudents.SelectedRows[0].Cells["TeacherId"].Value.ToString();
                txtLastName.Text = grdStudents.SelectedRows[0].Cells["LastName"].Value.ToString();
                txtFirstName.Text = grdStudents.SelectedRows[0].Cells["FirstName"].Value.ToString();
                txtAge.Text = grdStudents.SelectedRows[0].Cells["Age"].Value.ToString();
            }
            else
            {
                lblGuid.Visible = false; lblTGuid.Visible = false;
                lblGuid.Text = "";
                lblTGuid.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
                txtAge.Text = "";
            }
        }
    }
}
