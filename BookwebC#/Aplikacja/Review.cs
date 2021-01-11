using System;
/// <summary>
/// Contains reviews.
/// </summary>
public class Review
{
    private string _user;
    private string _review;

    /// <summary>
    /// Constructor which allows user to add a review.
    /// </summary>
    /// <param name="review">Review of the book.</param>
    /// <param name="user">Name of the user who rated the book.</param>
    public Review(string review, string user)
    {
        _review = review;
        _user = user;
    }

    /// <summary>
    /// Returns the review.
    /// </summary>
    public string Reviews
    {
        get
        {
            return _review;
        }
        
    }

    /// <summary>
    /// Returns name of the user who wrote the review.
    /// </summary>
    public string Username
    {
        get
        {
            return _user;
        }
       
    }

}