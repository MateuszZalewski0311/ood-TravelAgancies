//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Photo
{
    class ItalyPhoto : CountryPhoto
    {
        public override string Name
        {
            get
            {
                return "Dello_" + Photo.Name;
            }
        }

        public ItalyPhoto(PhotoMetadata metadata, IDecoder<PhotoMetadata> decoder) => Photo = new Photo(metadata, decoder);
    }
}
