/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package bruteforce;

import java.util.Random;

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
    
    private void crackPassword(String passwd, String generated){
        int i;
        if(generated.equals(passwd)){
            System.out.printf("### PASSWORD HAS BEEN CRACKED ###\n");
        }else{
            for(i = 0; i < PASSWD_CHARS.length(); i++){
                generated += PASSWD_CHARS.charAt(i);
                crackPassword(passwd, generated);
            }
        }
    }
    
    
    public static void main(String[] args) {
        BruteForce bf = new BruteForce();
        String passwd = bf.generatePassword(1);
        bf.crackPassword(passwd, "");
    }

}
