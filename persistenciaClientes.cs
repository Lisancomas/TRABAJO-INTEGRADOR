using System;
using System.IO;
using System.Collections.Generic;

namespace Agencia
{
    public class PersistenciaClientes
    {
    public static void GuardarClientes(List<Cliente> listaC, string ruta)
        {
            using (StreamWriter sw = new StreamWriter(ruta, append: false))
            {
                foreach(Cliente c in listaC)
                {
                    string persona = $"{c.Dni};{c.Nombre};{c.Apellido};{c.Telefono}";
                    sw.WriteLine(persona);
                }
            }
        } //explicacion teorica del sw: Primero instanciamos el metodo estatico GuardarClientes llamamndo a la List<Clientes>, e instanciando una variable ruta para su manejo (ruta es la variable que hace de "puntero" de Clientes.csv). 
          //luego, utilizando el termino obligatorio using para q se libere la memoria al terminar el proceso, instanciamos el StreamWriter con la variable sw para su manipulacion y instanciando entre parentesis que pide la variable ruta y, un append: false, que sobreescribe el proyecto y nos permite iniciar el proyecto desde 0, no como el true q solo instancia al final del mismo.
          //lo siguiente es instanciar el foreach que recorre toda la list<Cliente>, y va a crear un texto con los datos de cada cliente divididos entre (;) para su distincion, guardando ese mismo texto en un archivo .csv en la memoria fisica de la computadora.
    public static List<Cliente> CargarClientes (string ruta)
        {
            List<Cliente> lista = new List<Cliente>(); //instanciacion de lista previo a comprobarla.

            if(File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(';'); //dice q va a parsear la variable linea q contiene los datos anteriormente seteados x el sw, y q los va a guardar en un arreglo de string llamado 'datos'.

                        int dni = int.Parse(datos[0]);
                        string nombre = datos[1];
                        string apellido = datos[2];
                        int telefono = int.Parse(datos[3]); //convierte los datos ingresados en el sw a variables que utilizaremos para generear las lineas y guardarlas.

                        Cliente c = new Cliente(nombre, apellido, dni, telefono); //aca se instancia la Lista<Cliente>  con los datos ingresados.
                        lista.Add(c);

                    }
                }
            }
            return lista;
        }
    }
}    
