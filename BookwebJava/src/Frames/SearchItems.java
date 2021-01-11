package Frames;

import Classess.Books;
import Classess.IUserFunctions;
import com.sun.tools.javac.Main;

import java.awt.event.*;
import java.util.LinkedList;
import java.util.List;
import java.util.Vector;
import javax.swing.*;
import javax.swing.event.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import javax.swing.table.AbstractTableModel;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableRowSorter;
import javax.swing.text.Document.*;
import javax.swing.event.MouseInputAdapter;
import java.awt.*;
import java.awt.print.Book;
import java.net.http.WebSocket;

public class SearchItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private JButton redButton;
    private JPanel buttonPanel;
    private JTextField search;
    private JTable searchtable;
    private JScrollPane scrollPane;
    private searchmodel km = new searchmodel();
    private JButton greenButton;
    private MouseAdapter Mouse;
    private String username;

    JFrame MainMenu;
    public SearchItems(JFrame MainMenu,IUserFunctions MainSystem,String username) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        this.username = username;
        setVisible(true);
        this.setSize(500, 500);
        redButton = new RedButton();
        greenButton = new GreenButton();

        search = new JTextField("Enter the name of the book.");
        search.getDocument().addDocumentListener(new SimpleDocumentListener());
        search.getDocument().putProperty("name", "Text Field");

        km.setData(this.MainSystem.BoookList());
        searchtable = new JTable(km);
        scrollPane = new JScrollPane(searchtable);
        buttonPanel = this;

        searchtable.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent me) {
                if (me.getClickCount() == 2) {     // to detect doble click events
                    JTable target = (JTable)me.getSource();
                    int row = target.getSelectedRow(); // select a row
                    Books selectedBook = MainSystem.BoookList().get(row);

                    EventQueue.invokeLater(new Runnable() {
                        @Override
                        public void run() {
                            new BookFrame(MainSystem,selectedBook,username);
                            MainMenu.dispose();

                        }
                    });
                }
            }
        });

        setLayout(new GridLayout(5, 1, 55, 5));
        setPreferredSize(new Dimension(HEIGHT, WIDTH));
        add(new JLabel("Bookweb"));
        add(search);
        add(scrollPane);
        add(greenButton);
        add(redButton);
    }
    //Dynamic search
    class SimpleDocumentListener implements DocumentListener {

        public void insertUpdate(DocumentEvent e) {
            km.setData(MainSystem.SearchABook(search.getText()));
            km.fireTableDataChanged();
        }
        public void removeUpdate(DocumentEvent e) {km.setData(MainSystem.SearchABook(search.getText()));
            km.fireTableDataChanged();
        }
        public void changedUpdate(DocumentEvent e) {km.setData(MainSystem.SearchABook(search.getText()));
            km.fireTableDataChanged();
        }

        public void updateLog(DocumentEvent e, String action) {
        }
    }
    //Add a Book
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
                        new NewBookFrame(MainSystem,username);
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

                    new MainMenuFrame(MainSystem);
                    MainMenu.dispose();
                }
            });
        }
    }
    public class searchmodel extends AbstractTableModel {
        private String[] colname= {"Book_ID","Name","Author","Genre","Publisher","Rate"};
        private List<Books> data;

        public searchmodel(){}

        public void setData(List<Books> listaDoModelu){
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
            Books r =(Books)data.get(row);
            switch(col){
                case 0:
                    return r.BookID();
                case 1:
                    return r.Name();
                case 2:
                    return r.Author();
                case 3:
                    return r.Genre();
                case 4:
                    return r.Publisher();
                case 5:
                    return r.Rate();
            }

            return null;

        }

    }
}
