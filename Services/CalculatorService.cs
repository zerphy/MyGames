﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyGames.Contracts;
using MyGames.Model;

namespace MyGames.Services
{
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
