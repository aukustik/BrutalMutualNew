using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public Stats stats;
    public abstract void OnPickup();
}
public class Guns : Item
{
    public override void OnPickup()
    {
        
    }
    
}

public class Stats
{

}
public class Stat
{
    int value = 0;
    string _stat_name;
    public Stat(string stat_name, int level)
    {
        _stat_name = stat_name;
    }
    int Value {
        get {
            return value;
        }
        set {
            this.value = value;
        }
    }
}