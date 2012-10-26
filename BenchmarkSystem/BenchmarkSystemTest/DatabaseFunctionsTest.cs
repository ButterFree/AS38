using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BenchmarkSystemTest {


  /// <summary>
  ///This is a test class for DatabaseFunctionsTest and is intended
  ///to contain all DatabaseFunctionsTest Unit Tests
  ///</summary>
  [TestClass()]
  public class DatabaseFunctionsTest {


    private TestContext testContextInstance;
    static Owner owner1, owner2;
    static Job j1, j2, j3, j4, j5, j6, j7, j8, j9, j10;
    static long timestampStart, timestampEnd;

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

    [TestInitialize]
    public void TestInitialize() {
      BenchmarkSystem bs = BenchmarkSystem.instance;
      BenchmarkSystem.db = null;
      owner1 = new Owner("DatabaseFunctions Owner1");
      owner2 = new Owner("DatabaseFunctions Owner2");
      j1 = new Job("DatabaseFunctions Job1", owner1, 4, (float)0.39919712943919); //Short
      j2 = new Job("DatabaseFunctions Job2", owner2, 9, (float)2.6312117980473);  //Very long
      j3 = new Job("DatabaseFunctions Job3", owner2, 7, (float)4.7457466516857);  //Very long
      j4 = new Job("DatabaseFunctions Job4", owner1, 8, (float)3.7855014080114);  //Very long
      j5 = new Job("DatabaseFunctions Job5", owner1, 2, (float)1.0786302726616);  //Long
      j6 = new Job("DatabaseFunctions Job6", owner2, 6, (float)4.3559041917584);  //Very long
      j7 = new Job("DatabaseFunctions Job7", owner1, 1, (float)2.0657835664068);  //Very long
      j8 = new Job("DatabaseFunctions Job8", owner1, 3, (float)2.2463377728808);  //Very long
      j9 = new Job("DatabaseFunctions Job9", owner2, 4, (float)2.0612939639768);  //Very long
      j10 = new Job("DatabaseFunctions Job10", owner2, 5, (float)4.1729730872777);//Very long
      timestampStart = System.DateTime.Now.Ticks;
      bs.Submit(j1);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j2);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j3);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j4);
      System.DateTime newTimestamp = System.DateTime.Now;
      newTimestamp = newTimestamp.AddDays(-2);
      j4.timestamp = newTimestamp.Ticks;
      BenchmarkSystem.db.SaveChanges();
      System.Threading.Thread.Sleep(1);
      bs.Submit(j5);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j6);
      j6.State = Job.JobState.Failed;
      timestampEnd = System.DateTime.Now.Ticks;
      System.Threading.Thread.Sleep(1);
      bs.Submit(j7);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j8);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j9);
      System.Threading.Thread.Sleep(1);
      bs.Submit(j10);
      System.Threading.Thread.Sleep(1);
    }


    /// <summary>
    ///A test for GetAllUsers
    ///</summary>
    [TestMethod()]
    public void GetAllUsersTest() {
      IList<Owner> result = DatabaseFunctions.GetAllUsers();
      Assert.IsTrue(result.Contains(owner1));
      Assert.IsTrue(result.Contains(owner2));
    }

    /// <summary>
    ///A test for GetGroupedJobs
    ///</summary>
    [TestMethod()]
    public void GetGroupedJobsTest() {
      IDictionary<Job.JobState, IList<Job>> result = DatabaseFunctions.GetGroupedJobs(timestampStart, timestampEnd);
      foreach (Job.JobState type in Enum.GetValues(typeof(Job.JobState))) {
        Assert.IsTrue(result.ContainsKey(type));
      }
      Assert.AreEqual(4, result[Job.JobState.Queued].Count);
      Assert.AreEqual(1, result[Job.JobState.Failed].Count);
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j1));
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j2));
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j3));
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j5));
      Assert.IsTrue(result[Job.JobState.Failed].Contains(j6));
    }

    /// <summary>
    ///A test for GetGroupedJobs
    ///</summary>
    [TestMethod()]
    public void GetGroupedJobsTest1() {
      IDictionary<Job.JobState, IList<Job>> result = DatabaseFunctions.GetGroupedJobs(owner2, timestampStart, timestampEnd);
      foreach (Job.JobState type in Enum.GetValues(typeof(Job.JobState))) {
        Assert.IsTrue(result.ContainsKey(type));
      }
      Assert.AreEqual(2, result[Job.JobState.Queued].Count);
      Assert.AreEqual(1, result[Job.JobState.Failed].Count);
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j2));
      Assert.IsTrue(result[Job.JobState.Queued].Contains(j3));
      Assert.IsTrue(result[Job.JobState.Failed].Contains(j6));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest() {
      IList<Job> result = DatabaseFunctions.GetJobs(owner1);
      Assert.AreEqual(5, result.Count);
      Assert.IsTrue(result.Contains(j1));
      Assert.IsTrue(result.Contains(j4));
      Assert.IsTrue(result.Contains(j5));
      Assert.IsTrue(result.Contains(j7));
      Assert.IsTrue(result.Contains(j8));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest1_1() {
      IList<Job> result = DatabaseFunctions.GetJobs(Scheduler.JobType.Short, Job.JobState.Queued);
      Assert.AreEqual(1, result.Count);
      Assert.IsTrue(result.Contains(j1));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest1_2() {
      IList<Job> result = DatabaseFunctions.GetJobs(Scheduler.JobType.Long, Job.JobState.Queued);
      Assert.AreEqual(1, result.Count);
      Assert.IsTrue(result.Contains(j5));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest1_3() {
      IList<Job> result = DatabaseFunctions.GetJobs(Scheduler.JobType.VeryLong, Job.JobState.Queued);
      Assert.AreEqual(7, result.Count);
      Assert.IsTrue(result.Contains(j2));
      Assert.IsTrue(result.Contains(j3));
      Assert.IsTrue(result.Contains(j4));
      Assert.IsTrue(result.Contains(j7));
      Assert.IsTrue(result.Contains(j8));
      Assert.IsTrue(result.Contains(j9));
      Assert.IsTrue(result.Contains(j10));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest1_4() {
      IList<Job> result = DatabaseFunctions.GetJobs(Scheduler.JobType.VeryLong, Job.JobState.Failed);
      Assert.AreEqual(1, result.Count);
      Assert.IsTrue(result.Contains(j6));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest2() {
      IList<Job> result = DatabaseFunctions.GetJobs(owner1, 1);
      Assert.AreEqual(4, result.Count);
      Assert.IsTrue(result.Contains(j1));
      Assert.IsTrue(result.Contains(j5));
      Assert.IsTrue(result.Contains(j7));
      Assert.IsTrue(result.Contains(j8));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest3() {
      IList<Job> result = DatabaseFunctions.GetJobs(owner1, timestampStart, timestampEnd);
      Assert.AreEqual(2, result.Count);
      Assert.IsTrue(result.Contains(j1));
      Assert.IsTrue(result.Contains(j5));
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest4() {
      IList<Job> result = DatabaseFunctions.GetJobs(Job.JobState.Failed);
      Assert.AreEqual(1, result.Count);
      Assert.IsTrue(result.Contains(j6));
    }

    /// <summary>
    ///A test for JobExists
    ///</summary>
    [TestMethod()]
    public void JobExistsTest() {
      Assert.IsTrue(DatabaseFunctions.JobExists(j1, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j2, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j3, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j4, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j5, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j6, Job.JobState.Failed));
      Assert.IsTrue(DatabaseFunctions.JobExists(j7, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j8, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j9, Job.JobState.Queued));
      Assert.IsTrue(DatabaseFunctions.JobExists(j10, Job.JobState.Queued));
    }
  }
}
