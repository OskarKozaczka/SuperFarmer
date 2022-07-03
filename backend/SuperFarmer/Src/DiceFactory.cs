namespace SuperFarmer.Src
{
    public class GreenDice : IDice
    {
        public animals Get(int roll)
        {
            var possibilities = new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 3, 5 };
            return (animals)possibilities[roll];
        }
    }

    public class RedDice : IDice
    {
        public animals Get(int roll)
        {
            var possibilities = new List<int>() { 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 4, 6 };
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