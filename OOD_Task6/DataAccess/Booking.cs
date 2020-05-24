//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System.Linq;
using TravelAgencies.DataAccess.Codecs;

namespace TravelAgencies.DataAccess
{
	class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	
	class BookingDatabase : IIterable<ListNode>, IDecodable<ListNode>
	{
		public ListNode[] Rooms { get; set; }

		private static IDecoder<ListNode> decoder = null;

		public IDecoder<ListNode> GetDecoder()
		{
			if (decoder == null)
				decoder = new BookingDecoder();
			return decoder;
		}

		public IIterator<ListNode> GetIterator()
		{
			return new BookingIterator(this);
		}
	}

	class BookingDecoder : IDecoder<ListNode>
	{
		private readonly FrameCodec frameCodec;
		private readonly ReverseCodec reverseCodec;
		private readonly CezarCodec cezarCodec;
		private readonly SwapCodec swapCodec;

		public BookingDecoder()
		{
			frameCodec = new FrameCodec(2);
			reverseCodec = new ReverseCodec();
			cezarCodec = new CezarCodec(-1);
			swapCodec = new SwapCodec();
		}
		public string Decode(string str)
		{
			string decoded = frameCodec.Decode(reverseCodec.Decode(cezarCodec.Decode(swapCodec.Decode(str))));
			if (str == swapCodec.Encode(cezarCodec.Encode(reverseCodec.Encode(frameCodec.Encode(decoded)))))
				return decoded;
			return null;
		}

		public ListNode Decode(ListNode input)
		{
			ListNode ret = new ListNode
			{
				Name = input.Name,
				Next = null,
				Price = Decode(input.Price),
				Rating = Decode(input.Rating)
			};
			if (ret.Price == null || ret.Rating == null)
				return null;
			return ret;
		}
	}

	class BookingIterator : IIterator<ListNode>
	{
		public bool IsDone { get; private set; }
		public ListNode Current { get; private set; }

		private readonly BookingDatabase bookingDatabase;
		
		//for iteration
		int CategoryIndex { get; set; }
		int Depth { get; set; }


		bool[] categoryExhausted;
		
		
		public BookingIterator(BookingDatabase _bookingDatabase)
		{
			bookingDatabase = _bookingDatabase;
			First();
		}

		public void First()
		{
			CategoryIndex = 0;
			Depth = 0;
			categoryExhausted = new bool[bookingDatabase.Rooms.Length];
			if (this.bookingDatabase.Rooms != null && this.bookingDatabase.Rooms.Length > 0)
			{
				IsDone = false;
			}
			else
			{
				IsDone = true;
				Current = new ListNode();
			}
		}

		public void Next()
		{
			if (IsDone)
				return;

			while (true)
			{
				while (CategoryIndex < bookingDatabase.Rooms.Length)
				{
					if (categoryExhausted[CategoryIndex] == true)
					{
						++CategoryIndex;
						continue;
					}
					Current = bookingDatabase.Rooms[CategoryIndex];
					int i = 0;
					while(i++ < Depth && Current.Next != null)
						Current = Current.Next;
					if (Current != null && Current.Next == null)
						categoryExhausted[CategoryIndex] = true;
					if (categoryExhausted.All(cat => cat == true))
					{
						IsDone = true;
						return;
					}
					++CategoryIndex;
					if (Current != null && bookingDatabase.GetDecoder().Decode(Current) != null)
						return;
				}
				CategoryIndex = 0;
				++Depth;
			}
		}
	}
}
