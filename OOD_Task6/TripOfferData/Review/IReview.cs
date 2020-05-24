//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Review
{
    interface IReview
    {
        string ReviewContent { get; }
        string UserName { get; }
    }

    class Review : IReview
    {
        public Review(BSTNode reviewData)
        {
            ReviewContent = reviewData.Review;
            UserName = reviewData.UserName;
        }
        public virtual string ReviewContent { get; }

        public virtual string UserName { get; }
    }

    abstract class CountryReview : IReview
    {
        protected IReview Review { get; set; }
        public virtual string ReviewContent => Review.ReviewContent;
        public virtual string UserName => Review.UserName;
        public override string ToString()
        {
            return UserName + $": {ReviewContent}";
        }
    }
}
