using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM_Compulsory_Assignment;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ILogicHandler Logic = new LogicHandler("RESOURCES/ratings.json");
        
        [TestMethod]
        public void TestGetReviewsForTrue()
        {
            Assert.IsTrue(Logic.getReviews(1) == 3);
        }

        [TestMethod]
        public void TestGetReviewsForFalse()
        {
            Assert.IsFalse(Logic.getReviews(1) == 325);
        }

        [TestMethod]
        public void TestAvgTru()
        {
            Assert.IsTrue(Logic.getAverageReview(1) == 4.0);
        }
        
        [TestMethod]
        public void TestAvgFalsHig()
        {
            Assert.IsFalse(Logic.getAverageReview(1) == 5.1);
        }
        
        [TestMethod]
        public void TestAvgFalsLow()
        {
            Assert.IsFalse(Logic.getAverageReview(1) == 3.8);
        }

        [TestMethod]
        public void TestGetGradeXTru()
        {
            Assert.IsTrue(Logic.GetCommonGrade(3, 4)== 7);
        }
        
        [TestMethod]
        public void TestGetGradeXFalsLow()
        {
            Assert.IsFalse(Logic.GetCommonGrade(3, 4)== 4);
        }
        
        [TestMethod]
        public void TestGetGradeXFalsHige()
        {
            Assert.IsFalse(Logic.GetCommonGrade(3, 4)== 200);
        }

        [TestMethod]
        public void TestRatingsOnMovieTrue()
        {
            Assert.IsTrue(Logic.getHowManyRatingsOnMovie(123456) == 5);
        }
        
        [TestMethod]
        public void TestRatingsOnMovieFalsHige()
        {
            Assert.IsFalse(Logic.getHowManyRatingsOnMovie(123456) == 54);
        }
        [TestMethod]
        public void TestRatingsOnMovieFalsLow()
        {
            Assert.IsFalse(Logic.getHowManyRatingsOnMovie(123456) == 2);
        }

        [TestMethod]
        public void TestAvgMovieGradeTrue()
        {
            Assert.IsTrue(Logic.getAvgRatingOnMovie(123456)== 3.6);
        }
        
        [TestMethod]
        public void TestAvgMovieGradeFalsLow()
        {
            Assert.IsFalse(Logic.getAvgRatingOnMovie(123456)== 2.6);
        }
        
        [TestMethod]
        public void TestAvgMovieGradeFalsHige()
        {
            Assert.IsFalse(Logic.getAvgRatingOnMovie(123456)== 5.6);
        }

        [TestMethod]
        public void TestGradeNumberOfRatingsOnMovie()
        {
            Assert.IsTrue(Logic.getNumberOfGradesOnMovie(123456, 4) == 3);
        }
        
        [TestMethod]
        public void TestGradeNumberOfRatingsOnMovieFalsHige()
        {
            Assert.IsFalse(Logic.getNumberOfGradesOnMovie(123456, 4) == 16);
        }
        [TestMethod]
        public void TestGradeNumberOfRatingsOnMovieFalsLow()
        {
            Assert.IsFalse(Logic.getNumberOfGradesOnMovie(123456, 4) == 2);
        }
  
        [TestMethod]
        public void testTopMovie()
        {
            Assert.AreEqual(Logic.getMostTopRatedMovie(), 822109);
        }

        [TestMethod]
        public void testTopReviwer()
        {
            Assert.AreEqual(Logic.TopReviewer(), 999);
        }
    }
}