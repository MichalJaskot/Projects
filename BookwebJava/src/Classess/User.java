package Classess;

public class User {

    private int _userID = 0;
    private String _login;
    private String _password;
    private String _email;

    public User(String login,String password,String email)
    {
        _login = login;
        _password = password;
        _email = email;
        _userID++;
    }

    public String Login()
    {
            return _login;
    }
    public String Password() { return _password; }
    public String Email() { return _email; }
    public int UserID() { return _userID; }


}
