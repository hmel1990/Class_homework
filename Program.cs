using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ClassHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Создание группы и студентов
            //Создаем студента и добавляем оценки
            Student student1 = new Student();
            student1.SetsurName("Якименко");

            student1.AddCredits(10);
            student1.AddCredits(5);
            student1.AddCredits(10);

            student1.AddExams(9);
            student1.AddExams(2);
            student1.AddExams(12);

            student1.AddCourseWorks(10);
            student1.AddCourseWorks(7);
            student1.AddCourseWorks(8);

            //Клонируем студента с певрого студента
            Student student2 = (Student) student1.Clone();
            student2.SetsurName("Хмеленко");

            //Добавляем первому студенту еще оценок
            student1.AddCredits(6);
            student1.AddExams(7);
            student1.AddCourseWorks(8);

            //Клонируем студента с певрого студента
            Student student3 = (Student)student1.Clone();
            student3.SetsurName("Антоненко");
            student3.SetName("Александр");

            Student student4 = (Student)student3.Clone();
            student3.SetName("Олександр");



            student1.AddCredits(9);
            student1.AddExams(11);
            student1.AddCourseWorks(10);

            Student student5 = (Student)student1.Clone();
            student3.SetName("Петро");

            Student student6 = new Student();
            student6.AddCredits(10);
            student6.AddExams(11);
            student6.AddCourseWorks(10);

            Student student7 = new Student();
            student7.AddCredits(10);
            student7.AddExams(11);
            student7.AddCourseWorks(10);

            // Создаем группу
            Group group1 = new Group();

            // добавляем в первую группу студентов
            group1.AddStudent(student1);
            group1.AddStudent(student2);
            group1.AddStudent(student3);
            group1.AddStudent(student4);
            group1.AddStudent(student5);
            group1.AddStudent(student6);
            group1.AddStudent(student7);


            #endregion
            //////////////////////////////////////// Анонимные методы  ///////////////////////////////////////////////////////
            ///
            //____________________ Студенты - отличники __________________________

            var excellentStudents = group1.FilterStudents(delegate (Student s) {                
                return s.GetAverageGrade() >10;
            });

            //____________________ Студенты - чьи имена начинаются с буквы "А" __________________________

            var aStudents = group1.FilterStudents(delegate (Student s) {
                return s.GetName()[0] == 'А';
            });

            //____________________ Студенты - у которых есть хотя бы одна оценка "2" за экзамен __________________________

            var badStudents = group1.FilterStudents(delegate (Student s) {                
                return s.GetExams().Contains(2) || s.GetCredits().Contains(2) || s.GetCourseWorks().Contains(2);
            });


            //____________________ Студенты без оценок за ДЗ __________________________

            var withNoCreditsStudents = group1.FilterStudents(delegate (Student s) {
                return s.GetCredits().Count ==0;
            });
            //////////////////////////////////////// Лямбда выражения  ///////////////////////////////////////////////////////

            //____________________ Студенты, чьи имена длиннее 5 символов __________________________

            var longNameStudents = group1.FilterStudents(s=>s.GetName().Count() > 5);

            //____________________ Студенты, с четным количеством оценок __________________________

            var evenCreditsStudents = group1.FilterStudents(s => s.GetCredits().Count()%2 ==0);

            //____________________ Студенты, чья сумма всех оценок больше 50 __________________________

            var fiftySumCreditsStudents = group1.FilterStudents(s => (s.numberOfAllCredits() > 50));


            //____________________ Студенты с одинаковыми оценками за ДЗ (совпадает количество и значения, но не порядок следования) __________________________

            var sameGradesStudents = group1.FilterStudents((s) => s.sameStudents(group1.students));


            #region предыдущие задания


            #endregion
        }


    }
}
