using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Dominio
{
    public class DistribucionesProbabilidad
    {
        public DistribucionesProbabilidad()
        {

        }
        public static double MetodoCongruencialMixto(int constMultiplicativa, int constAditiva, int modulo, int digitoPrecision)
        {
            Random rand = new Random();
            var semilla = rand.Next(1, 10000);

            semilla = (constMultiplicativa * semilla + constAditiva) % modulo; // modulo o resto
            double numeroAletario = (double)semilla / (double)modulo;
            numeroAletario = Math.Round(numeroAletario, digitoPrecision);

            return numeroAletario;
        }

        public static double Uniforme(int a, int b)
        {
            var u = MetodoCongruencialMixto(4309, 2311, 6031, 3);
            return (a + (b - a) * u);
        }

        public static double Exponencial(int e)
        {
            var u = MetodoCongruencialMixto(4309, 2311, 6031, 3);
            return (-e * Math.Log(u));
        }
        
        public static double Normal(double media, double desviacion)
        {
            double sum = 0;
            double u;
            for (int i = 1; i <= 12; i++)
            {
                u = MetodoCongruencialMixto(4309, 2311, 6031, 3);
                sum = sum + u;
            }
            return (desviacion * (sum - 6) + media);
        }

        public static bool Binomial(double probabilidad)
        {
            var u = MetodoCongruencialMixto(4309, 2311, 6031, 3);
            if (u <= probabilidad)
                return true;
            else
                return false;
        }

    }
}