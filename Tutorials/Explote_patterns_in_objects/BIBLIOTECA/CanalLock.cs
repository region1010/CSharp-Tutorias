namespace BIBLIOTECA;

//  Design API

public enum WaterLevel{
    
        Low,
        High
    
}
public class CanalLock
{

    //  Query canla lock state
    public WaterLevel CanalLockWaterLevel {get; private set; }  =  WaterLevel.Low;
    public bool HighWaterGateOpen {get; private set;}  =  false;
    public bool LowWaterGateOpen {get; private set;}  =  false;
    
    //  Change the upper gate
    public void SetHighGate(bool open){
    
        //throw new NotImplementedException();
        //HighWaterGateOpen  =  open;
        /*if(open && (CanalLockWaterLevel  ==  WaterLevel.High)){
        
            HighWaterGateOpen  =  true;
                  
        }else if (open && (CanalLockWaterLevel  ==  WaterLevel.Low)) {
        
            throw new InvalidOperationException("Cannot open high gate when the water is Low");
        
        }**/
        
        HighWaterGateOpen  =  (open, HighWaterGateOpen, CanalLockWaterLevel) switch {
            /*
            (false,  false,  WaterLevel.High)  =>  false,
            (false,  false,  WaterLevel.Low)  =>  false,
            (false,  true,  WaterLevel.High)  =>  false,
            (false,  true,  WaterLevel.Low)  =>  false,
            (true,  false,  WaterLevel.High)  =>  true,
            (true,  false,  WaterLevel.Low)  =>  throw  new  InvalidOperationException("Cannot open high gate when the water is low"),
            (true,  true,  WaterLevel.High)  =>  true,
            (true,  true,  WaterLevel.Low)  =>  false,
            _  =>  throw  new  InvalidOperationException("Invalid internal state")
            **/
            (false,  _,  _)  =>  false,
            (true,  _,  WaterLevel.High)  =>  true,
            (true,  false,  WaterLevel.Low)  =>  throw  new  InvalidOperationException("Cannot open high gate whem the water is low"),
            _  =>  throw new InvalidOperationException("Invalid internal state")
        
        };
    }
    
    //  Change the Lower gate
    public void SetLowGate(bool open){
    
        //throw new NotImplementedException();
        //LowWaterGateOpen  =  open;
        LowWaterGateOpen  =  (open, LowWaterGateOpen, CanalLockWaterLevel) switch {
        
            (false,  _,  _)  =>  false,
            (true,  _,  WaterLevel.Low)  =>  true,
            (true,  false,  WaterLevel.High)  =>  throw  new  InvalidOperationException("Cannot open high gate whem the water is low"),
            _  =>  throw new InvalidOperationException("Invalid internal state")
        
        };
    }
    
    //  Change water Level
    public void SetWaterLevel(WaterLevel newLevel){
    
        //throw new NotImplementedException();
        //CanalLockWaterLevel  =  newLevel;
        CanalLockWaterLevel  =  (newLevel,  CanalLockWaterLevel,  LowWaterGateOpen,  HighWaterGateOpen ) switch {
            (WaterLevel.Low, WaterLevel.Low,  true,  false)  =>  WaterLevel.Low,
            (WaterLevel.High, WaterLevel.High,  false,  true)  =>  WaterLevel.High,
            (WaterLevel.Low, _,  false,  false)  =>  WaterLevel.Low,
            (WaterLevel.High, _,  false,  false)  =>  WaterLevel.High,
            (WaterLevel.Low, WaterLevel.High,  false,  true)  =>  throw  new  InvalidOperationException("Cannot open high gate when the water is low"),
            (WaterLevel.High, WaterLevel.Low,  true,  false)  =>  throw  new  InvalidOperationException("Cannot open high gate when the water is low"),
            _  =>  throw  new  InvalidOperationException("Invalid internal state")
        };
    }
    
    public override string ToString() => 
        $"The lower gate is {(LowWaterGateOpen ? "Open":"Closed")}.\n"+
        $"The upper gate is {(HighWaterGateOpen ? "Open" : "Closed")}.\n"+
        $"The water level is {CanalLockWaterLevel}.";
}
