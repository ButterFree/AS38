using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for LoggerTest and is intended
    ///to contain all LoggerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class LoggerTest {


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
    ///A test for Logger Constructor
    ///</summary>
    [TestMethod()]
    public void LoggerConstructorTest() {
      BenchmarkSystem benchmarkSystem = null; // TODO: Initialize to an appropriate value
      Logger target = new Logger(benchmarkSystem);
      Assert.Inconclusive("TODO: Implement code to verify target");
    }

    /// <summary>
    ///A test for benchmarkSystem_JobCancelled
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void benchmarkSystem_JobCancelledTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Logger_Accessor target = new Logger_Accessor(param0); // TODO: Initialize to an appropriate value
      object sender = null; // TODO: Initialize to an appropriate value
      JobEventArgs e = null; // TODO: Initialize to an appropriate value
      target.benchmarkSystem_JobCancelled(sender, e);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for benchmarkSystem_JobFailed
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void benchmarkSystem_JobFailedTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Logger_Accessor target = new Logger_Accessor(param0); // TODO: Initialize to an appropriate value
      object sender = null; // TODO: Initialize to an appropriate value
      JobEventArgs e = null; // TODO: Initialize to an appropriate value
      target.benchmarkSystem_JobFailed(sender, e);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for benchmarkSystem_JobRunning
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void benchmarkSystem_JobRunningTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Logger_Accessor target = new Logger_Accessor(param0); // TODO: Initialize to an appropriate value
      object sender = null; // TODO: Initialize to an appropriate value
      JobEventArgs e = null; // TODO: Initialize to an appropriate value
      target.benchmarkSystem_JobRunning(sender, e);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for benchmarkSystem_JobSubmitted
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void benchmarkSystem_JobSubmittedTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Logger_Accessor target = new Logger_Accessor(param0); // TODO: Initialize to an appropriate value
      object sender = null; // TODO: Initialize to an appropriate value
      JobEventArgs e = null; // TODO: Initialize to an appropriate value
      target.benchmarkSystem_JobSubmitted(sender, e);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }

    /// <summary>
    ///A test for benchmarkSystem_JobTerminated
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void benchmarkSystem_JobTerminatedTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Logger_Accessor target = new Logger_Accessor(param0); // TODO: Initialize to an appropriate value
      object sender = null; // TODO: Initialize to an appropriate value
      JobEventArgs e = null; // TODO: Initialize to an appropriate value
      target.benchmarkSystem_JobTerminated(sender, e);
      Assert.Inconclusive("A method that does not return a value cannot be verified.");
    }
  }
}
