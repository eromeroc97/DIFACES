package pruebajavabeans;

import MisBeans.Producto;
import MisBeans.Pedido;

public class PruebaJavaBeans {

    public static void main(String[] args) {
        Producto producto = new Producto (1, "Raton USB", 10, 3, 16);
        Pedido pedido = new Pedido();
        pedido.setProducto(producto);
        producto.addPropertyChangeListener(pedido);
        producto.setStockactual(2);
    }

}
