using System;
using System.Collections.Generic;
using System.Text;

namespace BUILDER
{
    public enum Cartype
    {
        Sedan,
        Crossover
    }
     
    public class Car
    {
        public Cartype Type;
        public int WheelSize;
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(Cartype type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }
    public interface IBuildCar
    {
        Car Build();
    }

    public class CarBuilder
    {
        private class Impl : ISpecifyCarType,
                             ISpecifyWheelSize,
                             IBuildCar
        {
            private Car car = new Car();
            public ISpecifyWheelSize OfType(Cartype type)
            {
                car.Type = type;
                return this;
            }
            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case Cartype.Sedan when (size < 15 || size > 17):
                        throw new ArgumentException("Sedan size must be between 15 and 17 inches.");
                    case Cartype.Crossover when (size < 17 || size > 20):
                        throw new ArgumentException("Crossover size must be between 17 and 20 inches.");
                }
                car.WheelSize = size;
                return this;
            }
            public Car Build()
            {
                return car;
            }
        }
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }

    public class Stepwise_Builder
    {
        static void Main(string[] args)
        {
            var car = CarBuilder
                .Create()
                .OfType(Cartype.Crossover)
                .WithWheels(18)
                .Build();
        }
    }
}

