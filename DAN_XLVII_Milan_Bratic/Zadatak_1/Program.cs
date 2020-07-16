﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Bridge bridge = new Bridge();
            //set max cars from each direction
            int max = 15;

            int countS = 0;
            Thread thSouth = new Thread(() =>
            {
                // create and start cars from South
                while (countS++ < max)
                {
                    Car car = new Car(bridge);

                    Thread th = new Thread(car.Run);
                    car.name = "South Car:" + th.ManagedThreadId;
                    th.Start();
                    Thread.Sleep(500);
                }

            });
            int countN = 0;
            Thread thNorth = new Thread(() =>
            {
                // create and start cars from North
                while (countN++ < max)
                {
                    Car car = new Car(bridge);

                    Thread th = new Thread(car.Run);
                    car.name = "North Car:" + th.ManagedThreadId;
                    th.Start();
                    Thread.Sleep(500);
                }

            });
            thSouth.Start();
            thNorth.Start();
            Console.ReadLine();
        }
    }
}
