using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearEquation
    {
        private List<double> coeff=new List<double>();

        public LinearEquation(double[] coeff)
        {
            this.coeff = coeff.ToList();
        }

        public LinearEquation(List<double> coeff)
        {
            this.coeff = coeff.ToList();
        }
        public LinearEquation(IEnumerable<double> coeff)
        {
            this.coeff = coeff.ToList();
        }

        public LinearEquation(string _coeff)
        {
            string[] coeff = Regex.Split(_coeff, @"[^\d.-]");
            for (int i = 0; i < coeff.Length; i++)
            {
                if (coeff[i] != "")
                {
                    coeff[i] = coeff[i].Replace('.', ',');
                                                         
                    this.coeff.Add(double.Parse(coeff[i]));
                }
            }
        }

        public LinearEquation(int n)
        {
            if (n > 0)
            {
                coeff = new List<double>();
                for (int i = 0; i <= n; i++)
                    coeff.Add(0);
            }
            else throw new ArgumentException();
        }

        public int Size
        {
            get => coeff.Count;
        }

        public void RandomInitialization()
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
                coeff[i] = rand.Next(35) / 10;
        }

        public void SameInitialization(double value)
        {
            for (int i = 0; i < Size; i++)
                coeff[i] = value;
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < Size)
                    return coeff[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size)
                    coeff[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        
        public override string ToString()
        {
            string result = "";
            int i;
            for (i = 0; i < Size - 2; i++)
            {
                result += (coeff[i + 1] >= 0) ? (coeff[i].ToString() + 'x' + (i + 1).ToString() + '+') : (coeff[i].ToString() + 'x' + (i + 1).ToString());
            }
            result += (coeff[i].ToString() + 'x' + (i + 1).ToString());
            result += '=' + coeff[Size - 1].ToString();
            return result;
        }
        public static LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            var result = a.coeff.Zip(b.coeff, (first, second) => first + second);
            return new LinearEquation(result);
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            var result = a.coeff.Zip(b.coeff, (first, second) => first - second);
            return new LinearEquation(result);
        }

        public static LinearEquation operator *(LinearEquation a, double r)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(a[i] * r);
            return new LinearEquation(result);
        }

        public static LinearEquation operator -(LinearEquation a)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(-a[i]);
            return new LinearEquation(result);
        }

        public static LinearEquation operator *(double r, LinearEquation a)
        {
            return a * r;
        }

        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            return !(a == b);
        }

        public static implicit operator double[](LinearEquation a)
        {
            return a.coeff.ToArray();
        }

        public static bool operator false(LinearEquation a)
        {
            if (a) return false;
            else return true;
        }

        public static bool operator true(LinearEquation a)
        {
            for (int i = 0; i < a.Size - 1; i++)
                if (a[i] != 0) return true;
            return (a[a.Size - 1] != 0) ? false : true;
        }

        public void Copy(LinearEquation b)
        {
            b.coeff = coeff.ToList();
        }

        public bool IsNull()
        {
            for (int i = 0; i < Size; i++)
                if (this[i] != 0) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            LinearEquation b = (LinearEquation)obj;
            for (int i = 0; i < Size; i++)
            {
                if (Math.Abs(this[i] - b[i]) > 1e-9) 
                    return false;
            }
            return true;
        }
    }
}
