using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DataServiceLib.Framework;

namespace DataServiceLib
{
    public interface FrameworkIDataService
    {
        // Framework Interfaces ////////
        // only users, searches and ratings implement CRUD for now

        // users interface
        IList<Users> GetUsers();
        void CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
        Users GetUser(int id);
        IList<Users> GetUserInfo(int page, int pageSize);
        int NumberOfUsers();

        // search interface
        IList<SearchHistory> GetSearches();
        IList<SearchHistory> GetStringSearches(string keyword);
        void CreateSearch(SearchHistory searches);
        bool UpdateSearch(SearchHistory searches);
        bool DeleteSearch(int id);
        SearchHistory GetSearch(int id);
        IList<SearchHistory> GetSearchInfo(int page, int pageSize);
        int NumberOfSearches();

        //ratings interface
        IList<RatingHistory> GetRatings();
        void CreateRating(RatingHistory ratings);
        bool UpdateRating(RatingHistory ratings);
        bool DeleteRating(int id);
        RatingHistory GetRating(int id);
        IList<RatingHistory> GetRatingInfo(int page, int pageSize);
        int NumberOfRatings();

        //titlebooking interface
        IList<TitleBookmarking> GetTBookings();

/*      bool CreateTBooking(TitleBookmarking tbookings);
        bool UpdateTBooking(TitleBookmarking tbookings);
        bool DeleteTBooking(int id);*/
        TitleBookmarking GetTBooking(int id);
        IList<TitleBookmarking> GetTBookInfo(int page, int pageSize);
        int NumberOfTBookings();

        //actorbooking interface
        IList<ActorBookmarking> GetABookings();

/*      bool CreateABooking(ActorBookmarking abookings);
        bool UpdateABooking(ActorBookmarking abookings);
        bool DeleteABooking(int id);*/
        ActorBookmarking GetABooking(int id);
        IList<ActorBookmarking> GetABookInfo(int page, int pageSize);
        int NumberOfABookings();

    }
}