//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
using System;
using System.Collections.Generic;
using TravelAgencies.AdvertisingAgencies;
using TravelAgencies.DataAccess;
using TravelAgencies.TravelAgencies;

namespace TravelAgencies
{
	class Program
	{
		static void Main(string[] args) { new Program().Run(); }

		private const int WebsitePermanentOfferCount = 5;
		private const int WebsiteTemporaryOfferCount = 5;
		private Random rd = new Random(257);

		//----------
		//YOUR CODE - additional fileds/properties/methods
		//----------

		public void Run()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			(
				BookingDatabase accomodationData, 
				TripAdvisorDatabase tripsData, 
				ShutterStockDatabase photosData, 
				OysterDatabase reviewData
			) = Init.Init.Run();


			//----------
			//YOUR CODE - set up everything
			OfferWebsite offerWebsite = new OfferWebsite();
			List<ITravelAgency> travelAgencies = new List<ITravelAgency>();
			List<IAdvertisingAgency> advertisingAgencies = new List<IAdvertisingAgency>();
			travelAgencies.Add(new PolandTravelAgency(rd, photosData, reviewData, accomodationData, tripsData));
			travelAgencies.Add(new ItalyTravelAgency(rd, photosData, reviewData, accomodationData, tripsData));
			travelAgencies.Add(new FranceTravelAgency(rd, photosData, reviewData, accomodationData, tripsData));
			for (int i = 0; i < WebsitePermanentOfferCount + WebsiteTemporaryOfferCount; ++i)
			{
				switch (rd.Next(1, 3))
				{
					case 1:
						advertisingAgencies.Add(new GraphicAdvertisingAgency(rd, rd.Next(3, 7), rd.Next(1, 5), travelAgencies));
						break;
					case 2:
						advertisingAgencies.Add(new TextAdvertisingAgency(rd, rd.Next(3, 7), rd.Next(1, 5), travelAgencies));
						break;
				}
			}
			for (int i = 0; i < WebsitePermanentOfferCount; ++i)
			{
				offerWebsite.AddOffer(advertisingAgencies[i].CreatePermanentTripOffer());
			}
			for (int i = 0; i < WebsiteTemporaryOfferCount; ++i)
			{
				offerWebsite.AddOffer(advertisingAgencies[i+WebsitePermanentOfferCount].CreateTemporaryTripOffer());
			}
			//----------

			while (true)
            {
				Console.Clear();

				//----------
				//YOUR CODE - run
				//----------

				//uncomment
				Console.WriteLine("\n\n=======================FIRST PRESENT======================");
				offerWebsite.Present();
				Console.WriteLine("\n\n=======================SECOND PRESENT======================");
				offerWebsite.Present();
				Console.WriteLine("\n\n=======================THIRD PRESENT======================");
				offerWebsite.Present();


				if (HandleInput()) break;
			}
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
    }
}
