﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace ClassHomework
{

    internal class Group:ICloneable,IEnumerable <Student>
    {
        // Поля
        public List<Student> students;
        private string groupName;
        private string specialization;
        private int courseNumber;

        //________________________ Delegate _____________________________________________________

        public delegate bool StudentFilter(Student student);

        public delegate bool StudentsInGroupFilter(Group g, Student student);


        public List <Student> FilterStudents (StudentFilter del)
        {
            List<Student> filteredStudents = new List<Student>();

            foreach (Student student in this.students)
            {
                if (del(student))
                {
                    filteredStudents.Add (student);
                }
            }
            return filteredStudents;
        }

        //public List<Student> FilterStudents(Group group, StudentsInGroupFilter del)
        //{
        //    List <Student> filteredStudents = new List<Student>();
        //    foreach (Student student in group.students)
        //    {
        //        if (del(group, student))
        //        {
        //            filteredStudents.Add(student);
        //        }
        //    }
        //    if (filteredStudents.Count <= 0) Console.WriteLine("There is no same students");
        //    return filteredStudents;
        //}


        //________________________ IEnumerable _____________________________________________________
        public IEnumerator<Student> GetEnumerator()
        {
            return new GroupEnumerator(students);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GroupEnumerator: IEnumerator<Student>
        {
            private List<Student>? studentsForNumerate = null;
            int index = -1;

            public Student Current
            {
                get
                {
                    return studentsForNumerate[index];
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public GroupEnumerator (List <Student> students)
            {
                studentsForNumerate = students;
            }

            public bool MoveNext()
            {
                index++;
                if (index < studentsForNumerate.Count())
                { 
                    return true; 
                }

                return false;
            }
            public void Reset ()
            {
                index = -1;
            }
            public void Dispose()
            {
                
            }
        }


        //________________________ IClonable_____________________________________________________
        public object Clone()
        {


            return new Group
            {
                groupName = this.groupName,
                specialization = this.specialization,
                courseNumber = this.courseNumber,
                students = this.students.Select(st => (Student) st.Clone()).ToList()
                //students = new List<Student>() //сделал сначала через foreach, но потом переделал через лямбда выражение
            };
            //foreach (Student s in this.students)
            //{
            //    students.Add((Student)s.Clone());
            //}

        }
        //____________________ Свойства ______________________________________________________
        #region Свойства
        public List<Student> ListStudent 
        {
            get => students;
            set => students = value; 
        }
        public List<Student> StudentToList // добавление в конец списка студентов еще одного списка со студентами (для слияния груп например)
        {
            set => students.AddRange(value);
        }
        public string GroupName
        {
            get => groupName;
            set => groupName = value;
        }
        public string Specialization
        {
            get => specialization;
            set => specialization = value;
        }
        public int CourseNumber
        {
            get => courseNumber;
            set => courseNumber = value;
        }
        //__________________________________________________________________________
        #endregion

        #region сеттеры и геттеры
        public void SetGroupName(string groupName)
        {
            if (groupName == "")
            { throw new Exception("Название группы не должно быть пустым"); }
            this.groupName = groupName;
        }

        public string GetGroupName ()
            { return this.groupName; }

        public void SetSpecialization (string specialization)
        {
            if (specialization == "")
            { throw new Exception("Название специальности не должно быть пустым"); }
            this.specialization = specialization; 
        }
        public string GetSpecialization()
        { return this.specialization; }

        public void SetCourseNumber (int courseNumber)
            {
            if (courseNumber <= 0) 
            { throw new Exception ("Номер группы должен быть больше 0"); }
            this.courseNumber = courseNumber; }
        public int GetCourseNumber()
        { return this.courseNumber; }

        #endregion

        #region Конструкторы
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
        #endregion

        // Методы

        public void SortByAverageGrade()
        {
            //students.Sort();
            students.Sort(new Student.AverageGradeComparer());
        }

        public void SortByFIO()
        {
            //students.Sort();
            students.Sort(new Student.FIO());
        }

        // Добавление студента
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        // Удаление студента
        public void DeleteStudent(int index)
        {
            this.students.RemoveAt(index); 
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

        public void ShowAllStudentsWithoutSort()
        {
            Console.WriteLine($"Группа: {groupName}, Специализация: {specialization}, Курс: {courseNumber}");
            int count = 1;

            foreach (var student in students)
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


        #region перегрузка операторов
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
        #endregion

    }

}
