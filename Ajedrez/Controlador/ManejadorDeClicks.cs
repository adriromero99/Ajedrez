using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ManejadorDeClicks {

    Tablero tablero;
    Posicion posicionInicial;
    Posicion posicionFinal;
    bool hayPosicionInicial;
    PiezaVista piezaVistaAnterior;
    PiezaVista piezaVistaActual;
    public ManejadorDeClicks(Tablero tablero) {
        this.tablero = tablero;
        posicionInicial = new Posicion(0, 0);
        posicionFinal = new Posicion(0, 0);
        hayPosicionInicial = false;
        piezaVistaAnterior = null;
    }
    public void manejar(Posicion posicionClickeada) {

        bool laPosicionClickeadaEstaVacia = tablero.piezaEn(posicionClickeada).obtenerColor() == "";

       

        if (!hayPosicionInicial && !laPosicionClickeadaEstaVacia) {
            posicionInicial = posicionClickeada;
            hayPosicionInicial = true;

            if (piezaVistaAnterior != null) {
                piezaVistaAnterior.desresaltarPiezaBox();
            }

        } else {
            posicionFinal = posicionClickeada;



            if (tablero.moverPieza(posicionInicial, posicionFinal)) {
                hayPosicionInicial = false;

                if (piezaVistaAnterior != null) {
                    piezaVistaAnterior.desresaltarPiezaBox();
                }

                tablero.actualizar();
            } else if (!laPosicionClickeadaEstaVacia) {

                hayPosicionInicial = true;
                posicionInicial = posicionClickeada;

                if (piezaVistaAnterior != null) {
                    piezaVistaAnterior.desresaltarPiezaBox();
                }

            } 

        }
    }

    public void manejar(Posicion posicionClickeada, PiezaVista piezaVista) {

        bool laPosicionClickeadaEstaVacia = tablero.piezaEn(posicionClickeada).obtenerColor() == "";

        piezaVistaActual = piezaVista;
        
        piezaVista.resaltarPiezaBox();

        manejar(posicionClickeada);

        if (!laPosicionClickeadaEstaVacia) {
            piezaVistaAnterior = piezaVista;
        }

      
    }

}
