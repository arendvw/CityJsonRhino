This is an initial plugin grasshopper wrapper for CityJSON

It is tested against a very shallow set of examples 
- Bag3d
- Files converted from [CityGML to CityJSON using citygml tools](https://github.com/citygml4j/citygml-tools)

 and is not tested against the full possible standard of CityGML.

A demo version can be found in GrasshopperExamples/


 *Wrapper*
 - The main wrapping classes are generated using [Quicktype](https://quicktype.io/csharp). The version of CityJSON schema is 1.0.3.
 - Not all classes are implemented

 *Newtonsoft JSON*
 - This project relies on newtonsoft JSON. It's recommended not to ship this dll to grasshopper and rhino, since they will provide their own


 # Code + Projects

 ## CityJSON/


 This project contains