using System.Text;
namespace EspacioId3v1Tag
{
    public class Id3v1Tag
    {
        private string header;
        private string titulo;
        private string artista;
        private string album;
        private string anio;
        private string comentario;
        private byte genero;

        public Id3v1Tag(byte[] buffer)
        {
            this.header     = Encoding.Default.GetString(buffer, 0, 3).Trim();
            this.titulo     = Encoding.Default.GetString(buffer, 3, 30).Trim();
            this.artista    = Encoding.Default.GetString(buffer, 33, 30).Trim();
            this.album      = Encoding.Default.GetString(buffer, 63, 30).Trim();
            this.anio       = Encoding.Default.GetString(buffer, 93, 4).Trim();
            this.comentario = Encoding.Default.GetString(buffer, 97, 30).Trim();
            this.genero     = buffer[127];
        }

        public string Header
        {
            get => header;
        }
        public string Titulo
        {
            get => titulo;
        }
        public string Artista
        {
            get => artista;
        }
        public string Album
        {
            get => album;
        }
        public string Anio
        {
            get => anio;
        }
        public string Comentario
        {
            get => comentario;
        }
        public byte Genero
        {
            get => genero;
        }
    }
}

