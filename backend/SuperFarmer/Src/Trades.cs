namespace SuperFarmer.Src
{
    public partial class Game
    {
        public void Trade(Player player,int tradeID)
        {
            switch (tradeID)
            {
                case 1:
                    //SheepFor6Rabbits
                    if (player.playerAnimals.GetAnimal((int)animals.rabbit) < 6) return;
                    MoveAnimals(player, (int)animals.rabbit, -6);
                    MoveAnimals(player, (int)animals.sheep, 1);
                    break;
                case 2:
                    //PigFor2Sheeps
                    if (player.playerAnimals.GetAnimal((int)animals.sheep) < 2) return;
                    MoveAnimals(player, (int)animals.sheep, -2);
                    MoveAnimals(player, (int)animals.pig, 1);
                    break;
                case 3:
                    //CowFor3Pigs
                    if (player.playerAnimals.GetAnimal((int)animals.pig) < 3) return;
                    MoveAnimals(player, (int)animals.pig, -3);
                    MoveAnimals(player, (int)animals.cow, 1);
                    break;
                case 4:
                    //HorseFor2Cows
                    if (player.playerAnimals.GetAnimal((int)animals.cow) < 2) return;
                    MoveAnimals(player, (int)animals.cow, -2);
                    MoveAnimals(player, (int)animals.horse, 1);
                    break;
                case 5:
                    //SmallDogForSheep
                    if (player.playerAnimals.GetAnimal((int)animals.sheep) < 1) return;
                    MoveAnimals(player, (int)animals.sheep, -1);
                    MoveAnimals(player, (int)animals.smallDogs, 1);
                    break;
                case 6:
                    //LargeDogForCow
                    if (player.playerAnimals.GetAnimal((int)animals.cow) < 1) return;
                    MoveAnimals(player, (int)animals.cow, -1);
                    MoveAnimals(player, (int)animals.largeDogs, 1);
                    break;

                default: throw new ArgumentOutOfRangeException();
            }

        }
    }
}