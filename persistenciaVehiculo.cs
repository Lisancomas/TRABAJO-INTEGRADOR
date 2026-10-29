using System;
using System.IO;
using System.Collections.Generic;

namespace Agencia
{
    public class PersistenciaVehiculos
    {
        public static void GuardarVehiculos(List<Vehiculo> lista, string ruta)
        {
            // HUECO 1: Abre el escritor seguro en modo sobrescritura
            using (StreamWriter sw = new StreamWriter(ruta, append: false))
            {
            //NO TENGO LAS CLASES DE TIPO DE VEHICULOS
            foreach(Vehiculo b in lista)
            {
                if(b is Auto a)
                {
                    string lineacompleta = $"Auto;{a.Patente};{a.Marca};{a.Modelo};{a.anio};{a.Precioxdia};{a.Disponible};{a.CantPuertas};{a.EsAutomatico}";
                    sw.WriteLine(lineacompleta);
                }
                else if(b is Moto m)
                    {
                    string lineacompleta = $"Moto;{m.Patente};{m.Marca};{m.Modelo};{m.anio};{m.Precioxdia};{m.Disponible};{m.Cilindrada}";
                    sw.WriteLine(lineacompleta);
                    }
                else if(b is Camioneta c)
                    {
                    string lineacompleta = $"Camioneta;{c.Patente};{c.Marca};{c.Modelo};{c.anio};{c.Precioxdia};{c.Disponible};{c.Es4x4};{c.CapacidadCargaKg}";
                    sw.WriteLine(lineacompleta);
                    }
            }
            }
        }

        public static List<Vehiculo> CargarVehiculos(string ruta)
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            // HUECO 2: Verificación de existencia previa
            if (File.Exists(ruta))
            {
                // HUECO 3: Creación del lector seguro
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        // HUECO 4: Troceado de la línea por ';'
                        string[] datos = linea.Split(';'); //tuve q revisar q comando era xq me lo confundi con Parse xd

                        string patente = datos[1];
                        string marca = datos[2];
                        string modelo = datos[3];
                        int anio = int.Parse(datos[4]);
                        double precio = double.Parse(datos[5]);
                        bool disponibilidad = bool.Parse(datos[6]);

                        if(datos[0] == "Auto")
                        {
                            int puertas = int.Parse(datos[7]);
                            bool esautomatico = bool.Parse(datos[8]);

                        Vehiculo v = new Auto(patente, marca, modelo, anio, precio, disponibilidad, puertas, esautomatico); //datos de muestra
                        lista.Add(v);
                        }
                        else if(datos[0] == "Moto")
                        {
                            double cilindrada = double.Parse(datos[7]);
                        Vehiculo v = new Moto(patente, marca, modelo, anio, precio, disponibilidad, cilindrada); //datos de muestra
                        lista.Add(v);    
                        }
                        else if(datos[0] == "Camioneta")
                        {
                            bool es4x4 = bool.Parse(datos[7]);
                            double capacidadcargakg = double.Parse(datos[8]);
                        Vehiculo v = new Camioneta(patente, marca, modelo, anio, precio, disponibilidad, es4x4, capacidadcargakg); //datos de muestra
                        lista.Add(v);     
                        }
                    }
                }
            }
            return lista;
        }
    }
}