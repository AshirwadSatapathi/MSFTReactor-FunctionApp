using DataAccess;
using Models;
using System;
using Utility;

namespace BL
{
    public class Business
    {
        public Feedback SubmitFeedback(Feedback feedback)
        {
            feedback.FeedbackRating = FeedbackAnalyzer.AnalyzeSentiment(feedback.FeedbackOnProduct);

            EmailHelper.SendEmail(feedback);
            var records = DAL.InsertData(feedback);
            return feedback;
        }
    }
}
