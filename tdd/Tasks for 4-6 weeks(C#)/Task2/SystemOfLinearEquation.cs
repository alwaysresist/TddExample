using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SystemOfLinearEquation
    {
        private List<LinearEquation> system = new List<LinearEquation>();
        private int n;

        public SystemOfLinearEquation(int n)
        {
            this.n = n;
        }
        public LinearEquation this[int index]
        {
            get
            {
                if (index >= 0 && index < Size)
                    return system[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size)
                    system[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public int Size => system.Count;
        public void Add(LinearEquation a)
        {
            if (a.Size == n + 1)
                system.Add(a);
            else throw new ArgumentException();
        }

        public void Delete(int index)
        {
            system.RemoveAt(index);
        }
        public void SteppingUp()
        {
            int c, z;
            double p1, p2;
            for (int i = 0; i < Size; i++)
            {
                z = i;
                if (this[i][z] == 0)
                {
                    while (this[i][z] == 0 && z < n) z++;//find not zero coefficient in equation
                    c = 1;
                    while ((i + c) < Size && this[i + c][z] == 0) c++;
                    if ((i + c) == Size)//last equation
                    {
                        return;
                    }
                    Swap(this[i], this[i + c]);//swap to get a stepped look
                }
                for (int j = i + 1; j < Size; j++)
                {
                    p1 = this[i][z];
                    p2 = this[j][z];
                    this[j] = this[j] * p1 - this[i] * p2;
                }
            }
        }

        public double[] SolveSystem()
        {
            while (this[Size - 1].IsNull())//delete zero rows
                this.Delete(Size - 1);
            if (this[Size - 1])
            {
                if (Size == n)
                {
                    double[] solve = new double[n];
                    for (int i = Size - 1; i >= 0; i--)
                    {
                        solve[i] = this[i][n];//take free member
                        for (int j = i + 1; j < n; j++)
                        {
                            solve[i] -= this[i][j] * solve[j];
                        }
                        solve[i] /= this[i][i];
                    }
                    return solve;
                }
                else throw new ArgumentException("The system has infinitely many solutions!");
            }
            else throw new ArgumentException("The system has no solutions!");
        }
        private void Swap(LinearEquation a, LinearEquation b)
        {
            LinearEquation tmp = new LinearEquation(a);
            b.CopyTo(a);
            tmp.CopyTo(b);
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Size; i++)
            {
                res += this[i].ToString() + '\n';
            }
            return res;
        }
    }
}
