using System.Collections.Generic;

namespace Ship
{
	public class Location
	{
		private const int FORWARD = 1;
		private const int BACKWARD = -1;

		public Point Point => _point;

		private Point _point;

		public int X => Point.X;
		public int Y => Point.Y;

		public Direction Direction { get; set; }

		public Location(Point point, Direction direction)
		{
			_point = point;
			Direction = direction;
		}

		public bool Forward()
		{
			return Move(FORWARD, new Point(100, 100), new List<Point>());
		}

		public bool Forward(Point max)
		{
			return Move(FORWARD, max, new List<Point>());
		}

		public bool Forward(Point max, List<Point> obstacles)
		{
			return Move(FORWARD, max, obstacles);
		}

		public bool Backward()
		{
			return Move(BACKWARD, new Point(100, 100), new List<Point>());
		}

		public bool Backward(Point max)
		{
			return Move(BACKWARD, max, new List<Point>());
		}

		public bool Backward(Point max, List<Point> obstacles)
		{
			return Move(BACKWARD, max, obstacles);
		}
		
		private bool Move(int fw, Point max, List<Point> obstacles)
		{
			int x = X, y = Y;
			switch (Direction)
			{
				case Direction.NORTH:
					y = Wrap(Y - fw, max.Y);
					break;
				case Direction.SOUTH:
					y = Wrap(Y + fw, max.Y);
					break;
				case Direction.EAST:
					x = Wrap(X + fw, max.X);
					break;
				case Direction.WEST:
					x = Wrap(X - fw, max.X);
					break;
			}

			if (IsObstacle(new Point(x, y), obstacles))
			{
				return false;
			}
			else
			{
				_point = new Point(x,y);
				return true;
			}
		}

		private int Wrap(int point, int maxPoint)
		{
			if (maxPoint > 0)
			{
				if (point > maxPoint)
					return 1;
				else if(point == 0)
					return maxPoint;
			}

			return point;
		}

		private bool IsObstacle(Point point, List<Point> obstacles)
		{
			foreach (var obstacle in obstacles)
			{
				if (obstacle.X == point.X && obstacle.Y == point.Y)
					return true;
			}

			return false;
		}

		public void TurnLeft()
		{
			Direction = DirectionExtensions.TurnLeft(Direction);
		}

		public void TurnRight()
		{
			Direction = DirectionExtensions.TurnRight(Direction);
		}

		public Location Copy()
		{
			return new Location(new Point(X, Y), Direction);
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || this.GetType() != obj.GetType()) return false;
			Location location = (Location) obj;
			if (X != location.X) return false;
			if (Y != location.Y) return false;
			if (Direction != location.Direction) return false;
			return true;
		}
	}
}