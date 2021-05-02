using MotoDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoDex.Db
{
    public class DbInitializer
    {
        public static void Initialize(MotorcyclesContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Motorcycles.Any())
            {
                MotorcycleMake honda = new("HONDA", "Making motorcycles with the basic goal of bringing joy and satisfaction to people serves as the starting point of Honda. Honda will continue offering products which fulfill the needs of its customers around the world.");

                Engine engine = new() { EngineConfiguration = "90 degree V4" };

                Tyre fTyre = new() {
                    Make = "Pirelli",
                };

                BreakPad brkPad = new() { Make = "EBC" };

                Motorcycle vfr = new()
                {
                    Model = "VFR 750",
                    FinalDrive = "Chain Driven",
                    Make = honda,
                    Engine = engine,
                    //RearTyre = new List<Tyre>() { fTyre },
                    FrontTyre = new List<Tyre>() { fTyre },
                    FrontBreakPads = brkPad,
                    RearBreakPads = brkPad
                };

                honda.Motorcycles = new List<Motorcycle>() { vfr };
                fTyre.Motorcycles = new List<Motorcycle>() { vfr };

                context.Motorcycles.Add(vfr);

                context.SaveChanges();
            }
        }
    }
}
