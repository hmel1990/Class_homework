namespace Class_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Student student1 = new Student();
            Student student2 = new Student();
            
            student2.AddCredits(12);
            student2.AddCredits(12);
            student2.AddCredits(12);
            student2.AddCredits(12);

            if (student2 > student1)
            {
                Console.WriteLine("student2 > student1");
            }
            else
            {
                Console.WriteLine("student2 < student1");
            }

            if (student2 == student1)
            {
                Console.WriteLine("student2 == student1");
            }
            else
            {
                Console.WriteLine("student2 != student1");
            }

            student.ShowStudentInfo();
        }
    }
}
