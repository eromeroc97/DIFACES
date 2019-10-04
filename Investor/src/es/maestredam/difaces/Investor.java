/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difaces;

import java.util.Arrays;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class Investor {

    private static Entidad[] lista = new Entidad[11];
    
    public static void main(String[] args) {
        lista[0] = (new Entidad(1,"BBVA", 3, 4, 300));
        lista[1] = (new Entidad(2,"Bonos del Tesoro", 10, 12, 330));
        lista[2] = (new Entidad(3,"Lingotes", 2, 5, 340));
        lista[3] = (new Entidad(4,"La Caixa Bank", 3, 4, 310));
        lista[4] = (new Entidad(5,"GlobalCaja", 3, 4, 320));
        lista[5] = (new Entidad(6,"Bankinter", 4, 10, 350));
        lista[6] = (new Entidad(7,"Sabadell", 6, 7, 260));
        lista[7] = (new Entidad(8,"Bankia", 8, 11, 360));
        lista[8] = (new Entidad(9,"ING Direct", 2, 12, 310));
        lista[9] = (new Entidad(10,"OpenBank", 1, 7, 340));
        lista[10] = (new Entidad(11,"Popular", 7, 12, 325));

        ordenar(lista); //ordenamos por mayor rentabilidad
        
        backtracking(0, new int[12], new int[12]);
    }
    
    private static void backtracking(int stage, int[] best, int[] actual){
        int i;
        if(stage == 12){
            System.out.println(stage);
            //print(best);
            System.out.printf("\trentabilidad: %d\n",calcularRentabilidad(best));
            clear(actual);
            stage = 0;
            
        }else{
            for(i = 0; i < lista.length; i++){
                if(esPosible(actual, lista[i])){
                    colocar(lista[i], actual);
                    if(esMejor(actual, best))
                        best = actual;
                }
                backtracking(stage+1, best, actual);
            }    
        }
    }
    
    private static void ordenar(Entidad[] lista){
        Arrays.sort(lista);
    }
    
    private static boolean esPosible(int[] anio, Entidad e){
        boolean posible = true;
        for(int i = e.getMesInicio()-1; i < e.getMesFin() && posible; i++)
            if(anio[i] != 0)
                posible = false;
        
        return posible;
    }
    
    private static void colocar(Entidad e, int[] anio){
        for(int i = e.getMesInicio()-1; i < e.getMesFin(); i++)
            anio[i] = e.getId();
    }
    
    private static void clear(int[] anio){
        for(int i = 0; i < anio.length; i++)
            anio[i] = 0;
    }
    
    private static boolean esMejor(int[] anio, int[] mejor){
        return calcularRentabilidad(anio) > calcularRentabilidad(mejor);
    }
    
    private static int calcularRentabilidad(int[] anio){
        int sum = 0;
        for(int i = 0; i < anio.length; i++){
            if(anio[i] != 0)
                sum += lista[indexOfEntidad(anio[i])].getRentabilidad();
        }
        return sum;
    }
    
    private static int indexOfEntidad(int id){
        for(int i = 0; i < lista.length; i++)
            if(lista[i].getId() == id)
                return i;
        
        return -1;
    }
    
    private static void print(int[] array){
        for(int i = 0; i < array.length; i++)
            System.out.printf("%d\t",array[i]);
    }
    
}
