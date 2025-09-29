using static System.Runtime.InteropServices.JavaScript.JSType;

public enum TipoTrabajo
{
    DESEMPLEADO,
    COMERCIO,
    SALUD,
    HUMANIDADES,

}

// Interface que contiene la información de la persona
public interface IInfoPersona
{
    protected string nombre { set; get; }
    protected string desc { set; get; }
    protected string[] afficiones { set; get; }

}

// Clase abstracta empleado que declara lo necesario para que la persona sea un empleado
public abstract class Empleado
{
    public abstract TipoTrabajo Trabajo { set; get; }

    public abstract string getTrabajo();
}

// tarjeta de presentación de la persona
public class Tarjeta : Empleado, IInfoPersona
{

    // Atributos
    public string nombre { get; set; }
    public string desc { get; set; }
    public override TipoTrabajo Trabajo { set; get; } = TipoTrabajo.DESEMPLEADO;
    public string[] afficiones { set; get; } = [];


    // Constructores
    public Tarjeta(string nombreTarjeta, string descripcion)
    {
        nombre = nombreTarjeta;
        desc = descripcion;
    }

    public Tarjeta(string nombreTarjeta, string descripcion, string[] afficionesTarjeta, TipoTrabajo trabajo)
    {
        nombre = nombreTarjeta;
        desc = descripcion;
        afficiones = afficionesTarjeta;
        Trabajo = trabajo;
    }

    // Métodos
    public string getNombre()
    {
        return nombre;
    }
    public string getdesc()
    {
        return desc;
    }
    public override string getTrabajo()
    {
        // Dependiendo del tipo de trabajo entonces la la persona obtendrá un cargo u otro 
        switch (Trabajo) {
            case TipoTrabajo.DESEMPLEADO: return "Desempleado";

            case TipoTrabajo.COMERCIO: return "Comerciante";
            
            case TipoTrabajo.SALUD: return "Doctor";
            
            case TipoTrabajo.HUMANIDADES: return "Escritor";
            
            default: return "Error";
        }
    }

    public string[] getSfficiones()
    {
        try
        {
            return afficiones;
        }
        catch (NullReferenceException e)
        {
            throw new NullReferenceException("Error, datos para imprimir válidos");
        }
    }
}

// Clase impresora, es la encargada de imprimir las tarjetas de presentación de las personas
public class Impresora
{
    private List<Tarjeta> _tarjetas = new List<Tarjeta>();

    // Métodos
    public void imprimirTarjetas()
    {
        foreach (Tarjeta info in _tarjetas)
            {
                Console.WriteLine($"Esta tarjeta es del {info.getTrabajo()} {info.getNombre()}, y su descripción es {info.getdesc()} ");
                if (info.getSfficiones().Length > 0)
                { // En caso de tener afficiones, las imprime
                    Console.Write("además, tienes las siguientes afficiones:\n");
                    foreach (string s in info.getSfficiones())
                    {
                        Console.Write($"*{s}\n");
                    }
                }
                else Console.Write("y no tiene afficiones.\n"); // En caso de no tenerla, imprime un mensaje que diga que no tiene afficiones
            }

    }
    
    public void añadirTarjeta(string nombreTarjeta, string descripcion, string[] afficionesTarjeta, TipoTrabajo trabajo)
    {
        _tarjetas.Add(new Tarjeta(nombreTarjeta, descripcion, afficionesTarjeta, trabajo));
    }

    public void añadirTarjetaDesempleado(string nombreTarjeta, string descripcion)
    {
        _tarjetas.Add(new Tarjeta(nombreTarjeta, descripcion));
    }


    public void BorrarLista()
    {
        _tarjetas.Clear();
    }

}

class Programa
{
    static void Main(string[] args)
    {
        Log lg = new Log();
        try 
        { 
            lg.addLinea("Iniciando la clase impresora");
            Impresora impresora = new Impresora();

            lg.addLinea("Se añadio una tarjeta de presentación a lista");
            impresora.añadirTarjeta("Juan garces", "Empleado de una farmaceutica", [], TipoTrabajo.HUMANIDADES);
            lg.addLinea("Se añadio una tarjeta de presentación a lista");
            impresora.añadirTarjeta("Tomas Torres", "Empleado de una empresa de electrodómesticos", ["Jugar", "Ver series", "Cocinar"], TipoTrabajo.COMERCIO);

            lg.addLinea("Se imprimen las tarjetas");
            impresora.imprimirTarjetas();

            lg.addLinea("Borrando la lista de tarjetas");
            impresora.BorrarLista();       
        }
        catch (Exception e) {
            lg.addLinea("Error, El programa ha tenido un error");
            throw new Exception("Error, El programa ha tenido un error");
        }
        lg.crearLog();

    }
}

