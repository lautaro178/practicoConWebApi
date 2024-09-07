using System.Text;

namespace Shared
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "-- Sin Nombre --";
        public string Apellido { get; set; } = "-- Sin Apellido --";
        public int Edad { get; set; } = 0;
        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        //public virtual ICollection<Vehiculo> Vehiculos { get; set; }

        public string GetString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Documento: {Documento}, Edad: {Edad}";
        }

        //public string GetStringConVehiculo()
        //{
        //    var infoVehiculos = new StringBuilder();
        //    foreach (var vehiculo in Vehiculos)
        //    {
        //        infoVehiculos.AppendLine(vehiculo.GetString());
        //    }

        //    return $"ID: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Documento: {Documento}, Edad: {Edad}\nVehiculos:\n{infoVehiculos}";
        //}


    }
}
