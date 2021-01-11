package Frames;

import Classess.*;
import Classess.IUserFunctions;
import Classess.MainSystem;
import Classess.Books;

import javax.swing.*;
import javax.swing.table.AbstractTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.print.Book;
import java.net.http.WebSocket;
import java.util.List;

public class RateReviewItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private JPanel buttonPanel;
    private Books selectedBook;
    private JTextField review;
    private JComboBox rate;
    private String[] rates={"0","1","2","3","4","5","6","7","8","9","10"};
    private String username;
    JFrame MainMenu;
    public RateReviewItems(JFrame MainMenu, IUserFunctions MainSystem,Books selectedBook,String username) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        this.selectedBook = selectedBook;
        this.username = username;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        blueButton = new BlueButton();
        review = new JTextField();
        rate = new JComboBox(rates);
        rate.setEditable(false);
        buttonPanel = this;

        setLayout(new GridLayout(7,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        blueButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Name: "+selectedBook.Name()));
        add(rate);
        add(review);


        add(blueButton);
        add(greenButton);
        add(redButton);
    }

    //Rate a book
    class BlueButton extends JButton implements ActionListener {

        BlueButton() {
            super("Rate a book");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if(MainSystem.RateABook(rate.getSelectedIndex(),username,selectedBook))
                        JOptionPane.showMessageDialog(null,"Successfully rated a book! ");
                    else JOptionPane.showMessageDialog(null,"You've already rated this book! ");
                }
            });
        }
    }


    //Add review
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Add a review");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    EventQueue.invokeLater(new Runnable() {
                        @Override
                        public void run() {
                            if(MainSystem.AddReview(review.getText(),username,selectedBook))
                                JOptionPane.showMessageDialog(null,"Successfully reviewed a book! ");
                            else JOptionPane.showMessageDialog(null,"You've already reviewed this book! ");
                        }
                    });

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

                    new BookFrame(MainSystem,selectedBook,username);
                    MainMenu.dispose();
                }
            });
        }
    }
}


