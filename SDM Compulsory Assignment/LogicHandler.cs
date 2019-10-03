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
            List<Review> reviews = Reviews.Where(re => re.Reviewer == reviewId).ToList();
            return reviews.Count;
        }
        //opgave 2
        public double getAverageReview(int reviewId)
        {
            IEnumerable<Review> per = Reviews.Where(re => re.Reviewer == reviewId);
            var avg = per.Average(re => re.Grade);
            return avg;
        }
        //opgave 3
        public int GetCommonGrade(int reviwerId, int Grade)
        {
            int per = Reviews.Count(re => re.Reviewer == reviwerId && re.Grade == Grade);
            return per;
        }
        //opgave 4
        public int getHowManyRatingsOnMovie(int movieId)
        {
            return Reviews.Count(m => m.Movie == movieId);
        }
        //opgave 5
        public double getAvgRatingOnMovie(int movieId)
        {
            IEnumerable<Review> per = Reviews.Where(mo => mo.Movie == movieId);
            var avg = per.Average(mo => mo.Grade);
            return avg;
        }
        //opgave 6
        public int getNumberOfGradesOnMovie(int MovieId, int Grade)
        {
            return Reviews.Count(g => g.Movie == MovieId && g.Grade == Grade);
        }
        
        /*opgave 7
         shut return a list of movies if the is more then one movie whit same number of 5 ratings.
         is still to be implemented
         */
        public int getMostTopRatedMovie()
        {
            IEnumerable<Review> topMovies = Reviews.Where(g => g.Grade == 5);
            topMovies.GroupBy(mo => mo.Movie)
                .OrderByDescending(gru => gru.Count());
            var max = topMovies.First().Movie;
            return max;
        }
        /*opgave 8
        shut return a list of reviewers if the is more then one reviewer whit same number of reviews.
        is still to be implemented
        */
        public int TopReviewer()
        {
           var topReviwer = Reviews.GroupBy(rw => rw.Reviewer)
               .OrderByDescending(gb => gb.Count()).Select(gb => gb.Key)
               .First();
           return topReviwer;
        }
        
        /**
         * Opgave 9 er ikke til at forstå
         */
        
        /**
         * opgave 10
         * har ikke kunne teste, men den skulle virke :P 
         */
        public List<int> GetReviwedMoviesByReviewer(int reviewerId)
        {
            var revs = Reviews.Where(mo => mo.Reviewer == reviewerId)
                .OrderByDescending(g => g.Grade)
                .ThenBy(d => d.Date).ToArray();
            
            List<int> movies = new List<int>();
            foreach (var movie in revs)
            {
                movies.Add(movie.Movie);
            }

            return movies;
        }
        
        /**
         * Opgave 11
         * Har ikke kunne test, men skulle virke :P 
         */
        public List<int> GetReviewersByMovieId(int movieId)
        {
            var revs = Reviews.Where(mo => mo.Movie == movieId)
                .OrderByDescending(g => g.Grade)
                .OrderBy(d => d.Date).ToList();

            
            List<int> reviwers = new List<int>();
            foreach (var reviewer in revs)
            {
                reviwers.Add(reviewer.Reviewer);
            }

            return reviwers;
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