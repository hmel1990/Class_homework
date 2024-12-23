namespace Class_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Student student1 = new Student();
            Student student2 = new Student();
            var list = new List<Student>();
            list.Add(student1);
            list.Add(student2);
            list.Add(student);
            Group group = new Group();
            group.ShowAllStudents();
            group.StudentToList = list; //проверка свойства которое добавляет список студентов в группу в конец 
            group.ShowAllStudents();


            //проверка выставления оценки за екзамен меньше 0
            try
            {
                student.AddExams(-1);
            }
            catch (Exception ex)
            {
                Console.Write("Слишком низкая оценка: ");
                Console.WriteLine(ex.Message);
            }

            //проверка присвонеия имени группы пустого значения
            try
            {
                group.SetGroupName("");
            }
            catch (Exception ex)
            {
                Console.Write("Неправильное имя: ");
                Console.WriteLine(ex.Message);
            }

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
        }
    }
}
