using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SDM_Compulsory_Assignment
{
    public class LogicHandler : ILogicHandler
    {
        public IEnumerable<Review> Reviews;

        public LogicHandler()
        {
            using (StreamReader r =
                new StreamReader(
                    "RESOURCES/SmallRating.json")
            )
            {
                string json = r.ReadToEnd();
                Reviews = JsonConvert.DeserializeObject<IEnumerable<Review>>(json);
            }
        }

        //opgave 1
        public int getReviews(int reviewId)
        {
            List<Review> reviews = new List<Review>();
            reviews = Reviews.Where(re => re.Reviewer == reviewId).ToList();
            return reviews.Count;
        }
        //opgave 2
        public double getAverigeRevive(int reviewId)
        {
            IEnumerable<Review> per = Reviews.Where(re => re.Reviewer == reviewId);
            var avg = per.Average(re => re.Grade);
            return avg;
        }
        //opgave 3
        public int GetCommenGrade(int reviwerId, int Grade)
        {
            int per = Reviews.Where(re => re.Reviewer == reviwerId && re.Grade == Grade).Count();
            return per;
        }
        //opgave 4
        public int getHowManyRatingsOnMovie(int movieId)
        {
            return Reviews.Count(m => m.Movie == movieId);
        }
        //opgave 5
        public double getAvgRatinOnMovie(int movieId)
        {
            IEnumerable<Review> per = Reviews.Where(mo => mo.Movie == movieId);
            var avg = per.Average(mo => mo.Grade);
            return avg;
        }
        //opgave 6
        public int getNumberOfGradeOnMovie(int MovieId, int Grade)
        {
            return Reviews.Count(g => g.Movie == MovieId && g.Grade == Grade);
        }
        
        /*opgave 7
         shut return a list of movies if the is more then one movie whit same number of 5 ratings.
         is still to be implemented
         */
        public int getMosTopRatedMovie()
        {
            IEnumerable<Review> TopMovis = Reviews.Where(g => g.Grade == 5);
            TopMovis.GroupBy(mo => mo.Movie).OrderByDescending(gru => gru.Count());
            var max =TopMovis.First().Movie;
            return max;
        }
        /*opgave 8
        shut return a list of reviewers if the is more then one reviewer whit same number of reviews.
        is still to be implemented
        */
        public int Topreviewer()
        {
           var topReviwer = Reviews.GroupBy(rw => rw.Reviewer).OrderByDescending(gb => gb.Count()).Select(gb => gb.Key).First();
           return topReviwer;
        }
        
        
    }
}


public class Review
{
    public int Reviewer { get; set; }
    public int Movie { get; set; }
    public int Grade { get; set; }
    public DateTime Date { get; set; }
}