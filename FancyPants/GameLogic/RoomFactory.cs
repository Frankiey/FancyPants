using System;
using System.Collections.Generic;
using FancyPants.Interfaces;
using FancyPants.Items;
using FancyPants.Monsters;

namespace FancyPants.GameLogic
{
    public class RoomFactory
    {
        /// <summary>
        /// Make a new room with items and monsters included.
        /// </summary>
        /// <returns></returns>
        public static Room MakeRoom()
        {
            Dictionary<string, Action> actions = new Dictionary<string, Action>
            {
                {"look", () => Game.Commands.LookAround()},
                {"hit", () => Game.Commands.Hit(Game.CurrentGame.CurrentArgs)},
                {"get", () => Game.Commands.Get(Game.CurrentGame.CurrentArgs)},
                {"bag", () => Game.Commands.Bag()}
            };

            List<IItem> itemList = new List<IItem>
            {
                new Sword()
            };

            List<IMonster> monsterList = new List<IMonster>
            {
                new Minatour
                {
                    Name = "vex",
                    Health = 5,
                    Description = "There is an evil Vex minatour fuming with void energy",
                    DropTable = new List<IItem>
                    {
                        new Key()
                    }
                }
            };

            Room room = new Room {Actions = actions, ItemList = itemList, MonsterList = monsterList};

            return room;
        }
    }
}