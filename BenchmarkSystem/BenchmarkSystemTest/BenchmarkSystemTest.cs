using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest {
  /// <summary>
  ///This is a test class for BenchmarkSystemTest and is intended
  ///to contain all BenchmarkSystemTest Unit Tests
  ///</summary>
  [TestClass()]
  public class BenchmarkSystemTest {
    bool EventCalledBool = false;
    JobEventArgs.EventType eventType;

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
      target.OnJobRemoved(job);
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobRemoved, eventType);
      EventCalledBool = false;
      target.JobRemoved -= new EventHandler<JobEventArgs>(EventCalled);
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
      target.OnJobFailed(job, new Exception("Test exception"));
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobFailed, eventType);
      EventCalledBool = false;
      target.JobFailed -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    ///A test for OnJobRunning
    ///</summary>
    [TestMethod()]
    public void OnJobStartedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobStarted += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.OnJobStarted(job);
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobStarted, eventType);
      EventCalledBool = false;
      target.JobStarted -= new EventHandler<JobEventArgs>(EventCalled);
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
      Assert.AreEqual(JobEventArgs.EventType.JobQueued, eventType);
      EventCalledBool = false;
      target.JobQueued -= new EventHandler<JobEventArgs>(EventCalled);
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
      Assert.AreEqual(JobEventArgs.EventType.JobTerminated, eventType);
      EventCalledBool = false;
      target.JobTerminated -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    ///A test for Submit
    ///</summary>
    [TestMethod()]
    public void SubmitTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      Job job = new Job(null, 1, 1);
      target.Submit(job);
      Assert.IsTrue(target.Contains(job));
    }

    /// <summary>
    /// Does the correct event get called by the correct trigger
    /// </summary>
    [TestMethod()]
    public void QueuedTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobQueued += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      EventCalledBool = false;
      target.Submit(job);
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobQueued, eventType);
      EventCalledBool = false;
      target.JobQueued -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    /// Does the correct event get called by the correct trigger
    /// </summary>
    [TestMethod()]
    public void RemovedTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobRemoved += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.Submit(job);
      EventCalledBool = false;
      target.Remove(job);
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobRemoved, eventType);
      EventCalledBool = false;
      target.JobRemoved -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    /// Does the correct event get called by the correct trigger
    /// </summary>
    [TestMethod()]
    public void StartedTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobStarted += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      target.Submit(job);
      EventCalledBool = false;
      target.ExecuteAll();
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobStarted, eventType);
      EventCalledBool = false;
      target.JobStarted -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    /// Does the correct event get called by the correct trigger
    /// </summary>
    [TestMethod()]
    public void TerminatedTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobTerminated += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      job.process = (a) => {
        return "";
      };
      target.Submit(job);
      EventCalledBool = false;
      target.ExecuteAll();
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobTerminated, eventType);
      EventCalledBool = false;
      target.JobTerminated -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    /// Does the correct event get called by the correct trigger
    /// </summary>
    [TestMethod()]
    public void FailedTest() {
      EventCalledBool = false;
      BenchmarkSystem target = BenchmarkSystem.instance;
      target.JobFailed += new EventHandler<JobEventArgs>(EventCalled);
      Job job = new Job(null, 1, 1);
      job.process = (a) => {
        throw new Exception("Test exception");
      };
      target.Submit(job);
      target.ExecuteAll();
      Assert.IsTrue(EventCalledBool);
      Assert.AreEqual(JobEventArgs.EventType.JobFailed, eventType);
      EventCalledBool = false;
      target.JobFailed -= new EventHandler<JobEventArgs>(EventCalled);
    }

    /// <summary>
    /// Test the Contains-method
    /// </summary>
    [TestMethod()]
    public void ContainsTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;

      // Add jobs and assert
      uint max = 10;
      Job[] jobs = new Job[max];
      for (uint i = 1; i <= max; i++) {
        Job job = new Job(null, 1, i);
        jobs[i - 1] = job;
        target.Submit(job);
        Assert.IsTrue(target.Contains(job));
      }
      // Remove jobs and assert
      for (uint i = max - 1; i > 0; i--) {
        target.Remove(jobs[i]);
        Assert.IsFalse(target.Contains(jobs[i]));
      }
    }

    /// <summary>
    /// Test TotalNumberOfJobs()
    /// </summary>
    [TestMethod()]
    public void TotalNumberOfJobsTest() {
      BenchmarkSystem target = BenchmarkSystem.instance;
      // Empty queues
      target.ExecuteAll();

      // Add jobs and assert
      uint max = 10;
      Job[] jobs = new Job[max];
      Assert.AreEqual((uint)0, target.TotalNumberOfJobs());
      for (uint i = 1; i <= max; i++) {
        Job job = new Job(null, 1, i);
        jobs[i - 1] = job;
        target.Submit(job);
        Assert.AreEqual(i, target.TotalNumberOfJobs());
      }

      // Remove jobs and assert
      for (uint i = max - 1; i > 0; i--) {
        target.Remove(jobs[i]);
        Assert.AreEqual(i, target.TotalNumberOfJobs());
      }
    }

    /// <summary>
    /// Did we receive an event?
    /// Remember to set EventCalledBool = false after this method call
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void EventCalled(object sender, JobEventArgs e) {
      eventType = e.eventType;
      EventCalledBool = true;
    }
  }
}
