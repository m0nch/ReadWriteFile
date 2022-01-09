using ReadWriteFile.Data.Models;
using ReadWriteFile.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace ReadWriteFile
{
    public partial class TeachersForm : Form
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private StudentsForm _secondForm;
        private readonly _IAppCache _appCache;

        public TeachersForm(
            ITeacherService teacherService,
            IStudentService studentService,
            StudentsForm secondForm,
            _IAppCache appCache)
        {
            InitializeComponent();

            _teacherService = teacherService;
            _studentService = studentService;
            _secondForm = secondForm;
            _appCache = appCache;
        }
        private void TeachersForm_Load(object sender, EventArgs e)
        {
            RefreshTeachers();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _teacherService.Add(teacher);
            RefreshTeachers();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Teacher teacher = _teacherService.Get(Guid.Parse(grdTeachers.SelectedRows[0].Cells["Id"].Value.ToString()));
            _teacherService.Remove(teacher);
            RefreshTeachers();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher
            {
                Id = Guid.Parse(lblGuid.Text),
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                Age = Convert.ToInt32(txtAge.Text)
            };
            _teacherService.Update(teacher);
            RefreshTeachers();
        }
        private void grdTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRow();
        }
        private void grdTeachers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var obj = ((DataGridView)sender).SelectedRows[0].Cells["Id"].Value;
                
                if (!_appCache._ViewBag.ContainsValue(obj))
                {
                    _appCache._ViewBag.Add("TeacherId", obj);
                }
                _secondForm.ShowDialog();
                _secondForm.Activate();
            }
        }
        private void RefreshTeachers()
        {
            DataTable dt = _teacherService.GetAll();
            grdTeachers.DataSource = dt;
            if (grdTeachers.Rows.Count > 0)
            {
                grdTeachers.Rows[0].Selected = true;
            }
            ShowRow();
        }
        private void ShowRow()
        {
            if (grdTeachers.SelectedRows.Count > 0)
            {
                lblGuid.Visible = true;
                lblGuid.Text = grdTeachers.SelectedRows[0].Cells["Id"].Value.ToString();
                txtLastName.Text = grdTeachers.SelectedRows[0].Cells["LastName"].Value.ToString();
                txtFirstName.Text = grdTeachers.SelectedRows[0].Cells["FirstNAme"].Value.ToString();
                txtAge.Text = grdTeachers.SelectedRows[0].Cells["Age"].Value.ToString();
            }
        }
    }
}
