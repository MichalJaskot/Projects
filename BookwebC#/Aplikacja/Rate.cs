using System;

/// <summary>
/// Contains Rate of the book.
/// </summary>
public class Rate
{

    private string _user;
    private float _rate;

    /// <summary>
    /// Construcor which add a rate to the book.
    /// </summary>
    /// <param name="rates">Rate of the book.</param>
    /// <param name="user">Name of the user who rated the book.</param>
    public Rate(float rates, string user)
    {
        _rate = rates;
        _user = user;
    }

    /// <summary>
    /// Returns rating of the book.
    /// </summary>
    public float rating
    {
        get
        {
            return _rate;
        }

    }

    /// <summary>
    /// Returns name of the user who rated the book.
    /// </summary>
    public string Username
    {
        get
        {
            return _user;
        }

    }

}