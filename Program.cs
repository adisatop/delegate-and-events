using System;

namespace ConsoleApp3
{
    class Program
    {
        public delegate void HandleSpeed (int speed) ;
        

        static void Main(string[] args)
        {
            Car car = new Car();
            car.speedUp(100);
        }


        class Car {
            HandleSpeed overSpeed;
            HandleSpeed underLimitedSpeed;
            public event HandleSpeed _wranningEvent;

            int maxSpeed = 90;
            int minSpeed = 50;

            public Car() {
                overSpeed = sendWarningEvent;
                underLimitedSpeed = sendWarningEvent;
            }
            
            public void speedUp(int currentSpeed) {
                if (currentSpeed > maxSpeed) {
                    _wranningEvent += overSpeed;
                }
                if (currentSpeed < minSpeed)
                {
                    _wranningEvent += drivingTooSlow;
                }
                if(currentSpeed>minSpeed && currentSpeed<maxSpeed){
                    _wranningEvent += drivingInLimitedSpeed;
                }
                _wranningEvent.Invoke(currentSpeed);
            }

            public void sendWarningEvent(int speed) {
                Console.WriteLine("You driving over the limited speed! ");
            }

            public void drivingInLimitedSpeed(int speed)
            {
                Console.WriteLine("You driving on limited speed! ");
            }

            public void drivingTooSlow(int speed)
            {
                Console.WriteLine("You driving too slow. speed up !");
            }
        }
    }
}
