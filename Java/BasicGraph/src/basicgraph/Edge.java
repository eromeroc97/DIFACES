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
public class Edge<T> {
    private Node src;
    private Node trg;
    private T property;
    
    public Edge(Node src, Node trg){
        this.src = src;
        this.trg = trg;
    }
    
    public Edge(Node src, Node trg, T property){
        this.src = src;
        this.trg = trg;
        this.property = property;
    }
    
    public Node getSource(){
        return this.src;
    }
    
    public Node getTarget(){
        return this.trg;
    }
    
    public void setProperty(T property){
        this.property = property;
    }
    
    public T getProperty(){
        return this.property;
    }
}
