using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{   
    /// <summary>
    ///This is a test class for BenchmarkSystemTest and is intended
    ///to contain all BenchmarkSystemTest Unit Tests
    ///</summary>
  [TestClass()]
  public class BenchmarkSystemTest {
    bool EventCalledBool = false;

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
    ///A test for Remove
    ///</summary>
    [TestMethod()]
    public void RemoveTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      Job job = new Job(owner, 3, 767);
      Job job2 = new Job(owner, 4, 2);
      target.Submit(job);
      target.Submit(job2);
      target.Remove(job);
      Assert.IsTrue(!target.Contains(job));
    }

    /// <summary>
    ///A test for ExecuteAll
    ///</summary>
    [TestMethod()]
    public void ExecuteAllTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job1 = new Job(owner, 2, 20);
      Job job2 = new Job(owner, 4, 40);
      Job job3 = new Job(owner, 6, 60);
      Job job4 = new Job(owner, 5, 80);
      Job job5 = new Job(owner, 3, 100);
      target.Submit(job1);
      target.Submit(job2);
      target.Submit(job3);
      target.Submit(job4);
      target.Submit(job5);
      target.ExecuteAll();
      Assert.AreEqual((uint)0, target.TotalNumberOfJobs());
    }

    /// <summary>
    ///A test for OnJobRemoved
    ///</summary>
    [TestMethod()]
    public void OnJobRemovedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobRemoved += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobQueued(job);
      Assert.IsTrue(EventCalledBool);
      EventCalledBool = false;
    }

    /// <summary>
    ///A test for OnJobFailed
    ///</summary>
    [TestMethod()]
    public void OnJobFailedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobFailed += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobQueued(job);
      Assert.IsTrue(EventCalledBool);
      EventCalledBool = false;
    }

    /// <summary>
    ///A test for OnJobRunning
    ///</summary>
    [TestMethod()]
    public void OnJobRunningTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobStarted += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobQueued(job);
      Assert.IsTrue(EventCalledBool);
      EventCalledBool = false;
    }

    /// <summary>
    ///A test for OnJobQueued
    ///</summary>
    [TestMethod()]
    public void OnJobQueuedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobQueued += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobQueued(job);
      Assert.IsTrue(EventCalledBool);
      EventCalledBool = false;
    }

    /// <summary>
    ///A test for OnJobTerminated
    ///</summary>
    [TestMethod()]
    public void OnJobTerminatedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobTerminated += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobTerminated(job);
      Assert.IsTrue(EventCalledBool);
      EventCalledBool = false;
    }

    /// <summary>
    ///A test for Submit
    ///</summary>
    [TestMethod()]
    public void SubmitTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      Job job = new Job(null, 1, 1);
      target.Queued(job);
      Assert.IsTrue(target.Contains(job));
    }

    /// <summary>
    /// Does the event 
    /// </summary>
    [TestMethod()]
    public void QueuedTest() {
    }

    /// <summary>
    /// Did we receive an event?
    /// Remember to set EventCalledBool = false after this method call
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void EventCalled(object sender, JobEventArgs e) {
      Console.WriteLine("Event: " + e.ToString());
      EventCalledBool = true;
    }
  }
}
