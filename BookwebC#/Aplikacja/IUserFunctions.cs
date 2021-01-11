using System;
using System.Collections.Generic;

/// <summary>
/// Contains methods that user will need to use the system.
/// </summary>
public interface IUserFunctions
{
    /// <summary>
    /// Allows user to search a book with a given name.
    /// </summary>
    /// <param name="name">Name of the book that user wants to find.</param>
    /// <returns>An array of valid items.</returns>
    List<Books> SearchABook(string name);

    /// <summary>
    /// Allows user to rate a book.
    /// </summary>
    /// <param name="rate">Rate in scale 1-10</param>
    /// <param name="bookID">Defines which book gets rated.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    bool RateABook(int rate, int bookID,string username);

    /// <summary>
    /// Allows user to add a review.
    /// </summary>
    /// <param name="review">New review.</param>
    /// <param name="bookID">Defines which book gets reviewed.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    bool AddReview(string review, int bookID, string username);

    /// <summary>
    /// Allows user to login to the application.
    /// </summary>
    /// <param name="login">Login.</param>
    /// <param name="password">Password.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    User LogIn(string login, string password);

    /// <summary>
    /// Allows user to log out from the system.
    /// </summary>
    /// <returns>Confirmation if action was succesful.</returns>
    bool LogOut();

    /// <summary>
    /// Allows user to register in the application.
    /// </summary>
    /// <param name="login">Login.</param>
    /// <param name="password">Password.</param>
    /// <param name="email">Email.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    bool Registration(string login, string password, string email);
    /// <summary>
    /// Allows user to register in the application.
    /// </summary>
    /// <param name="name">Name of the book.</param>
    /// <param name="author">Author of the book.</param>
    /// <param name="genre">Genre of the book.</param>
    /// <param name="publisher">Publisher of the book.</param>
    /// <returns>Confirmation if action was succesful.</returns>
    bool AddABook(string name, string author, string genre, string publisher);

}