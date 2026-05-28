using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_GIT
{

    public class Vehiculos
    {

        public string marca;
        public string modelo;
        public string anioFabricacion;
        public string color;
        public string matricula;
        public bool tieneLuces;
        public string tipo;
        public string maxVelocity;
        public bool esElectrico;
        public string placa;
        private bool estado;

        public Vehiculos() { }

        public bool encender()
        {

            return this.estado = true;
        }

        public bool apagar()
        {

            return this.estado = false;
        }

        public string getEstado()
        {
            if (this.estado == true)
            {
                return "Encendido";
            }

            return "Apagado";
        }

    }

    public class Automovil : Vehiculos
    {
        private int cantRuedas;
        public int cantPuertas;
        public string uso; //si es privado/publico
        public string segmento;
        public string motor;
        public string tipoCombustible;
        public bool tieneEspejos;
        public int pasajeros;
        private int kilometraje;
        string nombre;

        public Automovil (string? name)
        {

            this.nombre = name ?? "Coshita";
        }

        public void acelerar(int velocidad, int tiempo)
        {
            if (this.getEstado() == "Encendido")
            {
                this.kilometraje += velocidad * tiempo / 1000;
            }

            //this.kilometraje = 0;

        }

        public int getKilometroRecorridos()
        {
            return this.kilometraje;
        }
    }
}
