/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package es.maestredam.difaces;

import java.util.LinkedList;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class VueltaAtras {
    private Entidad[] entidades;

    public VueltaAtras(Entidad[] entidades) {
        this.entidades = entidades;
        LinkedList<Entidad> sol = backtracking(0, new LinkedList<Entidad>(), new LinkedList<Entidad>());
        System.out.println("Fin");
        System.out.println(sol);
    }
    
    private LinkedList<Entidad> backtracking(int stage, LinkedList<Entidad> mejor, LinkedList<Entidad> escogidas){
        int i;
        if(stage >= entidades.length && esMejor(escogidas, mejor)){
            mejor = escogidas;
            print(mejor);
            escogidas.clear();
            return mejor;
        }else{
            for(i = 0; i < entidades.length; i++){
                if(!seSolapan(escogidas, entidades[i])){
                    escogidas.add(entidades[i]);
                }  
                
            }
        }
        return null;
    }
    
    
    private boolean seSolapan(LinkedList<Entidad> lista, Entidad e){
        boolean seguir = false;
        for(int i = 0; i < lista.size() && !seguir; i++)
            seguir = lista.get(i).esSolapable(e);
        
        return seguir;
    }
        
    private boolean esMejor(LinkedList<Entidad> actual, LinkedList<Entidad> mejor){
        int sum = 0, mSum = 0;
        for(Entidad e1 : actual)
            sum += e1.getTotal();
        
        for(Entidad e2 : mejor)
            mSum += e2.getTotal();
        
        
        return sum > mSum;
    }
    
    private void print(LinkedList<Entidad> lista){
        for(Entidad e : lista)
            System.out.print(e.getId()+" , ");
        System.out.println("");
    }
    
}
