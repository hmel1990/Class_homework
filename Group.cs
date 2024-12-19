using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Class_homework
{

    internal class Group
    {
        // Поля
        private List<Student> students;
        private string groupName;
        private string specialization;
        private int courseNumber;

        // Конструктор по умолчанию
        public Group()
        {
            students = new List<Student>();
            groupName = "";
            specialization = "";
            courseNumber = 0;
        }

        // Конструктор с параметрами
        public Group(string groupName, string specialization, int courseNumber)
            : this()
        {
            this.groupName = groupName;
            this.specialization = specialization;
            this.courseNumber = courseNumber;
        }

        // Методы

        // Добавление студента
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        // Показ всех студентов с сортировкой по фамилии и имени
        public void ShowAllStudents()
        {
            Console.WriteLine($"Группа: {groupName}, Специализация: {specialization}, Курс: {courseNumber}");
            // Сортируем студентов по фамилии и имени

            var sortedStudents = students.OrderBy(s => s.surName).ThenBy(s => s.name).ToList();

            // Выводим отсортированный список студентов
            int count = 1;
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"{count} {student.surName} {student.name}");
                count++;
            }        
        }


        // Редактирование данных студента
        public void EditStudent(int index, Student student)
        {
            if (index >= 0 && index < students.Count)
                students[index] = student;
        }


        //////////////////////////////////////////////////////////////////////////////



        // Перевод студента в другую группу
        public void TransferStudent(int index, Group newGroup)
        {
            if (index >= 0 && index < students.Count)
            {
                this.students.RemoveAt(index);
                newGroup.AddStudent(students[index]);
            }
        }

        // Отчисление студентов со средним баллом ниже 7
        public void DeleteStudents7()
        {
            students = students.Where(s => s.GetAverageGrade() >= 7).ToList();
        }


        // Отчисление самого неуспевающего студента
        public void DeleteWorstStudent()
        {
            if (students.Count == 0) return;

            Student worstStudent = students.OrderBy(s => s.GetAverageGrade()).First();
            students.Remove(worstStudent);
        }

        public static bool operator true(Group g)
        {
            return g.students.Count > 0;
        }

        public static bool operator false(Group g)
        {
            return g.students.Count == 0;
        }

        public static bool operator >(Group left, Group right)
        {

            return left.students.Count() > right.students.Count();
        }

        public static bool operator <(Group left, Group right)
        {
            return left.students.Count() < right.students.Count();
        }
        public static bool operator ==(Group left, Group right)
        {

            return left.students.Count() == right.students.Count();
        }

        public static bool operator !=(Group left, Group right)
        {
            return left.students.Count() != right.students.Count();
        }

        public Student this[int index]
        {
            get
            {
                return students[index];
            }
        }

        public override bool Equals(object some_group)
        {
            var who_is_it = some_group as Group;
            if (who_is_it == null)
            {
                Console.WriteLine("this is not Student, or reference is null");
                return false;
            }

            return who_is_it.students.Count() == this.students.Count();
        }

        public override int GetHashCode()
        {
            return (students.Count()+courseNumber).GetHashCode();
        }

    }

}
