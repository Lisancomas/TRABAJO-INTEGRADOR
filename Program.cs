using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Agencia
{
    class Program
    {
        static void Main(string[] args)
        {

            Agencia MiAgencia = new ("Concesionario Automotriz");
            
            MiAgencia.cargarClientes();
            MiAgencia.cargarVehiculos();
            MiAgencia.cargarAlquileres();
            bool salir = false;

            while(!salir)
            {
             Console.Clear();
              Menu();

            Console.Write(" >> Ingrese su eleccion: ");
            int eleccion;
            while(!int.TryParse(Console.ReadLine() ,out eleccion))
            {
                   Console.WriteLine(" >> Error: El valor ingresado no es válido. Por favor, ingrese un número entero ");
                   Console.Write(" >> Ingrese su eleccion: ");
            }
         
       try{
          switch(eleccion)
          {
            case 1: 
            Console.Clear();
            if(AgregarVehiculo(MiAgencia)) Console.WriteLine("  >> Vehiculo registrado con exito ");
            else Console.WriteLine("  >> Error: El vehículo ya se encuentra registrado en el sistema ");
            Console.ReadKey();
            break;
            case 2: 
            Console.Clear();
            if(EliminarVehiculo(MiAgencia)) Console.WriteLine(" >> Vehiculo eliminado con exito");
            else Console.WriteLine(" >> Ocurrió un fallo al intentar eliminar el vehículo del registro");
            Console.ReadKey();
            break;
            case 3: 
            Console.Clear();
            if(RegistrarCliente(MiAgencia)) Console.WriteLine(" >> Cliente registrado con éxito en el sistema ");
            else Console.WriteLine(" >> Error: El cliente ya se encuentra registrado en el sistema ");
            Console.ReadKey();
            break;
            case 4:
              Console.Clear();  
            double valor = RegistrarAlquiler(MiAgencia);
            Console.WriteLine(" >> Monto total a abonar: {0}", valor);
            Console.ReadKey();
            break;
            case 5:
            Console.Clear();
            MiAgencia.ListadoVehiculo();
            Console.ReadKey();
            break;
            case 6:
            Console.Clear();
            MiAgencia.ListadoCliente();
            Console.ReadKey();
            break;
            case 7:
            Console.Clear();
            MiAgencia.ListadoAlquileres();
            Console.ReadKey();
            break;
            case 8:
            Console.Clear();
            MiAgencia.ListadoVseguro();
            Console.ReadKey();
            break;
            case 9:
            Console.Clear();
            Console.WriteLine(" >> Finalizando la ejecución del sistema. ");
            salir = true;
            break;
            default:
            Console.Clear();
            Console.WriteLine(" >> Opcion ingresada invalida. Se le regresarà al menù... ");
            Console.ReadKey();

            break;
  
          }
       }
       catch(Exception ex)
        {
          Console.WriteLine("{0}", ex.Message);
          Console.ReadKey();
        }
      
  }

            MiAgencia.guardarClientes();
            MiAgencia.guardarVehiculos();
            MiAgencia.guardarAlquileres();
           Console.ReadKey();
        }
       
        public static bool AgregarVehiculo(Agencia MiAgencia)
    {

       Console.WriteLine(">> selecciones el tipo de vehiculo  << ");
        Console.WriteLine(" 1.  Auto");
        Console.WriteLine(" 2. Camioneta");
        Console.WriteLine(" 3. Moto");
        Console.WriteLine(" >> Ingrese la opcion: ");     
        int opcion;
          if(!int.TryParse(Console.ReadLine(), out opcion))throw new Exception("  Error: tipo de dato invalido");
         if(opcion < 1 || opcion > 3) throw new Exception(" Error: eleccion invalida ");

         Console.Write(" >> Ingrese el marca: ");
         string marca = Console.ReadLine();
         Console.Write(" >> Ingrese modelo:");
         string modelo = Console.ReadLine();
        Console.Write(" >> Ingrese patente: ");
        string patente = Console.ReadLine();
        Console.Write(" >> Ingrese año: ");
        int anio;
        if(!int.TryParse(Console.ReadLine(), out anio) ) throw new Exception(" Error: Año invalido");
        Console.WriteLine(" >>Ingrese precio por dia: ");
        int precio;
        if(!int.TryParse(Console.ReadLine(),out precio) )throw new Exception(" Error: precio invalido");
         


        switch(opcion)
      {
         case 1: 
         Console.Write(" >> Ingrese cantidad de puerta: "); 
         int puertas = int.Parse(Console.ReadLine());
         Console.Write(" >> Ingrese si el vehiculo posee caja automatica(true/false): ");
         bool cajaAutomatica = bool.Parse(Console.ReadLine());
           return MiAgencia.AgregarVehiculo(new Auto(patente.ToUpper(),marca,modelo,anio,precio, puertas ,cajaAutomatica,true));  
         case 2:
          Console.Write(" >> Ingrese si el vehiculo es 4x4(true/false):" );
          bool cxc = bool.Parse(Console.ReadLine());
          Console.Write(" >> Ingrese la capacidad de carga: (sin especificar unidades de medida (kg, g, etc))");
          double carga = double.Parse(Console.ReadLine());
         return MiAgencia.AgregarVehiculo(new Camioneta(patente.ToUpper(),marca,modelo,anio,precio,carga,cxc,true) );
         case 3:
         Console.Write(" >> Ingrese la cilindrada del vehiculo: ");
         int cilindrada = int.Parse(Console.ReadLine());
         return MiAgencia.AgregarVehiculo(new Moto(patente.ToUpper(),marca,modelo,anio,precio,cilindrada, true));
      }
      return false;
      }
    public static bool RegistrarCliente(Agencia MiAgencia)
    {
                  Console.Write(" >> Ingrese el nombre del cliente: ");
                  string nombre = Console.ReadLine();
                 
                 
                  Console.Write(">> Ingrese el dni del cliente:");
                  int dni;
                  if(!int.TryParse(Console.ReadLine(), out dni )) throw new Exception(" Error: tipo de dato Invalido");
                  
                 
                  Console.Write(">> Ingrese el apellido del cliente:");
                  string apellido = Console.ReadLine();
                 
                  Console.Write(">> Ingrese el telefono del cliente:");
                  int telefono;
                  if(!int.TryParse(Console.ReadLine(), out telefono)) throw new Exception(" Error: tipo de datos invalido"); 

              return  MiAgencia.AgregarCliente(new Cliente(nombre,apellido,dni,telefono));
                  
    }
    public static double  RegistrarAlquiler(Agencia MiAgencia)
    {
      Console.Write("  >> Ingrese el dni del cliente: ");
      int dni;
      if(!int.TryParse(Console.ReadLine(),out dni))throw new Exception(" Error: tipo de dato invalido");
      Console.Write("  >> Ingrese la patente del vehiculo: ");
      string patente = Console.ReadLine();
      Console.Write("  >> Ingrese los dias del alquiler: ");
      int  dias;
      if(!int.TryParse(Console.ReadLine(),out dias))throw new Exception(" Error tipo de dato invalido");
      return MiAgencia.RealizarAlquileres(dni,patente.ToUpper(), dias);
    }
    public static bool EliminarVehiculo(Agencia MiAgencia)
    {
       Console.Write(" >> Ingrese la patente del vehiculo: ");
       string patente = Console.ReadLine();
       if(string.IsNullOrWhiteSpace(patente)) throw new Exception(" >> Error: la patente esta vacia");
      return MiAgencia.EliminarVehiculo(patente.ToUpper());
    }
        
   
    public static  void Menu()
    {
        
            Console.WriteLine("1- Agregar vehiculo");
            Console.WriteLine("2- Eliminar vehiculo");
            Console.WriteLine("3- Registrar clientes");
            Console.WriteLine("4- Registrar alquiler");
            Console.WriteLine("5- Listado de vehiculos");
            Console.WriteLine("6- Listado de clientes");
            Console.WriteLine("7- Listado de alquileres");
            Console.WriteLine("8- Mostrar vehiculos con seguro");
            Console.WriteLine("9- Salir del programa");
           
    

    } 
}
}
     
    

