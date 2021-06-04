using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Dominio
{
    public class GeneradoresAleatorios
    {
        public int Poisson(double entrada)
        {
            int numeroAleatorio = 0;
            double y, v;
            y = 1.0;
            v = Math.Exp(-1.0 / entrada);
            while (y >= v)
            {
                var r = new Random();
                y = y * r.Next();
                numeroAleatorio = numeroAleatorio + 1;
            }
            return numeroAleatorio;
        }

        public List<double> MetodoCongruencialMixto(int constMultiplicativa, int semilla, int constAditiva, int modulo, int totalAGenerar, int digitoPrecision)
        {
            var listaNumerosAleatorios = new List<double>();
            var trucador = Math.Pow(10, digitoPrecision);
            //var trucador = Math.Round(10, digitoPrecision);
            //Math.Round(_Numero, _cantidadDigitosDespuesdeLaComa);

            for (int i = 1; i <= totalAGenerar; i++)
            {
                semilla = (constMultiplicativa * semilla + constAditiva) % modulo; // modulo o resto
                double numeroAletario = (double)semilla / (double)modulo;
                numeroAletario = Math.Round(numeroAletario, digitoPrecision);
                listaNumerosAleatorios.Add(numeroAletario);
            }

            return listaNumerosAleatorios;
        }

        public double MetodoCongruencialMixto(int constMultiplicativa, int constAditiva, int modulo, int digitoPrecision)
        {
            Random rand = new Random();
            var semilla = rand.Next(1, 10000);

            semilla = (constMultiplicativa * semilla + constAditiva) % modulo; // modulo o resto
            double numeroAletario = (double)semilla / (double)modulo;
            numeroAletario = Math.Round(numeroAletario, digitoPrecision);

            return numeroAletario;
        }
        /*
        public long Binomial(long n, double p)
        {
            // As of now it is an approximation 
            if (n < 1000)
            {
                long result = 0;
                for (int i = 0; i < n; ++i)
                    if (Random.NextDouble() < p) result++;
                return result;
            }
            if (n * p < 10) return Poisson(n * p);
            else if (n * (1 - p) < 10) return n - Poisson(n * p);
            else
            {
                long v = (long)(0.5 + nextNormal(n * p, Math.Sqrt(n * p * (1 - p))));
                if (v < 0) v = 0;
                else if (v > n) v = n;
                return v;
            }
        }
        */
    }
}