using Azure;
using System;
using System.Globalization;
using Azure.AI.TextAnalytics;

namespace Utility
{
    public class FeedbackAnalyzer
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("apikey");
        private static readonly Uri endpoint = new Uri("your-endpoint");
        public static string AnalyzeSentiment(string feedback)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            // You will implement these methods later in the quickstart.
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(feedback);
            return documentSentiment.Sentiment.ToString();
        }

    }
}
