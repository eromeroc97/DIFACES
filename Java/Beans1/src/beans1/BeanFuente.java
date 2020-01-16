/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package beans1;

import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeSupport;
import java.io.Serializable;

/**
 *
 * @author Eugenio Romero ciudad
 */
public class BeanFuente implements Serializable {

private PropertyChangeSupport propertySupport;

    public BeanFuente () {

    propertySupport = new PropertyChangeSupport(this);

    }
    public void addPropertyChangeListener (PropertyChangeListener listener) {

    propertySupport.addPropertyChangeListener(listener);

    }
    public void removePropertyChangeListener(PropertyChangeListener listener) {

    propertySupport.removePropertyChangeListener(listener);

    }
}
