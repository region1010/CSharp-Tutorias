﻿using System.Text;

namespace BIBLIOTECA;

public class record_types
{

   


    public override string ToString()
    {

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("HeatingDegreeDays");
        stringBuilder.Append("{");
        if (PrintMembers(stringBuilder))
        {

            stringBuilder.Append(" ");

        }
        stringBuilder.Append("}");
        return stringBuilder.ToString();

    }

    public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
    {

        public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);

    }

    public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords) : DegreeDays(BaseTemperature, TempRecords)
    {

        public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);

    }

    public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);


    public readonly record struct DailyTemperature(double HighTemp, double LowTemp)
    {


        public double Mean => (HighTemp + LowTemp) / 2.0;
    }

    private static DailyTemperature[] data = [

         new DailyTemperature(HighTemp: 57, LowTemp: 30),
         new DailyTemperature(60, 35),
         new DailyTemperature(63, 33),
         new DailyTemperature(68, 29),
         new DailyTemperature(72, 47),
         new DailyTemperature(75, 55),
         new DailyTemperature(77, 55),
         new DailyTemperature(72, 58),
         new DailyTemperature(70, 47),
         new DailyTemperature(77, 59),
         new DailyTemperature(85, 65),
         new DailyTemperature(87, 65),
         new DailyTemperature(85, 72),
         new DailyTemperature(83, 68),
         new DailyTemperature(77, 65),
         new DailyTemperature(72, 58),
         new DailyTemperature(77, 55),
         new DailyTemperature(76, 53),
         new DailyTemperature(80, 60),
         new DailyTemperature(85, 66)


    ];
    
     protected virtual bool PrintMembers(StringBuilder stringBuilder  )
    {
        bool BaseTemperature = false;
        stringBuilder.Append($"BaseTemperature  =  {BaseTemperature}");
        return true;

    }

    public string record()
    {



        foreach (var item in data) Console.WriteLine(item);
        Console.WriteLine("---------------------------");
        var heatingDegreeDays = new HeatingDegreeDays(65, data);
        Console.WriteLine(heatingDegreeDays);
        var coolingDegreeDays = new CoolingDegreeDays(65, data);
        Console.WriteLine(coolingDegreeDays);
        Console.WriteLine("---------------------------");
        var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 };
        Console.WriteLine(growingDegreeDays);
        Console.WriteLine("---------------------------");
        List<CoolingDegreeDays> movingAccumulation = new();
        int rangeSize = (data.Length > 5) ? 5 : data.Length;
        for (int start = 0; start < data.Length - rangeSize; start++)
        {

            var fiveDayTotal = growingDegreeDays with { TempRecords = data[start..(start + rangeSize)] };
            movingAccumulation.Add(fiveDayTotal);

        }
        Console.WriteLine();
        Console.WriteLine("Total degree days in the last five days");
        foreach (var item in movingAccumulation) Console.WriteLine(item);

        var growingDegreeDaysCopy = growingDegreeDays with { };
        return "record";

    }


}
