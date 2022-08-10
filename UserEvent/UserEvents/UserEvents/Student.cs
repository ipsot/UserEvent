using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserEvents
{
    class Student
    {
        public int Age;//возраст
        public string Name;//имя
        public string Surname;//фамилия
        public int EGEMark;//балл егэ
        public void PerformUniversityResult(University University)//метод обработки университета
        {
            if(University.AllowedStudents.Contains(this))//если универ одобрил студента
            {
                Console.WriteLine(String.Format("Студент {0} {1}, принят в университет {2} с баллом ЕГЭ = {3}", Surname, Name, University.Name, EGEMark));
            }
            else//не одобрил студента
            {
                Console.WriteLine(String.Format("Студент {0} {1}, не принят в университет {2}, не добрал {3} баллов ", Surname, Name, University.Name, University.MinimumEGEMark - EGEMark));
            }
        }
        public Student(int Age, string Name, string Surname, int EGEMark)//конструктор класса
        {
            this.Age = Age;
            this.Name = Name;
            this.Surname = Surname;
            this.EGEMark = EGEMark;
        }
    }
}
