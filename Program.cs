namespace UC4COMPARABLE
{  
        public class Point : IComparable<Point>
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int CompareTo(Point other)
            {
                // Compare points based on their X and Y coordinates
                if (X.CompareTo(other.X) != 0)
                    return X.CompareTo(other.X);
                else
                    return Y.CompareTo(other.Y);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Point other = (Point)obj;
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }

        // Line class representing a line segment between two points
        public class Line : IComparable<Line>
        {
            public Point Start { get; }
            public Point End { get; }

            public Line(Point start, Point end)
            {
                Start = start;
                End = end;
            }

            public int CompareTo(Line other)
            {
                // Compare lines based on the length
                double length = CalculateLength();
                double otherLength = other.CalculateLength();
                return length.CompareTo(otherLength);
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Line other = (Line)obj;
                return Start.Equals(other.Start) && End.Equals(other.End);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Start, End);
            }

            private double CalculateLength()
            {
                int deltaX = End.X - Start.X;
                int deltaY = End.Y - Start.Y;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                Point point1 = new Point(2, 3);
                Point point2 = new Point(5, 7);

                Line line1 = new Line(point1, point2);
                Line line2 = new Line(point1, point2);

                Console.WriteLine(line1.Equals(line2));  // Output: True
                Console.WriteLine(line1.CompareTo(line2)); // Output: 0 (lines are equal in length)
            }
        }

    
}
    