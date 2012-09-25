using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest
{
    
    
    /// <summary>
    ///This is a test class for JobTest and is intended
    ///to contain all JobTest Unit Tests
    ///</summary>
  [TestClass()]
  public class JobTest {


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
    ///A test for SetTimestamp
    ///</summary>
    [TestMethod()]
    public void SetTimestampTest() {
      Owner owner = null;
      byte CPU = 0; 
      int ExpectedRuntime = 0; 
      Job target = new Job(owner, CPU, ExpectedRuntime); 
      target.SetTimestamp();
      long time = System.DateTime.Now.Millisecond;
      long dif = time - target.timestamp;
      Assert.IsTrue(dif < 10);
    }

    /// <summary>
    ///A test for Job Constructor
    ///</summary>
    [TestMethod()]
    public void JobConstructorTest() {
      Owner owner = new Owner("Test owner");
      byte CPU = 3;
      int ExpectedRuntime = 42; 
      Job target = new Job(owner, CPU, ExpectedRuntime);
      Assert.AreEqual(owner, target.owner);
      Assert.AreEqual(CPU, target.CPU);
      Assert.AreEqual(ExpectedRuntime, target.ExpectedRuntime);
    }

    /// <summary>
    ///A test for ToString
    ///</summary>
    [TestMethod()]
    public void ToStringTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      string expected = string.Empty; // TODO: Initialize to an appropriate value
      string actual;
      actual = target.ToString();
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for CPU
    ///</summary>
    [TestMethod()]
    public void CPUTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      byte expected = 0; // TODO: Initialize to an appropriate value
      byte actual;
      target.CPU = expected;
      actual = target.CPU;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for ExpectedRuntime
    ///</summary>
    [TestMethod()]
    public void ExpectedRuntimeTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      int expected = 0; // TODO: Initialize to an appropriate value
      int actual;
      target.ExpectedRuntime = expected;
      actual = target.ExpectedRuntime;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for State
    ///</summary>
    [TestMethod()]
    public void StateTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      JobState expected = new JobState(); // TODO: Initialize to an appropriate value
      JobState actual;
      target.State = expected;
      actual = target.State;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for owner
    ///</summary>
    [TestMethod()]
    public void ownerTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      Owner expected = null; // TODO: Initialize to an appropriate value
      Owner actual;
      target.owner = expected;
      actual = target.owner;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for process
    ///</summary>
    [TestMethod()]
    public void processTest() {
      Owner owner = null; // TODO: Initialize to an appropriate value
      byte CPU = 0; // TODO: Initialize to an appropriate value
      int ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
      Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
      Func<string[], string> expected = null; // TODO: Initialize to an appropriate value
      Func<string[], string> actual;
      target.process = expected;
      actual = target.process;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }

    /// <summary>
    ///A test for timestamp
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void timestampTest() {
      PrivateObject param0 = null; // TODO: Initialize to an appropriate value
      Job_Accessor target = new Job_Accessor(param0); // TODO: Initialize to an appropriate value
      long expected = 0; // TODO: Initialize to an appropriate value
      long actual;
      target.timestamp = expected;
      actual = target.timestamp;
      Assert.AreEqual(expected, actual);
      Assert.Inconclusive("Verify the correctness of this test method.");
    }
  }
}
