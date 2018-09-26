using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace ChessDemo
 {
    class Program
    {
        static void Main(string[] args)
        {
            Chess.Chess chess = new Chess.Chess(); // Создаем объект "chess" класса "Chess" из подключенного пространства имен "Chess". Пространство имен у нас совпадает с названием класса, пожтому нам приходится объявлять класс таким образом "Chess.Chess".
            while (true)                           
            {
                Console.WriteLine(chess.fen); // Выводим значение "fen" на экран.
                Console.WriteLine(ChesToAscii(chess)); // Выводим на экнан содержимое метода ChesToAscii с переданным в него параметром "chess" 'этот параметр представляет так же объект шахмат которые мы построили
                string move = Console.ReadLine(); // Переменная "move" записывает в себя ход который намеривается осуществить игрок.
                if (move == "") break;
                chess =  chess.Move(move); // Наша сущьность "chess" берет на себя новое значение передавая аргумент "move"
            }
        }

        static string ChesToAscii(Chess.Chess chess)
        {
            string text = "  +-----------------+\n"; // Оформление.
            for (int y = 7; y >= 0; y--)
            {
                text += y + 1; // Нумеруем поля
                text += " | "; // Оформление
                for (int x = 0; x < 8; x++)
                    text += chess.GetFigureAt(x, y) + " ";
                text += "|\n"; // Оформление
            }
            text += "  +-----------------+\n"; // Оформление
            text += "    a b c d e f g h\n";
            return text;
        }
    }
}

