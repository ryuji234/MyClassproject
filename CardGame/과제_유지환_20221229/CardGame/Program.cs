using System;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrumpCard TrumpCard = new TrumpCard();
            TrumpCard.SetupTrumpCards();
            TrumpCard.UserBetting();
        }
    }
}