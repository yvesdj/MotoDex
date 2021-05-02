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

                Engine engine = new() { 
                    EngineType = "4 Stroke",
                    EngineConfiguration = "90 degree V4",
                    Capacity = 748,
                    MaxPower = 74,
                    MaxTorque = 76.5f,
                    Cooling = "Liquid cooled",
                    InductionType = "Carburated",
                    SparkPlug = "NGK CR8EH9"
                };

                Tyre fTyre = new() {
                    Make = "Pirelli",
                    Model = "Angel GT2",
                    TyreWidth = 120,
                    HeightAspect = 70,
                    RimSize = 17
                };

                Tyre fTyre2 = new()
                {
                    Make = "Bridgestone",
                    Model = "BattleAx Sport Touring T32",
                    TyreWidth = 120,
                    HeightAspect = 70,
                    RimSize = 17
                };

                BreakPad brkPad = new() { 
                    PadType = "Sintered",
                    Make = "EBC",
                    Model = "MCB598SV"
                };

                Motorcycle vfr = new()
                {
                    Model = "VFR 750",
                    FinalDrive = "Chain Driven",
                    Make = honda,
                    Engine = engine,
                    //RearTyre = new List<Tyre>() { fTyre },
                    FrontTyre = new List<Tyre>() { fTyre, fTyre2 },
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
