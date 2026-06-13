using System.IO;
using EspacioArchivo;
List<Archivo> listaArchivos = new List<Archivo>();
bool valido = true;
do
{
    Console.WriteLine("Ingrese un directorio valido: ");

    string RutaCarpeta = Console.ReadLine();

    if (Directory.Exists(RutaCarpeta))
    {
        Console.WriteLine("Existe el directorio");
        string[] carpetas;
        carpetas = Directory.GetDirectories(RutaCarpeta);
        Console.WriteLine("Carpetas dentro del directorio:");

        foreach (string cpt in carpetas)
        {
            DirectoryInfo carpeta = new DirectoryInfo(cpt);
            Console.WriteLine(carpeta.Name);
        }

        string[] archivos = Directory.GetFiles(RutaCarpeta);
        Console.WriteLine("Archivos dentro del directorio:");

        foreach (string arch in archivos)
        {
            FileInfo archivo = new FileInfo(arch);
            Archivo nuevoArchivo = new Archivo(archivo.Name, archivo.Length / 1024.0, archivo.LastWriteTime);
            listaArchivos.Add(nuevoArchivo);
            Console.WriteLine(archivo.Name + $" TAM = {archivo.Length / 1024.0} KB");
        }

        string nombreCSV = Path.Combine(RutaCarpeta, "reporte_archivos.csv");

        using (StreamWriter escribo = new StreamWriter(nombreCSV))
        {
            escribo.WriteLine($"Nombre del Archivo ; Tamaño(KB) ; Fecha de modificacion ");
            foreach (Archivo arch in listaArchivos)
            {
                escribo.WriteLine($"{arch.Nombre} ; {Math.Round(arch.Tam, 2)} ; {arch.FechaMod}");

            }
        }

    }
    else
    {
        Console.WriteLine("No existe el directorio");
        valido = false;
    }
} while (valido == false);
