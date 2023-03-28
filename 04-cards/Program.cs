using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int TakeCard = 1;
            const int TakeLotCard = 2;
            const int OutputInformation = 3;
            const int ExitProgram = 4;
            bool isProgramWork = true;
            Deck deck = new Deck();

            while (isProgramWork)
            {
                Console.Clear();
                deck.ShowPlayerDeck();
                Console.WriteLine($"{TakeCard}) Вбрать случайную карту.\n{TakeLotCard}) Взять несколько карт.\n{OutputInformation}) Вывод оставшихся карт в колоде.\n{ExitProgram}) Выход");                
                Console.Write("Выбирите команду: ");
                int.TryParse(Console.ReadLine(), out int userInput);                

                switch (userInput)
                {
                    case TakeCard:
                        deck.TakeRandomCard();
                        break;
                    case TakeLotCard:
                        deck.TakeQuantityCards();
                        break;
                    case OutputInformation:
                        deck.ShowDeck();
                        break;
                    case ExitProgram:
                        isProgramWork = false;
                        break;
                }
            }
        }               
    }

    class Deck
    {        
        List<Card> deck = new List<Card>();
        List<Card> playerDeck = new List<Card>();
        Random random = new Random();

        public Deck()
        {
            deck.Add(new Card(NameCard.Шесть, Suit.Вини));
            deck.Add(new Card(NameCard.Семь, Suit.Вини));
            deck.Add(new Card(NameCard.Восемь, Suit.Вини));
            deck.Add(new Card(NameCard.Девять, Suit.Вини));
            deck.Add(new Card(NameCard.Десять, Suit.Черви));
            deck.Add(new Card(NameCard.Валет, Suit.Черви));
            deck.Add(new Card(NameCard.Дама, Suit.Черви));
            deck.Add(new Card(NameCard.Король, Suit.Черви));
            deck.Add(new Card(NameCard.Туз, Suit.Черви));
            deck.Add(new Card(NameCard.Шесть, Suit.Буби));
            deck.Add(new Card(NameCard.Семь, Suit.Буби));
            deck.Add(new Card(NameCard.Восемь, Suit.Буби));
            deck.Add(new Card(NameCard.Девять, Suit.Буби));
            deck.Add(new Card(NameCard.Десять, Suit.Крести));
            deck.Add(new Card(NameCard.Валет, Suit.Крести));
            deck.Add(new Card(NameCard.Дама, Suit.Крести));
            deck.Add(new Card(NameCard.Король, Suit.Крести));
            deck.Add(new Card(NameCard.Туз, Suit.Крести));
        }        

        public void ShowDeck()
        {
            if (deck.Count > 0)
            {
                foreach (Card cards in deck)
                {
                    cards.ShowCard();
                }
            }

            else
            {
                Console.WriteLine("Карты закончились");
            }
            Console.ReadKey();
        }

        public void TakeRandomCard()
        {
            if (deck.Count > 0)
            {
                int numberCard = random.Next(0, deck.Count);
                playerDeck.Add(deck[numberCard]);
                deck.RemoveAt(numberCard);
                Console.Write("Вы взяли: ");
                playerDeck.Last().ShowCard();
                Console.Write("\nДля продолжения нажмите любую кнопку:");    
            }

            else
            {
                Console.WriteLine("Карты закончились.Для продолжения нажмите любую кнопку:");
            }
            Console.ReadKey();
        }

        public void TakeQuantityCards()
        {
            if (deck.Count >= 0)
            {
                Console.Write("Введите число карт: ");
                int.TryParse(Console.ReadLine(), out int userInput); 
                
                for (int i = 0; i < userInput; i++)
                {
                    TakeRandomCard();
                }
            }
        }

        public void ShowPlayerDeck()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Карты игрока: ");

            foreach (Card cards in playerDeck)
            {
                cards.ShowCard();
            }            
            Console.SetCursorPosition(0,0);
        }
    }

    class Card
    {        
        public NameCard NameCard { get; private set; }
        public Suit Suit { get; private set; }

        public Card(NameCard name, Suit suit)
        {
            NameCard = name;
            Suit = suit;
        }

        public void ShowCard()
        {
            Console.WriteLine($"{NameCard} - {Suit}");
        }
    }

    enum NameCard
    {
        Шесть,  
        Семь,
        Восемь,
        Девять,
        Десять,
        Валет,
        Дама,
        Король,
        Туз
    }

    enum Suit
    {
        Вини,
        Буби,
        Крести,
        Черви,
    }
}
