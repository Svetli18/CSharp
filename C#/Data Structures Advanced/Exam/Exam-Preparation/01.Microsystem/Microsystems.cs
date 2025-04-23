namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        List<Computer> computers = new List<Computer>();
        Dictionary<int, Computer> byNumber = new Dictionary<int, Computer>();
        Dictionary<Brand, List<Computer>> byBrand = new Dictionary<Brand, List<Computer>>();
        Dictionary<double, List<Computer>> byPrice = new Dictionary<double, List<Computer>>();
        Dictionary<double, List<Computer>> byScreenSize = new Dictionary<double, List<Computer>>();
        Dictionary<string, List<Computer>> byColor = new Dictionary<string, List<Computer>>();

        public void CreateComputer(Computer computer)
        {
            if (this.byNumber.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }

            if (!this.byBrand.ContainsKey(computer.Brand))
            {
                this.byBrand[computer.Brand] = new List<Computer>();
            }

            if (!this.byPrice.ContainsKey(computer.Price))
            {
                this.byPrice[computer.Price] = new List<Computer>();
            }

            if (!this.byScreenSize.ContainsKey(computer.ScreenSize))
            {
                this.byScreenSize[computer.ScreenSize] = new List<Computer>();
            }

            if (!this.byColor.ContainsKey(computer.Color))
            {
                this.byColor[computer.Color] = new List<Computer>();
            }

            this.computers.Add(computer);
            this.byNumber[computer.Number] = computer;
            this.byBrand[computer.Brand].Add(computer);
            this.byPrice[computer.Price].Add(computer);
            this.byScreenSize[computer.ScreenSize].Add(computer);
            this.byColor[computer.Color].Add(computer);
        }

        public bool Contains(int number)
        {
            return this.byNumber.ContainsKey(number);
        }

        public int Count()
        {
            return this.byNumber.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!this.byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            return this.byNumber[number];
        }

        public void Remove(int number)
        {
            Computer computer = this.GetComputer(number);

            this.computers.Remove(computer);
            this.byNumber.Remove(number);
            this.byBrand[computer.Brand].Remove(computer);
            this.byPrice[computer.Price].Remove(computer);
            this.byScreenSize[computer.ScreenSize].Remove(computer);
        }

        public void RemoveWithBrand(Brand brand)
        {
            if (!this.byBrand.ContainsKey(brand))
            {
                throw new ArgumentException();
            }

            foreach (var computer in this.byBrand[brand])
            {
                this.computers.Remove(computer);
                this.byNumber.Remove(computer.Number);
                if (this.byPrice.ContainsKey(computer.Price) && this.byPrice[computer.Price].Any())
                {
                    this.byPrice[computer.Price].Remove(computer);

                    if (!this.byPrice[computer.Price].Any())
                    {
                        this.byPrice.Remove(computer.Price);
                    }
                }

                if (this.byScreenSize.ContainsKey(computer.ScreenSize) && this.byScreenSize[computer.ScreenSize].Any())
                {
                    this.byScreenSize[computer.ScreenSize].Remove(computer);

                    if (!this.byScreenSize[computer.ScreenSize].Any())
                    {
                        this.byScreenSize.Remove(computer.ScreenSize);
                    }
                }
            }

            this.byBrand.Remove(brand);
        }

        public void UpgradeRam(int ram, int number)
        {
            Computer computer = GetComputer(number);

            if (computer.RAM < ram)
            {
                computer.RAM = ram;
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            ICollection<Computer> computers = new List<Computer>();

            if (this.byBrand.ContainsKey(brand))
            {
                computers = this.byBrand[brand]
                    .OrderByDescending(c => c.Price)
                    .ToList();
            }

            return computers;
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            ICollection<Computer> computers = new List<Computer>();

            if (this.byScreenSize.ContainsKey(screenSize))
            {
                computers = this.byScreenSize[screenSize]
                    .OrderByDescending(c => c.Number)
                    .ToList();
            }

            return computers;
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            ICollection<Computer> computers = new List<Computer>();

            if (this.byColor.ContainsKey(color))
            {
                computers = this.byColor[color]
                    .OrderByDescending(c => c.Price)
                    .ToList();
            }

            return computers;
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            ICollection<Computer> computers = this.computers
                .Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price)
                .ToList();

            return computers;
        }
    }
}
