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
public class Entidad {
    private static int contador=0;
    private int id;    
    private int mesInicio;
    private int mesFin;
    private double rentabilidad;

    public Entidad(int mesInicio, int mesFin, double rentabilidad) {
        this.id = contador++;        
        this.mesInicio = mesInicio;
        this.mesFin = mesFin;
        this.rentabilidad = rentabilidad;
    }

    public int getId() {
        return id;
    }

    public int getMesInicio() {
        return mesInicio;
    }

    public int getMesFin() {
        return mesFin;
    }

    public double getRentabilidad() {
        return rentabilidad;
    }
    
    public double getTotal (){
        return (this.mesFin-this.mesInicio + 1)*this.rentabilidad;
    }
            
    public boolean esSolapable(Entidad e){
        boolean solapado = false;
        
        if(e.getMesFin() >= this.mesInicio && e.getMesFin() <= this.mesFin)
            solapado = true;
        
        if(e.getMesInicio() <= this.mesFin && e.getMesInicio() >= this.mesInicio)
            solapado = true;
        
        if(e.getMesInicio() <= this.mesInicio && e.getMesFin() >= this.mesFin)
            solapado = true;
        
        return solapado;
    }     
    
    
}
