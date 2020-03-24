using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leadsquare
{
    class CardGame
    {
        //As the size is known, so its better to use Array, as array is faster than List.
        private Card[] currentCards;
        private static Card[] newCards;

        public CardGame()
        {
            currentCards = newCards;
        }

        static CardGame()
        {
            CreateANewCardDeck();
        }

        private static void CreateANewCardDeck()
        {
            newCards = new Card[52];
            int i = 0;
            foreach (SuitTypeEnum suit in Enum.GetValues(typeof(SuitTypeEnum)))
            {
                foreach (CardNumberEnum cardNumber in Enum.GetValues((typeof(CardNumberEnum))))
                {
                    newCards[i] = new Card(suit, cardNumber);
                    i++;
                }
            }

            // For shuffling the newly created deck
            newCards = newCards.OrderBy(g => Guid.NewGuid()).ToArray();
        }


        public void Start()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose an option!!!         CardsLeft: "+currentCards.Length);
                Console.WriteLine("1. Play a card");
                Console.WriteLine("2. Shuffle the deck");
                Console.WriteLine("3. Restart the game");
                Console.WriteLine("4. Close the application");
                string inputFromUser = Console.ReadLine();

                if (Int32.TryParse(inputFromUser, out int value))
                {
                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("Playing");
                            PlayACard();
                            break;
                        case 2:
                            Console.WriteLine("Shuffling");
                            ShuffleTheDeck();
                            break;
                        case 3:
                            Console.WriteLine("Restarting");
                            CreateNewDeck();
                            break;
                        case 4:
                            Console.WriteLine("Closing");
                            Environment.Exit(0);
                            break;
                        default:
                            DisplayErrorMessage("Invalid integer input");
                            break;
                    }
                }
                else
                {
                    DisplayErrorMessage("Only integer input is allowed");
                }
            }
        }

        private void PlayACard()
        {
            if (currentCards.Length < 1)
            {
                DisplayErrorMessage("Deck is empty");
                return;
            }
            string currentCard = currentCards[currentCards.Length - 1].Play();
            DisplayInGreen(currentCard);
            currentCards = currentCards.SkipLast(1).ToArray();
        }

        private void CreateNewDeck()
        {
            currentCards = newCards.OrderBy(g => Guid.NewGuid()).ToArray();
        }
        private void ShuffleTheDeck()
        {
            if (currentCards.Length < 1)
            {
                DisplayErrorMessage("No card left to shuffle");
                return;
            }
            currentCards = currentCards.OrderBy(g => Guid.NewGuid()).ToArray();
        }

        private void DisplayInGreen(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        private void DisplayErrorMessage(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.ForegroundColor = currentColor;
        }


    }
}

