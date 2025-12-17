using System;
using System.Collections.Generic;
using Best_Practices.Infraestructure.Defaults;
using Best_Practices.Infraestructure.Factories;
using Best_Practices.Models;
using Best_Practices.Repositories;

namespace Best_Practices.Services
{
    // Service Layer: aqui va la logica de negocio, el controller queda mas limpio (SRP)
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repo;
        private readonly IVehicleDefaultsProvider _defaults;

        public VehicleService(IVehicleRepository repo, IVehicleDefaultsProvider defaults)
        {
            _repo = repo;
            _defaults = defaults;
        }

        public ICollection<Vehicle> GetVehicles()
        {
            return _repo.GetVehicles();
        }

        public Vehicle AddVehicle(Creator creator)
        {
            if (creator == null) throw new ArgumentNullException(nameof(creator));

            // Factory Method: crea el objeto segun el modelo
            var vehicle = creator.Create();

            // Defaults (Strategy): aplica año actual y props por defecto
            _defaults.ApplyDefaults(vehicle);

            // Repository: persistencia (por ahora en memoria)
            _repo.AddVehicle(vehicle);

            return vehicle;
        }

        public void StartEngine(string id)
        {
            var vehicle = _repo.Find(id);
            if (vehicle == null) throw new Exception("Vehicle not found");
            vehicle.StartEngine();
        }

        public void StopEngine(string id)
        {
            var vehicle = _repo.Find(id);
            if (vehicle == null) throw new Exception("Vehicle not found");
            vehicle.StopEngine();
        }

        public void AddGas(string id)
        {
            var vehicle = _repo.Find(id);
            if (vehicle == null) throw new Exception("Vehicle not found");
            vehicle.AddGas();
        }
    }
}
