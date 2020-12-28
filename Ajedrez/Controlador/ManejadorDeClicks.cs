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
    public ManejadorDeClicks(Tablero tablero) {
        this.tablero = tablero;
        posicionInicial = new Posicion(0, 0);
        posicionFinal = new Posicion(0, 0);
        hayPosicionInicial = false;
        piezaVistaAnterior = null;
    }
    public void manejar(Posicion posicionClickeada) {

        bool laPosicionClickeadaEstaVacia = tablero.piezaEn(posicionClickeada).obtenerColor() != "";

        if (!hayPosicionInicial && laPosicionClickeadaEstaVacia) {
            posicionInicial = posicionClickeada;
            hayPosicionInicial = true;
        } else {
            posicionFinal = posicionClickeada;
            if (tablero.moverPieza(posicionInicial, posicionFinal)) {
                hayPosicionInicial = false;

              
            } else if (laPosicionClickeadaEstaVacia) {
                //hayPosicionInicial = true;
                posicionInicial = posicionClickeada;
            }

        }
    }

    public void manejar(Posicion posicionClickeada, PiezaVista piezaVista) {
        if (piezaVistaAnterior != null) {
            piezaVistaAnterior.desresaltarPiezaBox();
        }
        piezaVistaAnterior = piezaVista;
        manejar(posicionClickeada);
        piezaVista.resaltarPiezaBox();
    }

}
