/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package beans1;

import java.io.Serializable;

public class MiPrimerBean implements Serializable {   
    
    public MiPrimerBean() {
        this.propiedad = "";

    }
    
    private String propiedad;
    
    public String getPropiedad(){
        return this.propiedad;
    }
    public void setPropiedad(String propiedad) {
        this.propiedad = propiedad;
    }
    
    //Propiedad booleana
    private boolean boolProp;
    
    public boolean isBoolProp() {
        return boolProp;
    }

    public void setBoolProp(boolean boolProp) {
        this.boolProp = boolProp;
    }
    
    // propiedad indexadas
    private int[] numeros = {1, 2, 3, 4};

    //para el array completo
    public void setNumeros(int[] nuevoValor){
        numeros = nuevoValor;
    }
    public int[] getNumeros(){
        return numeros;
    }
    
    //para un solo elemento del array
    public void setNumeros(int indice, int nuevoValor){
        numeros[indice] = nuevoValor;
    }
    public int getNumeros(int indice){
        return numeros[indice];
    }

}
