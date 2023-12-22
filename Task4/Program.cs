using System;
using System.IO;

namespace FinalTask
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime BithDay { get; set; }
    }
    class Programm
    {

        static void Main()
        {
            string BaseStudent = "/Users/tyr1k_qq/Desktop/Student";

            string DesktopPatch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string StudentPatch = Path.Combine(DesktopPatch, "Studens");
            Directory.CreateDirectory(StudentPatch);

            List<Student> students = GetStudentFromBase(BaseStudent);
        }

        static List<Student> GetStudentFromBase(string BaseStudent)
        {
            var students = new List<Student>();

            using (BinaryReader reader = new BinaryReader(File.Open(BaseStudent, FileMode.Open)))
            {
                while (reader.PeekChar() != -1)
                {
                    string name = reader.ReadString();
                    string group = reader.ReadString();
                    DateTime bithDay = new DateTime(reader.ReadInt32());

                    Student student = new Student
                    {
                        Name = name,
                        Group = group,
                        BithDay = bithDay
                    };

                    students.Add(student);
                }
            }
            return students;
        }
        static void SortStudentsAndWriteToFile(List<Student> students)
        {
            Dictionary<string, List<Student>> groupedStudents = new Dictionary<string, List<Student>>();
            foreach (Student student in students)
            {
                if (!groupedStudents.ContainsKey(student.Group))
                {
                    groupedStudents.Add(student.Group, new List<Student>());
                }
                groupedStudents[student.Group].Add(student);
            }


            foreach (List<Student> group in groupedStudents.Values)
            {
                for (int i = 0; i < group.Count - 1; i++)
                {
                    for (int j = 0; j < group.Count - i - 1; j++)
                    {
                        if (group[j].Name.CompareTo(group[j + 1].Name) > 0)
                        {
                            Student temp = group[j];
                            group[j] = group[j + 1];
                            group[j + 1] = temp;
                        }
                    }
                }
            }

            string DesktopPatch = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string StudentPatch = Path.Combine(DesktopPatch, "Studens");

            string outputPath = Path.Combine(StudentPatch, "SortedStudents.txt");
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (List<Student> group in groupedStudents.Values)
                {
                    foreach (Student student in group)
                    {
                        writer.WriteLine($"Name: {student.Name}, Group: {student.Group}, Birthday: {student.BithDay}");
                    }
                }
            }
        }
    }
}