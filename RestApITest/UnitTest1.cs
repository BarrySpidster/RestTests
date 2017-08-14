using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestApITest
{
   
    [TestClass]
    public class UnitTest1
    {

        private string pub_key = "https://yadi.sk/i/A5OdQPf73LtRqY";//скачиваемый ресурс
        private string fileInfoPath = "disk:/RestApITest.zip";

        [TestMethod]
        public void LastUploadedTest()
        {
            RestComands restcomands = new RestComands();
            Assert.IsTrue(restcomands.LastUploadedInfo());
        }

        [TestMethod]
        public void DownloadFileTest()
        {
            RestComands restcomands = new RestComands();
            Assert.IsTrue(restcomands.DownloadFile(pub_key));
        } 

        [TestMethod]
        public void FileInfoTest()
        {
            RestComands restcomands = new RestComands();
            Assert.IsTrue(restcomands.GetFileInfo(fileInfoPath));
        }
    }
}
