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
        lista[0] = (new Entidad(3, 4, 300));
        lista[1] = (new Entidad(10, 12, 330));
        lista[2] = (new Entidad(2, 5, 340));
        lista[3] = (new Entidad(3, 4, 310));
        lista[4] = (new Entidad(3, 4, 320));
        lista[5] = (new Entidad(4, 10, 350));
        lista[6] = (new Entidad(6, 7, 260));
        lista[7] = (new Entidad(8, 11, 360));
        lista[8] = (new Entidad(2, 12, 310));
        lista[9] = (new Entidad(1, 7, 340));
        lista[10]= (new Entidad(7, 12, 325));
        
        new VueltaAtras(lista);
    }
    
    
   
    
    
}
