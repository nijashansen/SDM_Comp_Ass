using System.Collections.Generic;

namespace SDM_Compulsory_Assignment
{
    public interface ILogicHandler
    {
        int getReviews(int reviewId);

        double getAverigeRevive(int reviewId);

        int GetCommenGrade(int reviwerId, int Grade);

        int getHowManyRatingsOnMovie(int movieId);

        double getAvgRatinOnMovie(int movieId);

        int getNumberOfGradeOnMovie(int MovieId, int Grade);
    }
}