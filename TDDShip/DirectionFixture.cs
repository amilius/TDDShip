using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ship;

namespace TDDShip
{
	[TestClass]
	public class DirectionFixture
	{
		[TestMethod]
		public void WhenGetFromShortNameNThenReturnDirectionN()
		{
			Direction direction = DirectionExtensions.GetFromShortName('N');
			Assert.AreEqual(direction, Direction.NORTH);
		}

		[TestMethod]
		public void WhenGetFromShortNameWThenReturnDirectionW()
		{
			Direction direction = DirectionExtensions.GetFromShortName('W');
			Assert.AreEqual(direction, Direction.WEST);
		}

		[TestMethod]
		public void WhenGetFromShortNameBThenReturnNone()
		{
			Direction direction = DirectionExtensions.GetFromShortName('B');
			Assert.AreEqual(direction, Direction.NONE);
		}

		[TestMethod]
		public void GivenSWhenLeftThenE()
		{
			Assert.AreEqual(DirectionExtensions.TurnLeft(Direction.SOUTH), Direction.EAST);
		}

		[TestMethod]
		public void GivenNWhenLeftThenW()
		{
			Assert.AreEqual(DirectionExtensions.TurnLeft(Direction.NORTH), Direction.WEST);
		}

		[TestMethod]
		public void GivenSWhenRightThenW()
		{
			Assert.AreEqual(DirectionExtensions.TurnRight(Direction.SOUTH), Direction.WEST);
		}

		[TestMethod]
		public void GivenWWhenRightThenN()
		{
			Assert.AreEqual(DirectionExtensions.TurnRight(Direction.WEST), Direction.NORTH);
		}
	}
}
