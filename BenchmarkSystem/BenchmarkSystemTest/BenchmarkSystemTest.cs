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
      target.ExecuteAll();
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for OnJobRemoved
    ///</summary>
    [TestMethod()]
    public void OnJobRemovedTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.OnJobRemoved(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for OnJobFailed
    ///</summary>
    [TestMethod()]
    public void OnJobFailedTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.OnJobFailed(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for OnJobRunning
    ///</summary>
    [TestMethod()]
    public void OnJobRunningTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.OnJobRunning(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for OnJobSubmitted
    ///</summary>
    [TestMethod()]
    public void OnJobSubmittedTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.OnJobSubmitted(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for OnJobTerminated
    ///</summary>
    [TestMethod()]
    public void OnJobTerminatedTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      Job job = null; // TODO: Initialize to an appropriate value
      target.OnJobTerminated(job);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for Status
    ///</summary>
    [TestMethod()]
    public void StatusTest() {
      BenchmarkSystem_Accessor target = new BenchmarkSystem_Accessor(); // TODO: Initialize to an appropriate value
      string expected = string.Empty; // TODO: Initialize to an appropriate value
      string actual;
      actual = target.Status();
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
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
  }
}
