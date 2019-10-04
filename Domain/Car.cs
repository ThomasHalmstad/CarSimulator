namespace CarSimulator.Domain
{
    class Car
    {
        private string brand;
        private string model;
        private string registrationNumber;

        public Car(string brand, string model,string registrationNumber)
        {
            this.brand = brand;
            this.model = model;
            RegistrationNumber = registrationNumber;
        }

        public string Brand
        {
            get
            {
                return brand;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                if (value.Length > 6)
                {
                    registrationNumber = value.Substring(0, 6);
                }
                else
                {
                    registrationNumber = value;
                }
            }
        }

    }
}
