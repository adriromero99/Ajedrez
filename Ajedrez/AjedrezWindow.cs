﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajedrez {
    public partial class AjedrezWindow : Form {

        private Tablero tablero;

        public AjedrezWindow() {
            this.tablero = new Tablero();
            tablero.inicializarTablero();
            InitializeComponent();
         }

        private void AjedrezWindow_Load(object sender, EventArgs e) {
            tablero.incializarVista(this);
        }
 
    }
}
