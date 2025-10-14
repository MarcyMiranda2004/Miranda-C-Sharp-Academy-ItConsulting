using EssDraw.Circle;
using EssDraw.Square;
using EssDraw;

namespace EssDraw.ShapeCreator
{
    public abstract class ShapeCreator
    {
        public static IShape CreateShape(string type)
        {
            switch (type)
            {
                case "Circle":
                    return new Circle.Circle();

                case "Square":
                    return new Square.Square();

                default:
                    return null;
            }
        }
    }
}