package Frames;
import Classess.*;
import java.awt.*;
import java.lang.System;

import javax.swing.*;
public class MainMenuFrame extends JFrame {
    IUserFunctions MainSystem;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() { new MainMenuFrame(new MainSystem()); }
        });
    }

    public MainMenuFrame(IUserFunctions MainSystem) {
        super("Bookweb");
        setSize(300, 100);
        setLocation(50,50);
        this.MainSystem = MainSystem;
        JPanel Panel = new MainMenuItems(this,this.MainSystem);
        add(Panel);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setVisible(true);


    }

}