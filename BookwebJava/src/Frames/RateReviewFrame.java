package Frames;

import Classess.IUserFunctions;
import Classess.Books;

import javax.swing.*;
import java.awt.*;

public class RateReviewFrame extends JFrame {
    IUserFunctions MainSystem;

    public RateReviewFrame(IUserFunctions MainSystem,Books book,String username) {
        super("Bookweb");
        setSize(300, 100);
        setLocation(50,50);
        this.MainSystem = MainSystem;
        JPanel Panel = new RateReviewItems(this,this.MainSystem,book,username);
        add(Panel);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setVisible(true);



    }
}
