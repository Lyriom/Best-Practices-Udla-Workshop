using System;
using System.Collections.Generic;

namespace Best_Practices.Models
{
    public abstract class Vehicle : IVehicle
    {
        // estado interno
        private bool _isEngineOn { get; set; }

        // ID unico del vehiculo
        public readonly Guid ID;

        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        // requerido: año actual por defecto (se aplica con DefaultsProvider)
        public int Year { get; set; }

        // para el siguiente sprint: 20 propiedades sin romper todo el proyecto
        // se dejan en diccionario para minimizar cambios
        public Dictionary<string, string> ExtraProperties { get; set; } = new Dictionary<string, string>();

        public double Gas { get; set; }
        public double FuelLimit { get; set; }

        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
        }

        public void AddGas()
        {
            if (Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }

        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("No enoguht gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Enigne already stopped");
            }

            _isEngineOn = false;
        }
    }
}
