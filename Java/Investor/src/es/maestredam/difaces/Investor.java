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

    private static Entity[] list = new Entity[11];
    
    public static void main(String[] args) {
        list[0] = (new Entity(3, 4, 300));
        list[1] = (new Entity(10, 12, 330));
        list[2] = (new Entity(2, 5, 340));
        list[3] = (new Entity(3, 4, 310));
        list[4] = (new Entity(3, 4, 320));
        list[5] = (new Entity(4, 10, 350));
        list[6] = (new Entity(6, 7, 260));
        list[7] = (new Entity(8, 11, 360));
        list[8] = (new Entity(2, 12, 310));
        list[9] = (new Entity(1, 7, 340));
        list[10]= (new Entity(7, 12, 325));
        
        new Launcher(list);
    }
    
    
   
    
    
}
