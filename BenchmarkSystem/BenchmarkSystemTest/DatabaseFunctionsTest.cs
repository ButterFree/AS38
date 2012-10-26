using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for DatabaseFunctionsTest and is intended
    ///to contain all DatabaseFunctionsTest Unit Tests
    ///</summary>
  [TestClass()]
  public class DatabaseFunctionsTest {


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
    ///A test for GetAllUsers
    ///</summary>
    [TestMethod()]
    public void GetAllUsersTest() {
      IList<Owner> expected = null; // TODO: Initialize to an appropriate value
      IList<Owner> actual;
      actual = DatabaseFunctions.GetAllUsers();
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetGroupedJobs
    ///</summary>
    [TestMethod()]
    public void GetGroupedJobsTest() {
      uint StartTimestamp = 0; // TODO: Initialize to an appropriate value
      uint EndTimestamp = 0; // TODO: Initialize to an appropriate value
      IDictionary<Job.JobState, IList<Job>> expected = null; // TODO: Initialize to an appropriate value
      IDictionary<Job.JobState, IList<Job>> actual;
      actual = DatabaseFunctions.GetGroupedJobs(StartTimestamp, EndTimestamp);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetGroupedJobs
    ///</summary>
    [TestMethod()]
    public void GetGroupedJobsTest1() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      uint StartTimestamp = 0; // TODO: Initialize to an appropriate value
      uint EndTimestamp = 0; // TODO: Initialize to an appropriate value
      IDictionary<Job.JobState, IList<Job>> expected = null; // TODO: Initialize to an appropriate value
      IDictionary<Job.JobState, IList<Job>> actual;
      actual = DatabaseFunctions.GetGroupedJobs(owner, StartTimestamp, EndTimestamp);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest() {
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      IList<Job> expected = null; // TODO: Initialize to an appropriate value
      IList<Job> actual;
      actual = DatabaseFunctions.GetJobs(State);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest1() {
      Scheduler.JobType type = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      IList<Job> expected = null; // TODO: Initialize to an appropriate value
      IList<Job> actual;
      actual = DatabaseFunctions.GetJobs(type, State);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest2() {
      Owner User = null; // TODO: Initialize to an appropriate value
      IList<Job> expected = null; // TODO: Initialize to an appropriate value
      IList<Job> actual;
      actual = DatabaseFunctions.GetJobs(User);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest3() {
      Owner User = null; // TODO: Initialize to an appropriate value
      uint DaysAgoMax = 0; // TODO: Initialize to an appropriate value
      IList<Job> expected = null; // TODO: Initialize to an appropriate value
      IList<Job> actual;
      actual = DatabaseFunctions.GetJobs(User, DaysAgoMax);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobs
    ///</summary>
    [TestMethod()]
    public void GetJobsTest4() {
      Owner User = null; // TODO: Initialize to an appropriate value
      uint StartTimestamp = 0; // TODO: Initialize to an appropriate value
      uint EndTimestamp = 0; // TODO: Initialize to an appropriate value
      IList<Job> expected = null; // TODO: Initialize to an appropriate value
      IList<Job> actual;
      actual = DatabaseFunctions.GetJobs(User, StartTimestamp, EndTimestamp);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for GetJobstate
    ///</summary>
    [TestMethod()]
    public void GetJobstateTest() {
      Job job = null; // TODO: Initialize to an appropriate value
      Job.JobState expected = new Job.JobState(); // TODO: Initialize to an appropriate value
      Job.JobState actual;
      actual = DatabaseFunctions.GetJobstate(job);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for JobExists
    ///</summary>
    [TestMethod()]
    public void JobExistsTest() {
      Job job = null; // TODO: Initialize to an appropriate value
      Job.JobState State = new Job.JobState(); // TODO: Initialize to an appropriate value
      bool expected = false; // TODO: Initialize to an appropriate value
      bool actual;
      actual = DatabaseFunctions.JobExists(job, State);
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }
  }
}
