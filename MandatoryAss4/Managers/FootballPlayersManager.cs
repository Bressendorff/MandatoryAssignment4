using System.Data;
using ManadatoryAssignment1;

namespace MandatoryAss4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Age = 21, Name = "Laudrup", ShirtNumber = 12},
            new FootballPlayer {Id=_nextId++, Age = 32, Name = "Laban", ShirtNumber = 27},
            new FootballPlayer {Id=_nextId++, Age = 25, Name = "Hansen", ShirtNumber = 18},
            new FootballPlayer {Id=_nextId++, Age = 18, Name = "Didriksen", ShirtNumber = 10}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(Data);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public FootballPlayer GetById(int id)
        {
            return Data.Find(player => player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.Id = _nextId++;
            newFootballPlayer.Validate();
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballPlayer = Data.Find(player1 => player1.Id == id);
            if (footballPlayer == null) return null;
            Data.Remove(footballPlayer);
            return footballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer footballPlayer = Data.Find(player1 => player1.Id == id);
            if (footballPlayer == null) return null;
            updates.Validate();
            footballPlayer.Name = updates.Name;
            footballPlayer.Age = updates.Age;
            footballPlayer.ShirtNumber = updates.ShirtNumber;
            return footballPlayer;
        }
    }
}
