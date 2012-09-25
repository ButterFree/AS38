using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for OwnerTest and is intended
    ///to contain all OwnerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class OwnerTest {


    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext {
      get {
        return testContextInstance;
      }
      set {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for Owner Constructor
    ///</summary>
    [TestMethod()]
    public void OwnerConstructorTest() {
      string Name = string.Empty; // TODO: Initialize to an appropriate value
      Owner target = new Owner(Name);
      Assert.Inconclusive("TODO: Implement code to verify target");
    }

    /// <summary>
    ///A test for Name
    ///</summary>
    [TestMethod()]
    public void NameTest() {
      string Name = string.Empty; // TODO: Initialize to an appropriate value
      Owner target = new Owner(Name); // TODO: Initialize to an appropriate value
      string expected = string.Empty; // TODO: Initialize to an appropriate value
      string actual;
      target.Name = expected;
      actual = target.Name;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }
  }
}
