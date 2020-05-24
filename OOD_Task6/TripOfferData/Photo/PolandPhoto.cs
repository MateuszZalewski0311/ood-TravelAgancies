//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Text;
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Photo
{
    class PolandPhoto : CountryPhoto
    {
        public override string Name
        {
            get
            {
                StringBuilder builder = new StringBuilder(Photo.Name);
                for (int i = 0; i < builder.Length; ++i)
                {
                    if (builder[i] == 's')
                        builder[i] = 'ś';
                    else if (builder[i] == 'c')
                        builder[i] = 'ć';
                }
                return builder.ToString();
            }
        }

        public PolandPhoto(PhotoMetadata metadata, IDecoder<PhotoMetadata> decoder) => Photo = new Photo(metadata, decoder);
    }
}
