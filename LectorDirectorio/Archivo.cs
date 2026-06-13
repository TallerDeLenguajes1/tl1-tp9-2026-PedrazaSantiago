namespace EspacioArchivo
{
    public class Archivo
    {
        private string nombre;
        private double tam;
        private DateTime fechaMod;
        public string Nombre
        {
            get { return nombre; }
        }
        public double Tam
        {
            get { return tam; }
        }
        public DateTime FechaMod
        {
            get { return fechaMod; }
        }
        public Archivo(string nom, double tam, DateTime fechaMod)
        {
            this.nombre = nom;
            this.tam = tam;
            this.fechaMod = fechaMod;
        }
    }


}