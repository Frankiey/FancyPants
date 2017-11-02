using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyPants.GameLogic
{
    public class RoomsFactory
    {
        public static Room[][] MakeRooms(int gridSize)
        {
            Room[][] rooms = new Room[gridSize][];
            for (int x = 0; x < gridSize; x++)
            {
                rooms[x] = new Room[gridSize];
                for (int y = 0; y < gridSize; y++)
                    rooms[x][y] = RoomFactory.MakeRoom();
            }

            return rooms;
        }
    }
}
