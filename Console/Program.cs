﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            CarManager carmanager = new CarManager(new EfCarDal());
            var result = carmanager.GetCarDetails();
            foreach (var car in result.Data)
            {
                System.Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
            System.Console.WriteLine(result.Message);

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            foreach (var color in result.Data )
            {
                System.Console.WriteLine(color.Name + " / " + color.Id);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                System.Console.WriteLine(brand.Name + " / " + brand.Id);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
            {
                System.Console.WriteLine(car.Name + " / " + car.Description);
            }
            System.Console.WriteLine("************************************");
            var result1 = carManager.GetById(1);
            foreach (var car in result1.Data)
            {
                System.Console.WriteLine(car.Name);
            }
            System.Console.WriteLine("************************************");
            Car newCar = new Car{ Name = "yeni araba 3", DailyPrice = 15, Description="deneme", BrandId=3, ColorId=2, Id=1, ModelYear=2021 };;
            carManager.Add(newCar);
            var result2 = carManager.GetAll();
            foreach (var car in result2.Data)
            {
                System.Console.WriteLine(car.Name);
            }
            System.Console.WriteLine("************************************");
            carManager.Delete(newCar);
            var result3 = carManager.GetAll();
            foreach (var car in result3.Data)
            {
                System.Console.WriteLine(car.Name);
            }
            System.Console.WriteLine("************************************");
            carManager.Update(newCar);
            var result4 = carManager.GetAll();
            foreach (var car in result4.Data)
            {
                System.Console.WriteLine(car.Name);
            }
        }
    }
}
