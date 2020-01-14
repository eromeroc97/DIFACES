/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package basicgraph;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class Node<T> {
    private int code;
    private T element;
    
    public Node(int code, T element){
        this.code = code;
        this.element = element;
    }
    
    public int getCode(){
        return this.code;
    }
    
    public T getElement(){
        return this.element;
    }
}
