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
        //print(sol);
    }
    
    private LinkedList<Entidad> backtracking(int stage, LinkedList<Entidad> mejor, LinkedList<Entidad> escogidas){
        int i;
        if(stage == entidades.length && esMejor(escogidas, mejor)){
            mejor = escogidas;
            System.out.println(mejor);
            return mejor;
        }else{
            for(i = 0; i < entidades.length; i++){
                if(escogidas.isEmpty())
                    escogidas.add(entidades[i]);
                else
                    if(!seSolapan(escogidas, entidades[i]))
                        escogidas.add(entidades[i]);
                    
                backtracking(stage+1, mejor, escogidas);
            }
        }
        return null;
    }
    
    
    private boolean seSolapan(LinkedList<Entidad> lista, Entidad e){
        boolean seguir = true;
        for(int i = 0; i < lista.size() && seguir; i++)
            seguir = lista.get(i).esSolapable(e);
        
        return seguir;
    }
    
    private void rellenar(Entidad e, int[] year){
        for(int i = e.getMesInicio()-1; i < e.getMesFin(); i++)
            year[i] = e.getId();
    }
    
    private boolean esMejor(LinkedList<Entidad> actual, LinkedList<Entidad> mejor){
        int sum = 0, mSum = 0;
        for(Entidad e : actual)
            sum += e.getTotal();
        
        for(Entidad e : mejor)
            mSum += e.getTotal();
        
        
        return sum > mSum;
    }
}
