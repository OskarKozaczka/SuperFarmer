namespace SuperFarmer.Src
{
    public enum animals
    {
        rabbit = 0,
        sheep = 1,
        pig = 2,
        cow = 3,
        horse = 4,
        wolf = 5,
        fox = 6,
        smallDogs = 7,
        largeDogs = 8,
    }

    public class Animals
    {
        public int rabbits { get; set; }
        public int sheeps {get;set;}
        public int pigs {get;set;}
        public int cows   {get;set;}
        public int horses { get; set; }
        public int smallDogs { get; set; }
        public int largeDogs { get; set; }

        public Animals(int r, int s, int p, int c,int h, int sd, int ld)
        {
            rabbits = r;
            sheeps = s;
            pigs = p;
            cows = c;
            horses = h;
            smallDogs = sd;
            largeDogs = ld;
        }

        public int GetAnimal(int id)
        {
            if (id == 0) return rabbits;
            if (id == 1) return sheeps;
            if (id == 2) return pigs;
            if (id == 3) return cows;
            if (id == 4) return horses;
            if (id == 7) return smallDogs;
            if (id == 8) return largeDogs;

            throw new IndexOutOfRangeException();
        }

        public int SetAnimal(int id, int change)
        {
            if (id == 0) return rabbits += change;;
            if (id == 1) return sheeps += change;
            if (id == 2) return pigs += change;
            if (id == 3) return cows += change;
            if (id == 4) return horses += change;
            if (id == 7) return smallDogs += change;
            if (id == 8) return largeDogs += change;

            throw new IndexOutOfRangeException();
        }
    }


}
