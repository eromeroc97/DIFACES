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
public class Entidad implements Comparable{
    private int id;
    private String nombre;
    private int mesInicio;
    private int mesFin;
    private int rentabilidad;

    public Entidad(int id, String nombre, int mesInicio, int mesFin, int rentabilidad) {
        this.id = id;
        this.nombre = nombre;
        this.mesInicio = mesInicio;
        this.mesFin = mesFin;
        this.rentabilidad = rentabilidad;
    }

    public int getId() {
        return id;
    }

    public String getNombre() {
        return nombre;
    }

    public int getMesInicio() {
        return mesInicio;
    }

    public int getMesFin() {
        return mesFin;
    }

    public int getRentabilidad() {
        return rentabilidad;
    }

    @Override
    public int compareTo(Object o) {
        Entidad e = (Entidad) o;
        return e.rentabilidad - this.rentabilidad ;
    }
    
    
    
}
