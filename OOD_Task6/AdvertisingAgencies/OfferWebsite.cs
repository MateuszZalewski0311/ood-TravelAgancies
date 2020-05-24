//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Collections.Generic;
using TravelAgencies.AdvertisingAgencies.TripOffers;

namespace TravelAgencies.AdvertisingAgencies
{
    public class OfferWebsite
    {
        private readonly List<ITripOffer> offers = new List<ITripOffer>();
        internal void AddOffer(ITripOffer offer) => offers.Add(offer);
        public void Present()
        {
            for (int i = 0; i < offers.Count; ++i)
                offers[i].WriteOffer();
        }
    }
}
