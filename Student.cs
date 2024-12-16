using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_homework
{

    internal class Student
    {
        internal string surName;
        internal string name;
        internal string secondName;
        internal DateTime birthDate;
        internal string address;
        internal string phoneNumber;

        private List<int> credits;       // Зачёты
        private List<int> courseWorks;   // Курсовые работы
        private List<int> exams;         // Экзамены

        // Конструкторы
        public Student()
        {
            surName = "Shevchenko";
            name = "Taras";
            secondName = "Grihorovich";
            birthDate = new DateTime(1814, 3, 9);
            address = "Ukraine";
            phoneNumber = "777";
            credits = new List<int>();
            courseWorks = new List<int>();
            exams = new List<int>();
        }

        public Student(string surName, string name, string secondName, DateTime birthDate,
                       string address, string phoneNumber)            
        {
            this.surName = surName;
            this.name = name;
            this.secondName = secondName;
            this.birthDate = birthDate;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        // Геттеры и сеттеры

        public void SetsurName(string surName) { this.surName = surName; }
        public string GetsurName() { return surName; }

        public void SetName(string name) { this.name = name; }
        public string GetName() { return name; }

        public void SetSecondName(string secondName) { this.secondName = secondName; }
        public string GetSecondName() { return secondName; }

        public void SetBirthDate(DateTime birthDate) { this.birthDate = birthDate; }
        public DateTime GetBirthDate() { return birthDate; }

        public void SetAddress(string address) { this.address = address; }
        public string GetAddress() { return address; }

        public void SetPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber; }
        public string GetPhoneNumber() { return phoneNumber; }

        // в Коллекциях оценок заменил Сеттеры на Add-еры, т.к. это будет логичнее, ситуаций когда наперед знаешь все оценки мало
        public void AddCredits(int credit)
        { this.credits.Add(credit); }
        public List<int> GetCredits() { return credits; }
        public void AddCourseWorks(int cours)
        { this.credits.Add(cours); }
        public List<int> GetCourseWorks() { return courseWorks; }

        public void AddExams(int Exam)
        { this.credits.Add(Exam); }
        public List<int> GetExams() { return exams; }

       

        // Метод для отображения данных о студенте
        public void ShowStudentInfo()
        {
            Console.WriteLine($"ФИО: {surName} {name} {secondName}");
            Console.WriteLine($"Дата рождения: {birthDate.ToShortDateString()}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Телефон: {phoneNumber}");
            Console.WriteLine($"Оценки за зачёты: {string.Join(", ", credits)}");
            Console.WriteLine($"Оценки за курсовые: {string.Join(", ", courseWorks)}");
            Console.WriteLine($"Оценки за экзамены: {string.Join(", ", exams)}");
        }

        // Переопределение ToString()
        public override string ToString()
        {
            return $"{surName} {name} {secondName} - {birthDate.ToShortDateString()}";
        }


        // Подсчёт среднего балла
        public double GetAverageGrade()
        {
            var allGrades = new List<int>();
            allGrades.AddRange(credits);
            allGrades.AddRange(courseWorks);
            allGrades.AddRange(exams);

            if (allGrades.Count == 0) return 0;

            double sum = 0;
            foreach (var grade in allGrades)
                sum += grade;

            return sum / allGrades.Count;
        }
    }

}
