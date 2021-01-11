package Frames;

import Classess.IUserFunctions;
import Classess.MainSystem;
import com.sun.tools.javac.Main;

import javax.swing.*;
import javax.swing.text.Document;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MainMenuItems extends JPanel{
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private JPanel buttonPanel;
    JFrame MainMenu;
    public MainMenuItems(JFrame MainMenu,IUserFunctions MainSystem) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        setVisible(true);
        greenButton = new GreenButton();
        blueButton = new BlueButton();
        redButton = new RedButton();

        buttonPanel = this;

        setLayout(new GridLayout(4,1,22,22));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        blueButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel ("Bookweb"));
        add(greenButton);
        add(blueButton);
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

                    new RegisterFrame(MainSystem);
                    MainMenu.dispose();
                }
            });
        }
    }
//Login
    class BlueButton extends JButton implements ActionListener {

        BlueButton() {
            super("Login");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            new LoginFrame(MainSystem);
            MainMenu.dispose();
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
            System.exit(0);
        }
    }

}
