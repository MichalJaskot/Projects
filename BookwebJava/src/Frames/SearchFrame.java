package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;

public class SearchFrame extends JFrame {
    IUserFunctions MainSystem;

    public SearchFrame(IUserFunctions MainSystem,String username) {
        super("Bookweb");
        setSize(300, 100);
        setLocation(50,50);
        this.MainSystem = MainSystem;
        JPanel Panel = new SearchItems(this,this.MainSystem,username);
        add(Panel);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setVisible(true);



    }
}
