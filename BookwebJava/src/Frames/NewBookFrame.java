package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;

public class NewBookFrame extends JFrame {
    IUserFunctions MainSystem;
    public static void RegisterFrame(String[] args) {

    }

    public NewBookFrame(IUserFunctions MainSystem,String username) {
        super("Bookweb");
        setSize(300, 100);
        setLocation(50,50);
        this.MainSystem = MainSystem;
        JPanel Panel = new NewBookItems(this,this.MainSystem,username);
        add(Panel);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setVisible(true);



    }
}
