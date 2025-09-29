public class Log
{
    private string rutaDestino { set; get; }
    private string logStr { set; get; } = "";

    public Log()
    {
        string directorio = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/"; // Directorio del proyecto
        string pathResultado = directorio + "Log.txt";
        rutaDestino = pathResultado;
        addLinea("Programa iniciado");
    }

    // Añade una línea al log
    public void addLinea(string linea)
    {
        try
        {
            logStr += $"[{DateTime.Now.ToString()}] {linea}\n";
        }
        catch (ArgumentException e) {
            logStr += $"[{DateTime.Now.ToString()}] Error, se intento añadir una cadena.\n";
            throw new ArgumentException("La linea esta vacía.");
        }
    }

    // Se crea el arcchivo log
    public void crearLog()
    {
        addLinea("Programa terminado");
        System.IO.File.WriteAllText(rutaDestino, logStr);
    }

}