/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difaces;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class Launcher {
    private Entity[] entities;

    public Launcher(Entity[] entities) {
        this.entities = entities;
        backtracking(0, new int[entities.length], new int[entities.length]);
    }
    
    public void backtracking(int stage, int[] sol, int[] bestSol){
        int i;
        if(stage == sol.length){
            
            if(isBetter(sol, bestSol)){
                    System.arraycopy(sol,0,bestSol,0,sol.length);
                    print(bestSol);
            }
            
        }else{
            for(i = 0; i <= 1; i++){
                if(!areOverlapped(sol, entities[stage]))
                    sol[stage] = i;
                
                backtracking(stage+1, sol, bestSol);
            }
        }
    }
    
    public void print(int[] array){
        for(int i : array)
            System.out.print(i+" ");
        System.out.println("");
    }
    
    public boolean areOverlapped(int[] array, Entity e){
        for(int i = 0; i < array.length; i++){
            if(entities[i].isOverlapped(e) && array[i] == 1)
                return true;
        }
        return false;
    }
    
    public boolean isBetter(int[] array1, int[] array2){
        return getTotalSum(array1) > getTotalSum(array2);
    }
    
    public double getTotalSum(int[] array){
        int sum = 0;
        for(int i = 0; i < array.length; i++){
            if(array[i] == 1)
                sum += entities[i].getTotal();
        }
        //System.out.println(sum);
        return sum;
    }
    
}
