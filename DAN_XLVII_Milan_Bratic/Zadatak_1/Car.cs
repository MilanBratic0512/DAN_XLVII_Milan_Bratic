using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Car
    {
        public string name { get; set; }
        Bridge bridge;

        public Car(Bridge bridge)
        {
            this.bridge = bridge;
        }
        
        public void Run()
        {
            bridge.OneVehicle(this);
        }
    }
}
