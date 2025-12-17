using System.Collections.Generic;
using Best_Practices.Infraestructure.Factories;
using Best_Practices.Models;

namespace Best_Practices.Services
{
    public interface IVehicleService
    {
        ICollection<Vehicle> GetVehicles();
        Vehicle AddVehicle(Creator creator);

        void StartEngine(string id);
        void StopEngine(string id);
        void AddGas(string id);
    }
}
