using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoxDemo;
using System.IO;
using System;

namespace CoxDemoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlphaOnly()
        {
            //arrange 
            var testString = "The quick brown fox jumped over the lazy red dog";
            var expectedResult = "T1e-q3k-b3n-f1x-j4d-o2r-t1e-l2y-r1d-d1g";
            
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            //act
            string[] inputArgs = new string[] { testString };
            Program.Main(inputArgs);
            

            Console.WriteLine(stringWriter.ToString());

            //Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[0]);

        }

        [TestMethod]
        public void MixedCharacters()
        {
            //arrange 
            var testString = "To3day should be a su-nny and wa3rm day";
            var expectedResult = "T0o3d1y-s4d-b0e-a-s0u-n1y-a1d-w0a3r0m-d1y";

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            //act
            string[] inputArgs = new string[] { testString };
            Program.Main(inputArgs);

            //Assert
            Assert.AreEqual(expectedResult, stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[0]);

        }


    }
}
