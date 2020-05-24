//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using System.Collections.Generic;
using TravelAgencies.DataAccess.Codecs;

namespace TravelAgencies.DataAccess
{
	class TripAdvisorNode
	{
		public string Name { get; set; }
		public string Price { get; set; }//Encrypted
		public string Rating { get; set; }//Encrypted
		public string Country { get; set; }
	}
	class TripAdvisorDatabase : IIterable<TripAdvisorNode>, IDecodable<TripAdvisorNode>
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }

		private static IDecoder<TripAdvisorNode> decoder = null;

		public IDecoder<TripAdvisorNode> GetDecoder()
		{
			if (decoder == null)
				decoder = new TripAdvisorDecoder();
			return decoder;
		}

		public IIterator<TripAdvisorNode> GetIterator()
		{
			return new TripAdvisorIterator(this);
		}
	}

	class TripAdvisorDecoder : IDecoder<TripAdvisorNode>
	{
		private readonly PushCodec pushCodec;
		private readonly FrameCodec frameCodec;
		private readonly SwapCodec swapCodec;

		public TripAdvisorDecoder()
		{
			pushCodec = new PushCodec(3);
			frameCodec = new FrameCodec(2);
			swapCodec = new SwapCodec();
		}
		public string Decode(string str)
		{
			string decoded = pushCodec.Decode(frameCodec.Decode(swapCodec.Decode(pushCodec.Decode(str))));
			if (str == pushCodec.Encode(swapCodec.Encode(frameCodec.Encode(pushCodec.Encode(decoded)))))
				return decoded;
			return null;
		}

		public TripAdvisorNode Decode(TripAdvisorNode input)
		{
			TripAdvisorNode ret = new TripAdvisorNode
			{
				Name = input.Name,
				Price = Decode(input.Price),
				Rating = Decode(input.Rating),
				Country = input.Country
			};
			if (ret.Price == null || ret.Rating == null)
				return null;
			return ret;
		}
	}

	class TripAdvisorIterator : IIterator<TripAdvisorNode>
	{
		public bool IsDone { get; private set; }
		public TripAdvisorNode Current { get; private set; }

		private readonly TripAdvisorDatabase tripAdvisorDatabase;
		int idx; //guid array index
		public TripAdvisorIterator(TripAdvisorDatabase _tripAdvisorDatabase)
		{
			tripAdvisorDatabase = _tripAdvisorDatabase;
			First();
		}

		public void First()
		{
			idx = 0;
			if (tripAdvisorDatabase.Ids != null && tripAdvisorDatabase.Prices != null && tripAdvisorDatabase.Ratings != null && tripAdvisorDatabase.Countries != null && tripAdvisorDatabase.Ids.Length > 0)
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

			while (idx < tripAdvisorDatabase.Ids.Length)
			{
				Guid id = tripAdvisorDatabase.Ids[idx];
				if (id == null)
				{
					++idx;
					continue;
				}
				string name = null;
				if (!tripAdvisorDatabase.Prices.TryGetValue(id, out string price) || !tripAdvisorDatabase.Ratings.TryGetValue(id, out string rating) || !tripAdvisorDatabase.Countries.TryGetValue(id, out string country))
				{
					++idx;
					continue;
				}
				for (int i = 0; i < tripAdvisorDatabase.Names.Length; ++i)
				{
					if (tripAdvisorDatabase.Names[i].TryGetValue(id, out name))
						break;
				}
				Current = new TripAdvisorNode
				{
					Name = name,
					Price = price,
					Rating = rating,
					Country = country
				};
				++idx;
				if (tripAdvisorDatabase.GetDecoder().Decode(Current) != null)
					return;
			}
			IsDone = true;
		}
	}
}