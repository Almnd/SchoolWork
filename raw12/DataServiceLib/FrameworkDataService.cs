using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Framework;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    public class FrameworkDataService : FrameworkIDataService
    {
        // Framework Dataservice ////////

        // Users data service
        public IList<Users> UserToList()
        {
            var ctx = new Raw12Context();
            var users = ctx.Users.ToList();
            return users;
        }

        public IList<Users> GetUsers()
        {
            return UserToList();
        }

        public Users GetUser(int id)
        {
            var ctx = new Raw12Context();
            var users = ctx.Users;

            return users.FirstOrDefault(x => x.UserId == id);
        }

        public IList<Users> GetUserInfo(int page, int pageSize)
        {
            return UserToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfUsers()
        {
            return UserToList().Count;
        }

        public void CreateUser(Users users)
        {
            var cont = new Raw12Context();

            var maxId = UserToList().Max(x => x.UserId);
            users.UserId = maxId + 1;

            cont.Users.Add(users);
            cont.SaveChanges();
        }

        public bool UpdateUser(Users users)
        {
            var cont = new Raw12Context();

            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;

            cont.Users.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetUser(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.Users.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        // searchhistory data service
        public IList<SearchHistory> SearchToList()
        {
            var ctx = new Raw12Context();
            var searches = ctx.SearchHistory.ToList();
            return searches;
        }

        public IList<SearchHistory> StringSearchToList(string keyword)
        {
            var ctx = new Raw12Context();
            var result = ctx.SearchHistory.FromSqlRaw($"select * from string_search({"%" + keyword + "%"})");

            return result.ToList();

            // use the schema column name instead of the table name
            // RETURNS TABLE("movie_id" bpchar, "movie_title" text) AS $BODY$
        }

        public IList<SearchHistory> GetStringSearches(string keyword)
        {
            return StringSearchToList(keyword);
        }

        public IList<SearchHistory> GetSearches()
        {
            return SearchToList();
        }

        public SearchHistory GetSearch(int id)
        {
            var ctx = new Raw12Context();
            var searches = ctx.SearchHistory;

            return searches.FirstOrDefault(x => x.UserId == id);
        }

        public void CreateSearch(SearchHistory searches)
        {
            var cont = new Raw12Context();

            var maxId = SearchToList().Max(x => x.UserId);
            searches.UserId = maxId + 1;

            cont.SearchHistory.Add(searches);
            cont.SaveChanges();
        }

        public bool UpdateSearch(SearchHistory searches)
        {
            var cont = new Raw12Context();

            var dbCat = GetSearch(searches.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Timestamp = searches.Timestamp;
            dbCat.Keyword = searches.Keyword;

            cont.SearchHistory.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteSearch(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetSearch(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.SearchHistory.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        public IList<SearchHistory> GetSearchInfo(int page, int pageSize)
        {
            return SearchToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfSearches()
        {
            return SearchToList().Count;
        }

        // ratings dataservice
        public IList<RatingHistory> RatingsToList()
        {
            var ctx = new Raw12Context();
            var ratings = ctx.RatingHistory.ToList();
            return ratings;
        }

        public IList<RatingHistory> GetRatings()
        {
            return RatingsToList();
        }

        public RatingHistory GetRating(int id)
        {
            var ctx = new Raw12Context();
            var ratings = ctx.RatingHistory;

            return ratings.FirstOrDefault(x => x.UserId == id);
        }

        public void CreateRating(RatingHistory ratings)
        {
            var cont = new Raw12Context();

            var maxId = RatingsToList().Max(x => x.UserId);
            ratings.UserId = maxId + 1;

            cont.RatingHistory.Add(ratings);
            cont.SaveChanges();
        }

        public bool UpdateRating(RatingHistory ratings)
        {
            var cont = new Raw12Context();

            var dbCat = GetRating(ratings.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Rating = ratings.Rating;
            dbCat.TitleId = ratings.TitleId;

            cont.RatingHistory.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteRating(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetRating(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.RatingHistory.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        public IList<RatingHistory> GetRatingInfo(int page, int pageSize)
        {
            return RatingsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfRatings()
        {
            return RatingsToList().Count;
        }


        // title bookings dataservice
        public IList<TitleBookmarking> TBookToList()
        {
            var ctx = new Raw12Context();
            var tbookings = ctx.TitleBook.ToList();
            return tbookings;
        }

        public IList<TitleBookmarking> GetTBookings()
        {
            return TBookToList();
        }

        public TitleBookmarking GetTBooking(int id)
        {
            var ctx = new Raw12Context();
            var tbookings = ctx.TitleBook;

            return tbookings.FirstOrDefault(x => x.UserId == id);
        }

        public IList<TitleBookmarking> GetTBookInfo(int page, int pageSize)
        {
            return TBookToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfTBookings()
        {
            return TBookToList().Count;
        }


        // actor bookings dataservice
        public IList<ActorBookmarking> ABookToList()
        {
            var ctx = new Raw12Context();
            var abookings = ctx.ActorBook.ToList();
            return abookings;
        }

        public IList<ActorBookmarking> GetABookings()
        {
            return ABookToList();
        }

        public ActorBookmarking GetABooking(int id)
        {
            var ctx = new Raw12Context();
            var abookings = ctx.ActorBook;

            return abookings.FirstOrDefault(x => x.UserId == id);
        }

        public IList<ActorBookmarking> GetABookInfo(int page, int pageSize)
        {
            return ABookToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfABookings()
        {
            return ABookToList().Count;
        }
    }
}
