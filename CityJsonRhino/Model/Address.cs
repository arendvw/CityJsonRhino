using System.Collections.Generic;
using CityJSON;
using CityJsonRhino.Helper;
using Rhino.Geometry;

namespace CityJsonRhino.Model
{
    public class Address
    {
        public Address() { }
        public Address(Address address)
        {
            if (address == null)
            {
                return;
            }
            Location = address.Location;
            PostalCode = address.PostalCode;
            Street = address.Street;
            Number = address.Number;
            CountryName = address.CountryName;
            LocalityName = address.LocalityName;
        }
        public static Address LoadFrom(CityJSON.Address source, CityJsonDocument doc)
        {
            if (source == null)
            {
                return null;
            }
            return new Address
            {
                PostalCode = source.PostalCode,
                CountryName = source.CountryName,
                LocalityName = source.LocalityName,
                Street = source.ThoroughfareName,
                Number = source.ThoroughfareNumber,
                Location = doc.GetVertices(source.Location.Boundaries).ToPoint3dList(),
            };
        }

        public override string ToString()
        {
            return $"{Street} {Number} {PostalCode} {LocalityName} {CountryName}";
        }

        public List<Point3d> Location { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string CountryName { get; set; }
        public string LocalityName { get; set; }
    }
}