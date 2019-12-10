using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ship;

namespace TDDShip
{
	[TestClass]
	public class PlanetFixture
	{
		private Planet _planet;
		private readonly Point _max = new Point(50,50);
		private List<Point> _obstacles;

		[TestInitialize]
		public void SetUp()
		{
			_obstacles = new List<Point>();
			_obstacles.Add(new Point(12,13));
			_obstacles.Add(new Point(16,32));
			_planet = new Planet(_max, _obstacles);
		}

		[TestMethod]
		public void WhenInstantiatedThenMaxIsSet()
		{
			Assert.AreEqual(_planet.Max, _max);
		}

		[TestMethod]
		public void WhenInstantiatedThenObstaclesAreSet()
		{
			Assert.AreEqual(_planet.Obstacles, _obstacles);
		}
	}
}