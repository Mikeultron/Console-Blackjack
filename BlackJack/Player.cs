using System;
namespace BlackJack
{
    class Player : Base
    {
        // To hold total value of player's cards.
        public static int value { get; set; }
        
        // override the base's class method.
        // Generate a new random card and ad it to the list.
        public override void Hit()
        {
            GamePlay.playerCard.Add(Card.GenerateCard());
            Card.ShowCard("player");
        }
        
        // Method for handling player's turn.
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
