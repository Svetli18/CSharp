using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;

        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height 
        {
            get { return this.height; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or less!");
                }

                this.height = value; 
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or less!");
                }

                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return (this.Height * this.Width);
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < (int)this.Height; i++)
            {
                for (int j = 0; j < (int)this.Width; j++)
                {
                    if (i == 0 || i == (int)this.Height - 1)
                    {
                        if (j == 0)
                        {
                            sb.Append("*");
                            continue;
                        }
                        sb.Append("*");
                    }
                    else if (j == 0 || j == (int)this.Width - 1)
                    {
                        if (j == 0)
                        {
                            sb.Append("*");
                            continue;
                        }
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
