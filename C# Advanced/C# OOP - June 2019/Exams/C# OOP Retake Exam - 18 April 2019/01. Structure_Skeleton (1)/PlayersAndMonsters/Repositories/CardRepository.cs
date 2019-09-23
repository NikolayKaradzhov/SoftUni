using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count
            => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards
            => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            ICard cardName = this.cards.FirstOrDefault(c => c.Name == card.Name);

            if (cards.Contains(cardName))
            {
                throw new ArgumentException($"Card {cardName.Name} already exists!");
            }

            this.cards.Add(cardName);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

           return this.cards.Remove(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards.FirstOrDefault(c => c.Name == name);

            return card;
        }
    }
}