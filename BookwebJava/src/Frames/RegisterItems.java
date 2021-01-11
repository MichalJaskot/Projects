package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.http.WebSocket;

public class RegisterItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private JPanel buttonPanel;
    private JTextField login;
    private JTextField email;
    private JPasswordField password;
    JFrame MainMenu;
    public RegisterItems(JFrame MainMenu,IUserFunctions MainSystem) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        login = new JTextField();
        this.email = new JTextField();
        password = new JPasswordField();
        buttonPanel = this;

        setLayout(new GridLayout(9,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Bookweb"));
        add(new JLabel("Login: "));
        add(login);
        add(new JLabel("Email: "));
        add(email);
        add(new JLabel("Password:"));
        add(password);
        add(greenButton);
        add(redButton);
    }



    //Register
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Register");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if(MainSystem.Registration(login.getText(),new String(password.getPassword()),email.getText()))
                    {
                        JOptionPane.showMessageDialog(null,"Registration successful. ");
                        new MainMenuFrame(MainSystem);
                        MainMenu.dispose();
                    }
                    else JOptionPane.showMessageDialog(null,"Registration unsuccessful. ");

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
