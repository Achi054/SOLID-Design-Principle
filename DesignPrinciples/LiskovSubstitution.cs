namespace DesignPrinciples
{
    /// <summary>
    /// Liskov Substitution Principle.
    /// If super/derived/child class inherits from base/parent class, then all the instance of the super/derived/child class
    /// should be able to replace base/parent class.
    /// </summary>
    public class LiskovSubstitution
    {
        public class LiskovSubstitutionBad
        {
            public class Program
            {
                MotorVehicle vehicle = new Bike();

                // Output: vehicle.NumberOfWheels is 2;
            }

            public class MotorVehicle
            {
                public virtual int NumberOfWheels => 4;
            }

            public class Bike : MotorVehicle
            {
                public override int NumberOfWheels => 2;
            }
        }

        public class LiskovSubstitutionGood
        {
            public class Program
            {
                MotorVehicle vehicleOne = new Car();
                MotorVehicle vehicleTwo = new Bike();

                // Output: vehicleOne.NumberOfWheels is 4, vehicleTwo.NumberOfWheels is 2;
            }

            public abstract class MotorVehicle
            {
                public abstract int NumberOfWheels { get; }
            }

            public class Bike : MotorVehicle
            {
                public override int NumberOfWheels { get => 2; }
            }

            public class Car : MotorVehicle
            {
                public override int NumberOfWheels { get => 4; }
            }
        }
    }
}
