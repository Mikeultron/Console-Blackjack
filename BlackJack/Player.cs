using System;
namespace BlackJack
{
    class Player : Base
    {
        public static int value { get; set; }
        public override void Hit()
        {
            GamePlay.playerCard.Add(Card.GenerateCard());
            Card.ShowCard("player");
        }
        public void PlayerTurn()
        {
            Console.WriteLine("Hit or stand? ");
            string choice = Console.ReadLine().ToLower();
            if(choice == "hit")
            {
                Console.WriteLine("\nPlayer's Card");
                Hit();
            }
            else if(choice == "stand")
            {
                GamePlay.playerTurn = false;
            }
        }
    }
}