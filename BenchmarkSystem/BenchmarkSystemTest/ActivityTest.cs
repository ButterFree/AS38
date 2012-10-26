using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for ActivityTest and is intended
    ///to contain all ActivityTest Unit Tests
    ///</summary>
  [TestClass()]
  public class ActivityTest {


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
    ///A test for Activity Constructor
    ///</summary>
    [TestMethod()]
    public void ActivityConstructorTest() {
      Owner owner = new Owner("Activity Testowner");
      Job job = new Job("Activity Testjob", owner, 5, 3);
      Job.JobState state = Job.JobState.Queued;
      long timestamp = System.DateTime.Now.Ticks;
      Activity ac = new Activity(job, state, timestamp);
      Assert.AreEqual(job, ac.Job);
      Assert.AreEqual(state, ac.State);
      Assert.AreEqual((int)state, ac.DbState);
      Assert.AreEqual(timestamp, ac.Timestamp);
    }

    /// <summary>
    ///A test for DbState
    ///</summary>
    [TestMethod()]
    public void DbStateTest() {
      Activity ac = new Activity(null, Job.JobState.Failed, 0);
      ac.State = Job.JobState.Succesfull;
      Assert.AreEqual((int)Job.JobState.Succesfull, ac.DbState);
    }
  }
}
