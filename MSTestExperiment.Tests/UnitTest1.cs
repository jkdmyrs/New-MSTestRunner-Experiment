namespace MSTestExperiment.Tests
{
    [TestClass]
    public class UnitTest1
    {
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