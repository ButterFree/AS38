using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BenchmarkSystemTest {


  /// <summary>
  ///This is a test class for SchedulerTest and is intended
  ///to contain all SchedulerTest Unit Tests
  ///</summary>
  [TestClass()]
  public class SchedulerTest {


    private TestContext testContextInstance;
    private Owner owner = new Owner("Testuser");
    private JobContext db = new JobContext();

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
      Scheduler target = new Scheduler(db);
      Job job = new Job(owner, 6, 100);
      target.AddJob(job);
      Job job2 = target.PopJob(30);
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
    ///A test for PopJob
    ///</summary>
    [TestMethod()]
    public void PopJobTest() {
      Job job1 = new Job(owner, 6, 100);
      Job job2 = new Job(owner, 1, 26);
      Scheduler target = new Scheduler(db);
      target.AddJob(job1);
      System.Threading.Thread.Sleep(1);
      target.AddJob(job2);

      Job expected = job1;
      Job actual = target.PopJob(30);
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for RemoveJob
    ///</summary>
    [TestMethod()]
    public void RemoveJobTest() {
      Scheduler target = new Scheduler(db);
      Job job = new Job(owner, 4, 23);
      target.AddJob(job);
      target.RemoveJob(job);
      Assert.IsNull(target.PopJob(30));
    }

    /// <summary>
    ///A test for ToString
    ///</summary>
    [TestMethod()]
    public void ToStringTest() {
      Scheduler target = new Scheduler(db);
      Job job1 = new Job(owner, 3, 12);
      Job job2 = new Job(owner, 6, 11);
      Assert.IsInstanceOfType(target.ToString(), typeof(string));
    }

    /// <summary>
    /// Test the Contains-method
    /// </summary>
    [TestMethod()]
    public void ContainsTest() {
      Scheduler target = new Scheduler(db);

      // Add jobs and assert
      uint max = 10;
      Job[] jobs = new Job[max];
      for (uint i = 1; i <= max; i++) {
        Job job = new Job(null, 1, i);
        jobs[i - 1] = job;
        target.AddJob(job);
        Assert.IsTrue(target.Contains(job));
      }
      // Remove jobs and assert
      for (uint i = max - 1; i > 0; i--) {
        target.RemoveJob(jobs[i]);
        Assert.IsFalse(target.Contains(jobs[i]));
      }
    }

    /// <summary>
    /// Test TotalNumberOfJobs()
    /// </summary>
    [TestMethod()]
    public void TotalNumberOfJobsTest() {
      Scheduler target = new Scheduler(db);

      // Add jobs and assert
      uint max = 10;
      Job[] jobs = new Job[max];
      Assert.AreEqual((uint)0, target.TotalNumberOfJobs());
      for (uint i = 1; i <= max; i++) {
        Job job = new Job(null, 1, i);
        jobs[i - 1] = job;
        target.AddJob(job);
        Assert.AreEqual(i, target.TotalNumberOfJobs());
      }

      // Remove jobs and assert
      for (uint i = max - 1; i > 0; i--) {
        target.RemoveJob(jobs[i]);
        Assert.AreEqual(i, target.TotalNumberOfJobs());
      }
    }
  }
}
