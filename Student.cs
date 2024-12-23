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


        //____________________ Свойства ______________________________________________________
        #region Свойства
        public List<int> Credits
        {
            get => credits;
            set => credits = value;
        }
     public List<int> CourseWorks
        {
            get => courseWorks;
            set => courseWorks = value;
        }
     public List<int> Exams
        {
            get => exams;
            set => exams = value;
        }

        public string SurName
        {
            get => surName;
            set => surName = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string SecondName
        {
            get => secondName;
            set => secondName = value;
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }
        #endregion


        // Геттеры и сеттеры
        #region Геттеры и сеттеры
        public void SetsurName(string surName) 
        {
            if (surName == "")
            {
                throw new Exception("Фамилия не может быть пустым или содержать только пробелы.");
            }
            this.surName = surName; 
        }
        public string GetsurName() { return surName; }

        public void SetName(string name)
        {
            if (name == "")
            {
                throw new Exception("Имя не может быть пустым или содержать только пробелы.");
            }
            this.name = name;
        }
        public string GetName() { return name; }

        public void SetSecondName(string secondName)
        {
            if (secondName == "")
            {
                throw new Exception("Отчество не может быть пустым или содержать только пробелы.");
            }
            this.secondName = secondName;
        }

        public string GetSecondName() { return secondName; }

        public void SetBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
            {
                throw new Exception("Дата рождения не может быть в будущем.");
            }
            this.birthDate = birthDate;
        }

        public DateTime GetBirthDate() { return birthDate; }

        public void SetAddress(string address)
        {
            if (address == "")
            {
                throw new Exception("Адрес не может быть пустым или содержать только пробелы.");
            }
            this.address = address;
        }
        public string GetAddress() { return address; }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == "")
            {
                throw new Exception("Номер телефона не может быть пустым и должен содержать не менее 7 символов.");
            }
            this.phoneNumber = phoneNumber;
        }
        public string GetPhoneNumber() { return phoneNumber; }
        #endregion

        #region сеттеры для List
        // в Коллекциях оценок заменил Сеттеры на Add-еры, т.к. это будет логичнее, ситуаций когда наперед знаешь все оценки мало
        public void AddCredits(int credit)
        { 
            if(credit < 0)
            { throw new Exception("Оценка не может быть меньше 0"); }
            this.credits.Add(credit); 
        }
        public List<int> GetCredits() { return credits; }
        public void AddCourseWorks(int cours)
        {
            if (cours < 0)
            { throw new Exception("Оценка не может быть меньше 0"); }
            this.courseWorks.Add(cours); }
        public List<int> GetCourseWorks() { return courseWorks; }
        public void AddExams(int Exam)
        {
            if (Exam < 0)
            { throw new Exception("Оценка не может быть меньше 0"); }
            this.exams.Add(Exam); }
        public List<int> GetExams() { return exams; }
        #endregion




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

        #region перегрузка операторов
        public static bool operator true(Student s)
        {
            return s.GetAverageGrade() >= 7;
        }
        public static bool operator false(Student s)
        {
            return s.GetAverageGrade() < 7;
        }

        public static bool operator > (Student left, Student right)
        {
            
            return left.GetAverageGrade() > right.GetAverageGrade();
        }

        public static bool operator <(Student left, Student right)
        {
            return left.GetAverageGrade() < right.GetAverageGrade();
        }
        public static bool operator == (Student left, Student right)
        {
            return left.GetAverageGrade() == right.GetAverageGrade();
        }

        public static bool operator !=(Student left, Student right)
        {
            return left.GetAverageGrade() != right.GetAverageGrade();
        }

        public override bool Equals(object some_student)
        {           
            var who_is_it = some_student as Student;
            if (who_is_it == null)
            {
                Console.WriteLine("this is not Student, or reference is null");
                return false;
            }

            return who_is_it.GetAverageGrade() == this.GetAverageGrade();
        }

        public override int GetHashCode()
        {
            return GetAverageGrade().GetHashCode();
        }
        #endregion

    }

}
