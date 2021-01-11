using System;
using System.Collections.Generic;
/// <summary>
/// Contains book information.
/// </summary>
public class Books
{
   
    private List<Review> review=new List<Review>();
    private List<Rate> rate=new List<Rate>();

    /// <summary>
    /// Constructor which sets private fields.
    /// </summary>
    /// <param name="BookID">Id of the book.</param>
    /// <param name="Name">Name of the book.</param>
    /// <param name="Author">Author of the book.</param>
    /// <param name="Genre">Genre of the book.</param>
    /// <param name="Publisher">Publisher of the book.</param>
    public Books(int BookID,string Name,string Author,string Genre,string Publisher)
    {
        _bookID = BookID;
        _name = Name;
        _author = Author;
        _genre = Genre;
        _publisher = Publisher;
    }

    /// <summary>
    /// Constructor which is used to add rating to the book.
    /// </summary>
    /// <param name="rates">Rating of the book./</param>
    /// <param name="user">Name of the user who rated the book.</param>
    /// <param name="BookID">ID of the book which is rated.</param>
    /// <param name="temp">Copy of the book which is being rated.</param>
    public Books(float rates, string user, int BookID, Books temp)
    {
        rate = temp.rate;
        _bookID = temp.BookID;
        _name = temp.Name;
        _author = temp.Author;
        _genre = temp.Genre;
        _publisher = temp.Publisher;
        _rate = temp.Rate;
        _review = temp.Review;
        review = temp.review;
        rate.Add(new Rate(rates, user));

        float sum = 0;
        for (int i = 0; i < rate.Count; i++)
        {
            sum += rate[i].rating;
        }
        _rate = (sum / rate.Count);
    }

    /// <summary>
    /// Constructor which is used to add review to the book.
    /// </summary>
    /// <param name="review">Review of the book./</param>
    /// <param name="user">Name of the user who rated the book.</param>
    /// <param name="BookID">ID of the book which is rated.</param>
    /// <param name="temp">Copy of the book which is being rated.</param>
    public Books(string reviews, string user, int BookID, Books temp)
    {
        review = temp.review;
        _bookID = temp.BookID;
        _name = temp.Name;
        _author = temp.Author;
        _genre = temp.Genre;
        _publisher = temp.Publisher;
        _rate = temp.Rate;
        _review = temp.Review;
        review.Add(new Review(reviews, user));
    }

    private int _bookID;

    private String _name;

    private String _author;

    private String _genre;

    private String _publisher;

    private float _rate;

    private string _review;

    /// <summary>
    /// Returns rate of the book.
    /// </summary>
    public float Rate
    {
        get
        {
            return _rate;
        }
        
    }

    /// <summary>
    /// Returns review of the book.
    /// </summary>
    public string Review
    {
        get
        {
            return _review;
        }
        
    }

    /// <summary>
    /// Returns name of the book.
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        
    }

    /// <summary>
    /// Returns name of the author of the book.
    /// </summary>
    public string Author
    {
        get
        {
            return _author;
        }
        
    }

    /// <summary>
    /// Returns genre of the book.
    /// </summary>
    public string Genre
    {
        get
        {
            return _genre;
        }
        
    }

    /// <summary>
    /// Returns publisher of the book.
    /// </summary>
    public string Publisher
    {
        get
        {
            return _publisher;
        }
 
    }

    /// <summary>
    /// Returns identificator of the book.
    /// </summary>
    public int BookID
    {
        get
        {
            return _bookID;
        }
  
    }

    /// <summary>
    /// Returns list of the ratings of the book.
    /// </summary>
    public List<Rate> GetList()
    {
        return rate;
    }

    /// <summary>
    /// Returns list of the reviews of the book.
    /// </summary>
    public List<Review> GetList2()
    {
        return review;
    }
}