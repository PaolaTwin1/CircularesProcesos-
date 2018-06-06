﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_CircularesAtención_de_procesos
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        Procesador proc = new Procesador();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            int contadorDeVacio = 0;
            int contadorDeCompletos = 0;
            int contadorCiclosquellegaron = 0;


            for (int i = 0; i < 300; i++)
            {
                if (rand.Next(1, 101) <= 35)
                {
                    Proceso nuevoP = new Proceso();
                    proc.enqueue(nuevoP);//Meter proceso
                    contadorCiclosquellegaron++;

                }
                Proceso vProceso = proc.peek(); //Ver primero de la cola
                if (vProceso != null)
                {
                    vProceso.ciclos--;
                    if (vProceso.ciclos == 0)
                    {
                        proc.dequeue();//saca proceso
                        contadorDeCompletos++;
                    }

                    proc.Avanzar();
                }
                else
                {
                    contadorDeVacio++; //si el procesador está vacío, suma uno al contador
                }

            }
            txtMostrar.Text = "Ciclos que estuvo vacía: " + contadorDeVacio.ToString() + Environment.NewLine
                                 + proc.procesosoPendientes() + Environment.NewLine + "Procesos completos: " + contadorDeCompletos.ToString() + Environment.NewLine
                                 + "Ciclos que llegaron: " + contadorCiclosquellegaron.ToString() + Environment.NewLine;
        }
    }
        
}
