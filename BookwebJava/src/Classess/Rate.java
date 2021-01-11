package Classess;


public class Rate{

    private String _user;
    private float _rate;

    public Rate(float rates, String user)
    {
        _rate = rates;
        _user = user;
    }

    /// <summary>
    /// Returns rating of the book.
    /// </summary>
    public float rating ()
    {
            return _rate;

    }

    /// <summary>
    /// Returns name of the user who rated the book.
    /// </summary>
    public String Username ()
    {
            return _user;
    }
}
