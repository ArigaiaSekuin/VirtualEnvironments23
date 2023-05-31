using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

namespace Homer
{
    public static class HomerJsonParser
    {
        public static string ApiVersion = "1.3";

        public static HomerProject LoadHomerProject(string jsonFileNameWithExt)
        {
            var pathAndFile = "Assets/Plugins/Homer/ProjectData/" + jsonFileNameWithExt;

            if (!System.IO.File.Exists(pathAndFile))
            {
                pathAndFile = "Assets/Homer/ProjectData/" + jsonFileNameWithExt;
                if (!System.IO.File.Exists(pathAndFile))
                    throw new Exception($"File {pathAndFile} does not exist.");
            }

            string jsonContent = System.IO.File.ReadAllText(pathAndFile).Trim();
            HomerProject project = JsonConvert.DeserializeObject<HomerProject>(jsonContent);

            if (project._apiVersion != ApiVersion)
            {
                Debug.Log($"WARNING: API VERSION ON UNITY PROJECT IS {ApiVersion} AND DOES NOT MATCH " +
                          $"JSON SERVICE VERSION {project._apiVersion}");
                Debug.Log($"YOU SHOULD UPDATE THE UNITY CLASSES FROM HOMER SUPPORT SITE homer.open-lab.com");


            }

            return project;
        }
    }
}
