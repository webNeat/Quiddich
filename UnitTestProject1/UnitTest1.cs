using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCoupes()
        {
            ServiceReference1.ServiceQuiddichClient client = new ServiceReference1.ServiceQuiddichClient();
            IList<ServiceReference1.CoupeWS> coupes = client.GetAllCoupes();
            Assert.AreEqual(2011, coupes[0].Year);
        }
    }
}
