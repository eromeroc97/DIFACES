/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package bruteforce;

import java.io.IOException;
import java.util.Random;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class BruteForce {

    /**
     * @param args the command line arguments
     */
    
    private final String PASSWD_CHARS = "ABCDEFGHIJKLMNOPQRTSUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
    public final int START_VALUE = 0;
    
    private String generatePassword(int length){
        StringBuilder sbPasswd = new StringBuilder();
        Random rand = new Random();
        
        for(int i = 0; i < length; i++){
            sbPasswd.append(PASSWD_CHARS.charAt(rand.nextInt(PASSWD_CHARS.length())));
        }
        System.out.printf("### GENERATED PASSWORD [ %s ] ###\n", sbPasswd.toString());
        return sbPasswd.toString();
    }
    
    /*
    
        a               b...     
    aa  ab  ac...    ba bb bc...  
    */
    
    private void crackPassword(char[] arr, int i, String s, int len, String buscada){ 
        if (i == 0){ 
            System.out.printf("\tTrying with: %s\n",s); 
            return; 
        } 
  
        for (int j = 0; j < len; j++){
            
            String appended = s + arr[j];
            if(appended.equals(buscada)){
                
                System.out.printf("Unlocked: %s\n",appended);
                System.out.println("*** PASSWORD HAS BEEN CRACKED ***");
                System.exit(0);
            }
            crackPassword(arr, i - 1, appended, len, buscada); 
            
        }
    }
    
    private void crackPassword(int length, String passwd) 
    {
        for (int i = 1; i <= length; i++) 
        { 
            crackPassword(PASSWD_CHARS.toCharArray(), i, "", PASSWD_CHARS.length(), passwd);
        } 
    } 

    
    private final static Scanner Teclado = new Scanner(System.in);
    public static void main(String[] args) {
        System.out.print("Choose a length for a new password: ");
        int leido = Teclado.nextInt();
        BruteForce bf = new BruteForce();
        String passwd = bf.generatePassword(leido);
        System.out.println("Click ENTER to start Brute Force");
        try {
            System.in.read();
        } catch (IOException ex) {}
        bf.crackPassword(leido, passwd);
        long end = System.nanoTime();
    }

}
