package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.http.WebSocket;

public class NewBookItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private JPanel buttonPanel;
    private JTextField name;
    private JTextField author;
    private JTextField genre;
    private JTextField publisher;
    private String username;
    JFrame MainMenu;
    public NewBookItems(JFrame MainMenu,IUserFunctions MainSystem,String username) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        this.username = username;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        name = new JTextField();
        author = new JTextField();
        genre = new JTextField();
        publisher = new JTextField();
        buttonPanel = this;

        setLayout(new GridLayout(11,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Bookweb"));
        add(new JLabel("Name: "));
        add(name);
        add(new JLabel("Author: "));
        add(author);
        add(new JLabel("Genre:"));
        add(genre);
        add(new JLabel("Publisher:"));
        add(publisher);


        add(greenButton);
        add(redButton);
    }



    //Register
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Add a book");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if(MainSystem.AddBook(name.getText(),author.getText(),genre.getText(),publisher.getText()))
                    {
                        JOptionPane.showMessageDialog(null,"Book added successfully. ");
                        new SearchFrame(MainSystem,username);
                        MainMenu.dispose();
                    }
                    else JOptionPane.showMessageDialog(null,"Adding a book unsuccessful. ");

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

                    new SearchFrame(MainSystem,username);
                    MainMenu.dispose();
                }
            });
        }
    }

}
