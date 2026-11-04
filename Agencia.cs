using System;
using System.Collections.Generic;
using System.Net.WebSockets;

using System.IO;


namespace Agencia
{
    public class Agencia
    {
        public string Nombre { get; set; } 
        private List<Vehiculo> vehiculos;
        private List<Cliente> clientes;
        private List<Alquiler> alquileres;

        public Agencia(string nombre)
        {
            this.Nombre = nombre;
            
            vehiculos = new List<Vehiculo>();
            clientes = new List<Cliente>();
            alquileres = new List<Alquiler>();
           
        }
        public bool AgregarVehiculo(Vehiculo c)
        {
          if(!vehiculos.Exists(a => a.Patente == c.Patente))
          {
                 vehiculos.Add(c);
                return true;

          }
          else
            {
                
               return false;

            }
        }//FIN DEL METODO

         public bool EliminarVehiculo(string patente) 
        {
            Vehiculo v1 = null;
           if((v1 = vehiculos.Find(e => e.Patente == patente)) != null && (v1.Disponible == true)) 
            {      
                     vehiculos.Remove(v1);
                     return true;
                   
                
            }
            else
            {
                return false;
            }
        }
        public void ListadoVehiculo()
        {
           
          if(vehiculos.Count > 0)
            {    
               foreach(Vehiculo v in vehiculos)
                {
                    
                  Console.WriteLine(" >> {0} << ",v.ToString());

                }
            }
            else
            { 
                  Console.WriteLine(">> no hay vehiculos registrados en el sistema <<");
            }
        }//Llave de fin del metodo lista d vehiculos

        public void ListadoCliente()
        {     
            if (clientes.Count > 0)
            {
       
               

             foreach(Cliente c in clientes)
                {
                        Console.WriteLine($"DNI: {c.Dni} | Nombre: {c.Nombre} {c.Apellido} | Teléfono: {c.Telefono}");
                }  
            }
            else
            {
              
                Console.WriteLine(" >> No hay registro de cliente en el sistema <<");
            }
        }//fin del metodo


  
      public  bool AgregarCliente(Cliente v)
        {
            if(!clientes.Exists(e => e.Dni == v.Dni))
            {
                
                 clientes.Add(v);
            
                return true;
            }
            else
            {
                  return false;

            }
        }//finn de llave del metodo agregar ub cliente

        public void ListadoVseguro()
        {
            
            int cont = 0;
             Console.WriteLine("  >> Listado de vehiculos con seguro:    ");
             foreach(Vehiculo v in vehiculos)
            {
               
                
               if(v is IAsegurable) 
                {
                    
                Console.WriteLine(" >> {0} << ",v.ToString()); 
                cont++;
                }
            }
            if(cont == 0)
            {
                Console.WriteLine(" >> No hay vehiculos con seguro registrado en el sistema <<");
            }


            
         }//fin del metodo
            public void ListadoAlquileres()
        {
           
          if(alquileres.Count > 0)
            {   

                foreach(Alquiler a in alquileres)
                {

                 
                 Console.WriteLine($"Cliente DNI: {a.Cliente.Dni} ({a.Cliente.Nombre} {a.Cliente.Apellido}) | Vehículo: {a.Vehiculo.Patente} ({a.Vehiculo.Marca} {a.Vehiculo.Modelo}) | Días: {a.CantidadDias} | Total: ${a.CostoTotal}");


                }   
               


            }
            else
            {
              Console.WriteLine(" >> No hay alquileres registrados en el sistema <<");

            }



        }
           public double RealizarAlquileres(int  dni,string patente,int dias)
        {
            Vehiculo v1 = null;
             Cliente c1 = null;
          
       if( (v1 = vehiculos.Find(e => e.Patente == patente )) == null)
      {
        throw new Exception(" >> Error: patente ingresada no registrada  << ");
      }
           
      if((c1 = clientes.Find(e => e.Dni == dni)) == null)
      {
        
          throw new Exception(" >> Error: cliente ingresado no registrado  <<");

      }
      if(dias <= 0)
      {

        throw new Exception(" >> Error: La cantidad de días debe ser mayor a cero.  <<");
        
      }
      if (!v1.Disponible)
    {
        throw new VehiculoNoDisponibleException($" >> Error: El vehículo {v1.Patente} ya se encuentra alquilado. <<");
    }
   
           
            Alquiler alquiler = new Alquiler(c1,v1,dias);
            alquileres.Add(alquiler);            
            v1.Disponible = false;
            return alquiler.CostoTotal;

            }


        //archivos 
        public void guardarAlquileres()
        {
            
        PersistenciaAlquileres.GuardarAlquiler(alquileres,"AlquileresAgencia.txt");

        }
        public void cargarAlquileres()
        {
            
          alquileres = PersistenciaAlquileres.CargarAlquiler(clientes,vehiculos,"AlquileresAgencia.txt");

            
        }
        public void guardarClientes()
        {
            
         PersistenciaClientes.GuardarClientes(clientes, "ClientesAgencia.txt");


        }
        public void cargarClientes()
        {
            
          clientes = PersistenciaClientes.CargarClientes("ClientesAgencia.txt");


        }
        public void cargarVehiculos()
        {
             
          vehiculos =  PersistenciaVehiculos.CargarVehiculos("VehiculosAgencia.txt");

        }
       
          public void guardarVehiculos()
        {
            
          PersistenciaVehiculos.GuardarVehiculos(vehiculos ,"VehiculosAgencia.txt");

        }

      
    }
 
} 
