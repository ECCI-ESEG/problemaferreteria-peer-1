using System;

namespace Solucion
{
    public class Ferreteria
    {
        const int capacidadMaxima = 500;
        
        private Almacen _almacen;
        
        public Ferreteria(double anchoInicial, double largoInicial, double precioBase)
        {
            _almacen = new Almacen(capacidadMaxima, new Tabla(anchoInicial, largoInicial, precioBase), precioBase);
        }
        
        public double ProcesarSolicitud(double anchoSolicitado, double largoSolicitado)
        {
            Tabla? return_table = _almacen.GetTabla(anchoSolicitado, largoSolicitado);

            if (return_table == null) {
                return -1;
            }
            
            return return_table.GetPrecio();
        }
    }
}