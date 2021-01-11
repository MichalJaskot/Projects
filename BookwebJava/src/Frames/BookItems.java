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
import java.net.http.WebSocket;
import java.util.List;

public class BookItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private String username;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private JPanel buttonPanel;
    private JTable review;
    private Books selectedBook;
    private searchmodel km = new searchmodel();
    private JScrollPane scrollPane;
    JFrame MainMenu;
    public BookItems(JFrame MainMenu, IUserFunctions MainSystem,Books selectedBook,String username) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        this.selectedBook = selectedBook;
        this.username = username;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        blueButton = new BlueButton();
        review = new JTable();
        buttonPanel = this;

        setLayout(new GridLayout(9,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Name: "+selectedBook.Name()));
        add(new JLabel("Author: "+selectedBook.Author()));
        add(new JLabel("Genre: "+selectedBook.Genre()));
        add(new JLabel("Publisher: "+selectedBook.Publisher()));
        add(new JLabel("Rate: "+selectedBook.Rate()));


        km.setData(this.selectedBook.Review());
        review = new JTable(km);
        scrollPane = new JScrollPane(review);
        add(scrollPane);
        add(greenButton);
        add(blueButton);
        add(redButton);
    }

    //Convert
    class BlueButton extends JButton implements ActionListener {

        BlueButton() {
            super("Convert a book");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    new ConvertFrame(MainSystem,selectedBook,username);
                    MainMenu.dispose();
                  }
            });
        }
    }


    //Rate/Review
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Rate/review a book");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    new RateReviewFrame(MainSystem,selectedBook,username);
                    MainMenu.dispose();
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
//Table
    public class searchmodel extends AbstractTableModel {
        private String[] colname= {"User","Review"};
        private java.util.List<Review> data;

        public searchmodel(){}

        public void setData(List<Review> listaDoModelu){
            this.data = listaDoModelu;
        }

        @Override
        public int getColumnCount() {
            return colname.length ;
        }

        @Override
        public int getRowCount() {
            return  data.size();
        }
        @Override
        public String getColumnName(int columnIndex){
            return colname[columnIndex].toString();
        }

        @Override
        public Object getValueAt(int row, int col) {
            Review r =(Review)data.get(row);
            switch(col){
                case 0:
                    return r.Username();
                case 1:
                    return r.Reviews();
            }

            return null;

        }

    }

}
