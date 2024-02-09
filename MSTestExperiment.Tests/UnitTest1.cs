namespace MSTestExperiment.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext _)
        {
            while (!Mutex.TryOpenExisting("FunctionStartup", out Mutex? _))
            {
                Thread.Sleep(200);
            }

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