using System;
using System.Collections.Generic;
using System.Windows;

public class Systemik : IUserFunctions
{
    private List<User> user = new List<User>();
    private List<Books> books = new List<Books>();


    /// <summary>
    /// Constructor which adds books to the system.
    /// </summary>
    public Systemik()
    {
        user.Add(new User("asd", "asd", "@" ,true));
        books.Add(new Books(1, "Droga Krolow", "Brandon Sanderson", "Fantasy", "Mag"));
        books.Add(new Books(2, "Slowa Swiatlosci", "Brandon Sanderson", "Fantasy", "Mag"));
        books.Add(new Books(3, "Dawca Przysiegi", "Brandon Sanderson", "Fantasy", "Mag"));
        books.Add(new Books(4, "Ruiny Gorlanu", "John Flanagan", "Fantasy", "Mag"));
        books.Add(new Books(5, "Pan Tadeusz", "Adam Mickiewicz", "Poezja Epicka", "Greg"));
        books.Add(new Books(6, "Harry Potter 1-7", "J.K.Rowling", "Fantasy", "Media Rodzina"));
        books.Add(new Books(7, "Pinokio", "Carlo Collodi", "Dla Dzieci", "Greg"));
        books.Add(new Books(8, "50 Twarzy Greya", "E.L.James", "Powiesc romantyczno-erotyczna", "Sonia Draga"));
        books.Add(new Books(9, "Wiedzmin Ostatnie Zyczenie", "Andrej Sapkowski", "Fantasy", "Supernowa"));
        books.Add(new Books(10, "Kubus Puchatek", "Milne Alan Alexander", "Dla Dzieci", "Nasza Ksiegarnia"));
        books.Add(new Books(11, "Minecraft, how to play", "Markus Persson", "Biografia", "Ether"));
        books.Add(new Books(12, "Muchy Chodza Po Mozgu", "Stanislaw Mackiewicz", "Esej", "Wydawnictwo Literackie"));
        books.Add(new Books(13, "Zmiechrz", "Stephenie Meyer", "Romans", "Wydawnictwo Dolnoslaskie"));
        books.Add(new Books(14, "Sztuka Pierdzenia", "Pierre-Thomas-Nicolas-Hurtaut", "Brak", "Wydawnictwo Slowo"));
        books.Add(new Books(15, "Dlaczego dziecko gotuje sie w mamalydze", "Aglaja Veteranyi", "Literatura Piekna", "Czarne"));
        books.Add(new Books(16, "Norbert Gierczak kontra caly swiat", "Twitch.tv", "Biografia", "Greg"));
    }

    List<Books> IUserFunctions.SearchABook(string name)
    {
        List<Books> search = new List<Books>();
        for (int i = 0; i < books.Count;i++)
        {
            if (books[i].Name.Contains(name))
                search.Add(books[i]);
        }
        return search;
    }

    bool IUserFunctions.RateABook(int rate, int bookID, string username)
    {

        int index = 0;
        
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookID == bookID) index = i;    
        }
        Books temp = books[index];

        for (int i = 0; i < books[index].GetList().Count; i++)
        {
            if (username==books[index].GetList()[i].Username)
            {
                return false;
            }            
        }
        
        books.RemoveAt(index);
        books.Insert(index, new Books(rate, username, bookID, temp));
        
        return true;
    }

    bool IUserFunctions.AddReview(string review, int bookID, string username)
    {
        int index = 0;

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookID == bookID) index = i;
        }
        Books temp = books[index];

        for (int i = 0; i < books[index].GetList2().Count; i++)
        {
            if (username == books[index].GetList2()[i].Username)
            {
                return false;
            }
        }

        books.RemoveAt(index);
        books.Insert(index, new Books(review, username, bookID, temp));

        return true;
    }

    User IUserFunctions.LogIn(string login, string password)
    {
        for (int i = 0; i < user.Count; i++)
        {
            if (login == user[i].Login)
            {
                if (password == user[i].Password ) return user[i];
                else return null;
            }
        }
        return null;
    }

    bool IUserFunctions.LogOut()
    {
        return false;
    }

    bool IUserFunctions.Registration(string login, string password, string email)
    {
       bool tmp = true;
        if (password==""||login==""||email=="")
        {
            return false;
        }
        else
        {
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].Login == login)
                {
                    tmp = false;
                }
            }
            if (tmp == true)
            {
                if (email.Contains("@"))
                {
                    user.Add(new User(login, password, email));
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }

    public bool AddABook(string name, string author, string genre, string publisher)
    {
        bool tmp = true;
        if (name == "" || author == "" || genre == "" || publisher == "")
        {
            return false;
        }
        else
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Name == name)
                {
                    tmp = false;
                }
                if (books[i].Author == author)
                {
                    tmp = false;

                }
                if (books[i].Genre == genre)
                {
                    tmp = false;
                }
                if (books[i].Publisher == publisher)
                {
                    tmp = false;
                }
            }
            if (tmp == true)
            {
                books.Add(new Books(books.Count+1, name, author, genre, publisher));
                return true;
            }
            else return false;
        }
    }
}