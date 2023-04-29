using System;
using System.IO;
using UnityEngine;

namespace InventorySystem
{
    /// <summary>
    /// Utility methods to write and load data to and from files. Files managed here are located in the "PersistentDataPath" folder, auto-managed by Unity.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Save to a file in Application.persistentDataPath
        /// </summary>
        /// <param name="fileName">Path and name of the file</param>
        /// <param name="fileContents">Content of the file</param>
        /// <returns>True if file has been written successfully, false otherwise</returns>
        public static bool WriteToFile(string fileName, string fileContents)
        {
            var fullPath = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                File.WriteAllText(fullPath, fileContents);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to write to {fullPath} with exception {e}");
                return false;
            }
        }

        /// <summary>
        /// Load data from a file in the persistentDataPath directory
        /// </summary>
        /// <param name="fileName">Path to the file</param>
        /// <param name="result">Result will be contained in this out parameter</param>
        /// <returns>True if success, false otherwise</returns>
        public static bool LoadFromFile(string fileName, out string result)
        {
            var fullPath = Path.Combine(Application.persistentDataPath, fileName);

            try
            {
                result = File.ReadAllText(fullPath);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to read from {fullPath} with exception {e}");
                result = "";
                return false;
            }
        }
    }
}