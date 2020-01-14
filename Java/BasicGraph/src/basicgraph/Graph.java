/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package basicgraph;

import java.util.LinkedList;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class Graph<T> {
    private LinkedList<Node> nodes;
    private LinkedList<Edge> edges;
    
    public Graph(){
        this.nodes = new LinkedList<>();
        this.edges = new LinkedList<>();
    }
    
    public Graph(LinkedList<Node> nodes, LinkedList<Edge> edges){
        this.nodes = nodes;
        this.edges = edges;
    }
    
    public LinkedList<Node> getAllNodes(){
        return this.nodes;
    }
    
    public LinkedList<Edge> getAllEdges(){
        return this.edges;
    }
    
    public void addNode(Node n){
        nodes.add(n);
    }
    
    public void addEdge(Edge e){
        edges.add(e);
    }
    
    public void addEdge(Node src, Node trg, T property){
        Edge e = new Edge(src, trg, property);
        edges.add(e);
    }
    
    public Node getOpposite(Node n, Edge e){
        if(e.getSource().equals(n))
            return e.getTarget();
        else if(e.getTarget().equals(n))
            return e.getSource();
        else
            return null;
    }
}
