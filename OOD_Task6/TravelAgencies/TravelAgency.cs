//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.DataAccess;
using TravelAgencies.TripOfferData.Photo;
using TravelAgencies.TripOfferData.Review;
using TravelAgencies.TripOfferData.Trip;

namespace TravelAgencies.TravelAgencies
{
    abstract class TravelAgency : ITravelAgency
    {
        protected TravelAgency(Random rd, ShutterStockDatabase photoDatabase, OysterDatabase reviewDatabase, BookingDatabase accommodationDatabase, TripAdvisorDatabase taDatabase)
        {
            NumOfDaysRandomizer = rd;
            PhotoIterator = photoDatabase.GetIterator();
            ReviewIterator = reviewDatabase.GetIterator();
            AccommodationIterator = accommodationDatabase.GetIterator();
            TaIterator = taDatabase.GetIterator();

            PhotoDecoder = photoDatabase.GetDecoder();
            AccommodationDecoder = accommodationDatabase.GetDecoder();
            TaDecoder = taDatabase.GetDecoder();
        }

        protected Random NumOfDaysRandomizer { get; }
        protected IIterator<PhotoMetadata> PhotoIterator { get; }
        protected IIterator<BSTNode> ReviewIterator { get; }
        protected IIterator<ListNode> AccommodationIterator { get; }
        protected IIterator<TripAdvisorNode> TaIterator { get; }
        
        protected IDecoder<PhotoMetadata> PhotoDecoder { get; }
        protected IDecoder<ListNode> AccommodationDecoder { get; }
        protected IDecoder<TripAdvisorNode> TaDecoder { get; }

        abstract public IPhoto CreatePhoto();

        abstract public IReview CreateReview();

        abstract public ITrip CreateTrip();
    }
}
