using System;
using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Defaults
{
    public class DefaultVehicleDefaultsProvider : IVehicleDefaultsProvider
    {
        public void ApplyDefaults(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));

            // requerido: año actual
            vehicle.Year = DateTime.Now.Year;

            // requerido: 20 props mas por defecto
            // se usa diccionario para minimizar cambios; aqui es el unico lugar que editas en el siguiente sprint
            for (int i = 1; i <= 20; i++)
            {
                var key = $"prop_{i:00}";
                if (!vehicle.ExtraProperties.ContainsKey(key))
                {
                    vehicle.ExtraProperties[key] = "default";
                }
            }
        }
    }
}
