using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;

namespace CityJsonRhino.Helper
{
    /// <summary>
    /// Class to help data access
    /// </summary>
    static class DataAccessHelper
    {
        /// <summary>
        /// Fetch data at index position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static T Fetch<T>(this IGH_DataAccess da, int position)
        {
            try
            {
                var temp = default(T);
                da.GetData(position, ref temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with position {position}", ex);
            }
        }

        /// <summary>
        /// Fetch data with name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Fetch<T>(this IGH_DataAccess da, string name)
        {
            try
            {
                var temp = default(T);
                da.GetData(name, ref temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with name {name}", ex);
            }
        }

        public static bool TryFetch<T>(this IGH_DataAccess da, int position, out T value)
        {

            try
            {
                var temp = default(T);
                var success = da.GetData(position, ref temp);
                value = temp;
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with position {position}", ex);
            }
        }

        public static bool TryFetch<T>(this IGH_DataAccess da, string name, out T value)
        {
            try
            {
                var temp = default(T);
                var success = da.GetData(name, ref temp);
                value = temp;
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with name {name}", ex);
            }
        }
        

        /// <summary>
        /// Fetch data list with position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static List<T> FetchList<T>(this IGH_DataAccess da, int position)
        {
            try
            {
                var temp = new List<T>();
                da.GetDataList(position, temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with position {position}", ex);
            }
        }

        /// <summary>
        /// Fetch data list with name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<T> FetchList<T>(this IGH_DataAccess da, string name)
        {
            try
            {
                var temp = new List<T>();
                da.GetDataList(name, temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with name {name}", ex);
            }
        }
        /// <summary>
        /// Fetch structure with position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static GH_Structure<T> FetchTree<T>(this IGH_DataAccess da, int position) where T : IGH_Goo
        {
            try
            {
                da.GetDataTree(position, out GH_Structure<T> temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with position {position}", ex);
            }
        }

        /// <summary>
        /// Fetch structure with name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="da"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GH_Structure<T> FetchTree<T>(this IGH_DataAccess da, string name) where T : IGH_Goo
        {
            try
            {
                da.GetDataTree(name, out GH_Structure<T> temp);
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not fetch data with name {name}", ex);
            }
        }
    }
}
