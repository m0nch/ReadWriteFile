using System;
using System.Data;
using System.IO;

namespace ReadWriteFile.Data.DB
{
    internal class DbContext : IDbContext
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public string TxtTeachers { get; set; }
        public string TxtStudents { get; set; }
        public string TxtTemp { get; set; }

        public DbContext()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory.Replace("\\bin\\Debug", ""), "*.txt", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Contains("dataT"))
                {
                    TxtTeachers = file;
                }
                else if (file.Contains("dataS"))
                {
                    TxtStudents = file;
                }
                else if (file.Contains("temp"))
                {
                    TxtTemp = file;
                }
            }
            //TxtTeachers = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\TXT\\dataT.txt";
            //TxtStudents = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\TXT\\dataS.txt";
            //TxtTemp = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\TXT\\temp.txt";
        }

        StreamWriter _streamWriter;
        StreamReader _streamReader;

        public void Write(string txt)
        {
            using (_streamWriter = new StreamWriter(txt, true))
            {
                if (txt.Contains("dataT"))
                {
                    _streamWriter.WriteLine(Id + "*" + LastName + "*" + FirstName + "*" + Age);
                }
                else
                {
                    _streamWriter.WriteLine(Id + "*" + LastName + "*" + FirstName + "*" + Age + "*" + TeacherId);
                }
            }
        }
        public DataTable Read(string txt)
        {
            using (_streamReader = new StreamReader(txt))
            {
                string[] columnnames = null;
                if (txt.Contains("dataT"))
                {
                    columnnames = new string[] { "Id", "LastName", "FirstName", "Age" };
                }
                else
                {
                    columnnames = new string[] { "Id", "LastName", "FirstName", "Age", "TeacherId" };
                }
                DataTable dt = new DataTable();
                foreach (string c in columnnames)
                {
                    dt.Columns.Add(c);
                }
                string newline;
                while ((newline = _streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(newline))
                    {
                        DataRow dr = dt.NewRow();
                        string[] values = newline.Split('*');
                        for (int i = 0; i < values.Length; i++)
                        {
                            dr[i] = values[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
        }
        public DataTable Read(Guid id, string txt)
        {
            string _id = id.ToString();

            using (_streamReader = new StreamReader(txt))
            {
                string[] columnnames = null;
                if (txt.Contains("dataT"))
                {
                    columnnames = new string[] { "Id", "LastName", "FirstName", "Age" };
                }
                else
                {
                    columnnames = new string[] { "Id", "LastName", "FirstName", "Age", "TeacherId" };
                }
                DataTable dt = new DataTable();
                foreach (string c in columnnames)
                {
                    dt.Columns.Add(c);
                }

                string newline;
                while ((newline = _streamReader.ReadLine()) != null)
                {
                    if (newline.Contains(_id))
                    {
                        DataRow dr = dt.NewRow();
                        string[] values = newline.Split('*');
                        for (int i = 0; i < values.Length; i++)
                        {
                            dr[i] = values[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
        }
        public string Find(string txt, string file)
        {
            string newline;
            string result = null;
            using (_streamReader = new StreamReader(file))
            {
                while ((newline = _streamReader.ReadLine()) != null)
                {
                    if (newline.Contains(txt))
                    {
                        result = newline;
                    }
                }
                return result;
            }
        }
        public void Replace(string lineRemove, string lineInsert, string file)
        {
            using (_streamReader = new StreamReader(file))
            {
                using (_streamWriter = new StreamWriter(TxtTemp))
                {
                    while ((lineInsert = _streamReader.ReadLine()) != null)
                    {
                        if (String.Compare(lineInsert, lineRemove) == 0)
                            continue;

                        if (!string.IsNullOrWhiteSpace(lineInsert))
                            _streamWriter.WriteLine(lineInsert);
                    }
                }
            }
            File.WriteAllText(file, String.Empty);

            using (_streamReader = new StreamReader(TxtTemp))
            {
                using (_streamWriter = new StreamWriter(file))
                {
                    _streamWriter.WriteLine(_streamReader.ReadToEnd());
                }
            }
            File.WriteAllText(TxtTemp, String.Empty);
        }
    }
}
