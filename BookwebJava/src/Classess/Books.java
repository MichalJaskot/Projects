package Classess;

import java.util.ArrayList;

public class Books {
    private ArrayList<Review> review=new ArrayList<Review>();
    private ArrayList<Rate> rate=new ArrayList<Rate>();

    private int _bookID;
    private String _name;
    private String _author;
    private String _genre;
    private String _publisher;
    private float _rate;

    public Books(int BookID,String Name,String Author,String Genre,String Publisher)
    {
        _bookID = BookID;
        _name = Name;
        _author = Author;
        _genre = Genre;
        _publisher = Publisher;
    }
    public Books(float rates, String user, Books temp)
    {
        rate = temp.rate;
        _bookID = temp.BookID();
        _name = temp.Name();
        _author = temp.Author();
        _genre = temp.Genre();
        _publisher = temp.Publisher();
        _rate = temp.Rate();
        review = temp.review;

        rate.add(new Rate(rates, user));

        float sum = 0;
        for (int i = 0; i < rate.size(); i++)
        {
            sum += rate.get(i).rating();
        }
        _rate = (sum / rate.size());
    }
    public Books(String reviews, String user, Books temp)
    {
        review = temp.review;
        _bookID = temp.BookID();
        _name = temp.Name();
        _author = temp.Author();
        _genre = temp.Genre();
        _publisher = temp.Publisher();
        _rate = temp.Rate();
        review = temp.review;
        review.add(new Review(reviews, user));
    }
    public String Name() { return _name; }
    public String Author() { return _author; }
    public String Genre() { return _genre; }
    public int BookID() { return _bookID; }
    public String Publisher()
    {
        return _publisher;
    }
    public ArrayList Review() { return review; }
    public float Rate() { return _rate; }
    public ArrayList<Rate> GetList(){ return rate; }
    public ArrayList<Review> GetList2(){ return review; }

}
