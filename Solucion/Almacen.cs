using System;
using System.Collections;

namespace Solucion
{
    public class Almacen
    {
        private int _capacidadMaxima;
        private List<Tabla> _sortedList;
        private Tabla _tablaInicial;
        private double _precioBase;

        public Almacen(int capacidadMaxima, Tabla tablaInicial, double precioBase)
        {
            _capacidadMaxima = capacidadMaxima;
            _sortedList = new List();
            _precioBase = precioBase;

            _tablaInicial = tablaInicial;
        }

        public Tabla? GetTabla(double ancho, double largo) {
            Tabla? return_table = null;
            for (int pos_tabla = 0; pos_tabla < _sortedList.Count(); ++pos_tabla) {
                if (_sortedList[pos_tabla].GetAncho() >= ancho && _sortedList[pos_tabla].GetLargo() >= largo) {
                    return_table = cortarTabla(_sortedList[pos_tabla], ancho, largo);
                    _sortedList.RemoveAt(pos_tabla);
                }
            }

            if (return_table == null) {
                return_table = buyTable();
                if (return_table != null) {
                    cortarTabla(return_table, ancho, largo);
                }
            }
            
            return return_table;
        }

        private void cortarTabla(Tabla tabla, double ancho, double largo) {
            double anchoRestante = tabla.GetAncho() - ancho;
            if (anchoRestante != 0) {
                Tabla tablaRestante = new Tabla(anchoRestante, tabla.GetLargo(), _precioBase); 
                insertarATabla(tablaRestante);

                tabla.SetAncho(ancho);
            }

            double largoRestante = tabla.GetLargo() - largo;
            if (largoRestante != 0) {
                Tabla tablaResidual = new Tabla(ancho, largoRestante, _precioBase);
                insertarATabla(tablaResidual);

                tabla.SetLargo(largo);
            }
        }


        private void insertarATabla(Tabla tabla) {
            bool inserted = false;

            for (int sizes = 0; sizes < _sortedList.Count(); ++sizes) {
                if (_sortedList[sizes].GetAncho() >= tabla.GetAncho()) {
                    if (_sortedList[sizes].GetLargo() >= tabla.GetLargo()) {
                        _sortedList.Insert(sizes, tabla);
                    }
                }
            }

            if (!inserted && _sortedList.Count() < _capacidadMaxima) {
                _sortedList.Add(tabla);
            }
        }
        
        private Tabla? buyTable() {
            if (_sortedList.Count() > _capacidadMaxima) {
                return null;
            }

            return _tablaInicial;
        }
    }
}
