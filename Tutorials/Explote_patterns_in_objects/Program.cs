using  BIBLIOTECA;

namespace  patterns;

public class Pattern{

    public static void Main(){
    
        //  Create a new canal lock
        CanalLock canalGate  =  new  CanalLock();
        
        //  State should be doors closed, water level low
        Console.WriteLine(canalGate);
        
        canalGate.SetLowGate(open: true);
        Console.WriteLine($"Open the Lower gate: {canalGate}");
        
        Console.WriteLine("Boat enters lock from lower gate");
        
        canalGate.SetLowGate(open: false);
        Console.WriteLine($"Close the lower gate: {canalGate}");
        
        canalGate.SetWaterLevel(WaterLevel.High);
        Console.WriteLine($"Raise the water level: {canalGate}");
        
        canalGate.SetHighGate(open: true);
        Console.WriteLine($"Open the higher gate: {canalGate}");
        
        Console.WriteLine("Boat exits lock at upper gate");
        Console.WriteLine("Boat enters lock from upper gate");
        
        canalGate.SetHighGate(open: false);
        Console.WriteLine($"Close the water level:{canalGate}");
          
        canalGate.SetWaterLevel(WaterLevel.Low);
        Console.WriteLine($"Lower the water level: {canalGate}");
        
        canalGate.SetLowGate(open: true);
        Console.WriteLine($"Open the lower gate: {canalGate}");
        
        Console.WriteLine("Boat exist lock at upper gate");
        
        canalGate.SetLowGate(open: false);
        Console.WriteLine($"Close the lower gate: {canalGate}");
        
        
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine("  Test invalid commands  ");
        
        //  open wrong gate (2test)
        try{
        
            canalGate  =  new  CanalLock();
            canalGate.SetHighGate(open:  true);
        
        }catch(InvalidOperationException){
        
            Console.WriteLine("Invalid operation: Can't open the high gate."+
            "Water is low");
        
        }
        Console.WriteLine($"Try to open upper gate: {canalGate}");
        
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++\n");
        Console.WriteLine("######################################");
        Console.WriteLine("Fix this TEST");
        Console.WriteLine();
        Console.WriteLine();
        
        try{
        
            canalGate  =  new  CanalLock();
            canalGate.SetWaterLevel(WaterLevel.High);
            canalGate.SetLowGate(open: true);
             
        }catch(InvalidOperationException){
        
            Console.WriteLine("Invalid operration: Can't open teh lower gate, Water is high");
        
        }
        Console.WriteLine($"Try to open lower gate: {canalGate}");
        Console.WriteLine();
        Console.WriteLine();
        try{
        
            canalGate  =  new  CanalLock();
            canalGate.SetLowGate(open: true);
            canalGate.SetWaterLevel(WaterLevel.High);
                    
        }catch(InvalidOperationException){
        
            Console.WriteLine("Invalid operation: Can't raise water when the lower gate is open.");
        
        }
        
        Console.WriteLine($"Try to raise water with lower gate opem: {canalGate}");
        Console.WriteLine();
        Console.WriteLine();
        try{
        
            canalGate  =  new  CanalLock();
            canalGate.SetWaterLevel(WaterLevel.High);
            canalGate.SetHighGate(open: true);
            canalGate.SetWaterLevel(WaterLevel.Low);
                        
        }catch(InvalidOperationException){
        
            Console.WriteLine("Invalid operation: Can't lower water when teh high gate is open.");
        
        }
        Console.WriteLine($"Try to lower water with high gate open: {canalGate}");
        
        Console.WriteLine("######################################");
        
    }
   
    

}