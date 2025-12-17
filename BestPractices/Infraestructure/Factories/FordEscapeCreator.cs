using Best_Practices.ModelBuilders;
using Best_Practices.Models;

namespace Best_Practices.Infraestructure.Factories
{
    // Factory Method: nuevo modelo pedido por negocio
    // Color: Red, Marca: Ford, Modelo: Escape
    public class FordEscapeCreator : Creator
    {
        public override Vehicle Create()
        {
            var builder = new CarBuilder();

            return builder
                .SetModel("Escape")
                .SetColor("Red")
                .SetBrand("Ford")
                .Build();
        }
    }
}
