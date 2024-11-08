using System;

namespace Solucion
{
    public class Tabla
    {
        private double _ancho;
        private double _largo;
        private double _precio;
        
        private double _precioBase;

        public Tabla(double ancho, double largo, double precioBase)
        {
            _ancho = ancho;
            _largo = largo;
            _precioBase = precioBase;
            recalcularPrecio();
        }

        public void SetAncho(double ancho) {
            _ancho = ancho;
            recalcularPrecio();
        }
        
        public void SetLargo(double largo) {
            _largo = largo;
            recalcularPrecio();
        }

        private void recalcularPrecio() {
            _precio = _ancho * _largo * _precioBase;
        }

        public double GetAncho() {
            return _ancho;
        }

        public double GetLargo() {
            return _largo;
        }

        public double GetPrecio() {
            return _precio;
        }
    }
}
