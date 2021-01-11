package Frames;

import Classess.IUserFunctions;

import javax.swing.*;
import java.awt.*;

public class RegisterFrame extends JFrame {
    IUserFunctions MainSystem;
    public static void RegisterFrame(String[] args) {

}

    public RegisterFrame(IUserFunctions MainSystem) {
        super("Bookweb");
        setSize(300, 100);
        setLocation(50,50);
        this.MainSystem = MainSystem;
        JPanel Panel = new RegisterItems(this,this.MainSystem);
        add(Panel);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        pack();
        setVisible(true);



    }
}
