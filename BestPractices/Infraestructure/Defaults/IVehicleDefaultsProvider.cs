using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Defaults
{
    // Strategy: encapsula como se ponen valores por defecto al vehiculo
    public interface IVehicleDefaultsProvider
    {
        void ApplyDefaults(Vehicle vehicle);
    }
}
