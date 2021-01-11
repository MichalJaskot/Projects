package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.http.WebSocket;

public class LoginItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton greenButton;
    private JButton redButton;
    private JPanel buttonPanel;
    private JTextField login;
    private JPasswordField password;
    JFrame MainMenu;
    public LoginItems(JFrame MainMenu,IUserFunctions MainSystem) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        login = new JTextField();
        password = new JPasswordField();
        buttonPanel = this;

        setLayout(new GridLayout(7,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Bookweb"));
        add(new JLabel("Login: "));
        add(login);
        add(new JLabel("Password:"));
        add(password);
        add(greenButton);
        add(redButton);
    }



    //Login
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Log in");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if(MainSystem.LogIn(login.getText(),new String(password.getPassword())))
                    {
                        JOptionPane.showMessageDialog(null,"Log in successful. ");
                        new SearchFrame(MainSystem,login.getText());
                        MainMenu.dispose();
                    }
                    else JOptionPane.showMessageDialog(null,"Log in unsuccessful. ");

                }
            });
        }
    }

    //Exit
    class RedButton extends JButton implements ActionListener {

        RedButton() {
            super("Exit");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {

                    new MainMenuFrame(MainSystem);
                    MainMenu.dispose();
                }
            });
        }
    }

}
