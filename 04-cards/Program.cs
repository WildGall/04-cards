using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Croupier croupier = new Croupier();
            croupier.Work();
        }         
    }

    class Croupier
    {     
        public void Work()
        {
            const string CommandTakeCard = "1";
            const string CommandTakeLotCard = "2";
            const string CommandOutputInformation = "3";
            const string CommandExitProgram = "4";

            bool isProgramWork = true;
            Player player = new Player();
            Deck deck = new Deck();           

            while (isProgramWork)
            {
                Console.Clear();
                player.ShowCards();
                Console.WriteLine($"{CommandTakeCard}) Вбрать случайную карту.\n{CommandTakeLotCard}) Взять несколько карт.\n{CommandOutputInformation}) Вывод оставшихся карт в колоде.\n{CommandExitProgram}) Выход");
                Console.Write("Выбирите команду: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandTakeCard:
                        TransferCard(deck, player);
                        break;

                    case CommandTakeLotCard:
                        TransferLotCard(deck, player);
                        break;

                    case CommandOutputInformation:
                        deck.ShowInfo();
                        break;

                    case CommandExitProgram:
                        isProgramWork = false;
                        break;
                }
            }
        }

        public void TransferCard(Deck deck, Player player)
        {            
            Card card = deck.GetCard();
            player.TakeCard(card);
        }

        public void TransferLotCard(Deck deck, Player player)
        {
            Console.Write("Введите число карт: ");
            int.TryParse(Console.ReadLine(), out int userInput);

            if (deck.VerifyUserInput(userInput))
            {
                for (int i = 0; i < userInput; i++)
                {
                    TransferCard(deck, player);
                }
            }
            else
            {
                Console.WriteLine("Не верный ввод");
                Console.ReadKey();
            }
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();            

        public void TakeCard(Card card)
        {
            if (card != null)
            {
                _cards.Add(card);
                Console.Write("Вы взяли: ");
                _cards.Last().Show();
                Console.Write("\nДля продолжения нажмите любую кнопку:");
                Console.ReadKey();
            }
        }        

        public void ShowCards()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Карты игрока: ");

            foreach (Card cards in _cards)
            {
                cards.Show();
            }

            Console.SetCursorPosition(0, 0);
        }        
    }

    class Deck
    {        
        private List<Card> _cards = new List<Card>();
        private Random _random = new Random();

        public Deck()
        {
            FillDeck();
        }                

        public Card GetCard()
        {
            if (_cards.Count != 0)
            {
                int numberCard = _random.Next(0, _cards.Count);
                Card card = _cards[numberCard];
                _cards.Remove(card);
                return card;
            }
            else
            {
                return null;
            }                       
        }

        public void ShowInfo()
        {
            if (_cards.Count > 0)
            {
                foreach (Card cards in _cards)
                {
                    cards.Show();
                }
            }
            else
            {
                Console.WriteLine("Карты закончились");
            }

            Console.ReadKey();
        }

        public bool VerifyUserInput(int userInput)
        {
            if (_cards.Count >= userInput)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FillDeck()
        {
            _cards.Add(new Card(Name.Six, Suit.Spades));
            _cards.Add(new Card(Name.Seven, Suit.Spades));
            _cards.Add(new Card(Name.Eight, Suit.Spades));
            _cards.Add(new Card(Name.Nine, Suit.Spades));
            _cards.Add(new Card(Name.Ten, Suit.Hearts));
            _cards.Add(new Card(Name.Jack, Suit.Hearts));
            _cards.Add(new Card(Name.Queen, Suit.Hearts));
            _cards.Add(new Card(Name.King, Suit.Hearts));
            _cards.Add(new Card(Name.Ace, Suit.Hearts));
            _cards.Add(new Card(Name.Six, Suit.Diamonds));
            _cards.Add(new Card(Name.Seven, Suit.Diamonds));
            _cards.Add(new Card(Name.Eight, Suit.Diamonds));
            _cards.Add(new Card(Name.Nine, Suit.Diamonds));
            _cards.Add(new Card(Name.Ten, Suit.Clubs));
            _cards.Add(new Card(Name.Jack, Suit.Clubs));
            _cards.Add(new Card(Name.Queen, Suit.Clubs));
            _cards.Add(new Card(Name.King, Suit.Clubs));
            _cards.Add(new Card(Name.Ace, Suit.Clubs));
        }
    }

    class Card
    {        
        public Card(Name name, Suit suit)
        {
            Name = name;
            Suit = suit;
        }

        public Name Name { get; private set; }
        public Suit Suit { get; private set; }

        public void Show()
        {
            Console.WriteLine($"{Name} - {Suit}");
        }
    }

    enum Name
    {        
        Six,  
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    enum Suit
    {
        Spades,
        Diamonds,
        Clubs,
        Hearts,
    }
}
