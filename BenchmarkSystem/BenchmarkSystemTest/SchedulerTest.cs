using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for SchedulerTest and is intended
    ///to contain all SchedulerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class SchedulerTest {


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
    ///A test for Scheduler Constructor
    ///</summary>
    [TestMethod()]
    public void SchedulerConstructorTest() {
      Scheduler target = new Scheduler();
      Scheduler_Accessor targetAccess = new Scheduler_Accessor();
      Assert.AreEqual(targetAccess.jobs.Count, Enum.GetValues(typeof(Scheduler.JobType)).Length);
    }

    /// <summary>
    ///A test for AddJob
    ///</summary>
    [TestMethod()]
    public void AddJobTest() {
      Scheduler target = new Scheduler(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.AddJob(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for GetJobType
    ///</summary>
    [TestMethod()]
    public void GetJobTypeTest() {
      Job job = null; // TODO: Initialize to an appropriate value
      Scheduler.JobType expected = new Scheduler.JobType(); // TODO: Initialize to an appropriate value
      Scheduler.JobType actual;
      actual = Scheduler.GetJobType(job);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for PopJob
    ///</summary>
    [TestMethod()]
    public void PopJobTest() {
      Scheduler target = new Scheduler(); // TODO: Initialize to an appropriate value
      Job expected = null; // TODO: Initialize to an appropriate value
      Job actual;
      actual = target.PopJob();
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for RemoveJob
    ///</summary>
    [TestMethod()]
    public void RemoveJobTest() {
      Scheduler target = new Scheduler(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.RemoveJob(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for ToString
    ///</summary>
    [TestMethod()]
    public void ToStringTest() {
      Scheduler target = new Scheduler(); // TODO: Initialize to an appropriate value
      string expected = string.Empty; // TODO: Initialize to an appropriate value
      string actual;
      actual = target.ToString();
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }
  }
}
