namespace SuperFarmer.Src
{
    public class Player
    {
        public Animals playerAnimals;

        public string nickname;
        public Player(string nickname)
        {
            playerAnimals = new Animals(0, 0, 0, 0, 0, 0, 0);
            this.nickname = nickname;
        }

        public bool CheckWin()
        {
            foreach (var animal in new animals[] { animals.rabbit, animals.sheep, animals.pig, animals.cow, animals.horse })
            {
                if (playerAnimals.GetAnimal((int)animal) == 0) return false;
            }
            return true;
        }
    }
}
