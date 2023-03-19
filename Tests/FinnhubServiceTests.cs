using Services;

namespace Tests

{
    public class FinnhubServiceTests
    {
        [Fact]
        public async Task GetCompanyProfile_ValidSymbol_ExpectedResult()
        {
            FinnService fn = new FinnService();
            string expected = "Microsoft Corp";


            Dictionary<string, object> profileQuoteDictionary = await fn.GetCompanyProfile("MSFT");



            // Assert
            Assert.NotNull(profileQuoteDictionary);
            string? actual = profileQuoteDictionary["name"]?.ToString();
            Assert.Equal(expected, actual);
        }



        [Fact]
        public async Task GetGetStockPriceQuote_Symbol_ExpectedResult()
        {
            FinnService fn = new FinnService();
            string expectedKey = "c";


            Dictionary<string, object> quote = await fn.GetStockPriceQuote("MSFT");

            // Assert
            Assert.True(quote?.ContainsKey(expectedKey), $"Close value is not found in quote dictionary");

        }
    }
}