using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SDM_Compulsory_Assignment
{
    public class LogicHandler : ILogicHandler
    {
        private repo _repo;

        public LogicHandler(repo repo)
        {
            _repo = repo;
        }

       

      

        //opgave 1
        public int getReviews(int reviewId)
        {
            return _repo.GetMovieReviews().Where(r => r.Reviewer == reviewId).Count();
        }

        //opgave 2
        public double getAverageReview(int reviewId)
        {
            List<Review> list = _repo.GetMovieReviews().Where(r => r.Reviewer == reviewId).ToList();
            double Sum = 0;
            foreach (var item in list)
            {
                Sum += item.Grade;
            }
            return Sum / list.Count();
        }
        //opgave 3
        public int GetCommonGrade(int reviwerId, int Grade)
        {
            return _repo.GetMovieReviews().Where(r => r.Reviewer == reviwerId).Where(r => r.Grade == Grade).Count();
        }
        //opgave 4
        public int getHowManyRatingsOnMovie(int movieId)
        {
            return _repo.GetMovieReviews().Count(m => m.Movie == movieId);
        }
        //opgave 5
        public double getAvgRatingOnMovie(int movieId)
        {
            List<Review> list = _repo.GetMovieReviews().Where(mr => mr.Movie == movieId).ToList();
            double gradeSum = 0;
            foreach (var item in list)
            {
                gradeSum += item.Grade;
            }
            return gradeSum / list.Count();
        }
        //opgave 6
        public int getNumberOfGradesOnMovie(int MovieId, int Grade)
        {
            return _repo.GetMovieReviews().Count(g => g.Movie == MovieId && g.Grade == Grade);
        }
        
        /*opgave 7
         shut return a list of movies if the is more then one movie whit same number of 5 ratings.
         is still to be implemented
         */
        public int[] GetTopRatedMovie()
        {
            var list = _repo.GetMovieReviews().Where(m => m.Grade == 5).GroupBy(m => m.Movie).OrderByDescending(g => g.Count()).AsEnumerable();
            var count = list.First().Count();

            var temp = list.Where(g => g.Count() == count).ToList();

            int[] arr = new int[temp.Count()];
            int i = 0;
            foreach (var item in temp)
            {
                arr[i] = item.First().Movie;
               i++;
            }

            return arr;

        }

        /*opgave 8
        shut return a list of reviewers if the is more then one reviewer whit same number of reviews.
        is still to be implemented
        */
        public int[] TopReviewer()
        {
            var list = _repo.GetMovieReviews().GroupBy(m => m.Reviewer).OrderByDescending(g => g.Count()).AsEnumerable();
            int count = list.First().Count();

            var temp = list.Where(g => g.Count() == count).ToList();

            int[] result = new int[temp.Count()];
            int i = 0;
            foreach (var item in temp)
            {
                result[i] = item.First().Reviewer;
                i++;
            }
            return result;
        }
        
        /**
         * Opgave 9 er ikke til at forstå
         */
        
        /**
         * opgave 10
         * har ikke kunne teste, men den skulle virke :P 
         */
        public int[] GetReviwedMoviesByReviewer(int reviewerId)
        {
           int[] byReviewer = _repo.GetMovieReviews().Where(m => m.Reviewer == reviewerId).OrderByDescending(m => m.Grade).ThenByDescending(mr => mr.Date).Select(mr => mr.Movie).ToArray();
           return byReviewer;
        }
        
        /**
         * Opgave 11
         * Har ikke kunne test, men skulle virke :P 
         */
        public List<int> GetReviewersByMovieId(int movieId)
        {
            var revs = _repo.GetMovieReviews().Where(mo => mo.Movie == movieId)
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