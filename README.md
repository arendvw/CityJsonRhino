# CityJSON for Grasshopper
This is an initial plugin grasshopper wrapper for CityJSON

This code is an abandoned, but functional WIP, it is tested and built for a very limited set of test cases.

It is tested against a very shallow set of examples, mainly aimed at buildings.
- Bag3d
- Files converted from [CityGML to CityJSON using citygml tools](https://github.com/citygml4j/citygml-tools)

It is still developer oriented, knowledge of [CityJSON topology](https://www.cityjson.org/about/) is adviced for the components to make sense.

## Geometry
Supported:
- MultiSurface
- Solid

Unsupported:
- CompositeSolid
- CompositeSurface
- GeometryInstance
- MultiLineString
- MultiPoint
- MultiSolid


## Demo
A demo version can be found in GrasshopperExamples/


## Installation
A test build can be found in releases/


## For developers

 *Wrapper*
 - Not all classes are implemented

 *Newtonsoft JSON*
 - This project relies on newtonsoft JSON. It's recommended not to ship this dll to grasshopper and rhino, since they will provide their own


 ## Code + Projects

 ### CityJSON/
This project contains the main wrapper code. Can be used outside Grasshopper / Rhino

The main wrapping classes are generated using [Quicktype](https://quicktype.io/csharp). The version of CityJSON schema is 1.0.3.


 ### CityJSONRhino/

Should probably be called CityJSONGh, but here we are. Contains grasshopper wrapper code for the main datatypes (CityJSONDocument, CityJSONObject, etc.)

### TestCityJSON/
Contains very rudementary tests to serialize and deserialize JSON documents.

### TestData
Contains several example city json files (Bag3d, and citygml converted minimal and maximal examples).