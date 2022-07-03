namespace SuperFarmer.Src
{
    public partial class Game
    {
        public Animals animalBank;
        public List<Player> players;
        private IDice[] dices;
        private Random _rand;
        public Player currentPlayer;
        private DiceFactory _diceFactory;

        public Game(Random random, DiceFactory diceFactory)
        {
            _diceFactory = diceFactory;
            _rand = random;
            players = new List<Player>();
            dices = new IDice[2];
            animalBank = new Animals(60, 24, 20, 12, 6, 4, 2);
            dices = new IDice[2] { _diceFactory.GetDice("green"), _diceFactory.GetDice("red") };
        }

        public animals[] Roll(Player player)
        {
            var rollResult = new List<animals>();
            foreach (IDice dice in dices) rollResult.Add(dice.Get(_rand.Next(0,12)));
            if (rollResult[0] == animals.wolf)
            {
                WolfAction(player);
            }
            if  (rollResult[1] == animals.fox)
            {
                FoxAction(player);
            }
            else if (rollResult[0] != animals.wolf)
            {
                BorrowPlayerAnimals(player, rollResult);
                BreedPlayerAnimals(player, rollResult);
                UnborrowPlayerAnimals(player, rollResult);
            }

            return rollResult.ToArray();
        }

        private void UnborrowPlayerAnimals(Player player, List<animals> rollResult)
        {
            foreach(var animal in rollResult)
            {
                player.playerAnimals.SetAnimal((int)animal, -1);
            }
        }

        private void BreedPlayerAnimals(Player player, List<animals> rollResult)
        {
            var respone = new List<int>();
            foreach (var animal in rollResult)
            {
                var animalsToGet = player.playerAnimals.GetAnimal((int)animal) / 2;
                MoveAnimals(player, (int)animal, animalsToGet);
                
                if (rollResult[0] == rollResult[1]) break;
            }
        }

        private void BorrowPlayerAnimals(Player player, List<animals> rollResult)
        {
            foreach (var animal in rollResult)
            {
                player.playerAnimals.SetAnimal((int)animal, 1);
            }
        }
        private void FoxAction(Player player)
        {
            if (player.playerAnimals.smallDogs > 0)
            {
                MoveAnimals(player, (int)animals.smallDogs, -1);
            }
            else
            {
                var playerRabbits = player.playerAnimals.GetAnimal((int)animals.rabbit);
                var playerRabbitsToRemove = playerRabbits == 0 ? 0 : player.playerAnimals.GetAnimal((int)animals.rabbit) - 1;
                MoveAnimals(player, (int)animals.rabbit, -playerRabbitsToRemove);
            }
        }

        private void WolfAction(Player player)
        {
            if (player.playerAnimals.largeDogs > 0)
            {
                MoveAnimals(player, (int)animals.largeDogs, -1);
            }
            else
            {
                foreach (var animal in new animals[] {animals.sheep,animals.pig,animals.cow })
                {
                    var animalsToremove = player.playerAnimals.GetAnimal((int)animal);
                    MoveAnimals(player, (int)animal, -animalsToremove);
                }
            }
        }

        private void MoveAnimals(Player player, int animalID, int amount)
        {
            if (animalBank.GetAnimal(animalID) >= amount)
            {
                player.playerAnimals.SetAnimal(animalID, amount);
                animalBank.SetAnimal(animalID, -amount);
            }
            else
            {
                player.playerAnimals.SetAnimal(animalID, animalBank.GetAnimal(animalID));
                animalBank.SetAnimal(animalID, -animalBank.GetAnimal(animalID));
            }

        }

        public Player FindPlayerByName(string playerName)
        {
            foreach (var player in players)
            {
                if (player.nickname == playerName) return player;
            }

            throw new PlayerNotFoundException();
        }

        public Player GetNextPlayer()
        {
            if (players.IndexOf(currentPlayer) == players.Count - 1)
            {
                currentPlayer = players[0];
                return currentPlayer;
            }else
            {
                currentPlayer = players[players.IndexOf(currentPlayer) + 1];
                return currentPlayer;
            }
        }
    }
}
