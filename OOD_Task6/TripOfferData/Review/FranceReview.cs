//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Text;
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Review
{
    class FranceReview : CountryReview
    {
        public override string ReviewContent
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (string word in Review.ReviewContent.Split(' '))
                    builder.Append(word.Length < 4 ? "la " : word+' ');
                return builder.ToString();
            }
        }
        public override string UserName => Review.UserName;

        public FranceReview(BSTNode reviewData) => Review = new Review(reviewData);
    }
}
