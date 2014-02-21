using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCoupes()
        {
            ServiceReference1.ServiceQuiddichClient client = new ServiceReference1.ServiceQuiddichClient();
            var coupes = client.GetAllCoupes();
        }
    }
}
