using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Ship
{
	public class Planet
	{
		public Point Max { get; }

		public List<Point> Obstacles { get; set; }

		public Planet(Point max)
		{
			Max = max;
		}

		public Planet(Point max, List<Point> obstacles)
		{
			Max = max;
			Obstacles = obstacles;
		}
	}
}