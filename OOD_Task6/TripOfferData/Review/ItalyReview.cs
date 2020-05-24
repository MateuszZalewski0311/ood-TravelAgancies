//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Review
{
    class ItalyReview : CountryReview
    {
        public override string ReviewContent => Review.ReviewContent;
        public override string UserName
        {
            get
            {
                return "Della_" + Review.UserName;
            }
        }

        public ItalyReview(BSTNode reviewData) => Review = new Review(reviewData);
    }
}
