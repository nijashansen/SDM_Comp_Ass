using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM_Compulsory_Assignment;

namespace PerformanceTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private LogicHandler Logic = new LogicHandler(new repo("RESOURCES/SmallRating.json"));

        private double MAXTIME = 4;
        
        [TestMethod]
        public void TestMethod1()
        {
            Stopwatch sw = Stopwatch.StartNew();
           

            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            Stopwatch sw = Stopwatch.StartNew();
           
            Logic.getReviews(23);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Logic.GetCommonGrade(123, 5);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Logic.getNumberOfGradesOnMovie(52, 2);
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }
        
        [TestMethod]
        public void TestMethod5()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Logic.GetTopRatedMovie();
            sw.Stop();

            var seconds = sw.ElapsedMilliseconds / 1000.0;

            Assert.IsTrue(seconds <= MAXTIME);
        }
    }
}