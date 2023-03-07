using ApiDemo;
namespace ApiDemo.Reposity
{
    public class CarRepository
    {
        private int _nextId;
        private List<Car>? _cars;

        public CarRepository()
        {
            _nextId = 0;
            _cars = new List<Car>
            {
                new Car() {Id = _nextId++, Model = "Tesla - Plaid", Licenseplate = "CB56789", Price = 500000},
                new Car() {Id = _nextId++, Model = "Fiat - Panda", Licenseplate = "KL47623", Price = 200000},
                new Car() {Id = _nextId++, Model = "BMW - I8", Licenseplate = "DK42445", Price = 800000},
                new Car() {Id = _nextId++, Model = "Mercedes - GLE", Licenseplate = "CV87692", Price = 100000}
            };
        }
        public List<Car>? GetAll()
        {
            return new List<Car>(_cars!);
        }

        public Car? GetById(int id)
        {
            Car? car = _cars!.Find(car => car.Id == id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars!.Add(newCar);
            return newCar;
        }

        public Car? Delete(int id)
        {
            Car? car = GetById(id);
            if (car != null)
            {
                _cars!.Remove(car);
                return car;
            }
            return null;
        }
    }
}
