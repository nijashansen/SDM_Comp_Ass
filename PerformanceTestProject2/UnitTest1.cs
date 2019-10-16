using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM_Compulsory_Assignment;

namespace PerformanceTestProject2
{
    [TestClass]
    public class UnitTest1
    {

        private LogicHandler _service;
        public UnitTest1()
        {
            _service = new LogicHandler(new repo("RESOURCES/ratings.json"));
        }

        private double getAvgTime(Action ac, int times)
        {
            double sum = 0.0;
            for (int i = 0; i < times; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ac.Invoke();
                sw.Stop();
                sum += sw.ElapsedMilliseconds;
            }
            return (sum / (double)times) / 1000.0;

        }



        
        

        [TestMethod]
        public void TestMethod1()
        {
            double avgTime = getAvgTime(() => _service.getAverageReview(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            double avgTime = getAvgTime(() => _service.GetCommonGrade(5, 5),5);
            Assert.IsTrue(avgTime < 4.0);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            double avgTime = getAvgTime(() => _service.getHowManyRatingsOnMovie(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            double avgTime = getAvgTime(() => _service.getAvgRatingOnMovie(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }
        
        [TestMethod]
        public void TestMethod5()
        {
            double avgTime = getAvgTime(() => _service.getNumberOfGradesOnMovie(5,5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            double avgTime = getAvgTime(() => _service.GetTopRatedMovie(), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        [TestMethod]
        public void TestMethod7()
        {
            double avgTime = getAvgTime(() => _service.TopReviewer(), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        [TestMethod]
        public void TestMethod8()
        {
            double avgTime = getAvgTime(() => _service.GetReviwedMoviesByReviewer(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        [TestMethod]
        public void TestMethod9()
        {
            double avgTime = getAvgTime(() => _service.GetReviewersByMovieId(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }


    }
}