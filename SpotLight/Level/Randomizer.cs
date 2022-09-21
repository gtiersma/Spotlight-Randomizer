using GL_EditorFramework;
using Spotlight.EditorDrawables;
using Spotlight.GUI;
using System;
using static Spotlight.GUI.RandomizerForm;
using System.Collections.Generic;
using System.Text.Json;
using OpenTK;

namespace Spotlight.Level
{
    /**
     * Used to randomize level(s)
     */
    public class Randomizer
    {
        // How strict the randomizer should be in regards to picking a fitting object (based upon its beatability, gpu/cpu demandability, and intended difficulty)
        // The smaller the number, the more strict
        private const int ACCEPTANCE_RANGE = 10;

        // The max number of attempts the randomizer is willing to find a fitting object replacement before it's like,
        // "Screw it. I'm just going with this one."
        private const int MAX_TRIES = 30;

        // The zone currently being randomized
        private SM3DWorldZone zone;

        private RandomizerForm form;

        // Used for when the randomization is set to be consistent
        // Used to track which object types should be replaced by which other object types
        private Dictionary<string, RandoObject> objDict;

        public Randomizer(SM3DWorldZone zone, RandomizerForm form)
        {
            this.zone = zone;
            this.form = form;

            objDict = new Dictionary<string, RandoObject>();
        }

        /*
         * Begin randomizing all objects in the level
         */
        public void Randomize()
        {
            foreach (var (listName, objList) in zone.ObjLists)
            {
                if (listName == SM3DWorldZone.MAP_PREFIX + "ObjectList")
                {
                    for (int i = 0; i < objList.Count; i++)
                    {
                        if (objList[i] is General3dWorldObject obj)
                        {
                            RandomizeInstance(obj);
                        }
                    }
                }
            }
        }

        /*
         * Randomize a single object
         */
        private void RandomizeInstance(General3dWorldObject obj)
        {
            int randoObjCount = form.objects.Count;
            int selectedObjCount = form.selectedObjs.Count;

            for (int i = 0; i < randoObjCount; i++)
            {
                // Find the matching randomization data for the object
                var possibleMatch = form.objects[i];
                if (obj.ObjectName == possibleMatch.Name)
                {
                    // If the randomization is to be consistent, and this object type has already been randomized...
                    if (form.settings.BeConsistent && objDict.ContainsKey(obj.ObjectName))
                    {
                        // ...replace this object with the same one the last of its type was replace with.
                        Replace(obj, objDict[obj.ObjectName]);
                    }
                    // ...otherwise, pick a new object
                    else
                    {
                        Random r = new(Guid.NewGuid().GetHashCode());

                        RandoObject okObj = null; // Set to an object that is decided to be an acceptable replacer
                        int tries = 0; // The number of times the randomizer has tried to find a replacement for this object
                        while (okObj == null)
                        {
                            int rObjIndex = r.Next(selectedObjCount - 1); // Random index of a selected object
                            var randomObj = form.selectedObjs[rObjIndex];

                            // If the object is decided to be acceptable, or if this randomizer should give up trying to find a good one...
                            if (IsOk(possibleMatch, randomObj) || tries > MAX_TRIES)
                            {
                                // ...pick it
                                okObj = randomObj;
                            }
                            tries++;
                        }

                        // If tracking objects for consistency, add it to be tracked
                        if (form.settings.BeConsistent)
                        {
                            objDict.Add(obj.ObjectName, okObj);
                        }

                        Replace(obj, okObj);
                    }

                    i = randoObjCount; // Exit loop
                }
            }
        }
        
        /*
         * Replace the given 3d world object with the object in the given random object data
         */
        private void Replace(General3dWorldObject obj, RandoObject randomObject)
        {
            // Pick a random model for that given random object
            Random r = new(Guid.NewGuid().GetHashCode());
            int rModelIndex = r.Next(randomObject.Models.Count - 1);
            string randomModel = randomObject.Models[rModelIndex];

            // Pick a random class
            int rClassIndex = r.Next(randomObject.Classes.Count - 1);
            string randomClass = randomObject.Classes[rClassIndex];

            // Pick other random data and set it
            obj.ObjectName = randomObject.Name;
            obj.ModelName = randomModel;
            obj.ClassName = randomClass;
            obj.Properties = GetRandomProperties(randomObject);
            obj.Links = new(); // I think it helps slightly lower the odds of crashing?
            obj.Scale = GetRandomScale();
            obj.Rotation = GetRandomRotation(obj);
        }

        /*
         * Gets whether it should be acceptable to replace the given source object with the given replacement object
         */
        private bool IsOk(RandoObject sourceObj, RandoObject replacementObj)
        {
            // Values based upon user input
            int userSetRisk = form.settings.Beatable - 50;
            int gpuSet = form.settings.Demand - 50;
            int difficultySet = (form.settings.Difficulty - 50) / 2;

            // Calculate maximum allowed risk for the source object to block the level
            int maxRisk = replacementObj.Safety.Source + userSetRisk + ACCEPTANCE_RANGE;

            // Calculate the maximum allowed resource demand for the object
            int maxPowerAllowed = replacementObj.GpuPower + gpuSet + ACCEPTANCE_RANGE;

            int minDifficulty = replacementObj.Difficulty + difficultySet - ACCEPTANCE_RANGE;
            int maxDifficulty = replacementObj.Difficulty + difficultySet + ACCEPTANCE_RANGE;

            // Check if all the comparisons of this data are ok
            return sourceObj.Safety.Destination < maxRisk &&
                sourceObj.GpuPower < maxPowerAllowed &&
                sourceObj.Difficulty > minDifficulty && sourceObj.Difficulty < maxDifficulty;
        }

        /**
         * Gets a random scaling amount based on user input
         */
        private Vector3 GetRandomScale()
        {
            float x;
            float y;
            float z;

            double scaleRange = form.settings.MaxSize - form.settings.MinSize;

            Random r = new(Guid.NewGuid().GetHashCode());

            if (form.settings.ScaleRatio)
            {
                float scale = (float)(r.NextDouble() * scaleRange + form.settings.MinSize);
                x = scale;
                y = scale;
                z = scale;
            }
            else
            {
                x = (float)(r.NextDouble() * scaleRange + form.settings.MinSize);
                y = (float)(r.NextDouble() * scaleRange + form.settings.MinSize);
                z = (float)(r.NextDouble() * scaleRange + form.settings.MinSize);
            }

            return new Vector3(x, y, z);
        }

        /*
         * Get a random rotation amount if rotation is to be randomized
         */
        private Vector3 GetRandomRotation(General3dWorldObject obj)
        {
            float x = obj.Rotation.X;
            float y = obj.Rotation.Y;
            float z = obj.Rotation.Z;

            Random r = new(Guid.NewGuid().GetHashCode());

            if (form.settings.XRotation)
            {
                x = (float)(r.NextDouble() * 360);
            }
            if (form.settings.YRotation)
            {
                y = (float)(r.NextDouble() * 360);
            }
            if (form.settings.ZRotation)
            {
                z = (float)(r.NextDouble() * 360);
            }

            return new Vector3(x, y, z);
        }

        /*
         * Get random values for the properties in the given random object data
         */
        private Dictionary<string, dynamic> GetRandomProperties(RandoObject obj)
        {
            Random r = new(Guid.NewGuid().GetHashCode());

            Dictionary<string, dynamic> rProperties = new();

            foreach (RandoProp prop in obj.Properties)
            {
                // If we are using ranges for picking number properties and this is a number property...
                if (form.settings.UseRange && (prop.Type == "Int32" || prop.Type == "Single"))
                {
                    if (prop.Type == "Int32")
                    {
                        int min = 9001;
                        int max = 0;

                        // Find the lowest and highest property value
                        foreach (string cerealValue in prop.Values)
                        {
                            int value = JsonSerializer.Deserialize<int>(cerealValue);
                            if (value < min) min = value;
                            if (value > max) max = value;
                        }

                        // Add a little bit of extra room for the value
                        min = (int)(min * 0.5);
                        max = (int)(max * 1.5);

                        int randomValue = r.Next(max - min) + min;
                        rProperties.Add(prop.Name, randomValue);
                    }
                    // Same as above (except for floats instead of ints)
                    else
                    {
                        double min = 9001;
                        double max = 0;

                        foreach (string cerealValue in prop.Values)
                        {
                            double value = JsonSerializer.Deserialize<double>(cerealValue);
                            if (value < min) min = value;
                            if (value > max) max = value;
                        }

                        min *= 0.5;
                        max *= 1.5;

                        float randomValue = (float)(r.NextDouble() * (max - min) + min);
                        rProperties.Add(prop.Name, randomValue);
                    }
                }
                // Otherwise, if randomization is not being done in a range...
                else
                {
                    // ...pick a random number that has already been used with this object in a level before (deserializing it)
                    int rValue = r.Next(prop.Values.Count - 1);
                    string randomCereal = prop.Values[rValue];
                    dynamic randomValue = prop.Type switch
                    {
                        "Boolean" => JsonSerializer.Deserialize<bool>(randomCereal),
                        "Int32" => JsonSerializer.Deserialize<int>(randomCereal),
                        "Single" => JsonSerializer.Deserialize<float>(randomCereal),
                        _ => JsonSerializer.Deserialize<string>(randomCereal),
                    };
                    rProperties.Add(prop.Name, randomValue);
                }
            }

            return rProperties;
        }
    }
}
