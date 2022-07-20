namespace SuperFarmer.Src
{
    public class GreenDice : IDice
    {
        List<int> possibilities = new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5 };
        public animals Get(int roll)
        {
            return (animals)possibilities[roll];
        }
    }

    public class RedDice : IDice
    {
        List<int> possibilities = new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 4, 6 };
        public animals Get(int roll)
        {
            return (animals)possibilities[roll];
        }
    }


    public class DiceFactory
    {

        public IDice GetDice(string typeOfDice)
        {
            if (typeOfDice == "green") return new GreenDice();
            if (typeOfDice == "red") return new RedDice();
            throw new InvalidDataException();
        }
    }
}