﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,CategoryId = 1,ColorId = 2,ModelYear = 2013,DailyPrice = 120,Description ="Ford Fiesta 2013 Dizel"},
                new Car{Id=2,BrandId=1,CategoryId = 1,ColorId = 3,ModelYear = 2015,DailyPrice = 150,Description ="Ford Fiesta 2015 Dizel"},
                new Car{Id=3,BrandId=2,CategoryId = 2,ColorId = 1,ModelYear = 2013,DailyPrice = 1000,Description ="Nissan GTR r35 2017 Nismo"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByCategory(int categoryId)
        {
            return _cars.Where(c => c.CategoryId == categoryId).ToList();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);


            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}