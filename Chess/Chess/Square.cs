using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    struct Square
    {
            public static Square none = new Square(-1, -1);
            public int x { get; private set; } 

            public int y { get; private set; }

        public Square (int x, int y) : this() // Конструктор используется если в метод передается 2 параметра отдельно.
        {
            this.x = x;
            this.y = y;        
        }

        public Square(string e2) : this() // Конструктор используется если в класс передается параметр одной строкой.
        {
            if (e2.Length == 2 &&    // Проводим проверку на соответствие строки параметра приемлемому значению.
                e2[0] >= 'a' && e2[0] <= 'h' &&
                e2[1] >= '1' && e2[1] <= '8')
            {
                x = e2[0] - 'a'; // так как мы начинаем счет с 0 то значения нам необходимо сместить в лево если от h-а будет 7 
                y = e2[1] - '1';
            }
            else
                this = none; // возвращает объект "none" того же типа с заданными параметрами
        }

        public bool OnBoard()       // метод проверяет находится ли клетка в области доски
        {
            return x >= 0 && x < 8 &&
                   y >= 0 && y < 8; // Выполняются проверки и в случае удовлетворительного результата возвращается "true"
        }
    }
}
