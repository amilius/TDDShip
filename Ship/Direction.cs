using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ship
{
    public enum Direction
    {
	    NORTH = 0,
		EAST = 1,
		SOUTH = 2,
		WEST = 3,
		NONE = 4
    }

    public static class DirectionExtensions
    {
	    public static char GetShortName(Direction direction)
	    {
		    switch (direction)
		    {
				case Direction.NORTH:
					return 'N';
				case Direction.EAST:
					return 'E';
				case Direction.SOUTH:
					return 'S';
				case Direction.WEST:
					return 'W';
				case Direction.NONE:
					return 'X';
		    }

		    return 'X';
	    }

	    public static Direction GetFromShortName(char shortName)
	    {
		    switch (shortName)
		    {
			    case 'N':
				    return Direction.NORTH;
			    case 'E':
				    return Direction.EAST;
			    case 'S':
				    return Direction.SOUTH;
			    case 'W':
				    return Direction.WEST;
			    case 'X':
				    return Direction.NONE;
		    }

		    return Direction.NONE;
	    }

	    public static Direction TurnLeft(Direction direction)
	    {
		    var index = (int) direction;
		    return (Direction)((index + 3) % 4);
	    }

	    public static Direction TurnRight(Direction direction)
	    {
		    var index = (int)direction;
		    return (Direction)((index + 1) % 4);
	    }
	}
}
