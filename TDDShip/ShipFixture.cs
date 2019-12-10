using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ship;

namespace TDDShip
{
    [TestClass]
    public class ShipFixture
    {
        private Ship.Spaceship _ship;
        private readonly int _x = 12;
        private readonly int _y = 32;
        private Direction _direction = Direction.NORTH;
        private Point _point;
        private Point _max;
        private List<Point> _obstacles;

        [TestInitialize]
        public void SetUp()
        {
            _point = new Point(_x, _y);
            _ship = new Ship.Spaceship(new Location(_point, _direction));
            _max = new Point(50, 50);
            _obstacles = new List<Point>();
        }

        [TestMethod]
        public void WhenInstantiatedThenHasLocation()
        {
            Assert.AreEqual(_x, _ship.Location.Point.X);
            Assert.AreEqual(_y, _ship.Location.Point.Y);
            Assert.AreEqual(_direction, _ship.Location.Direction);
        }

        [TestMethod]
        public void WhenGetLocationReturnPoint()
        {
            Assert.AreEqual(_point, _ship.GetLocation() );
        }

        [TestMethod]
        public void WhenGetDirectionReturnDirection()
        {
            Assert.AreEqual(_direction, _ship.GetDirection());
        }

        [TestMethod]
        public void WhenTurnLeftThanPointStaysTheSame()
        {
            _ship.TurnLeft();
            Assert.AreEqual(_point, _ship.GetLocation());
        }

        [TestMethod]
        public void WhenTurnRightThanPointStaysTheSame()
        {
            _ship.TurnRight();
            Assert.AreEqual(_point, _ship.GetLocation());
        }

        [TestMethod]
        public void WhenTurnLeftGivenDirectionNThanDirectionW()
        {
            _ship.TurnLeft();
            Assert.AreEqual(Direction.WEST, _ship.GetDirection());
        }

        [TestMethod]
        public void WhenTurnRightGivenDirectionNThanDirectionE()
        {
            _ship.TurnRight();
            Assert.AreEqual(Direction.EAST, _ship.GetDirection());
        }

        [TestMethod]
        public void WhenMoveForwardFacingNorthThanSubstractOneFromY()
        {
            _ship.Forward(_max,_obstacles);
            Assert.AreEqual(_y-1, _ship.GetLocation().Y);
        }

        [TestMethod]
        public void WhenMoveBackwardFacingNorthThanAddOneToY()
        {
            _ship.Backward(_max, _obstacles);
            Assert.AreEqual(_y + 1, _ship.GetLocation().Y);
        }

        [TestMethod]
        public void WhenMoveForwardFacingSouthThanAddOneToY()
        {
            _ship.TurnLeft();
            _ship.TurnLeft();
            _ship.Forward(_max, _obstacles);
            Assert.AreEqual(_y + 1, _ship.GetLocation().Y);
        }

        [TestMethod]
        public void WhenMoveBackwardFacingSouthThanSubstractOneFromY()
        {
            _ship.TurnLeft();
            _ship.TurnLeft();
            _ship.Backward(_max, _obstacles);
            Assert.AreEqual(_y - 1, _ship.GetLocation().Y);
        }

        [TestMethod]
        public void WhenMoveForwardFacingEastThanAddOneToX()
        {
            _ship.TurnRight();
            _ship.Forward(_max, _obstacles);
            Assert.AreEqual(_x + 1, _ship.GetLocation().X);
        }

        [TestMethod]
        public void WhenMoveBackwardFacingEastThanSubstractOneFromX()
        {
            _ship.TurnRight();
            _ship.Backward(_max, _obstacles);
            Assert.AreEqual(_x - 1, _ship.GetLocation().X);
        }

        [TestMethod]
        public void WhenMoveForwardFacingWestThanSubstractOneFromX()
        {
            _ship.TurnLeft();
            _ship.Forward(_max, _obstacles);
            Assert.AreEqual(_x - 1, _ship.GetLocation().X);
        }

        [TestMethod]
        public void WhenMoveBackwardFacingWestThanAddOneToX()
        {
            _ship.TurnLeft();
            _ship.Backward(_max, _obstacles);
            Assert.AreEqual(_x + 1, _ship.GetLocation().X);
        }

        [TestMethod]
        public void WhenTypedInstructionsThanShipWillFollowInstructions()
        {
            Location expected = _ship.Location.Copy();
            expected.Forward();
            expected.TurnLeft();
            expected.Forward();
            expected.TurnRight();
            expected.Backward();
            expected.Backward();
            expected.TurnRight();
            _ship.Command("flfrbbr", _max, _obstacles);
            Assert.AreEqual(_ship.Location,expected);
        }

        [TestMethod]

        public void WhenTypedSingleInstructionAndObstacleThanReturnX()
        {
            _obstacles.Add(new Point(12, 31));
            string result = _ship.Command("f", _max, _obstacles);
            Assert.AreEqual("x", result);
        }

        [TestMethod]

        public void WhenTypedSingleInstructionAndNoObstacleThanReturnO()
        {
            string result = _ship.Command("f", _max, _obstacles);
            Assert.AreEqual("o", result);
        }

        [TestMethod]

        public void WhenTypedInstructionsThanFunctionWillReturnStringWithSuccessAndFailForEachInstruction()
        {
            //przeszkody.Add(new Point(namiar1, namiar2));
            _obstacles.Add(new Point(12,31));
            string result = _ship.Command("flfrfrfllblb", _max, _obstacles);
            Assert.AreEqual("xoooooxooxoo",result);
        }
    }
}