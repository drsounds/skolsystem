﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Skolprojekt.Models;
namespace Skolprojekt
{
    public partial class CourseForm : Form
    {
        private Course course;
        public Course Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
                textBox1.Text = course.Name;
                textBox2.Text = course.Code;
                LoadAttendants();
            }
        }
        public CourseForm()
        {
            InitializeComponent();
            Course = new Course();
            Course.Attendants = new List<Attendee>();

        }
        private void LoadAttendants()
        {
            if (this.Course != null)
            {
                foreach(Student student in Course.Students)
                {
                    var item = listView1.Items.Add(student.LastName);
                    item.SubItems.Add(student.FirstName);
                    item.SubItems.Add(student.Address);
                    item.SubItems.Add(student.Zip);
                    item.SubItems.Add(student.City);
                    item.SubItems.Add(student.Phone);
                    item.SubItems.Add(student.Email);
                    item.SubItems.Add(student.SSN);
                    
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
        }
        public CourseForm(Course course)
        {
            InitializeComponent();
            Course = course;
        }
        private void EditCourseForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            course.Name = textBox1.Text;
            course.Code = textBox2.Text;
            using (SchoolContext sc = new SchoolContext())
            {
                if (Course.Id > 0)
                    sc.Courses.Attach(Course);
                else
                    sc.Courses.Add(Course);
                sc.SaveChanges();
            }
            Close();
        }
    }
}
