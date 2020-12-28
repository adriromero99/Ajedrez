using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Turnero {

    string turnoDeColor;

    public Turnero() {
        turnoDeColor = "Blanco";
    }
    public void actualizarTurno() {
        if (turnoDeColor == "Blanco") {
            turnoDeColor = "Negro";
        } else {
            turnoDeColor = "Blanco";
        }
    }


    public bool esElTurnoCorrespondiente(string colorPieza) {
        return colorPieza == turnoDeColor;
    }

}

