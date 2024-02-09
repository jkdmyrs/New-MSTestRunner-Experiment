using System.ComponentModel.Design;

namespace MSTestExperiment.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext _)
        {
            Mutex? functionStarted = null;
            while (!Mutex.TryOpenExisting("FunctionStartup", out functionStarted))
            {
                Thread.Sleep(200);
            }
            functionStarted?.Dispose();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            // arrange
            HttpClient client = new();

            // act
            var response = await client.GetAsync("http://localhost:7015/api/Function");

            // assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}