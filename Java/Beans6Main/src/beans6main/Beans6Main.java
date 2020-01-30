/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package beans6main;

import beans6.Producto;
import beans6.Pedido;
import beans6.Venta;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

/**
 *
 * @author Eugenio Romero Ciudad
 */
public class Beans6Main {

    public static void main(String[] args) {
        try {
            Class.forName("oracle.jdbc.driver.OracleDriver");
            Connection conexion = DriverManager.getConnection("jdbc:oracle:thin:@10.14.0.200:1521:ds01","ORACLE4","ORACLE4");
            
            Producto p = buscarProducto(conexion, 2);
            System.out.println(p != null);
            
            conexion.close();
        } catch (ClassNotFoundException ex) {
            System.out.println(ex.getMessage());
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
    }
    
    
    public static Producto buscarProducto(Connection con, int idProducto){
        Producto p = null;
        try {
            String sql = "SELECT * FROM PRODUCTOS WHERE IDPRODUCTO="+idProducto;
            Statement sentencia = con.createStatement();
            ResultSet rs = sentencia.executeQuery(sql);
            
            while(rs.next()) {
                p = new Producto(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getInt(4), rs.getFloat(5));    
            }
            rs.close(); // Cerrar ResultSet
            sentencia.close(); // Cerrar Statement
            
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
        return p;
    }
    
    public static void crearVenta(Connection con, Producto p, int cantidad){
        //comprobar que hay stock para la cantidad
        //crear la venta
        //insertar venta y actualizar cantidad del producto
    }

}
