//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.DataAccess;
using TravelAgencies.TripOfferData.Photo;
using TravelAgencies.TripOfferData.Review;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.TravelAgencies
{
    class ItalyTravelAgency : TravelAgency
    {
        public ItalyTravelAgency(Random rd, ShutterStockDatabase photoDatabase, OysterDatabase reviewDatabase, BookingDatabase accommodationDatabase, TripAdvisorDatabase taDatabase) : base(rd, photoDatabase, reviewDatabase, accommodationDatabase, taDatabase)
        {
            //PhotoIterator.Next(); //set to first element
            //reviewIterator.Next(); //set to first element
            AccommodationIterator.Next(); //set to first element
            TaIterator.Next(); //set to first element
        }
        public override IPhoto CreatePhoto()
        {
            do
            {
                if (PhotoIterator.IsDone)
                    PhotoIterator.First();
                PhotoIterator.Next();
            } while (PhotoIterator.Current.Longitude < 8.8 || PhotoIterator.Current.Longitude > 15.2 || PhotoIterator.Current.Latitude < 37.7 || PhotoIterator.Current.Latitude > 44.0);
            return new ItalyPhoto(PhotoIterator.Current, PhotoDecoder);
        }

        public override IReview CreateReview()
        {
            if (ReviewIterator.IsDone)
                ReviewIterator.First();

            ReviewIterator.Next();
            return new ItalyReview(ReviewIterator.Current);
        }

        public override ITrip CreateTrip()
        {
            int days = NumOfDaysRandomizer.Next(1, 5);
            ListNode[] _accommodation = new ListNode[days];
            TripAdvisorNode[,] _attractions = new TripAdvisorNode[days, 3];
            for (int i = 0; i < days; ++i)
            {
                if (AccommodationIterator.IsDone)
                {
                    AccommodationIterator.First();
                    AccommodationIterator.Next(); //set to first element
                }
                _accommodation[i] = AccommodationDecoder.Decode(AccommodationIterator.Current);
                AccommodationIterator.Next();
            }
            for (int i = 0; i < days; ++i)
            {
                for (int j = 0; j < 3;)
                {
                    if (TaIterator.IsDone)
                    {
                        TaIterator.First();
                        TaIterator.Next(); //set to first element
                    }
                    if (TaIterator.Current.Country == "Italy")
                        _attractions[i, j++] = TaDecoder.Decode(TaIterator.Current);
                    TaIterator.Next();
                }
            }
            return new ItalyTrip(days, _accommodation, _attractions);
        }
    }
}
