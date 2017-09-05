using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DemoData
{
    public class Students
    {
        static DataSet _dataSet = new DataSet();
        static DataTable _studentsTable = new DataTable();

        public int StudentID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        static Students()
        {
            _studentsTable.Columns.Add("StudentID", typeof(System.Int32));
            _studentsTable.Columns.Add("StudentName", typeof(System.String));
            _studentsTable.Columns.Add("StudentCity", typeof(System.String));

            _studentsTable.Rows.Add(new object[] { 1, "M. H. Kabir", "Calcutta" });
            _studentsTable.Rows.Add(new object[] { 2, "Ayan J. Sarkar", "Calcutta" });

            _dataSet.Tables.Add(_studentsTable);
        }

        public Students()
        { }

        public DataSet GetStudents()
        {

            return _dataSet;
        }

        public bool RemoveStudent(int studentID)
        {
            bool res = false;
            int i = 0;

            while (i < _studentsTable.Rows.Count)
            {
                DataRow row = _studentsTable.Rows[i];

                if (row["StudentID"].Equals(studentID))
                {
                    row.Delete();
                    res = true;
                    break;
                }

                i++;
            }

            return res;
        }
    }
}