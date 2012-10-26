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
      Job Job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      long Timestamp = 0; // TODO: Initialize to an appropriate value
      Activity target = new Activity(Job, State, Timestamp);
      Assert.Inconclusive("TODO: Implement code to verify target");
    }

    /// <summary>
    ///A test for DbState
    ///</summary>
    [TestMethod()]
    public void DbStateTest() {
      Job Job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      long Timestamp = 0; // TODO: Initialize to an appropriate value
      Activity target = new Activity(Job, State, Timestamp); // TODO: Initialize to an appropriate value
      int expected = 0; // TODO: Initialize to an appropriate value
      int actual;
      target.DbState = expected;
      actual = target.DbState;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for Job
    ///</summary>
    [TestMethod()]
    public void JobTest() {
      Job Job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      long Timestamp = 0; // TODO: Initialize to an appropriate value
      Activity target = new Activity(Job, State, Timestamp); // TODO: Initialize to an appropriate value
      Job expected = null; // TODO: Initialize to an appropriate value
      Job actual;
      target.Job = expected;
      actual = target.Job;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for State
    ///</summary>
    [TestMethod()]
    public void StateTest() {
      Job Job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      long Timestamp = 0; // TODO: Initialize to an appropriate value
      Activity target = new Activity(Job, State, Timestamp); // TODO: Initialize to an appropriate value
      Job.JobState expected = new Job.JobState(); // TODO: Initialize to an appropriate value
      Job.JobState actual;
      target.State = expected;
      actual = target.State;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for Timestamp
    ///</summary>
    [TestMethod()]
    public void TimestampTest() {
      Job Job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      long Timestamp = 0; // TODO: Initialize to an appropriate value
      Activity target = new Activity(Job, State, Timestamp); // TODO: Initialize to an appropriate value
      long expected = 0; // TODO: Initialize to an appropriate value
      long actual;
      target.Timestamp = expected;
      actual = target.Timestamp;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }
  }
}
