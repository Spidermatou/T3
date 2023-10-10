﻿using System.IO;
using System.Text;
using Terriflux.Programs.GameContext;
using Terriflux.Programs.Model;

namespace Terriflux.Programs.Data.Management
{
    public static partial class DataManager
    {
        /* Security: Number of information required for a building. 
         * If less or more information than this is detected in the file, the entire invalid line cannot (and should not) be read! */
        private static readonly int NECESSARIES_BUILD_DATA = 6;

        public static StreamReader Load(string fileName)
        {
            string filePath = (Paths.DATA + fileName + Paths.TEXTEXT);
            if (File.Exists(filePath))
            {
                return new StreamReader(filePath);
            }
            else
            {
                throw new FileNotFoundException($"Unable to find the specified file at '{filePath}'");
            }
        }

        public static StreamReader LoadBuildingData()
        {
            return Load("Buildings");
        }

        public static string PrintAvaibleBuildings()
        {
            StringBuilder result = new();
            StreamReader reader = LoadBuildingData();

            result.AppendLine("Avaible buildings:");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] split = line.Split(";");

                if (split.Length == NECESSARIES_BUILD_DATA)
                {
                    BuildingModel model = BuildingModel.CreateFromName(split[0]);
                    result.Append(model.Verbose());
                    result.Append("---\n");
                }
            }

            return result.ToString();
        }
    }
}
