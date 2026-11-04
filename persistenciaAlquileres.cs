using System;
using System.IO;
using System.Collections.Generic;

namespace Agencia
{
    public class PersistenciaAlquileres
    {
        public static void GuardarAlquiler(List<Alquiler> lista, string ruta)
        {
            using (StreamWriter sw = new StreamWriter(ruta, append: false))
            {
                foreach(Alquiler a in lista)
                {
                    string lineaAlquiler = $"{a.Cliente.Dni};{a.Vehiculo.Patente};{a.CantidadDias};{a.CostoTotal}";
                    sw.WriteLine(lineaAlquiler);
                }
            }
        }
        public static List<Alquiler> CargarAlquiler(List<Cliente> clientes, List<Vehiculo> vehiculos, string ruta)
        {
            List<Alquiler> lista = new List<Alquiler>();

            if (File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(';');
                        
                        int dni = int.Parse(datos[0]);
                        Cliente definitivo = null;
                        foreach(Cliente c in clientes)
                        {
                            if(c.Dni == dni)
                            {
                             definitivo = c;  
                            }
                        }
                        string patente =  datos[1];
                        Vehiculo otrodefinitivo = null;
                        foreach(Vehiculo d in vehiculos)
                        {
                            if(d.Patente == patente)
                            {
                             otrodefinitivo = d;  
                            }
                        }
                        int cantdias = int.Parse(datos[2]);
                        double costtotal = double.Parse(datos[3]);
                        if (definitivo != null && otrodefinitivo != null)
                        {
                            Alquiler a = new Alquiler(definitivo, otrodefinitivo, cantdias);
                        lista.Add(a);
                        }

                    }
                }
            }
            return lista;
        }
    }
}