namespace SuperFarmer.Src
{
    public class GameManager
    {

        private static readonly Dictionary<string, Game> GamesDict = new();

        public static void CreateGameAndAddPlayers(string gameID, string playerName)
        {
            if (!GamesDict.ContainsKey(gameID))
            {
                GamesDict.Add(gameID, new Game(new Random(), new DiceFactory()));
                GamesDict[gameID].players.Add(new Player(playerName));
                GamesDict[gameID].currentPlayer = GamesDict[gameID].players[0];
            }
            else
            {
                if (!GamesDict[gameID].players.Exists(x => x.nickname == playerName))
                {
                    if (GamesDict[gameID].players.Count == 4) throw new GameIsFullException();
                    var newPlayer = new Player(playerName);
                    GamesDict[gameID].players.Add(newPlayer);
                    GamesDict[gameID].currentPlayer = newPlayer;
                }
            }
        }

        internal static string GetCurrentPlayer(string gameID)
        {
            if (GamesDict.ContainsKey(gameID))
            {
                return GamesDict[gameID].currentPlayer.nickname;
            }
            throw new GameNotFoundExeption();
        }

        internal static Animals GetBank(string gameID)
        {
            if (GamesDict.ContainsKey(gameID))
            {
                return GamesDict[gameID].animalBank;
            }
            throw new GameNotFoundExeption();
        }
                

        public static Animals GetPlayerAnimals(string gameID, string playerName)
        {
            if (GamesDict.ContainsKey(gameID))
            {
                if (GamesDict.ContainsKey(gameID))
                {
                    var game = GamesDict[gameID];
                    return game.FindPlayerByName(playerName).playerAnimals;
                }
            }

            throw new GameNotFoundExeption();
        }

        public static Animals MakeTrade(string gameID, string playerName, int tradeID)
        {
            if (GamesDict.ContainsKey(gameID))
            {
                var game = GamesDict[gameID];
                if (game.currentPlayer.nickname != playerName) throw new WrongPlayerExeption();
                game.Trade(game.FindPlayerByName(playerName), tradeID);
                return game.FindPlayerByName(playerName).playerAnimals;
            }

            throw new GameNotFoundExeption();
        }

        public static RollRespone RollForPlayer(string gameID, string playerName)
        {

            if (GamesDict.ContainsKey(gameID))
            {
                var game = GamesDict[gameID];
                if (game.currentPlayer.nickname != playerName) throw new WrongPlayerExeption();
                game.GetNextPlayer();
                var rollResponse = new RollRespone();
                rollResponse.rollResult = game.Roll(game.FindPlayerByName(playerName));
                rollResponse.nextPlayer = game.currentPlayer.nickname;
                rollResponse.animals = game.FindPlayerByName(playerName).playerAnimals;

                foreach(var player in game.players)
                {
                    if (player.CheckWin()) GamesDict.Remove(gameID);
                }

                return rollResponse;
            }
            throw new GameNotFoundExeption(); 
        }

        public class RollRespone
        {
            public animals[] rollResult { get; set; }
            public Animals animals { get; set; }
            public string nextPlayer { get; set; }
        }
    }
}
