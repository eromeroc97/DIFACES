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
 * @author Eugenio Romero Ciudad
 */
public class MoneyMoney {

    private final static int BOARD_SIZE = 8;
    private static Random rand = new Random();
    
    public static void main(String[] args) {
        ArrayList<Path> paths = new ArrayList<>();
        final int TARGET_COINS = rand.nextInt(30)+30+1; //min value: 30 max value: 60
                                                        //including 60 to bound: +1
        
        //We initialize the board of coins
        Square[][] board = fillBoard();
        
        //Then we set a random source square and set it visited
        Square source = setRandomStartSquare();
        source.setVisited(true);
        board[source.getPosX()][source.getPosY()] = source;
        
        
        Path actualPath = new Path();
        actualPath.append(source);
        
        paths = DFS(TARGET_COINS, source, actualPath, paths, board);
        //System.out.println(paths);
        System.out.println(paths.get(0));
        System.out.println(paths.get(0).getValue());
    }
    
    private static Square[][] fillBoard(){
        Square[][] myBoard = new Square[BOARD_SIZE][BOARD_SIZE];
        for(int x = 0; x < BOARD_SIZE; x++){
            for(int y = 0; y < BOARD_SIZE; y++){
                myBoard[x][y] = new Square(x, y);
            }
        }
        return myBoard;
    }

    private static Square setRandomStartSquare(){
        int randomX = rand.nextInt(BOARD_SIZE);
        int randomY = rand.nextInt(BOARD_SIZE);
        return new Square(randomX, randomY);
    }
    
    private static ArrayList<Path> DFS(int TARGET, Square sq,
            Path actualPath, ArrayList<Path> possibles, Square[][] board){
        
        if(actualPath.getValue() == TARGET){
            possibles.add(new Path(actualPath));//we have find a solution
        }else{
            ArrayList<Square> adjacents = new ArrayList<>();
            ArrayList<int[]> possibleAdjacents = sq.getAdjacents();
            for(int[] pos : possibleAdjacents){ //getting all adjacents
                Square posCheck = new Square(pos[0],pos[1]);
                if(posCheck.isInside(0, board.length))
                    adjacents.add(board[pos[0]][pos[1]]);
            }
            
            for(Square actual : adjacents){
                actualPath.append(actual);
                actualPath.addToValue(actual.getCoins());
                DFS(TARGET, actual, actualPath, possibles, board);
                
                actualPath.remove(actual);
                actualPath.addToValue(-actual.getCoins());
                actual.setVisited(false);
                board[actual.getPosX()][actual.getPosY()]=actual;
            }
        }
        return possibles;
    }
    
}
