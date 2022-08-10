using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserEvents
{
    class Program
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);

        static void Main()
        {
            List<Student> students = new List<Student>();//список студентов
            List<University> universities = new List<University>();//список универов
            universities.Add(new University("БГТУ", 60, 1000));//создать новый универ
            for (int i = 0; i < 10; i++)//создать 10 студентов
            {
                //генерируем параметры через рандом
                string Name = RandChar().ToString() + RandChar() + RandChar() + RandChar() + RandChar();
                string SurName = RandChar().ToString() + RandChar() + RandChar() + RandChar() + RandChar();
                int Age = rnd.Next(16, 25);
                int EgeMark = rnd.Next(0, 100);
                Student s = new Student(Age, Name, SurName, EgeMark);//создать студента
                for (int j = 0; j < universities.Count; j++)//добавить обработчик события завершения во все универы
                {
                    universities[j].Finished += s.PerformUniversityResult;
                }
                students.Add(s);//добавить студента в список
            }
            //Используя LINQ.ForEach Запускаем ассинхронную задачу, которая выполняет проверку студентов
            universities.ForEach(t => Task.Run(() => { t.PerformStudents(students); }));
            
            Console.ReadKey();//ожидаем нажатия до закрытия
        }
        static char RandChar()//функция создает новый рандомный символ
        {
            return (char)rnd.Next('а', 'я');
        }
    }
}
