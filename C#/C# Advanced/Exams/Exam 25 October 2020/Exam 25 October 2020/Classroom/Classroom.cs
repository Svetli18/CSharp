namespace ClassroomProject
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class Classroom
    {
        private List<Student> students;

        private Classroom()
        {
            this.students = new List<Student>();
        }

        public Classroom(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            this.students.Remove(student);

            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents = this.students
                .Where(s => s.Subject == subject)
                .ToList();

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

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = this.students
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
