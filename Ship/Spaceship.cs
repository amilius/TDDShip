using System.Collections.Generic;
using System.Text;

namespace Ship
{
	public class Spaceship
    {
        public Location Location;

        public Spaceship(Location location)
        {
            Location = location;
        }

        public Point GetLocation()
        {
            return Location.Point;
        }

        public Direction GetDirection()
        {
            return Location.Direction;
        }

        public void TurnLeft()
        {
            Location.TurnLeft();
        }

        public void TurnRight()
        {
            Location.TurnRight();
        }

        public bool Forward(Point max, List<Point> obstacles)
        {
            return Location.Forward(max,obstacles);
        }
        public bool Backward(Point max, List<Point> obstacles)
        {
            return Location.Backward(max, obstacles);
        }

        public string Command(string command, Point max, List<Point> obstacles)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in command)
            {

                switch (c)
                {
                    case 'f':
                        if (Forward(max, obstacles))
                            sb.Append("o");
                        else
                            sb.Append("x");
                        break;
                    case 'b':
                        if(Backward(max, obstacles))
                            sb.Append("o");
                        else
                            sb.Append("x");
                        break;
                    case 'l':
                        TurnLeft();
                        sb.Append("o");
                        break;
                    case 'r':
                        TurnRight();
                        sb.Append("o");
                        break;
                }
            }
            return sb.ToString();
        }

    }
}