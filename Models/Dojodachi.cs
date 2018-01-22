using System;

namespace dojodachi_proj
{
    public class Dojodachi
    {
        public int happiness { get; set; }
        public int fullness { get; set; }
        public int energy { get; set; }
        public int meals { get; set; }
        public string message { get;set; }

        public Dojodachi()
        {
            happiness = 20;
            fullness = 20;
            energy = 50;
            meals = 3;
        }

        public void Feed()
        {
            Random rand = new Random();
            if(meals > 0)
            {
                meals--;
                if(rand.Next(1,5) == 1)
                {
                    fullness += 0;
                    message = "I don't like this food! *throws it in your face*";
                }
                else
                {
                    int rando = rand.Next(5,11);
                    if(fullness > 100-rando)
                    {
                        fullness = 100;
                        message = "Fullness maxed!";
                    }
                    else
                    {
                        fullness += rando;
                        message = $"My fullness increased by {rando}!";
                    }
                }
            }
            else
            {
                message = "No more meals, work for it!";
            }

        }
        public void Play()
        {
            Random rand = new Random();
            if (energy > 0)
            {
                energy -= 5;
                if (rand.Next(1, 5) == 1)
                {
                    happiness += 0;
                    message = "I don't want to play! *kicks you in the shin*";
                }
                else
                {
                    int rando = rand.Next(5, 11);
                    happiness += rando;
                    message = $"My happiness increased by {rando}!";
                }
            }
            else
            {
                message = "No more.. energy...need sleep...";
            }

        }
        public void Work()
        {
            if(energy > 0)
            {
                energy -= 5;
                Random rand = new Random();
                int rando = rand.Next(1,4);
                meals += rando;
                message = $"You earned {rando} meal(s)!";
            }
            else
            {
                message = "No more.. energy...need sleep...";
            }
        }
        public void Sleep()
        {
            happiness -= 5;
            fullness -= 5;
            message = "Sleep was AMAZING!";
            if(energy > 85)
            {
                energy = 100;
            }
            else
            {
                energy += 15;
            }
        }
    }
}