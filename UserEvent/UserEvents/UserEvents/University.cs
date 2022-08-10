using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserEvents
{
    class University
    {
        public string Name;//название
        public int MinimumEGEMark;//минимальный балл егэ
        public int Capacity;//вместимость универа
        public List<Student> AllowedStudents = new List<Student>();//список допущенных студентов
        public delegate void OnPerformFinished(University University);//делегат метода события(необходим для объявления event)
        public event OnPerformFinished Finished;//событие завершения обработки
        public void PerformStudents(List<Student> students)//метод выполняет проверку студентов
        {
            Console.WriteLine("Университет {0} начал отбор студентов.", this.Name);//выдать сообщение
            AllowedStudents = new List<Student>();//создать новый список
            for (int i = 0; i < students.Count; i++)//прогнать всех студентов
            {
                if (students[i].EGEMark >= MinimumEGEMark && Capacity > AllowedStudents.Count)//если баллов достаточно и еще есть своб места
                {
                    AllowedStudents.Add(students[i]);//добавить студента в список допущенных
                }
            }
            Console.WriteLine("Университет {0} завершил отбор студентов.", this.Name);//вывести сообщение
            Finished(this);//вызвать событие обработки завершения
        }
        public University(string Name, int MinimumEGEMark, int Capacity)//конструктор класса
        {
            this.Name = Name;
            this.MinimumEGEMark = MinimumEGEMark;
            this.Capacity = Capacity;
        }
    }
}
