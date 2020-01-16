/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package beans1;

import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class BeanReceptor implements PropertyChangeListener {

    public void propertyChange(PropertyChangeEvent evt) {
        System.out.println("Valor anterior: " + evt.getOldValue());
        System.out.println("Valor actual: " + evt.getNewValue());
    }
}
