using System;
using System.Threading;
namespace BlackJack
{
    class Dealer : Base
    {
        public static int value { get; set; }
        public override void Hit()
        {
            GamePlay.dealerCard.Add(Card.GenerateCard());
            Card.ShowCard("dealer");
        }
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