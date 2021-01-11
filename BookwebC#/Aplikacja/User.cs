using System.Xml.Serialization;
using System;
using System.Collections.Generic;

/// <summary>
/// Contains information about user.
/// </summary>
public class User
{
    private IUserFunctions iUserFunctions;

    private int _userID = 1;
    private string _login;
    private string _password;
    private string _email;
    private bool _admin = false;

    /// <summary>
    /// Constructor which sets private fields.
    /// </summary>
    /// <param name="login">Login of the user.</param>
    /// <param name="password">Password of the user.</param>
    /// <param name="email">Email of the user.</param>
    public User(string login,string password,string email)
    {
        _login = login;
        _password = password;
        _email = email;
        _userID++;
    }

    /// <summary>
    /// Constructor which sets private fields.
    /// </summary>
    /// <param name="login">Login of the user.</param>
    /// <param name="password">Password of the user.</param>
    /// <param name="email">Email of the user.</param>
    public User(string login, string password, string email, bool tmp)
    {
        _login = login;
        _password = password;
        _email = email;
        _admin = true;
        _userID++;
    }

    /// <summary>
    /// Returns login of the user.
    /// </summary>
    public string Login
    {
        get
        {
            return _login;
        }
     
    }

    /// <summary>
    /// Returns password of the user.
    /// </summary>
    public string Password
    {
        get
        {
            return _password;
        }
        
    }

    /// <summary>
    /// Returns email of the user.
    /// </summary>
    public string Email
    {
        get
        {
            return _email;
        }
       
    }

    /// <summary>
    /// Returns identificator of the user.
    /// </summary>
    public int UserID
    {
        get
        {
            return _userID;

        }
       
    }
    /// <summary>
    /// Returns status of the user.
    /// </summary>
    public bool Admin
    {
        get
        {
            return _admin;

        }

    }
}