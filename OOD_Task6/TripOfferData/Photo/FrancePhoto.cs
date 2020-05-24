//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Photo
{
    class FrancePhoto : CountryPhoto
    {
        public override string Name => Photo.Name;

        public FrancePhoto(PhotoMetadata metadata, IDecoder<PhotoMetadata> decoder) => Photo = new Photo(metadata, decoder);
    }
}
