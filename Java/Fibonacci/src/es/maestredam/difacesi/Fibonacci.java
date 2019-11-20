/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difacesi;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class Fibonacci {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        final int VALOR = 5;
        System.out.println(fibonacci(VALOR-1));
        System.out.println(fibonacci_it(VALOR));
        System.out.println(fibonacci_it_v2(VALOR));
    }
    
    public static int fibonacci(int n){
        int value;
        if (n < 2) value = n;
        else value = fibonacci(n-1)+fibonacci(n-2);
        return value;
    }
    
    public static int fibonacci_it(int n){
        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
            if(i < 2)
               arr[i] = i;
            else
               arr[i] = arr[i-1] + arr[i-2];
         return arr[n-1];
    }
    
    public static int fibonacci_it_v2(int n){
        int[] arr = new int[n+1];
        for(int i = 0; i <= n; i++)
            if(i < 2)
               arr[i] = i;
            else
               arr[i] = arr[i-1] + arr[i-2];
         return arr[n];
    }

}
