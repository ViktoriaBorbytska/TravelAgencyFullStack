using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Seeders;

namespace TravelAgency.DatabaseAccess
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ITravelAgencyDbContext context;

        #region Offers
        #region Paris
        private const string ParisDescription = "This dynamic destination is the very definition of world-class! " +
            "You simply can't visit without seeing Eiffel Tower and Palace of Versailles. It is also famous for the " +
            "Arc de Triomphe and the Louvre Museum. Escape the ordinary and throw yourself into a realm of imagination" +
            " at Disneyland® Paris and Aquaboulevard. If you're looking for even more family fun, head on to the La" +
            " Geode and the Montmartre Funicular.";
        private const string ParisDestination = "Paris, France";
        private const string ParisImageLink = "images/top-1.png";
        private const int ParisMark = 5;
        private const int ParisPrice = 600;
        private const string ParisHotelName = "Hôtel La Nouvelle République";
        private const string ParisHotelLink = "https://www.hotel-la-nouvelle-republique.paris/en/";
        private const string ParisDetailedDescription = "Your evening tour begins at a meeting point in the heart of " +
            "Paris. Climb aboard the air-conditioned coach head to either the Eiffel Tower or a Seine riverboat," +
            " according to your preference. If the former, enjoy a gourmet meal with wine, beer, or soft drinks in a" +
            " heated bubble-dome on the Eiffel Tower’s terrace. It offers guests unbeatable views of the City of Lights." +
            " After dinner, head to the Seine for a riverboat tour and to admire landmarks as they pass by. If you’ve" +
            " chosen the second option, tuck into a gourmet 3-course meal aboard the riverboat and sightsee. After your" +
            " meal, visit the Eiffel Tower’s second-floor observation deck with its panoramic views. Then travel by coach " +
            "to your third destination: the Moulin Rouge, a landmark cabaret bar founded in the 19th century. See dozens" +
            " of dancers, acrobats, and performers take to the stage as you toast with Champagne. Following the performance," +
            " the coach returns you to central Paris, where the tour ends. Note: If the late evening Moulin Rouge " +
            "performance is fully booked, you see an earlier showing and receive vouchers to the Eiffel Tower or Seine " +
            "river cruise.";
        private const string ParisInclusions = "Luxury air-conditioned coach transport|Découverte’ dinner cruise on the " +
            "Seine(first service of the Marina restaurant) with drinks(if option selected)|Féerie show at the Moulin Rouge " +
            "with 1/2 bottle(or 1 glass) of champagne depending on option selected( if option selected)|French Style Gourmet " +
            "Meal in heated Dome on 1st Floor Eiffel Tower's Terrace( if option selected)|One-hour Seine cruise by " +
            "glass-enclosed boat with recorded commentary and personal headphones to listen in the language of your " +
            "choice(French, English, Spanish, Italian, German, Portuguese, Russian, Polish, Dutch, Hindi, Arabic, " +
            "Chinese, Japanese and Korean)|Multilingual hostess at your service|Entry/Admission - Eiffel Tower|" +
            "Entry/Admission - Seine River|Entry/Admission - Moulin Rouge|Guaranteed to skip the lines";
        #endregion

        #region Rome
        private const string RomeDescription = "Start off your trip at the iconic St. Peter's Basilica and Roman " +
            "Forum. Escape the adult world for a while and throw yourself into a place of imagination and wonder " +
            "at Rainbow MagicLand and Zoomarine. If you're on the lookout for even more family fun, head onwards " +
            "to the Explora Children's Museum and Hydromania. Your family doesn't need to have gills and scales " +
            "in order to enjoy the deep waters at Mediterraneum Aquarium Rome.";
        private const string RomeDestination = "Rome, Italy";
        private const string RomeImageLink = "images/top-2.png";
        private const int RomeMark = 5;
        private const int RomePrice = 500;
        private const string RomeHotelName = "Hotel Regent Rome";
        private const string RomeHotelLink = "https://www.hotelregentroma.net/en-gb";
        private const string RomeDetailedDescription = "Depending on the time slot you selected at checkout, your " +
            "experience begins outside of the Vatican Museums. Access the Vatican through a special entrance with no " +
            "lines, saving hours of waiting time.\nWalk first through the Gallery of Maps and the Gallery of Tapestries, " +
            "hearing your guide's commentary loud and clear through your personal headset. Snap photos in front of the Pigna" +
            " statue in the Pinecone Courtyard before you continue to Raphael’s Rooms.\nSpend the next part of the tour " +
            "gazing upward at the Sistine Chapel, home to Michelangelo’s 'The Creation of Adam' and 'The Last Judgement.' " +
            "After, say farewell to your guide and continue to St.Peter’s Basilica to enjoy the church independently.\nPlease" +
            " note that on Wednesdays, due to the weekly Papal Audience, St.Peter’s Basilica may be unavailable.Ensure " +
            "you select a day other than Wednesday if you’re set on seeing the landmark.";
        private const string RomeInclusions = "Professional guide|Headsets to hear the guide clearly|Priority Access " +
            "to the Vatican|Entry/Admission - Vatican Museums|Entry/Admission - Sistine Chapel|Entry/Admission - Stanze" +
            " di Raffaello|Entry/Admission - St.Peter's Basilica";
        #endregion

        #region London
        private const string LondonDescription = "Dynamic and international, London is famous for the Big Ben and " +
            "Buckingham Palace. Royal Albert Hall and Trafalgar Square are also iconic sights here. Rediscover the " +
            "joys of childhood at the Coca-Cola London Eye and Chessington World of Adventures. Want more? The Madame" +
            " Tussaud's Wax Museum and the Electric Cinema are sure to keep everyone grinning. Sea Life London " +
            "Aquarium and Horniman Museum Aquarium offer guests an opportunity to see the wonderful world of " +
            "underwater creatures.";
        private const string LondonDestination = "London, UK";
        private const string LondonImageLink = "images/top-3.png";
        private const int LondonMark = 5;
        private const int LondonPrice = 800;
        private const string LondonHotelName = "Travelodge London Stratford";
        private const string LondonHotelLink = "https://www.travelodge.co.uk/hotels/522/London-Stratford-hotel?utm_source=google&utm_medium=GHA_Organic&utm_campaign=GHA_London%20Stratford";
        private const string LondonDetailedDescription = "Redeem your pass at a date convenient to you, and board " +
            "your sightseeing bus at one of the multiple stops around London. Opt to remain on each bus route for " +
            "the entire loop, or disembark whenever an attraction captures your attention.\nLive or prerecorded commentary" +
            " brings the capital city’s history to life, while the included Thames River cruise and a walking tour reveals" +
            " a different side to London.\nSome popular attractions this hop-on hop-off tour stops at are the London Eye, " +
            "Big Ben, Madame Tussauds London, Kensington Palace, and Piccadilly Circus.";
        private const string LondonInclusions = "Unlimited Hop-on Hop-off on 7 routes|More than 100 stops|A complementary" +
            " Hop-on Hop-off Thames river cruise|FREE Walking Tour|Live guided tour on the yellow route(T1)|Multilingual" +
            " commentary available in 11 languages|Kids' Club Activity Book & child friendly commentary on-board. *Must " +
            "collect from Visitor Centre";
        #endregion

        #region Florence
        private const string FlorenceDescription = "Cradle of the Renaissance, La Cittá Bella: Florence is known as many " +
            "things, but it’s never been known as boring. Perched in the heart of Italy, this Tuscan capital blends " +
            "historically important sights with an effortlessly modern style, and the range of Florence activities " +
            "is a testament to its vibrant personality. Whether you’re interested in strolling the stylish streets " +
            "or want to join one of the guided Florence tours, this is a city that belongs on your must-travel map.";
        private const string FlorenceDestination = "Florence, Italy";
        private const string FlorenceImageLink = "images/top-4.png";
        private const int FlorenceMark = 5;
        private const int FlorencePrice = 300;

        private const string FlorenceHotelName = "Residenza Castiglioni";
        private const string FlorenceHotelLink = "https://www.residenzacastiglioni.com/";
        private const string FlorenceDetailedDescription = "Depart from a meeting point in central Florence, and travel" +
            " toward Tuscany’s wine country in an air-conditioned coach limited to 25 passengers. On arrival at the first" +
            " wine estate in Chianti, learn about the farm and vineyard before sampling three wine options paired with olive" +
            " oil and bread.\nAt the next winery, take a tour of the wine cellars, and learn about a different production" +
            " process.Pleasure your palate with three more wine options accompanied by Tuscan specialties such as cold cuts," +
            " bruschetta, salami, and cheese.\nThis wine-tasting tour concludes with drop-off at your original departure point" +
            " in Florence. ";
        private const string FlorenceInclusions = "Small-group tour (max. group size 25 people)|Transport by air-conditioned " +
            "vehicle|Free Wi-Fi on board|Professional and informative English-speaking driver/guide to lead you through the " +
            "experience|Guided visit to 2 different wine estate|Tasting of 3 wines and olive oil at the first winery|Tasting of" +
            " 3 wines and olive oil at the second winery paired with local Tuscan specialties(cheese, salami, cured ham and " +
            "bruschetta)";
        #endregion

        #region Tahiti
        private const string TahitiDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string TahitiDestination = "Tahity";
        private const string TahitiImageLink = "images/popular-2.png";
        private const int TahitiMark = 4;
        private const int TahitiPrice = 900;
        #endregion

        #region SouthIsland
        private const string SouthIslandDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string SouthIslandDestination = "South Island";
        private const string SouthIslandImageLink = "images/popular-4.png";
        private const int SouthIslandMark = 4;
        private const int SouthIslandPrice = 700;
        #endregion

        #region Phuket
        private const string PhuketDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string PhuketDestination = "Phuket";
        private const string PhuketImageLink = "images/popular-5.png";
        private const int PhuketMark = 4;
        private const int PhuketPrice = 550;
        #endregion

        #region Dubai
        private const string DubaiDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string DubaiDestination = "Dubai";
        private const string DubaiImageLink = "images/popular-6.png";
        private const int DubaiMark = 4;
        private const int DubaiPrice = 950;
        #endregion

        #region NewYorkCity
        private const string NewYorkCityDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string NewYorkCityDestination = "New York City";
        private const string NewYorkCityImageLink = "images/popular-7.png";
        private const int NewYorkCityMark = 4;
        private const int NewYorkCityPrice = 1000;
        #endregion

        #region Barcelona
        private const string BarcelonaDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string BarcelonaDestination = "Barcelona";
        private const string BarcelonaImageLink = "images/popular-8.png";
        private const int BarcelonaMark = 4;
        private const int BarcelonaPrice = 700;
        #endregion

        #region ParisPopular
        private const string ParisPopularDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string ParisPopularDestination = "Paris";
        private const string ParisPopularImageLink = "images/popular-1.png";
        private const int ParisPopularMark = 4;
        private const int ParisPopularPrice = 600;
        #endregion

        #region LondonPopular
        private const string LondonPopularDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
            "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown " +
            "printer took a galley of type and scrambled it to make a type specimen book. It has survived not only " +
            "five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was " +
            "popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more" +
            " recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        private const string LondonPopularDestination = "London";
        private const string LondonPopularImageLink = "images/popular-3.png";
        private const int LondonPopularMark = 4;
        private const int LondonPopularPrice = 600;
        #endregion
        #endregion

        #region News
        #region CostaRica
        private DateTime CostaRicaNewsDate = new DateTime(2018, 12, 20);
        private const string CostaRicaNewsHeader = "The best places to visit in Costa Rica";
        private const string CostaRicaNewsImageLink = "images/news-post-1.png";
        private const string CostaRicaNewsText = "Costa Rica is one of the most visited countries in Central America." +
            " American tourists have been flocking to the country for years, and it’s become a hot spot for retirees " +
            "and expats due to its cheap living, great weather, amazing beaches, and friendly locals. I love Costa " +
            "Rica. It was the first place that inspired me to travel. It holds a special place in my heart. I’ve " +
            "been back to visit Costa Rica many times since then, falling in love with it over and over again. " +
            "But, because it’s not as cheap to visit as its neighbors, many budget travelers skip over Costa " +
            "Rica. And, while that’s true (but there are many ways to save money in Costa Rica), in my opinion," +
            " the beauty of the destinations below is worth the extra price.";
        #endregion

        #region HolidayGuide
        private DateTime HolidayGuideNewsDate = new DateTime(2018, 12, 3);
        private const string HolidayGuideNewsHeader = "The ultimate 2018 Holiday Guide";
        private const string HolidayGuideNewsImageLink = "images/news-post-2.png";
        private const string HolidayGuideNewsText = "Travelers can be a fickle group of people to buy gifts for " +
            "as we’re constantly coming and going. We usually don’t carry a lot of stuff with us, and no two " +
            "travelers are alike so finding the perfect gift for the traveler in your life can be tricky. " +
            "While a plane ticket is never a bad idea (I’m a window seat in case anyone is thinking of " +
            "getting me one), I’ve put together this ultimate (and our first ever) holiday gift guide for " +
            "travelers as there’s a lot of great travel gear out there these days that helps people travel " +
            "cheaper and better. Even me, the gear adverse traveler, likes a lot of this stuff! This is stuff" +
            " I actually think is super useful. No nonsense. No fluff.";
        #endregion

        #region SoloTravel
        private DateTime SoloTravelNewsDate = new DateTime(2019, 1, 2);
        private const string SoloTravelNewsHeader = "How I research my solo travel destinations";
        private const string SoloTravelNewsImageLink = "images/news-post-3.png";
        private const string SoloTravelNewsText = "What’s the best way to go about researching your next trip when" +
            " all of the decisions will fall to you as a solo traveler? Where should you go, what should you do, " +
            "how will you navigate in your new surroundings? Where do you even begin to get answers to these " +
            "questions? Over the past six years, I’ve been mostly nomadic, traveling solo for the bulk of that " +
            "time. Since I’ve been chief decision-maker for all of those trips, there are tricks I’ve learned " +
            "along the way to help me save time in the long run, avoid spending too much and getting scammed, " +
            "and make sure I know my way around before I even touch down.";
        #endregion

        #region TopTenPlaces
        private DateTime TopTenPlacesNewsDate = new DateTime(2019, 1, 5);
        private const string TopTenPlacesNewsHeader = "Top Ten Places to Go for New Year’s Eve  ";
        private const string TopTenPlacesNewsImageLink = "images/sidebar-1.png";
        private const string TopTenPlacesNewsText = "";
        #endregion

        #region ChangingMyTune
        private DateTime ChangingMyTuneNewsDate = new DateTime(2018, 11, 2);
        private const string ChangingMyTuneNewsHeader = "Changing my tune: how I learnt to love LA";
        private const string ChangingMyTuneNewsImageLink = "images/sidebar-2.png";
        private const string ChangingMyTuneNewsText = "";
        #endregion

        #region SignsYouAre
        private DateTime SignsYouAreNewsDate = new DateTime(2018, 8, 19);
        private const string SignsYouAreNewsHeader = "41 Signs You Are a Travel Addict";
        private const string SignsYouAreNewsImageLink = "images/sidebar-3.png";
        private const string SignsYouAreNewsText = "";
        #endregion
        #endregion

        #region Reviews
        #region OverallFantastic
        private DateTime OverallFantasticReviewsDate = new DateTime(2018, 12, 20);
        private const string OverallFantasticReviewsHeader = "Overall, fantastic! I'd recommend them to anyone " +
            "looking for a creative, thoughtful, and professional team.”";
        private const string OverallFantasticReviewsImageLink = "images/reviews-1.png";
        private const string OverallFantasticReviewsText = "Our travel agency provided outstanding advice and " +
            "direction in helping us develop our plans for travel in Austria, Czech Republic, and elsewhere " +
            "in Bavaria. There selection of local guides and accommodations was a real 'difference maker' " +
            "in making this travel experience as special as it was.";
        #endregion

        #region ThumbsWay
        private DateTime ThumbsWayReviewsDate = new DateTime(2018, 12, 20);
        private const string ThumbsWayReviewsHeader = "4 thumbs way up from my 2 sons!”";
        private const string ThumbsWayReviewsImageLink = "images/reviews-2.png";
        private const string ThumbsWayReviewsText = "Our travel agent exceeded expectations with respect to our " +
            "recent trip to New Zealand. All lodging accomodations were outstanding - a nice mix of 5 star hotels " +
            "with 'motels' with eat-in kitchens, all within budget. Locations of the lodging were right on target" +
            " - typically within walking distances of restaurants and other fun activities. Excursions booked by our agent were also very interesting and fun, based on a general interest expressed in areas such as hiking, sightseeing, etc. I was surprised by professionalism and great customer service the excursion operators demonstrated.";
        #endregion

        #region EverythingWe
        private DateTime EverythingWeReviewsDate = new DateTime(2018, 12, 20);
        private const string EverythingWeReviewsHeader = "Everything we wanted and more.”";
        private const string EverythingWeReviewsImageLink = "images/reviews-3.png";
        private const string EverythingWeReviewsText = "We cannot recommend this travel company enough! " +
            "My husband and I had been wanting to go to Germany/Austria for quite some time but had not " +
            "done so due to lack of time to plan a worthwhile trip. Booking with this company was exactly " +
            "what we needed--we told them the types of places and sites we wanted to see and they took care " +
            "of the rest. Our travel agents and the rest of the travel company were simply amazing throughout the whole process. We felt that we got a truly unique and very low stress traveling experience by booking through this company.";
        #endregion
        #endregion

        public DatabaseSeeder(ITravelAgencyDbContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            AddOffers();
            AddNews();
            AddReviews();
            AddSubscribers();
        }

        private void AddOffers()
        {
            if (!context.Offers.Any())
            {
                var offers = new List<Offer>
                {
                    new Offer
                    {
                        Description = ParisDescription,
                        Destination = ParisDestination,
                        ImageLink = ParisImageLink,
                        Mark = ParisMark,
                        Price = ParisPrice,
                        HotelName = ParisHotelName,
                        HotelLink = ParisHotelLink,
                        DetailedDescription = ParisDetailedDescription,
                        Inclusions = ParisInclusions
                    },
                    new Offer
                    {
                        Description = RomeDescription,
                        Destination = RomeDestination,
                        ImageLink = RomeImageLink,
                        Mark = RomeMark,
                        Price = RomePrice,
                        HotelName = RomeHotelName,
                        HotelLink = RomeHotelLink,
                        DetailedDescription = RomeDetailedDescription,
                        Inclusions = RomeInclusions
                    },
                    new Offer
                    {
                        Description = LondonDescription,
                        Destination = LondonDestination,
                        ImageLink = LondonImageLink,
                        Mark = LondonMark,
                        Price = LondonPrice,
                        HotelName = LondonHotelName,
                        HotelLink = LondonHotelLink,
                        DetailedDescription = LondonDetailedDescription,
                        Inclusions = LondonInclusions
                    },
                    new Offer
                    {
                        Description = FlorenceDescription,
                        Destination = FlorenceDestination,
                        ImageLink = FlorenceImageLink,
                        Mark = FlorenceMark,
                        Price = FlorencePrice,
                        HotelName = FlorenceHotelName,
                        HotelLink = FlorenceHotelLink,
                        DetailedDescription = FlorenceDetailedDescription,
                        Inclusions = FlorenceInclusions
                    },
                    new Offer
                    {
                        Description = ParisPopularDescription,
                        Destination = ParisPopularDestination,
                        ImageLink = ParisPopularImageLink,
                        Mark = ParisPopularMark,
                        Price = ParisPopularPrice
                    },
                    new Offer
                    {
                        Description = TahitiDescription,
                        Destination = TahitiDestination,
                        ImageLink = TahitiImageLink,
                        Mark = TahitiMark,
                        Price = TahitiPrice
                    },
                    new Offer
                    {
                        Description = LondonPopularDescription,
                        Destination = LondonPopularDestination,
                        ImageLink = LondonPopularImageLink,
                        Mark = LondonPopularMark,
                        Price = LondonPopularPrice
                    },
                    new Offer
                    {
                        Description = SouthIslandDescription,
                        Destination = SouthIslandDestination,
                        ImageLink = SouthIslandImageLink,
                        Mark = SouthIslandMark,
                        Price = SouthIslandPrice
                    },
                    new Offer
                    {
                        Description = PhuketDescription,
                        Destination = PhuketDestination,
                        ImageLink = PhuketImageLink,
                        Mark = PhuketMark,
                        Price = PhuketPrice
                    },
                    new Offer
                    {
                        Description = DubaiDescription,
                        Destination = DubaiDestination,
                        ImageLink = DubaiImageLink,
                        Mark = DubaiMark,
                        Price = DubaiPrice
                    },
                    new Offer
                    {
                        Description = NewYorkCityDescription,
                        Destination = NewYorkCityDestination,
                        ImageLink = NewYorkCityImageLink,
                        Mark = NewYorkCityMark,
                        Price = NewYorkCityPrice
                    },
                    new Offer
                    {
                        Description = BarcelonaDescription,
                        Destination = BarcelonaDestination,
                        ImageLink = BarcelonaImageLink,
                        Mark = BarcelonaMark,
                        Price = BarcelonaPrice
                    }
                };

                context.Offers.AddRange(offers);

                context.SaveChanges();
            }
        }

        private void AddNews()
        {
            if (!context.News.Any())
            {
                var news = new List<News>
                {
                    new News
                    {
                        Date = CostaRicaNewsDate,
                        Header = CostaRicaNewsHeader,
                        ImageLink = CostaRicaNewsImageLink,
                        Text = CostaRicaNewsText
                    },
                    new News
                    {
                        Date = HolidayGuideNewsDate,
                        Header = HolidayGuideNewsHeader,
                        ImageLink = HolidayGuideNewsImageLink,
                        Text = HolidayGuideNewsText
                    },
                    new News
                    {
                        Date = SoloTravelNewsDate,
                        Header = SoloTravelNewsHeader,
                        ImageLink = SoloTravelNewsImageLink,
                        Text = SoloTravelNewsText
                    },
                    new News
                    {
                        Date = TopTenPlacesNewsDate,
                        Header = TopTenPlacesNewsHeader,
                        ImageLink = TopTenPlacesNewsImageLink,
                        Text = TopTenPlacesNewsText
                    },
                    new News
                    {
                        Date = ChangingMyTuneNewsDate,
                        Header = ChangingMyTuneNewsHeader,
                        ImageLink = ChangingMyTuneNewsImageLink,
                        Text = ChangingMyTuneNewsText
                    },
                    new News
                    {
                        Date = SignsYouAreNewsDate,
                        Header = SignsYouAreNewsHeader,
                        ImageLink = SignsYouAreNewsImageLink,
                        Text = SignsYouAreNewsText
                    },
                };

                context.News.AddRange(news);

                context.SaveChanges();
            }
        }

        private void AddReviews()
        {
            if (!context.Reviews.Any())
            {
                var reviews = new List<Review>
                {
                    new Review
                    {
                        Date = OverallFantasticReviewsDate,
                        Header = OverallFantasticReviewsHeader,
                        ImageLink = OverallFantasticReviewsImageLink,
                        Text = OverallFantasticReviewsText
                    },
                    new Review
                    {
                        Date = ThumbsWayReviewsDate,
                        Header = ThumbsWayReviewsHeader,
                        ImageLink = ThumbsWayReviewsImageLink,
                        Text = ThumbsWayReviewsText
                    },
                    new Review
                    {
                        Date = EverythingWeReviewsDate,
                        Header = EverythingWeReviewsHeader,
                        ImageLink = EverythingWeReviewsImageLink,
                        Text = EverythingWeReviewsText
                    },
                };

                context.Reviews.AddRange(reviews);

                context.SaveChanges();
            }
        }

        private void AddSubscribers()
        {
            if (!context.Subscribers.Any())
            {
                List<Subscriber> subscribers = new List<Subscriber>
                {
                    new Subscriber {Email = "francesca.whitehead@outlook.com"},
                    new Subscriber {Email = "danon.thompson@i.ua"},
                    new Subscriber {Email = "samuel.faulkner@email.ua"}
                };

                context.Subscribers.AddRange(subscribers);

                context.SaveChanges();
            }
        }
    }
}