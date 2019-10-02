/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difaces;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class GivenDice {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        final int rolls = 3;
        final int overcome = 16;
        int[] values = new int[rolls];
        
        for(int i = 0; i < values.length; i++)
            values[i] = -1;
        
        recursiveDice(values, overcome, 0);
    }
    
    public static void recursiveDice(int[] values, int over, int pos){
        if(values[values.length-1] != -1){ //Esta lleno
            int total = 0;
            for(int i = 0; i<values.length;i++)
                total += values[i];
            
            if(total > over)//Es solucion
                print(values);
        }else{ //caso general
            for(int i = 1; i <= 6; i++){
                values[pos] = i;
                recursiveDice(values, over, pos+1);
            }
        }
    }
    
    
    public static void print(int[] array){
        for(int i = 0; i < array.length; i++)
            System.out.printf("%d\t",array[i]);
        
        System.out.println();
    }
    

}
