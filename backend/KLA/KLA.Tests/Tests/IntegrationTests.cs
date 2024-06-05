using KLA.Models.Request;
using KLA.Tests.Fixture;
using System.Text.Json;

namespace KLA.Tests.Tests
{
    public class IntegrationTests : IClassFixture<APIFixture<Program>>
    {
        private readonly HttpClient _client;
        public IntegrationTests(APIFixture<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public async Task ConvertNumber_Null_Input_Fail(string? req)
        {
            ConvertNumberRequest request = new()
            {
                Number = req
            };

            var res = await _client.PostAsync("/ConvertNumber",
                new StringContent(JsonSerializer.Serialize(request), null, "application/json"));

            string body = await res.Content.ReadAsStringAsync();

            Assert.False(res.IsSuccessStatusCode);
            Assert.Contains("Value cannot be null", body);
        }

        [Theory]
        [InlineData("asd1")]
        [InlineData("11,2,3")]
        [InlineData("11.3")]
        [InlineData("11.33")]
        [InlineData("11,332")]
        [InlineData("1111111111")]
        public async Task ConvertNumber_Invalid_Input_Fail(string? req)
        {
            ConvertNumberRequest request = new()
            {
                Number = req
            };
            var res = await _client.PostAsync("/ConvertNumber",
                new StringContent(JsonSerializer.Serialize(request), null, "application/json"));

            string body = await res.Content.ReadAsStringAsync();

            Assert.False(res.IsSuccessStatusCode);
            Assert.Contains("Invalid format", body);
        }

        [Theory]
        [InlineData("0", "zero dollars")]
        [InlineData("1", "one dollar")]
        [InlineData("25,1", "twenty-five dollars and ten cents")]
        [InlineData("0,01", "zero dollars and one cent")]
        [InlineData("45100", "forty-five thousand one hundred dollars")]
        [InlineData("999999999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public async Task ConvertNumber_Invalid_Input_Success(string? req, string expected)
        {
            ConvertNumberRequest request = new()
            {
                Number = req
            };
            var res = await _client.PostAsync("/ConvertNumber",
                new StringContent(JsonSerializer.Serialize(request), null, "application/json"));

            string body = await res.Content.ReadAsStringAsync();

            Assert.True(res.IsSuccessStatusCode);
            Assert.Contains(expected, body);
        }
    }
}