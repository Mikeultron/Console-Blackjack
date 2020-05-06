using System;
using System.Collections.Generic;
namespace BlackJack
{
    class GamePlay
    {
        public static List<string> dealerCard = new List<string>();
        public static List<string> playerCard = new List<string>();
        static Player player = new Player();
        static Dealer dealer = new Dealer();
        public static bool gameOver = false;
        public static bool playerTurn = true;
        static void Main(string[] args) => MainMenu();
        static void MainMenu()
        {
            Console.WriteLine("Welcome to the game of Blackjack");
            Console.WriteLine("Type 1 to start");
            Console.Write("Input: ");
            string a = Console.ReadLine();
            if(a == "1")
                Play();
        }
        static void Play()
        {
            dealerCard.Add(Card.GenerateCard());
            dealerCard.Add(Card.GenerateCard());
            playerCard.Add(Card.GenerateCard());
            playerCard.Add(Card.GenerateCard());
            Console.WriteLine($"Dealer got {dealerCard[0]} and {dealerCard[1]} ");
            Console.WriteLine($"You got {playerCard[0]} and {playerCard[1]}");
            while(!gameOver)
            {
                Console.WriteLine($"\nDealer value: {Dealer.value = EvaluateValue("dealer")}");
                Console.WriteLine($"Player value: {Player.value = EvaluateValue("player")}\n");
                if(Player.value == 21)
                {
                    Console.WriteLine("\nPlayer BlackJack!!");
                    gameOver = true;
                }
                else if(Dealer.value == 21)
                {
                    Console.WriteLine("\nDealer BlackJack!!");
                    gameOver = true;
                }
                else if(Player.value > 21)
                {
                    Console.WriteLine("\nPlayer busted!");
                    gameOver = true;
                }
                else if(Dealer.value > 21)
                {
                    Console.WriteLine("\nDealer Busted!");
                    gameOver = true;
                }
                if(playerTurn && !gameOver)
                    player.PlayerTurn();
                if(!playerTurn && !gameOver)
                    dealer.DealerTurn();
            }
        }
        static int EvaluateValue(string name)
        {
            if(name == "player")
            {
                Player.value = 0;
                if(playerCard[0][0] == 'A' || playerCard[1][0] == 'A')
                    Player.value += 10;
                for(int i = 0; i < playerCard.Count; i++)
                {
                    string[] splitCard = playerCard[i].Split();
                    if(splitCard[0] == "J" || splitCard[0] == "Q" || splitCard[0] == "K")
                        Player.value += 10;
                    else if(splitCard[0] == "A")
                        Player.value += 1;
                    else
                    {
                        int value = int.Parse(splitCard[0]);
                        Player.value += value;
                    }
                }
                return Player.value;
            }
            else if(name == "dealer")
            {
                Dealer.value = 0;
                if(dealerCard[0][0] == 'A' || dealerCard[1][0] == 'A')
                    Dealer.value += 10;
                for(int i = 0; i < dealerCard.Count; i++)
                {
                    string[] splitCard = dealerCard[i].Split();
                    if(splitCard[0] == "J" || splitCard[0] == "Q" || splitCard[0] == "K")
                        Dealer.value += 10;
                    else if(splitCard[0] == "A")
                        Dealer.value += 1;
                    else
                    {
                        int value = int.Parse(splitCard[0]);
                        Dealer.value += value;
                    }
                }
                return Dealer.value;
            }
            return 0;
        }
    }
}
