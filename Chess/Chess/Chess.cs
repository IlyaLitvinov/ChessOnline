using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Chess
    {
        public string fen { get; private set; } // Переменная "fen" хранит положение фигур на доске, ее можно получить но нельзя задать извне.
        Board board; // Переменна "board" класса "Board", класс доступен из за общего пространства имен "Шахматы"

        public Chess (string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1") // Конструктор задает в переменную "fen" начальное положение фигур на доске, а так же помещает в переменную "board", новый объект, на который передает положение фигур.
        {
            this.fen = fen; // Присваиваем значение переменной положение шахмат на доске.
            board = new Board(fen); // Создает экземпляр "board" и передает параметр "fen".
        }

        Chess(Board board)
        {
            this.board = board;        
        }

        public Chess Move(string move) // Pe2e4 - (пешка)P(от)e2(к)e4, Pe7e8Q - (пешка)P(от)e7(к)e8(превращается в ферзя)Q.
        {
            FigureMoving fm = new FigureMoving(move); // Передаем параметр движения фигуры и получаем сущьность описывающую перемещение фигуры.
            Board nextBoard = board.Move(fm); // Записываем новую доску в новую сущьность новой доски учитывая ход.
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt (int x, int y) // Метот позволяет получить значение фигуры имея координаты клетки.
        {
            Square square = new Square(x,y); // Так как структура хранит значение предыдущее то мы создаем новый объект со старыми данными
            Figure f  = board.GetFigureAt(square); // Получили фигуру с активной клетки 
            return f == Figure.none ? '.' : (char)f; // Тернанрный оператор если фигуры нет на данной клетке то вернем символ "." иначече символ фигуры.
        }
    }
}
