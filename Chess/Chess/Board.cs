using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public string fen { get; private set;} // Переменная хранит положение всех фигур на доске.
        Figure[,] figures; // Двумерный массив который будет хранить значения на клетках. Типы значения элементов беруться из перечисления "Figure"
        public Color moveColor { get; private set; } // Хранит значение цвета фигуры, той чей ход в данный момент активен.
        public int moveNumber { get; private set; } // Переменная считает кол-во ходов. 

        public Board(string fen) // Конструктор, принимающий значения положения всех фигур на доске.
        {
            this.fen = fen; // отправляет значение в локальную переменную "fen".
            figures = new Figure [8, 8]; // создаем массив в переменную "figures" представим его как поле 8x8 с пустыми значениями:
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .
                                         //        . . . . . . . .

            Init(); // Вызываем метод для того что бы расположить фигуры в массиве
        }
        void Init() // Метод расставляет фигуры на нашем массиве "figure"
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing); // Вызываем метод и передаем в него значения: 1 - выделяем клетку(создаем новую сущьность клетка, передаем туда параметр), 2 - помещаем на клетку значение фигуры.  
            SetFigureAt(new Square("h8"), Figure.blackKing );
            moveColor = Color.white; // Определяет какой цвет шахмат ходит первым
        }

        public Figure GetFigureAt(Square square) // Метод для возвращения фигуры которая стоит на клетке которую мы передаем
        {
            if (square.OnBoard()) // Если клетка на доске то
                return figures[square.x, square.y]; // Возвращаем значение фигуры из массива "figures"
            return Figure.none; 
        }

        void SetFigureAt(Square square, Figure figure) // Метод помещает фигуру на клетку
            {
            if (square.OnBoard()) // Проверяет находится ли ли клетка в области видимости иными словами на доске   
                figures[square.x, square.y] = figure; // Помещаем в массив "figures" значение фигуры
        }

        public Board Move(FigureMoving fm) // Создает новую доску с учетом нового хода.
        {
            Board next = new Board(fen); // Новая доска
            next.SetFigureAt(fm.from, Figure.none); // Удаляет фигуру из того места от куда она делает ход.
            next.SetFigureAt(fm.to, fm.promotion == Figure.none ? fm.figure : fm.promotion); // Отправляет фигу на нужную клетку, в случае трансформации меняет фигуру
            if (moveColor == Color.black)
                next.moveNumber++;
            next.moveColor = moveColor.FlipColor(); // Меняем цвет ходящих фигур.
            return next;
        }

    }
}
