using Microsoft.VisualBasic.CompilerServices;

namespace SimpleSnake.GameObjects;

public class Field
{
    public Field(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; }
    public int Height { get; }
}