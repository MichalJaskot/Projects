package Classess;

public class Review {
    private String _user;
    private String _review;

    public Review(String review, String user)
    {
        _review = review;
        _user = user;
    }

    public String Reviews ()
    {
            return _review;
    }

    public String Username ()
    {
            return _user;
    }
}
