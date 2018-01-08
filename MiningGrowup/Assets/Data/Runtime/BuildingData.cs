using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class BuildingData
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
  int computercount;
  public int Computercount { get {return computercount; } set { computercount = value;} }
  
  [SerializeField]
  bool ismaxlevel;
  public bool Ismaxlevel { get {return ismaxlevel; } set { ismaxlevel = value;} }
  
}