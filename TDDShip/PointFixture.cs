using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ship;

namespace TDDShip
{
	[TestClass]
	public class PointFixture
	{
		private Point _point;
		private readonly int _x = 12;
		private readonly int _y = 21;

		[TestInitialize]
		public void SetUp()
		{
			_point = new Point(_x, _y);
		}

		[TestMethod]
		public void WhenInstantiatedThenXIsSet()
		{
			Assert.AreEqual(_point.X, _x);
		}

		[TestMethod]

		public void WhenInstantiatedThenYIsSet()
		{
			Assert.AreEqual(_point.Y, _y);
		}
	}
}