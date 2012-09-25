using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for SchedulerTest and is intended
    ///to contain all SchedulerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class SchedulerTest {


    private TestContext testContextInstance;
    private Owner owner = new Owner("Testuser");

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
    ///A test for AddJob
    ///</summary>
    [TestMethod()]
    public void AddJobTest() {
      Scheduler target = new Scheduler();
      Job job = new Job(owner, 6, 100);
      target.AddJob(job);
      Job job2 = target.PopJob();
      Assert.AreSame(job, job2);
    }

    /// <summary>
    ///A test for GetJobType
    ///</summary>
    [TestMethod()]
    public void GetJobTypeTest() {
      Dictionary<Job, Scheduler.JobType> testCases = new Dictionary<Job, Scheduler.JobType>();
      testCases.Add(new Job(owner, 6, 1), Scheduler.JobType.Short);
      testCases.Add(new Job(owner, 6, 29), Scheduler.JobType.Short);
      testCases.Add(new Job(owner, 6, 30), Scheduler.JobType.Long);
      testCases.Add(new Job(owner, 6, 119), Scheduler.JobType.Long);
      testCases.Add(new Job(owner, 6, 120), Scheduler.JobType.VeryLong);
      testCases.Add(new Job(owner, 6, int.MaxValue), Scheduler.JobType.VeryLong);
      foreach (Job test in testCases.Keys) {
        Scheduler.JobType actual = Scheduler.GetJobType(test);
        Assert.AreEqual(testCases[test], actual);
      }
    }

    /// <summary>
    /// Testing negative runtime values for GetJobType
    /// </summary>
    //[TestMethod]
    //[ExpectedException(typeof(ArgumentOutOfRangeException))]
    //public void GetJobTypeNegativeTest() {
      //Job test = new Job(owner, 6, -1);
      //Scheduler.JobType jobType = Scheduler.GetJobType(test);
    //}

    /// <summary>
    ///A test for PopJob
    ///</summary>
    [TestMethod()]
    public void PopJobTest() {
      Job job1 = new Job(owner, 6, 100);
      Job job2 = new Job(owner, 1, 26);
      Scheduler target = new Scheduler();
      target.AddJob(job1);
      System.Threading.Thread.Sleep(1);
      target.AddJob(job2);

      Job expected = job1;
      Job actual = target.PopJob();
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for RemoveJob
    ///</summary>
    [TestMethod()]
    public void RemoveJobTest() {
      Scheduler target = new Scheduler();
      Job job = new Job(owner, 4, 23);
      target.AddJob(job);
      target.RemoveJob(job);
      Assert.IsNull(target.PopJob());
    }

    /// <summary>
    ///A test for ToString
    ///</summary>
    [TestMethod()]
    public void ToStringTest() {
      Scheduler target = new Scheduler();
      Job job1 = new Job(owner, 3, 12);
      Job job2 = new Job(owner, 6, 11);
      Assert.IsInstanceOfType(target.ToString(), typeof(string));
    }
  }
}
