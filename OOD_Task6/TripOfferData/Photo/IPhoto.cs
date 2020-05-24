//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using TravelAgencies.DataAccess;

namespace TravelAgencies.TripOfferData.Photo
{
    interface IPhoto
    {
        string Name { get; }
        string WidthPx { get; }//Encrypted
        string HeightPx { get; }//Encrypted
    }

    class Photo : IPhoto
    {
        public Photo(PhotoMetadata metadata, IDecoder<PhotoMetadata> decoder)
        {
            Name = metadata.Name;
            WidthPx = decoder.Decode(metadata.WidthPx);
            HeightPx = decoder.Decode(metadata.HeightPx);
        }
        public virtual string Name { get; }

        public virtual string WidthPx { get; }

        public virtual string HeightPx { get; }
    }

    abstract class CountryPhoto : IPhoto
    {
        protected IPhoto Photo { get; set; }
        public virtual string Name => Photo.Name;

        public string WidthPx => Photo.WidthPx;
        public string HeightPx => Photo.HeightPx;
        public override string ToString()
        {
            return Name + $" ({WidthPx}x{HeightPx})";
        }
    }
}
