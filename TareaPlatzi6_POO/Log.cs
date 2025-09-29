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

    public void addLinea(string linea)
    {
        logStr += $"[{DateTime.Now.ToString()}] {linea}\n";
    }

    public void crearLog()
    {
        addLinea("Programa terminado");
        System.IO.File.WriteAllText(rutaDestino, logStr);
    }

}