/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difaces;

import java.util.LinkedList;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class Investor {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        LinkedList<Entidad> lista = new LinkedList<>();
        lista.add(new Entidad(1,"BBVA", 3, 4, 300));
        lista.add(new Entidad(2,"Bonos del Tesoro", 10, 12, 330));
        lista.add(new Entidad(3,"Lingotes", 2, 5, 340));
        lista.add(new Entidad(4,"La Caixa Bank", 3, 4, 310));
        lista.add(new Entidad(5,"GlobalCaja", 3, 4, 320));
        lista.add(new Entidad(6,"Bankinter", 4, 10, 350));
        lista.add(new Entidad(7,"Sabadell", 6, 7, 260));
        lista.add(new Entidad(8,"Bankia", 8, 11, 360));
        lista.add(new Entidad(9,"ING Direct", 2, 12, 310));
        lista.add(new Entidad(10,"OpenBank", 1, 7, 340));
        lista.add(new Entidad(11,"GlobalCaja", 7, 12, 325));
        
        int[] year = new int[12];
        
        backtracking(0, year, lista);
    }
    
    private static void backtracking(int stage, int[] year, LinkedList<Entidad> lista){
        System.out.println(stage);
        if(stage == lista.size()){
            print(year);
        }else{
            for(int i = stage; i < lista.size(); i++){
                if(isPossible(year, lista.get(i))){
                    colocarEntidad(lista.get(i), year);
                    backtracking(stage+1, year, lista);
                }
            }
        }
    }

    private static boolean isFull(int[] year) {
        boolean full = true;
        for(int i = 0; i < year.length && full; i++)
            if(year[i] == 0)
                full = false;
        
        return full;
    }
    
    private static void print(int[] array){
        for(int i = 0; i < array.length; i++)
            System.out.printf("%d\t",array[i]);
        
        System.out.println();
    }
    
    private static void colocarEntidad(Entidad e, int[] year){
        int id = e.getId();
        for(int i = e.getMesInicio()-1; i <= e.getMesFin()-1; i++)
            year[i] = id;
    }
    
    private static boolean isPossible(int[] year, Entidad e){
        boolean possible = true;
        for(int i = e.getMesInicio()-1; i <= e.getMesFin()-1 &&  possible; i++)
            if(year[i] != 0)
                possible = false;
        
        return possible;
    }
}
