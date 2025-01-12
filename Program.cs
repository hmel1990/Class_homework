namespace ClassHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создаем студента и добавляем оценки
            Student student = new Student();
            student.SetsurName("Якименко");

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

            Console.WriteLine("\n_________ Без сортировки__________");
            group1.ShowAllStudentsWithoutSort();

            Console.WriteLine("\n_________ Сортировка по среднему баллу __________");
            group1.SortByAverageGrade();
            group1.ShowAllStudentsWithoutSort();

            Console.WriteLine("\n_________ Сортировка по ФИО __________");
            group1.SortByFIO();
            group1.ShowAllStudentsWithoutSort();








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
