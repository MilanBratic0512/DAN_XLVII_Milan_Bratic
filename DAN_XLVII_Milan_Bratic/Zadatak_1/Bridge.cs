using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Bridge
    {
        SemaphoreSlim semaphore;
        //to store the current direction on bridge
        static Direction direc = new Direction();
        
        public Bridge()
        {
            semaphore = new SemaphoreSlim(0);
        }
        //called when car arrives to bridge
        public void ArriveBidge(string dir, Car car)
        {
            //if cars heading to South
            if (dir.Equals("South"))
            {
                //and if current traffic is towards North
                while (direc.Status.Equals("North"))
                {
                    Console.WriteLine("Waiting " + car.name);
                    semaphore.Wait();
                }
            }
            else
            {
                //if current traffic is towards South
                while (direc.Status.Equals("South"))
                {
                    
                    Console.WriteLine("Waiting " + car.name);
                    semaphore.Wait();
                }
            }
        }

        public void CrosBridge(string carName)
        {
            //show the carname on bridge
            Console.WriteLine("{0} is crossing the bridge.", carName);
        }

        public void ExitBridge(string carName)
        {
            semaphore.Release();
            Console.WriteLine("{0} has crossed the bridge", carName);

            if (semaphore.CurrentCount == 0)
            {
                direc.Status = "Free";
                
            }

        }
        public void OneVehicle(Car car)
        {
            try
            {
                string dir = "";
                Console.WriteLine("{0} is trying cross the bridge", car.name);

                if (car.name.Contains("South"))
                {
                    dir = "South";
                }
                else
                {
                    dir = "North";
                }

                ArriveBidge(dir, car);
                // if cars is ready to go
                semaphore.Release();
                // and car is going to south
                if (dir.Equals("South"))
                {
                    direc.Status = "South";
                }
                // car is going to North
                else
                {
                    direc.Status = "North";
                }

                CrosBridge(car.name);
                Thread.Sleep(500);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                ExitBridge(car.name);
            }
        }
    }
}
