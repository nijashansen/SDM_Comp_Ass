using System.Collections.Generic;

namespace SDM_Compulsory_Assignment
{
    public interface ILogicHandler
    {
        int getReviews(int reviewId);

        double getAverageReview(int reviewId);

        int GetCommonGrade(int reviwerId, int Grade);

        int getHowManyRatingsOnMovie(int movieId);

        double getAvgRatingOnMovie(int movieId);

        int getNumberOfGradesOnMovie(int MovieId, int Grade);
        
        int getMostTopRatedMovie();

        int TopReviewer();

        List<int> GetReviwedMoviesByReviewer(int reviewerId);

        List<int> GetReviewersByMovieId(int movieId);
    }
}