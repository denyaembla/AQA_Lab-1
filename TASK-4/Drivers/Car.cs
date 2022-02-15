namespace Drivers;

public class Car
{
   public Car()
   {
      this._engine = Engine.CreateEngine();
      this._vehicle = Vehicle.GenerateVehicle();
   }

   public Engine _engine;
   public Vehicle _vehicle;

   
}

   
