using BenchmarkSystemNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BenchmarkSystemTest {


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
      byte CPU = 1;
      uint ExpectedRuntime = 0;
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
      uint ExpectedRuntime = 42;
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
      Owner owner = new Owner("Test owner");
      byte CPU = 3;
      uint ExpectedRuntime = 42;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      string actual = target.ToString();
      Assert.IsTrue(target.ToString().Contains(owner.Name));
      Assert.IsTrue(target.ToString().Contains("42"));
      Assert.IsTrue(target.ToString().Contains("3"));
      Assert.IsTrue(target.ToString().Contains("Created"));
    }

    /// <summary>
    ///A test for CPU
    ///</summary>
    [TestMethod()]
    public void CPUTest() {
      Owner owner = null;
      byte CPU = 3;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      byte expected = 3;
      byte actual;
      target.CPU = expected;
      actual = target.CPU;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for CPU
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CPUTest0() {
      Owner owner = null;
      byte CPU = 0;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
    }

    /// <summary>
    ///A test for CPU
    ///</summary>
    [TestMethod()]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CPUTest255() {
      Owner owner = null;
      byte CPU = 255;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
    }

    /// <summary>
    ///A test for ExpectedRuntime
    ///</summary>
    [TestMethod()]
    public void ExpectedRuntimeTest0() {
      Owner owner = null;
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      uint expected = 0;
      uint actual;
      target.ExpectedRuntime = expected;
      actual = target.ExpectedRuntime;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for ExpectedRuntime
    ///</summary>
    [TestMethod()]
    public void ExpectedRuntimeTest200() {
      Owner owner = null;
      byte CPU = 1;
      uint ExpectedRuntime = 200;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      uint expected = 200;
      uint actual;
      target.ExpectedRuntime = expected;
      actual = target.ExpectedRuntime;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for State
    ///</summary>
    [TestMethod()]
    public void StateTest() {
      Owner owner = null;
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      JobState expected = JobState.Created;
      JobState actual;
      target.State = expected;
      actual = target.State;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for State
    ///</summary>
    [TestMethod()]
    public void StateTest2() {
      Owner owner = null;
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      JobState expected = JobState.Queued;
      JobState actual;
      target.State = expected;
      actual = target.State;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for State
    ///</summary>
    [TestMethod()]
    public void StateTest3() {
      Owner owner = null;
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      JobState expected = JobState.Queued;
      JobState shouldfail;
      target.State = expected;
      shouldfail = JobState.Running;
      Assert.AreNotEqual(expected, shouldfail);
    }

    /// <summary>
    ///A test for owner
    ///</summary>
    [TestMethod()]
    public void ownerTest() {
      Owner owner = new Owner("Test owner");
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      Owner expected = new Owner("Test owner");
      Owner actual;
      target.owner = expected;
      actual = target.owner;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for owner
    ///</summary>
    [TestMethod()]
    public void ownerTest2() {
      Owner owner = new Owner("Some owner");
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      Owner expected = new Owner("Some owner");
      Owner actual;
      target.owner = expected;
      actual = target.owner;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for owner
    ///</summary>
    [TestMethod()]
    public void ownerTest3() {
      Owner owner = new Owner("Some owner");
      byte CPU = 1;
      uint ExpectedRuntime = 0;
      Job target = new Job(owner, CPU, ExpectedRuntime);
      Owner shouldfail = new Owner("Test owner");
      Owner actual;
      actual = target.owner;
      Assert.AreNotEqual(shouldfail, actual);
    }

    // TODO: That:
    /// <summary>
    ///A test for process
    ///</summary>
    //[TestMethod()]
    //public void processTest() {
    //Owner owner = null; // TODO: Initialize to an appropriate value
    //byte CPU = 0; // TODO: Initialize to an appropriate value
    //uint ExpectedRuntime = 0; // TODO: Initialize to an appropriate value
    //Job target = new Job(owner, CPU, ExpectedRuntime); // TODO: Initialize to an appropriate value
    //Func<string[], string> expected = null; // TODO: Initialize to an appropriate value
    //Func<string[], string> actual;
    //target.process = expected;
    //actual = target.process;
    //Assert.AreEqual(expected, actual);
    //Assert.Inconclusive("Verify the correctness of this test method.");
    //}

    /// <summary>
    ///A test for timestamp
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void timestampTest() {
      PrivateObject param0 = new PrivateObject(new Job(null, 1, 20));
      Job_Accessor target = new Job_Accessor(param0);
      long expected = 20;
      long actual;
      target.timestamp = expected;
      actual = target.timestamp;
      Assert.AreEqual(expected, actual);
    }

    /// <summary>
    ///A test for timestamp
    ///</summary>
    [TestMethod()]
    [DeploymentItem("BenchmarkSystem.dll")]
    public void timestampTest2() {
      PrivateObject param0 = new PrivateObject(new Job(null, 1, 20));
      Job_Accessor target = new Job_Accessor(param0);
      long expected = 2000;
      long actual;
      target.timestamp = expected;
      actual = target.timestamp;
      Assert.AreEqual(expected, actual);
    }
  }
}
