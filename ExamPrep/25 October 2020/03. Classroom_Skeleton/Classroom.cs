using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>();

        }


        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count => students.Count;


        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (student == null)
            {
                return "Student not found";
            }
            students.Remove(student);

            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents = students.Where(x => x.Subject == subject).ToList();

            if (subjectStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var student in subjectStudents)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => this.Count;


        public Student GetStudent(string firstName, string lastName) => students.First(x => x.FirstName == firstName && x.LastName == lastName);

    }
}
