/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package exam;

import java.util.ArrayList;
import java.util.Random;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class Square {
    private static Random rand = new Random();
    private static final int MAX_COINS = 5;
    private final int POSX;
    private final int POSY;
    private boolean visited;
    private int coins;
    
    public Square(int posX, int posY) {
        this.POSX = posX;
        this.POSY = posY;
        this.visited=false;
        this.coins = rand.nextInt(MAX_COINS + 1); //We fill the square with a random
                                //number of coins between 0 and a maximun number
    }

    public int getCoins() {
        return coins;
    }
    
    public void setVisited(boolean visited) {
        this.visited = visited;
    }

    public boolean isVisited() {
        return visited;
    }

    public int getPosX() {
        return POSX;
    }

    public int getPosY() {
        return POSY;
    }
    
    public boolean equals(Square s){
        return (this.POSX==s.getPosX() && this.POSY==s.getPosY());
    }
    @Override
    public String toString(){
        return "("+POSX+", "+POSY+")";
    }

    public boolean isInside(int limInf, int limSup) {
        return POSX>=limInf&&POSX<limSup&&POSY>=limInf&&POSY<limSup;
    }

    public ArrayList<int[]> getAdjacents() {
        ArrayList<int[]> adjacentValues = new ArrayList<>();
        
        for(int i = -1; i <= 1; i++){ 
            for(int j = -1; j <= 1; j++){
                if(i != 0 && j != 0){
                    adjacentValues.add(new int[]{i, j});
                }
            }
        }        
        return adjacentValues;
    }
}
