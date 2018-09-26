using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum Color // перечисление возможных цветов
    {
        none,
        white,
        black
    }

    static class ColorMethods // статический класс для того что бы он являлся объективным для всех
    {
        public static Color FlipColor(this Color color) // метод меняет цвет активных фигур
        {
            if (color == Color.black) return Color.white;
            if (color == Color.white) return Color.black;
            return Color.none;
        }
    }
}
