package Classess;

import Frames.SearchItems;

import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableRowSorter;
import javax.swing.*;
import java.lang.reflect.Array;
import java.util.*;

public class MainSystem implements IUserFunctions,IBooksFunctions {

    private ArrayList<User> users = new ArrayList<User>();
    private ArrayList<Books> books = new ArrayList<Books>();

    public MainSystem()
    {
        users.add(new User("asd", "asb", "@"));
        books.add(new Books(1, "Droga Krolow", "Brandon Sanderson", "Fantasy", "Mag"));
        books.add(new Books(2, "Slowa Swiatlosci", "Brandon Sanderson", "Fantasy", "Mag"));
        books.add(new Books(3, "Dawca Przysiegi", "Brandon Sanderson", "Fantasy", "Mag"));
        books.add(new Books(4, "Ruiny Gorlanu", "John Flanagan", "Fantasy", "Mag"));
        books.add(new Books(5, "Pan Tadeusz", "Adam Mickiewicz", "Poezja Epicka", "Greg"));
        books.add(new Books(6, "Harry Potter 1-7", "J.K.Rowling", "Fantasy", "Media Rodzina"));
        books.add(new Books(7, "Pinokio", "Carlo Collodi", "Dla Dzieci", "Greg"));
        books.add(new Books(8, "50 Twarzy Greya", "E.L.James", "Powiesc romantyczno-erotyczna", "Sonia Draga"));
        books.add(new Books(9, "Wiedzmin Ostatnie Zyczenie", "Andrej Sapkowski", "Fantasy", "Supernowa"));
        books.add(new Books(10, "Kubus Puchatek", "Milne Alan Alexander", "Dla Dzieci", "Nasza Ksiegarnia"));
        books.add(new Books(11, "Minecraft, how to play", "Markus Persson", "Biografia", "Ether"));
        books.add(new Books(12, "Muchy Chodza Po Mozgu", "Stanislaw Mackiewicz", "Esej", "Wydawnictwo Literackie"));
        books.add(new Books(13, "Zmiechrz", "Stephenie Meyer", "Romans", "Wydawnictwo Dolnoslaskie"));
        books.add(new Books(14, "Sztuka Pierdzenia", "Pierre-Thomas-Nicolas-Hurtaut", "Brak", "Wydawnictwo Slowo"));
        books.add(new Books(15, "Dlaczego dziecko gotuje sie w mamalydze", "Aglaja Veteranyi", "Literatura Piekna", "Czarne"));
        books.add(new Books(16, "Norbert Gierczak kontra caly swiat", "Twitch.tv", "Biografia", "Greg"));
    }

    @Override
    public List<Books> SearchABook(String name) {
        ArrayList<Books> search = new ArrayList<Books>();
        if(name.equals(""))
        {
            return books;
        }
        else
        {
            for (int i = 0; i < books.size();i++)
            {
                if (books.get(i).Name().contains(name))
                    search.add(books.get(i));
            }
            return search;
        }
    }

    @Override
    public boolean RateABook(int rate, String username,Books selectedBook) {

        for (int i = 0; i < books.get(selectedBook.BookID()-1).GetList().size(); i++)
        {
            if (username==books.get(selectedBook.BookID()-1).GetList().get(i).Username())
            {
                return false;
            }
        }

        books.remove(selectedBook.BookID()-1);
        books.add(selectedBook.BookID()-1,new Books(rate,username,selectedBook));
        return true;
    }
    @Override
    public boolean AddReview(String review, String username,Books selectedBook){
        for (int i = 0; i < books.get(selectedBook.BookID()-1).GetList2().size(); i++)
        {
            if (username==books.get(selectedBook.BookID()-1).GetList2().get(i).Username())
            {
                return false;
            }
        }

        books.remove(selectedBook.BookID()-1);
        books.add(selectedBook.BookID()-1,new Books(review,username,selectedBook));
        return true;
    }

    @Override
    public boolean LogIn(String login, String password) {
        for (int i = 0; i < users.size(); i++)
        {
            if (users.get(i).Login().equals(login))
            {
                if (users.get(i).Password().equals(password)) return true;
                else return false;
            }
        }
        return false;
    }

    @Override
    public boolean Registration(String login, String password, String email) {
        for (int i = 0; i < users.size(); i++)
        {
            if (users.get(i).Login().equals(login)) return false;
        }

            if(password.length()>3)
            {
                if(email.contains("@"))
                {
                    users.add(new User(login,password,email));
                    return true;
                }
                else return false;
            }
            else return false;
        }

    @Override
    public boolean AddBook( String Name, String Author, String Genre, String Publisher) {
        for (int i = 0; i < books.size(); i++)
        {
            if (books.get(i).Name().equals(Name)) return false;
        }

        books.add(new Books(books.size()+1,Name,Author,Genre,Publisher));
        return true;


    }

    public ArrayList<Books> BoookList() { return books; }

}
