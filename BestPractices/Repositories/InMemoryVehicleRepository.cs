using System;
using System.Collections.Generic;
using System.Linq;
using Best_Practices.Models;

namespace Best_Practices.Repositories
{
    // Repositorio en memoria: sirve para probar sin base de datos
    // despues se cambia por DBVehicleRepository cuando el schema este listo
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public InMemoryVehicleRepository()
        {
            // datos iniciales para que la tabla no salga vacia
            _vehicles.Add(new Car("Red", "Ford", "Mustang"));
            _vehicles.Add(new Car("Black", "Ford", "Explorer"));
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            _vehicles.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;

            if (!Guid.TryParse(id, out var guid))
            {
                return null;
            }

            return _vehicles.FirstOrDefault(v => v.ID.Equals(guid));
        }
    }
}
