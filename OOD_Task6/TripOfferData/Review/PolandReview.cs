//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Text;
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Review
{
    class PolandReview : CountryReview
    {
        public override string ReviewContent
        {
            get
            {
                StringBuilder builder = new StringBuilder(Review.ReviewContent);
                for (int i = 0; i < builder.Length; ++i)
                {
                    if (builder[i] == 'e')
                        builder[i] = 'ę';
                    else if (builder[i] == 'a')
                        builder[i] = 'ą';
                }
                return builder.ToString();
            }
        }
        public override string UserName
        {
            get
            {
                StringBuilder builder = new StringBuilder(Review.UserName);
                for (int i = 0; i < builder.Length; ++i)
                {
                    if (builder[i] == 'e')
                        builder[i] = 'ę';
                    else if (builder[i] == 'a')
                        builder[i] = 'ą';
                }
                return builder.ToString();
            }
        }

        public PolandReview(BSTNode reviewData) => Review = new Review(reviewData);
    }
}
