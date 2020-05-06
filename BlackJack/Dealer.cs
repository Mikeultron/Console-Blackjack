using System;
using System.Threading;
namespace BlackJack
{
    // Derived class
    class Dealer : Base
    {
        // To hold the total value of dealer's cards.
        public static int value { get; set; }
        
        // override the base's class method.
        // Generate a new random card and add it to the list.
        public override void Hit()
        {
            GamePlay.dealerCard.Add(Card.GenerateCard());
            Card.ShowCard("dealer");
        }
        
        // Simple dealer AI.
        public void DealerTurn()
        {
            if(value < Player.value)
            {
                Console.Write("\nDealer's card ");
                Hit();
                Thread.Sleep(1000);
            }
            else if(value >= 18)
            {
                if(value == Player.value)
                {
                    Console.WriteLine("\nDraw");
                    GamePlay.gameOver = true;
                }
                else if(value > Player.value)
                {
                    Console.WriteLine("Dealer win!");
                    GamePlay.gameOver = true;
                    return;
                }
            }
        }
    }
}
