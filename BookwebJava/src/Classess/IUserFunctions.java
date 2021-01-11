package Classess;

import Frames.SearchItems;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.util.*;

public interface IUserFunctions {
    /// <summary>
    /// Allows user to search a book with a given name.
    /// </summary>
    /// <param name="name">Name of the book that user wants to find.</param>
    /// <returns>An array of valid items.</returns>
    List<Books> SearchABook(String name);

    /// <summary>
    /// Allows user to rate a book.
    /// </summary>
    /// <param name="rate">Rate in scale 1-10</param>
    /// <param name="bookID">Defines which book gets rated.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    boolean RateABook(int rate, String username,Books selectedBook);

    /// <summary>
    /// Allows user to add a review.
    /// </summary>
    /// <param name="review">New review.</param>
    /// <param name="bookID">Defines which book gets reviewed.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    boolean AddReview(String review, String username,Books selectedBook);

    /// <summary>
    /// Allows user to login to the application.
    /// </summary>
    /// <param name="login">Login.</param>
    /// <param name="password">Password.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    boolean LogIn(String login, String password);

    /// <summary>
    /// Allows user to register in the application.
    /// </summary>
    /// <param name="login">Login.</param>
    /// <param name="password">Password.</param>
    /// <param name="email">Email.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    boolean Registration(String login, String password, String email);

    boolean AddBook(String Name,String Author, String Genre,String Publisher);

    public ArrayList<Books> BoookList();
}
