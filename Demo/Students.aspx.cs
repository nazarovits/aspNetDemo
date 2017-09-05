using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{

    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Student()
        { }

        public DataSet GetStudents()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("StudentId", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("City", typeof(string));

            // dt.Rows.Add(new object[] { 1, "Jack", "Calcutta" });
            // dt.Rows.Add(new object[] { 2, "Bob", "Washington" });

            ds.Tables.Add(dt);

            return ds;
        }
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}