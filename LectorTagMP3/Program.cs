using System.IO;
using EspacioId3v1Tag;
bool valido = false;
do
{
    Console.WriteLine("Ingrese un la ruta de un archivo mp3: ");

    string RutaArchivo = Console.ReadLine();

    if (File.Exists(RutaArchivo))
    {
        valido = true;
        Console.WriteLine("=== MP3 VALIDO (ID3v1) ===");
        byte[] buffer = new byte[128];

        using (FileStream fs = new FileStream(RutaArchivo, FileMode.Open, FileAccess.Read))
        {
            fs.Seek(-128, SeekOrigin.End);
            int bytesLeidos = fs.Read(buffer, 0, 128);
        }
        Id3v1Tag miTag = new Id3v1Tag(buffer);
        if (miTag.Header == "TAG")
        {
            Console.WriteLine($"Titulo: {miTag.Titulo}");
            Console.WriteLine($"Artista: {miTag.Artista}");
            Console.WriteLine($"Album: {miTag.Album}");
            Console.WriteLine($"Año de la cancion: {miTag.Anio}");
            Console.WriteLine("==========================");
        }
        else
        {
            Console.WriteLine("El archivo existe, pero no contiene una etiqueta ID3v1 valida");
            valido = false;
        }
    }
    else
    {
        Console.WriteLine("No existe el archivo");
        valido = false;
    }
} while (!valido);