using System;
namespace BlackJack
{
    public class Card
    {
        public static string[] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        public static string[] cardShapes = {"Heart", "Spade", "Club", "Diamond"};
        public static string GenerateCard()
        {
            Random rand = new Random();
            return $"{cards[rand.Next(0, 13)]} {cardShapes[rand.Next(0, 4)]}";
        }
        public static void ShowCard(string name)
        {
            if(name == "player")
                foreach(string card in GamePlay.playerCard)
                    Console.Write(card + " ");
            if(name == "dealer")
                foreach(string card in GamePlay.dealerCard)
                    Console.Write(card + " ");
        }
    }
}