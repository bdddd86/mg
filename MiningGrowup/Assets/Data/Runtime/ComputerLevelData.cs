using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class ComputerLevelData
{
  [SerializeField]
  int id;
  public int Id { get {return id; } set { id = value;} }
  
  [SerializeField]
  int level;
  public int Level { get {return level; } set { level = value;} }
  
  [SerializeField]
  long cost;
  public long Cost { get {return cost; } set { cost = value;} }
  
  [SerializeField]
  float operationperseconds;
  public float Operationperseconds { get {return operationperseconds; } set { operationperseconds = value;} }
  
  [SerializeField]
  long miningmin;
  public long Miningmin { get {return miningmin; } set { miningmin = value;} }
  
  [SerializeField]
  long miningmax;
  public long Miningmax { get {return miningmax; } set { miningmax = value;} }
  
  [SerializeField]
  bool ismaxlevel;
  public bool Ismaxlevel { get {return ismaxlevel; } set { ismaxlevel = value;} }
  
}