namespace ApiDemo
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public double Price { get; set; }
        public string? Licenseplate { get; set; }





        public void ValidatePrice()
        {
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public void ValidateModel()
        {
            if (Model == null) { throw new ArgumentNullException(); }

            if (Model.Length < 4) { throw new ArgumentException(); }
        }

        public void ValidateLicensePlate()
        {

            if (Licenseplate.Length < 2) { throw new ArgumentOutOfRangeException(); }
            if (Licenseplate.Length > 7) { throw new ArgumentOutOfRangeException(); }



        }

        public void Validate()
        {
            ValidatePrice();
            ValidateModel();
            ValidateLicensePlate();

        }
    }


}