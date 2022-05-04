using Microsoft.VisualStudio.TestTools.UnitTesting;
using MIS218_FinalProject;

namespace TestsForFinal
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOne()
        {
            double f = 32;
            double c = 0;
            double tvalue = Convert.C2f(c);
            Assert.AreEqual(f, tvalue);
            Assert.AreEqual(100, Convert.F2c(212));
        }   

        [TestMethod]
        public void TestTwo()
        {
            Assert.AreEqual(212, Convert.C2f(100));
            Assert.AreEqual(122, Convert.C2f(50));
        }
    }
}
