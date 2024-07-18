using UberClone.Core.Entities;

namespace UberClone.Tests.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(string licensePlate, string model)
        {
            return new Vehicle
            {
                LicensePlate = licensePlate,
                Model = model
            };
        }
    }
}
