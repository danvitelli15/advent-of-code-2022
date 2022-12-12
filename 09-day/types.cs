using System.Text;

namespace Types;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Field
{
    private int _minX = 0;
    private int _maxX = 0;
    private int _minY = 0;
    private int _maxY = 0;

    private int _height = 1;
    private int _width = 1;

    public int Height { get => this._height; }
    public int Width { get => this._width; }

    private List<Knot> _knots;

    public Field(List<Knot> knots)
    {
        this._knots = knots;
    }

    public void Print(string? header = "")
    {
        Console.WriteLine(header);
        for (var y = 0; y < this._height; y++)
        {
            var row = new StringBuilder();
            var knotsInRow = this._knots.Where(k => k.Y == y).ToList();
            for (var x = 0; x < this._width; x++)
            {
                if (knotsInRow.Count > 0 && knotsInRow.Find(k => k.X == x) != null)
                {
                    row.Append(knotsInRow.Find(k => k.X == x).Name);
                }
                else
                {
                    row.Append('.');
                }
            }
            Console.WriteLine(string.Join("", row));
        }
        Console.WriteLine();
    }

    public void UpdateDimensions()
    {
        this._minX = Math.Min(this._minX, this._knots.First().X);
        this._maxX = Math.Max(this._maxX, this._knots.First().X);
        this._minY = Math.Min(this._minY, this._knots.First().Y);
        this._maxY = Math.Max(this._maxY, this._knots.First().Y);
        this._height = this._maxY - this._minY + 1;
        this._width = this._maxX - this._minX + 1;
    }
}

public class Knot
{
    public char Name { get; }
    public int X;
    public int Y;
    public HashSet<string> visited;

    public Knot(int x, int y, char name)
    {
        this.Name = name;
        this.X = x;
        this.X = y;
        this.visited = new HashSet<string>();
        this.visited.Add($"{this.X},{this.Y}");
    }

    private void _moved()
    {
        this.visited.Add($"{this.X},{this.Y}");
    }

    public void MoveUp() { this.Y++; }
    public void MoveDown() { this.Y--; }
    public void MoveRight() { this.X++; }
    public void MoveLeft() { this.X--; }

    public bool PredicessorMoved(int x, int y)
    {
        var result = false;
        if (y - this.Y > 1)
        {
            this.MoveUp();
            if (x - this.X > 0) this.MoveRight();
            else if (this.X - x > 0) this.MoveLeft();
            this._moved();
            result = true;
        }
        if (this.Y - y > 1)
        {
            this.MoveDown();
            if (x - this.X > 0) this.MoveRight();
            else if (this.X - x > 0) this.MoveLeft();
            this._moved();
            result = true;
        }
        if (x - this.X > 1)
        {
            this.MoveRight();
            if (y - this.Y > 0) this.MoveUp();
            else if (this.Y - y > 0) this.MoveDown();
            this._moved();
            result = true;
        }
        if (this.X - x > 1)
        {
            this.MoveLeft();
            if (y - this.Y > 0) this.MoveUp();
            else if (this.Y - y > 0) this.MoveDown();
            this._moved();
            result = true;
        }
        return result;
    }
}


public class Rope
{
    public List<Knot> knots { get; }
    public Knot Head => this.knots.First();
    public Knot Tail => this.knots.Last();

    private Field _field;

    public Rope(int numberOfKnots)
    {
        this.knots = new List<Knot>();
        this._field = new Field(this.knots);
        for (var i = 0; i < numberOfKnots; i++)
        {
            this.knots.Add(new Knot(0, 0, $"{i}"[0]));
        }
    }

    public void Move(Direction direction, int distance)
    {
        for (var j = 0; j < distance; j++)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.Head.MoveUp();
                    for (var i = 1; i < this.knots.Count; i++)
                    {
                        var iMoved = this.knots[i].PredicessorMoved(this.knots[i - 1].X, this.knots[i - 1].Y);
                        if (!iMoved) break;
                    }
                    break;
                case Direction.Down:
                    this.Head.MoveDown();
                    for (var i = 1; i < this.knots.Count; i++)
                    {
                        var iMoved = this.knots[i].PredicessorMoved(this.knots[i - 1].X, this.knots[i - 1].Y);
                        if (!iMoved) break;
                    }
                    break;
                case Direction.Left:
                    this.Head.MoveLeft();
                    for (var i = 1; i < this.knots.Count; i++)
                    {
                        var iMoved = this.knots[i].PredicessorMoved(this.knots[i - 1].X, this.knots[i - 1].Y);
                        if (!iMoved) break;
                    }
                    break;
                case Direction.Right:
                    this.Head.MoveRight();
                    for (var i = 1; i < this.knots.Count; i++)
                    {
                        var iMoved = this.knots[i].PredicessorMoved(this.knots[i - 1].X, this.knots[i - 1].Y);
                        if (!iMoved) break;
                    }
                    break;
            }
            // this._field.UpdateDimensions();
            // this._field.Print($"<== {direction} {distance} | {j + 1}/{distance} ==>");
            // Console.WriteLine($"Locations: {string.Join(", ", this.knots.Select(k => $"[{k.X}, {k.Y}]"))}\n");
        }
    }
}