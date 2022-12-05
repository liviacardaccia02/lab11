namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string _seeds;
        private readonly string _name;
        private readonly int _ordinal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="_seeds">the _seeds of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seeds, int ordinal)
        {
            _name = name;
            _ordinal = ordinal;
            _seeds = seeds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        public string Seed
        {
            get => _seeds;
        }

        public string Name
        {
            get => _name;
        }

        public int Ordinal
        {
            get => _ordinal;
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={Name}, Seed={Seed}, Ordinal={Ordinal})";
        }

        // TODO generate Equals(object obj)
        public override bool Equals(object obj)
        {
            Card card = obj as Card;

            if (card == null)
            {
                return false;
            }

            if (card.Name == _name && card.Seed == _seeds && card.Ordinal == _ordinal)
            {
                return true;
            }

            return false;
        }

        // TODO generate GetHashCode()
        public override int GetHashCode() => HashCode.Combine(Name, Seed);
    }
}
