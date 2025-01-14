using System.ComponentModel.Design;
using System.Reflection;

namespace ClassHomework
{
    internal class Program
    {
        public static int Menu ()
        {
            Console.WriteLine("Выберите необходимео действие: \n0 - добавить студента в группу\n1 - удалить студента из группы\n2 - показать всех отличников\n3 - показать всех студентов, у которых есть двойки по экзаменам\n4 - выход из меню");
            return Convert.ToInt32 (Console.ReadLine ());
        }

        public static void AddStudent (Group g)
        {
            Console.WriteLine("Группа до добавления студента: \n");
            g.ShowAllStudents();
            Console.WriteLine("Группа после добавления студента: \n");
            g.AddStudent(new Student ());
            g.ShowAllStudents();
        }

        public static void DeleteStudentWithIndex1(Group g)
        {
            Console.WriteLine("Группа до удаления: \n");
            g.ShowAllStudents();
            Console.WriteLine("Группа после удаления: \n");
            g.DeleteStudent(1);
            g.ShowAllStudents();

        }
        public static void ShowAllBotans(Group g)
        {
            List <Student> botanStudents = g.students.Where(s => s.GetAverageGrade()>10).ToList();
            if (botanStudents.Count > 0)
            {
                Console.WriteLine("Список студентов отличников: ");
                foreach (Student student in botanStudents)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("Отличников нет (((");
            }
        }


        public static void ShowStudentsWith2(Group g)
        {
            List<Student> StudentsWith2 = g.students.Where(s => s.Exams.Contains(2)).ToList();
            
            
            if (StudentsWith2.Count > 0)
            {
                Console.WriteLine("Список студентов c двойками по єказмену: \n");
                foreach (Student student in StudentsWith2)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("Двоечников нет )))");
            }
        }


        delegate void WorkWithGroup (Group g, int x);

        static void Main(string[] args)
        {
            #region Создание группы и студентов
            //Создаем студента и добавляем оценки
            Student student = new Student();
            student.SetsurName("Якименко");

            student.AddCredits(10);
            student.AddCredits(5);
            student.AddCredits(10);

            student.AddExams(9);
            student.AddExams(2);
            student.AddExams(12);

            student.AddCourseWorks(10);
            student.AddCourseWorks(7);
            student.AddCourseWorks(8);

            //Клонируем студента с певрого студента
            Student student2 = (Student) student.Clone();
            student2.SetsurName("Хмеленко");

            //Добавляем первому студенту еще оценок
            student.AddCredits(6);
            student.AddExams(7);
            student.AddCourseWorks(8);

            //Клонируем студента с певрого студента
            Student student3 = (Student)student.Clone();
            student3.SetsurName("Антоненко");
            student3.SetName("Александр");

            Student student4 = (Student)student3.Clone();
            student3.SetName("Олександр");



            student.AddCredits(9);
            student.AddExams(11);
            student.AddCourseWorks(10);

            // Создаем группу
            Group group1 = new Group();

            // добавляем в первую группу студентов
            group1.AddStudent(student);
            group1.AddStudent(student2);
            group1.AddStudent(student3);
            group1.AddStudent(student4);
            #endregion


            var wwg = AddStudent;
            wwg += DeleteStudentWithIndex1;
            wwg += ShowAllBotans;
            wwg += ShowStudentsWith2;


            int index = Menu();
            while(index != 4)
            {                
                Delegate del = wwg.GetInvocationList()[index];
                MethodInfo method = del.Method;
                method.Invoke(typeof(Program), [group1]);
                index = Convert.ToInt32(Console.ReadLine());
            }




            #region предыдущие задания

            /*
              //Создаем студента и добавляем оценки
            Student student = new Student();
            student.AddCredits(10);
            student.AddCredits(5);
            student.AddCredits(10);

            student.AddExams(9);
            student.AddExams(10);
            student.AddExams(12);

            student.AddCourseWorks(10);
            student.AddCourseWorks(6);
            student.AddCourseWorks(5);

            //Клонируем студента с певрого студента
            Student student2 = (Student) student.Clone();

            //Добавляем первому студенту еще оценок
            student.AddCredits(6);
            student.AddExams(7);
            student.AddCourseWorks(8);

            // Выводим оценки первого студента
            Console.WriteLine("\nДанные по student:\n");
            student.ShowStudentInfo();

            // Выводим оценки второго студента
            Console.WriteLine("\nДанные по student2:\n");

            student2.ShowStudentInfo();

            // Создаем группу
            Group group1 = new Group();

            // добавляем в первую группу студентов
            group1.AddStudent(student);
            group1.AddStudent(student2);

            //Клонируем группу с двумя студентами
            Group group2 = (Group) group1.Clone();

            //Добавляем к первой группе третьего студента
            group1.AddStudent(student2);

            // В первой группе теперь 3 студента
            Console.WriteLine("\n\n ShowAllStudent from group");
            group1.ShowAllStudents();



            // Во второй группе осталось по прежнему 2 студента
            Console.WriteLine("\n\n ShowAllStudent from group2");
            group2.ShowAllStudents();
            group2.students[1].AddExams(1);

            Console.WriteLine("\n_____________________________________________\n");

            group2.students[1].ShowStudentInfo();

            Console.WriteLine("\n_____________________________________________\n");


            group1.students[1].ShowStudentInfo();
             */
            //Student student1 = new Student();
            //Student student2 = new Student();
            //var list = new List<Student>();
            //list.Add(student1);
            //list.Add(student2);
            //list.Add(student);
            //Group group = new Group();
            //group.ShowAllStudents();
            //group.StudentToList = list; //проверка свойства которое добавляет список студентов в группу в конец 
            //group.ShowAllStudents();

            ////проверка выставления оценки за екзамен меньше 0
            //try
            //{
            //    student.AddExams(-1);
            //}
            //catch (Exception ex)
            //{
            //    Console.Write("Слишком низкая оценка: ");
            //    Console.WriteLine(ex.Message);
            //}

            ////проверка присвонеия имени группы пустого значения
            //try
            //{
            //    group.SetGroupName("");
            //}
            //catch (Exception ex)
            //{
            //    Console.Write("Неправильное имя: ");
            //    Console.WriteLine(ex.Message);
            //}

            //student2.AddCredits(12);
            //student2.AddCredits(12);
            //student2.AddCredits(12);
            //student2.AddCredits(12);

            //if (student2 > student1)
            //{
            //    Console.WriteLine("student2 > student1");
            //}
            //else
            //{
            //    Console.WriteLine("student2 < student1");
            //}

            //if (student2 == student1)
            //{
            //    Console.WriteLine("student2 == student1");
            //}
            //else
            //{
            //    Console.WriteLine("student2 != student1");
            //}

            //student.ShowStudentInfo();
            #endregion
        }


    }
}
