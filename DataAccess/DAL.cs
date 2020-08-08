using Models;
using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DAL
    {
        private static string connectionString = "your connection string";
        public static int InsertData(Feedback feedback)
        {
            int recordsInserted;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = @"INSERT INTO [dbo].[CustomerFeedback]
                                       ([CustomerName]
                                       ,[CustomerEmail]
                                       ,[FeedbackOnProduct]
                                       ,[FeedbackCategory]
                                       ,[ProductId]
                                       ,[CreatedOn])
                                 VALUES(@name,@email,@feedback,@feedbackRating,@productId,@createdOn)";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@name", feedback.Name);
                    command.Parameters.AddWithValue("@email", feedback.Email);
                    command.Parameters.AddWithValue("@feedback", feedback.FeedbackOnProduct);
                    command.Parameters.AddWithValue("@feedbackRating", feedback.FeedbackRating);
                    command.Parameters.AddWithValue("@productId", feedback.Product.ProductId);
                    command.Parameters.AddWithValue("@createdOn", feedback.CreatedOn);
                    connection.Open();
                    recordsInserted = command.ExecuteNonQuery();
                }

            }

            return recordsInserted;
        }
    }
}
