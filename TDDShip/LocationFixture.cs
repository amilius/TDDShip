using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ship;

namespace TDDShip
{
	[TestClass]
	public class LocationFixture
	{
		private readonly int _x = 12;
		private readonly int _y = 32;
		private readonly Direction _direction = Direction.NORTH;
		private Point _max;
		private Location _location;
		private List<Point> _obstacles;

		[TestInitialize]
		public void SetUp()
		{
			_max = new Point(50, 50);
			_location = new Location(new Point(_x, _y), _direction);
			_obstacles = new List<Point>();
		}

		[TestMethod]
		public void WhenInstantiatedThenXIsStored()
		{
			Assert.AreEqual(_location.X, _x);
		}

		[TestMethod]
		public void WhenInstantiatedThenYIsStored()
		{
			Assert.AreEqual(_location.Y, _y);
		}
		[TestMethod]
		public void WhenInstantiatedThenDirectionIsStored()
		{
			Assert.AreEqual(_location.Direction, _direction);
		}

		[TestMethod]
		public void GivenDirectionNWhenForwardThenYDecreases()
		{
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.Y, _y - 1);
		}

		[TestMethod]
		public void GivenDirectionSWhenForwardThenYIncreases()
		{
			_location.Direction = Direction.SOUTH;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.Y, _y + 1);
		}

		[TestMethod]
		public void GivenDirectionEWhenForwardThenXIncreases()
		{
			_location.Direction = Direction.EAST;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.X, _x + 1);
		}

		[TestMethod]
		public void GivenDirectionWWhenForwardThenXDecreases()
		{
			_location.Direction = Direction.WEST;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.X, _x - 1);
		}

		[TestMethod]
		public void GivenDirectionNWhenBackwardThenYIncreases()
		{
			_location.Direction = Direction.NORTH;
			_location.Backward(_max, _obstacles);
			Assert.AreEqual(_location.Y, _y + 1);
		}

		[TestMethod]
		public void GivenDirectionSWhenBackwardThenYDecreases()
		{
			_location.Direction = Direction.SOUTH;
			_location.Backward(_max, _obstacles);
			Assert.AreEqual(_location.Y, _y - 1);
		}

		[TestMethod]
		public void GivenDirectionEWhenBackwardThenXDecreases()
		{
			_location.Direction = Direction.EAST;
			_location.Backward(_max, _obstacles);
			Assert.AreEqual(_location.X, _x - 1);
		}

		[TestMethod]
		public void GivenDirectionWWhenBackwardThenXIncreases()
		{
			_location.Direction = Direction.WEST;
			_location.Backward(_max, _obstacles);
			Assert.AreEqual(_location.X, _x + 1);
		}

		[TestMethod]
		public void WhenTurnLeftThenDirectionIsSet()
		{
			_location.TurnLeft();
			Assert.AreEqual(_location.Direction, Direction.WEST);
		}

		[TestMethod]
		public void WhenTurnRightThenDirectionIsSet()
		{
			_location.TurnRight();
			Assert.AreEqual(_location.Direction, Direction.EAST);
		}

		[TestMethod]
		public void GivenSameObjectsWhenEqualsThenTrue()
		{
			Assert.IsTrue(_location.Equals(_location));
		}

		[TestMethod]
		public void GivenDifferentObjectWhenEqualsThenFalse()
		{
			Assert.IsFalse(_location.Equals("bla"));
		}

		[TestMethod]
		public void GivenDifferentXWhenEqualsThenFalse()
		{
			Location locationCopy = new Location(new Point(999, _location.Y), _location.Direction);
			Assert.IsFalse(_location.Equals(locationCopy));
		}

		[TestMethod]
		public void GivenDifferentYWhenEqualsThenFalse()
		{
			Location locationCopy = new Location(new Point(_location.X, 999), _location.Direction);
			Assert.IsFalse(_location.Equals(locationCopy));
		}

		[TestMethod]
		public void GivenDifferentDirectionWhenEqualsThenFalse()
		{
			Location locationCopy = new Location(_location.Point, Direction.SOUTH);
			Assert.IsFalse(_location.Equals(locationCopy));
		}

		[TestMethod]
		public void GivenSameXYDirectionWhenEqualsThenTrue()
		{
			Location locationCopy = new Location(_location.Point, _location.Direction);
			Assert.IsTrue(_location.Equals(locationCopy));
		}

		[TestMethod]
		public void WhenCopyThenDifferentObject()
		{
			Location copy = _location.Copy();
			Assert.AreEqual(_location, copy);
		}

		[TestMethod]
		public void WhenCopyThenEquals()
		{
			Location copy = _location.Copy();
			Assert.AreEqual(copy, _location);
		}

		[TestMethod]
		public void GivenDirectionEAndXEqualsMaxXWhenForwardThen1()
		{
			_location.Direction = Direction.EAST;
			_location.Point.X = _max.X;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.X, 1);
		}

		[TestMethod]
		public void GivenDirectionWAndXEquals1WhenForwardThenMaxX()
		{
			_location.Direction = Direction.WEST;
			_location.Point.X = 1;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.X, _max.X);
		}

		[TestMethod]
		public void GivenDirectionNAndYEquals1WhenForwardThenMaxY()
		{
			_location.Direction = Direction.NORTH;
			_location.Point.Y = 1;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.Y, _max.Y);
		}

		[TestMethod]
		public void GivenDirectionSAndYEqualsMaxYWhenForwardThen1()
		{
			_location.Direction = Direction.SOUTH;
			_location.Point.Y = _max.Y;
			_location.Forward(_max, _obstacles);
			Assert.AreEqual(_location.Y, 1);
		}

		[TestMethod]
		public void GivenObstacleWhenForwardThenReturnFalse()
		{
			_location.Direction = Direction.EAST;
			_obstacles.Add(new Point(_x + 1, _y));
			Assert.IsFalse(_location.Forward(_max, _obstacles));
		}

		[TestMethod]
		public void GivenObstacleWhenBackwardThenReturnFalse()
		{
			_location.Direction = Direction.EAST;
			_obstacles.Add(new Point(_x - 1, _y));
			Assert.IsFalse(_location.Backward(_max, _obstacles));
		}
	}
}