
package es.maestredam.difaces;

public class DiceRolls {
    private static final int MAX_VALUE = 6;
    private final int rolls;
    private final int overcome;
    private int n_sols;

    public DiceRolls(int rolls, int overcome) {
        this.rolls = rolls;
        this.overcome = overcome;
        this.n_sols = 0;
        int[] solutions = new int[rolls];
        backtracking(0, solutions);
        System.out.println("Number of Solutions: "+n_sols);
    }
    
    private void backtracking(int stage, int sol[]){
        int i;
        if(stage == sol.length){
            if(isSolution(sol)){
                print(sol);
                this.n_sols++;
            }
        }else{
            for(i = 1; i <= MAX_VALUE; i++){
                if(isPossible(i, stage, sol)){ //podar
                    sol[stage] = i;
                    backtracking(stage+1, sol); //ramificar
                }
            }
        }
             
    }
    
    private boolean isPossible(int next_val, int stage, int[] array){       
        int sum = 0;
        for(int i = 0; i < stage; i++)
            sum += array[i];
        
        sum += next_val;
        sum += (array.length - (stage+1))* MAX_VALUE;
        
        return sum > this.overcome;
    }
    
    private boolean isSolution(int[] array){
        int sum = 0;
        for(int i = 0; i < array.length; i++)
            sum += array[i];
        
        return sum > this.overcome;
    }
    
    private void print(int[] array){
        for(int i = 0; i < array.length; i++)
            System.out.printf("%d\t",array[i]);
        
        System.out.println();
    }
}
