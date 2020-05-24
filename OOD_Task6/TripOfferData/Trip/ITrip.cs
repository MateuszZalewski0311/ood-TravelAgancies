//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Text;
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Trip
{
    interface ITrip
    {
        double Rating { get; }
        int Price { get; }
        int NumberOfDays { get; }
        int NumberOfAtractions { get; }
        ListNode[] Accommodation { get; }
        TripAdvisorNode[,] Atractions { get; }
    }

    class Trip : ITrip
    {
        public Trip(int _NumberOfDays, int _NumberOfAtractions, ListNode[] _accommodation, TripAdvisorNode[,] _attractions)
        {
            NumberOfDays = _NumberOfDays;
            NumberOfAtractions = _NumberOfAtractions;
            Accommodation = _accommodation;
            Atractions = _attractions;
            Rating = 0.0;
            Price = 0;
            for (int i = 0; i < NumberOfDays; ++i)
            {
                Rating += double.Parse(Accommodation[i].Rating);
                Price += int.Parse(Accommodation[i].Price);
                for (int j = 0; j < NumberOfAtractions; ++j)
                {
                    Rating += double.Parse(Atractions[i, j].Rating);
                    Price += int.Parse(Atractions[i, j].Price);
                }
            }
            Rating /= NumberOfDays + NumberOfDays * NumberOfAtractions;
        }

        public double Rating { get; }
        public int Price { get; }
        public int NumberOfDays { get; }
        public int NumberOfAtractions { get; }
        public ListNode[] Accommodation { get; }
        public TripAdvisorNode[,] Atractions { get; }

    }

    abstract class CountryTrip : ITrip
    {
        protected CountryTrip(int _NumberOfDays, int _NumberOfAtractions, ListNode[] _accommodation, TripAdvisorNode[,] _attractions, string _country)
        {
            Trip = new Trip(_NumberOfDays, _NumberOfAtractions, _accommodation, _attractions);
            Country = _country;
        }
        protected ITrip Trip { get; set; }
        protected string Country { get; }

        public double Rating => Trip.Rating;
        public int Price => Trip.Price;
        public int NumberOfDays => Trip.NumberOfDays;
        public int NumberOfAtractions => Trip.NumberOfAtractions;
        public ListNode[] Accommodation => Trip.Accommodation;
        public TripAdvisorNode[,] Atractions => Trip.Atractions;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Rating: {Rating:0.0000}\n");
            builder.Append($"Price: {Price}\n\n");
            for (int i = 0; i < NumberOfDays; ++i)
            {
                builder.Append($"Day {i+1} in {Country}!\n");
                builder.Append($"Accommodation: {Accommodation[i].Name}\n");
                builder.Append("Attractions:\n");
                for (int j = 0; j < NumberOfAtractions; ++j)
                    builder.Append($"\t{Atractions[i, j].Name}\n");
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
