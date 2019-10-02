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
public class TelescopicSeries {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        int N = 3;
        
        System.out.println(telescopicIterative(N));
        System.out.println(telescopicRecursive(N));
    }
    
    public static double telescopicRecursive(int n){
        double sum;
        if(n == 0)
            sum = 0;
        else
            sum = (Math.pow(-1, n-1) / Math.pow(n, 2)) + telescopicRecursive(n-1);
        
        return sum;
    }
    
    public static double telescopicIterative(int n){
        double result=0;
        for(int i = 1; i <= n; i++)
            result = result +(1/ (Math.pow(i, 2)))*((Math.pow(-1, i-1)));        
        return result;
    }
    

}
