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
                    "C:/Users/Nijas Hansen/source/repos/SDM_Compulsory_Assignment1/SDM Compulsory Assignment/RESOURCES/SmallRating.json")
            )
            {
                string json = r.ReadToEnd();
                Reviews = JsonConvert.DeserializeObject<IEnumerable<Review>>(json);
            }
        }

        public int getReviews(int reviewId)
        {
            List<Review> reviews = new List<Review>();
            reviews = Reviews.Where(re => re.Reviewer == reviewId).ToList();
            return reviews.Count;
        }

        public double getAverigeRevive(int reviewId)
        {
            IEnumerable<Review> per = Reviews.Where(re => re.Reviewer == reviewId);
            var avg = per.Average(re => re.Grade);
            return avg;
        }

        public int GetCommenGrade(int reviwerId, int Grade)
        {
            int per = Reviews.Where(re => re.Reviewer == reviwerId && re.Grade == Grade).Count();
            return per;
        }

        public int getHowManyRatingsOnMovie(int movieId)
        {
            return Reviews.Where(m => m.Movie == movieId).Count();
        }

        public double getAvgRatinOnMovie(int movieId)
        {
            IEnumerable<Review> per = Reviews.Where(mo => mo.Movie == movieId);
            var avg = per.Average(mo => mo.Grade);
            return avg;
        }

        public int getNumberOfGradeOnMovie(int MovieId, int Grade)
        {
            return Reviews.Where(g => g.Movie == MovieId && g.Grade == Grade).Count();
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