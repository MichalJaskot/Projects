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

public class ConvertItems extends JPanel {
    IUserFunctions MainSystem;
    public static final int HEIGHT = 300;
    public static final int WIDTH = 300;
    private String username;
    private JButton greenButton;
    private JButton blueButton;
    private JButton redButton;
    private Books selectedBook;
    private JProgressBar progressBar;

    private ProgressThread Thread;
    JFrame MainMenu;
    public ConvertItems(JFrame MainMenu, IUserFunctions MainSystem,Books selectedBook,String username) {
        this.MainMenu = MainMenu;
        this.MainSystem = MainSystem;
        this.selectedBook = selectedBook;
        this.username = username;
        setVisible(true);

        greenButton = new GreenButton();
        redButton = new RedButton();
        blueButton = new BlueButton();
        progressBar = new JProgressBar();
        progressBar.setStringPainted(true);
        Thread = new ProgressThread();
        setLayout(new GridLayout(9,1,55,5));
        setPreferredSize(new Dimension(WIDTH, HEIGHT));
        greenButton.setPreferredSize(new Dimension(WIDTH,50));
        redButton.setPreferredSize(new Dimension(WIDTH,50));
        add(new JLabel("Convert progress: "));

        add(progressBar);
        add(greenButton);
        add(blueButton);
        add(redButton);
    }

    //Stop
    class BlueButton extends JButton implements ActionListener {

        BlueButton() {
            super("Stop converting");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                        Thread.Exit(true);
                }
            });
        }
    }


    //Start
    class GreenButton extends JButton implements ActionListener {

        GreenButton() {
            super("Start converting");
            addActionListener(this);
        }

        @Override
        public void actionPerformed(ActionEvent e) {

            EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    if(Thread.exit) Thread.resume();
                    else Thread.start();
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
                    Thread.stop();
                    new SearchFrame(MainSystem,username);
                    MainMenu.dispose();
                }
            });
        }
    }

    //Thread
    class ProgressThread extends Thread implements Runnable {

        private int progress=0;
        private boolean exit;
        public void Exit(boolean exit)
        {
            this.exit = exit;
            this.suspend();
        }

        @Override
        public synchronized void start() {
            super.start();
            progressBar.setValue(progress);
        }

        public void run() {
               while(progress<101)
               try {
                   progressBar.setValue(progress+1);
                   progress=progressBar.getValue();
                   Thread.sleep(100);
                   if(progress==100){ this.done();
                   this.Exit(true); }
               } catch (InterruptedException e) {
               }
           }
           public void done()
           {
               JOptionPane.showMessageDialog(null,"Converting successful. ");
               this.stop();
           }
        }
    }


