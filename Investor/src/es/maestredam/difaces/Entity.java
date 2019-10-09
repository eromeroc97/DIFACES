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
public class Entity {
    private static int counter=0;
    private int id;    
    private int startMonth;
    private int endMonth;
    private double profit;

    public Entity(int startMonth, int endMonth, double profit) {
        this.id = ++counter;        
        this.startMonth = startMonth;
        this.endMonth = endMonth;
        this.profit = profit;
    }

    public int getId() {
        return id;
    }

    public int getStartMonth() {
        return startMonth;
    }

    public int getEndMonth() {
        return endMonth;
    }

    public double getProfit() {
        return profit;
    }
    
    public double getTotal (){
        return (this.endMonth-this.startMonth + 1)*this.profit;
    }
            
    public boolean isOverlapped(Entity e){
        boolean overlapped = false;
        
        if(e.getEndMonth() >= this.startMonth && e.getEndMonth() <= this.endMonth)
            overlapped = true;
        
        if(e.getStartMonth() <= this.endMonth && e.getStartMonth() >= this.startMonth)
            overlapped = true;
        
        if(e.getStartMonth() <= this.startMonth && e.getEndMonth() >= this.endMonth)
            overlapped = true;
        
        return overlapped;
    }     
    
    
}
