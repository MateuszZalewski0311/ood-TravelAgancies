//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using TravelAgencies.DataAccess.Codecs;

namespace TravelAgencies.DataAccess
{
	class PhotoMetadata
	{
		public string Name { get; set; }
		public string Camera { get; set; }
		public double[] CameraSettings { get; set; }
		public DateTime Date { get; set; }
		public string WidthPx { get; set; }//Encrypted
		public string HeightPx { get; set; }//Encrypted
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
	class ShutterStockDatabase : IIterable<PhotoMetadata>, IDecodable<PhotoMetadata>
	{
		public PhotoMetadata[][][] Photos;

		private static IDecoder<PhotoMetadata> decoder = null;

		public IDecoder<PhotoMetadata> GetDecoder()
		{
			if (decoder == null)
				decoder = new ShutterStockDecoder();
			return decoder;
		}

		public IIterator<PhotoMetadata> GetIterator()
		{
			return new ShutterStockIterator(this);
		}
	}

	class ShutterStockDecoder : IDecoder<PhotoMetadata>
	{
		private readonly CezarCodec cezarCodec;
		private readonly FrameCodec frameCodec;
		private readonly PushCodec pushCodec;
		private readonly ReverseCodec reverseCodec;

		public ShutterStockDecoder()
		{
			cezarCodec = new CezarCodec(4);
			frameCodec = new FrameCodec(1);
			pushCodec = new PushCodec(-3);
			reverseCodec = new ReverseCodec();
		}
		public string Decode(string str)
		{
			string decoded = cezarCodec.Decode(frameCodec.Decode(pushCodec.Decode(reverseCodec.Decode(str))));
			if (str == reverseCodec.Encode(pushCodec.Encode(frameCodec.Encode(cezarCodec.Encode(decoded)))))
				return decoded;
			return null;
		}

		public PhotoMetadata Decode(PhotoMetadata input)
		{
			PhotoMetadata ret = new PhotoMetadata
			{
				Name = input.Name,
				Camera = input.Camera,
				CameraSettings = input.CameraSettings,
				Date = input.Date,
				WidthPx = Decode(input.WidthPx),
				HeightPx = Decode(input.HeightPx),
				Longitude = input.Longitude,
				Latitude = input.Latitude
			};
			if (ret.WidthPx == null || ret.HeightPx == null)
				return null;
			return ret;
		}
	}

	class ShutterStockIterator : IIterator<PhotoMetadata>
	{
		public bool IsDone { get; private set; }
		public PhotoMetadata Current { get; private set; }
		private readonly PhotoMetadata[][][] photos;
		private IDecoder<PhotoMetadata> decoder;

		int x, y, z; //indexes

		public ShutterStockIterator(ShutterStockDatabase _shutterStockDatabase)
		{
			photos = _shutterStockDatabase.Photos;
			decoder = _shutterStockDatabase.GetDecoder();
			First();
		}

		public void First()
		{
			x = 0;
			y = 0;
			z = 0;
			if (photos != null || photos.Length > 0)
			{
				IsDone = false;
			}
			else
				IsDone = true;
		}

		public void Next()
		{
			if (IsDone)
				return;

			while (x < photos.Length)
			{
				if (photos[x] != null)
					while (y < photos[x].Length)
					{
						if (photos[x][y] != null)
							while (z < photos[x][y].Length)
							{
								if (photos[x][y][z] != null)
								{
									Current = photos[x][y][z++];
									if (decoder.Decode(Current) != null)
										return;
								}
								++z;
							}
						z = 0;
						++y;
					}
				z = y = 0;
				++x;
			}
			IsDone = true;
			return;
		}
	}
}
