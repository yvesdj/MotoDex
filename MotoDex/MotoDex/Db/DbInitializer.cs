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
                MotorcycleMake honda = new("HONDA", "Honda is the largest motorcycle manufacturer in Japan and has been since it started production in 1955.[11] At its peak in 1982, Honda manufactured almost three million motorcycles annually. By 2006 this figure had reduced to around 550,000 but was still higher than its three domestic competitors.");
                MotorcycleMake yamaha = new("YAMAHA", "Yamaha Motor Co., Ltd. (ヤマハ発動機株式会社, Yamaha Hatsudōki Kabushiki-gaisha) is a Japanese manufacturer of motorcycles, marine products such as boats and outboard motors, and other motorized products. The company was established in 1955 upon separation from Yamaha Corporation (however, Yamaha Corporation is still the largest private company shareholder with 9.92%, as of 2019),[1] and is headquartered in Iwata, Shizuoka, Japan.");

                Engine engineH = new() { 
                    EngineType = "4 Stroke",
                    EngineConfiguration = "90 degree V4, DOHC, 4 Valve per cylinder",
                    Capacity = 748,
                    MaxPower = 74,
                    MaxTorque = 76.5f,
                    Cooling = "Liquid cooled",
                    InductionType = "Carburated",
                    SparkPlug = "NGK CR8EH9"
                };

                Engine engineY = new()
                {
                    EngineType = "4 Stroke",
                    EngineConfiguration = "70 degree V2, SOHC, 2 Valve per cylinder",
                    Capacity = 535,
                    MaxPower = 32.1f,
                    MaxTorque = 43,
                    Cooling = "Air cooled",
                    InductionType = "Carburated",
                    SparkPlug = "NGK BRP7ES"
                };

                Tyre fTyreH = new() {
                    Make = "Pirelli",
                    Model = "Angel GT2",
                    TyreWidth = 120,
                    HeightAspect = 70,
                    RimSize = 17
                };

                Tyre fTyreH2 = new()
                {
                    Make = "Bridgestone",
                    Model = "BattleAx Sport Touring T32",
                    TyreWidth = 120,
                    HeightAspect = 70,
                    RimSize = 17
                };

                Tyre bTyreY = new()
                {
                    Make = "Metzeler",
                    Model = "Perfect ME77",
                    TyreWidth = 140,
                    HeightAspect = 90,
                    RimSize = 15
                };

                BreakPad brkPadH = new() { 
                    PadType = "Sintered",
                    Make = "TRW",
                    Model = "MCB598SV"
                };

                BreakPad brkPadY = new()
                {
                    PadType = "Organic",
                    Make = "EBC",
                    Model = "MCB640"
                };

                Motorcycle vfr = new()
                {
                    Model = "VFR 750",
                    FinalDrive = "Chain Driven",
                    Make = honda,
                    Engine = engineH,
                    //RearTyre = new List<Tyre>() { fTyre },
                    MotorcycleFrontTyres = new List<MotorcycleFrontTyres>() { fTyreH, fTyreH2 },
                    FrontBreakPads = brkPadH,
                    RearBreakPads = brkPadH
                };

                Motorcycle xv535 = new()
                {
                    Model = "XV 535 Virago",
                    FinalDrive = "Shaft Driven",
                    Make = yamaha,
                    Engine = engineY,
                    //RearTyre = new List<Tyre>() { fTyre },
                    MotorcycleFrontTyres = new List<MotorcycleFrontTyres>() { bTyreY },
                    FrontBreakPads = brkPadY,
                    RearBreakPads = brkPadY
                };

                //honda.Motorcycles = new List<Motorcycle>() { vfr };

                //fTyreH.Motorcycles = new List<Motorcycle>() { vfr };

                context.Motorcycles.Add(vfr);
                context.Motorcycles.Add(xv535);

                context.SaveChanges();
            }
        }
    }
}
