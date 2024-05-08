using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;
using _4RTools.Forms;
using System.IO;
using System;
using _4RTools.Overlay;

namespace _4RTools.Model
{
    public class ProfileSingleton
    {
        public static Profile profile = new Profile("Default");

        public static void Load(string profileName)
        {
            try
            {
                string json = File.ReadAllText(AppConfig.ProfileFolder + profileName + ".json");
                dynamic rawObject = JsonConvert.DeserializeObject(json);

                if ((rawObject != null))
                {   
                    profile.Name = profileName;
                    profile.UserPreferences = JsonConvert.DeserializeObject<UserPreferences>(Profile.GetByAction(rawObject, profile.UserPreferences));
                    profile.AHK = JsonConvert.DeserializeObject<AHK>(Profile.GetByAction(rawObject, profile.AHK));
                    profile.Autopot = JsonConvert.DeserializeObject<Autopot>(Profile.GetByAction(rawObject, profile.Autopot));
                    profile.AutopotYgg = JsonConvert.DeserializeObject<Autopot>(Profile.GetByAction(rawObject, profile.AutopotYgg));
                    profile.StatusRecovery = JsonConvert.DeserializeObject<StatusRecovery>(Profile.GetByAction(rawObject, profile.StatusRecovery));
                    profile.AutoRefreshSpammer = JsonConvert.DeserializeObject<AutoRefreshSpammer>(Profile.GetByAction(rawObject, profile.AutoRefreshSpammer));
                    profile.Autobuff = JsonConvert.DeserializeObject<AutoBuff>(Profile.GetByAction(rawObject, profile.Autobuff));
                    profile.SongMacro = JsonConvert.DeserializeObject<Macro>(Profile.GetByAction(rawObject, profile.SongMacro));
                    profile.AtkDefMode = JsonConvert.DeserializeObject<ATKDEFMode>(Profile.GetByAction(rawObject, profile.AtkDefMode));
                    profile.MacroSwitch = JsonConvert.DeserializeObject<Macro>(Profile.GetByAction(rawObject, profile.MacroSwitch));
                    profile.Custom = JsonConvert.DeserializeObject<Custom>(Profile.GetByAction(rawObject, profile.Custom));
                    profile.DebuffsRecovery = JsonConvert.DeserializeObject<DebuffsRecovery>(Profile.GetByAction(rawObject, profile.DebuffsRecovery));
                    profile.AutoSwitch = JsonConvert.DeserializeObject<AutoSwitch>(Profile.GetByAction(rawObject, profile.AutoSwitch));
                    profile.OverlayCanvas = JsonConvert.DeserializeObject<OverlayCanvas>(Profile.GetByAction(rawObject, profile.OverlayCanvas));
                }
            }
            catch {
                throw new Exception("Houve um problema ao carregar o perfil. Delete a pasta Profiles e tente novamente.");   
            }
        }

        public static void Create(string profileName)
        {
            string jsonFileName = AppConfig.ProfileFolder + profileName + ".json";

            if (!File.Exists(jsonFileName))
            {
                if (!Directory.Exists(AppConfig.ProfileFolder)) { Directory.CreateDirectory(AppConfig.ProfileFolder); }
                FileStream fs = File.Create(jsonFileName);
                fs.Close();

                Profile profile = new Profile(profileName);
                string output = JsonConvert.SerializeObject(profile, Formatting.Indented);
                File.WriteAllText(jsonFileName, output);
            }

            ProfileSingleton.Load(profileName);
        }

        public static string CreateCopy(string profileName)
        {
            string fileName = AppConfig.ProfileFolder + profileName;
            string jsonFileName = fileName + ".json";
            string newFileName;
            string newJsonFileName;

            if (File.Exists(jsonFileName))
            {
                for (int i = 1; true;  i++)
                {
                    try
                    {
                        newFileName = fileName + i.ToString();
                        newJsonFileName = newFileName + ".json";
                        File.Copy(jsonFileName, newJsonFileName, false);
                        newFileName = profileName + i.ToString();
                        break;
                    } catch (Exception e)
                    {
                        continue;
                    }
                }
                return newFileName;
            } 
            else
            {
                throw new Exception("Houve um problema ao carregar o perfil selecionado.");
            }
        }

        public static void Delete(string profileName)
        {
            try
            {
                if (profileName != "Default") { File.Delete(AppConfig.ProfileFolder + profileName + ".json"); }
            }
            catch { }
        }

        public static void Rename(string profileName, string newProfileName)
        {
            string jsonFileName = AppConfig.ProfileFolder + profileName + ".json";
            string newJsonFilename = AppConfig.ProfileFolder + newProfileName + ".json";

            if (File.Exists(jsonFileName))
            {
                if (!File.Exists(newJsonFilename))
                {
                    File.Move(jsonFileName, newJsonFilename);
                } 
                else
                {
                    throw new Exception("There is already a profile with that name.");
                }
            }
            else
            {
                throw new Exception("There was a problem loading the selected profile.");
            }
        }

        public static void SetConfiguration(Action action)
        {
            if (profile != null)
            {
                string jsonData = File.ReadAllText(AppConfig.ProfileFolder + profile.Name + ".json");
                dynamic jsonObj = JsonConvert.DeserializeObject(jsonData);
                jsonObj[action.GetActionName()] = action.GetConfiguration();
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(AppConfig.ProfileFolder + profile.Name + ".json", output);
            }
        }

        public static Profile GetCurrent()
        {
            return profile;
        }
    }

    public class Profile
    {
        public string Name { get; set; }
        public UserPreferences UserPreferences { get; set; }
        public AHK AHK { get; set; }
        public Autopot Autopot { get; set; }
        public Autopot AutopotYgg { get; set; }
        public AutoRefreshSpammer AutoRefreshSpammer { get; set; }
        public AutoBuff Autobuff { get; set; }
        public StatusRecovery StatusRecovery { get; set; }
        public DebuffsRecovery DebuffsRecovery { get; set; }
        public Macro SongMacro { get; set;}
        public Macro MacroSwitch { get; set;}

        public Custom Custom { get; set; }
        public ATKDEFMode AtkDefMode { get; set; }
        public AutoSwitch AutoSwitch { get; set; }
        
        public OverlayCanvas OverlayCanvas { get; set; }

        public Profile(string name)
        {
            this.Name = name;

            this.UserPreferences = new UserPreferences();
            this.AHK = new AHK(); 
            this.Autopot = new Autopot(Autopot.ACTION_NAME_AUTOPOT);
            this.AutopotYgg = new Autopot(Autopot.ACTION_NAME_AUTOPOT_YGG);
            this.AutoRefreshSpammer = new AutoRefreshSpammer();
            this.Autobuff = new AutoBuff();
            this.StatusRecovery = new StatusRecovery();
            this.SongMacro = new Macro(Macro.ACTION_NAME_SONG_MACRO,MacroSongForm.TOTAL_MACRO_LANES_FOR_SONGS);
            this.MacroSwitch = new Macro(Macro.ACTION_NAME_MACRO_SWITCH, MacroSwitchForm.TOTAL_MACRO_LANES);
            this.AtkDefMode = new ATKDEFMode();
            this.DebuffsRecovery = new DebuffsRecovery();
            this.Custom = new Custom();
            this.AutoSwitch = new AutoSwitch();
            this.OverlayCanvas = new OverlayCanvas();
        }

        public static object GetByAction(dynamic obj, Action action)
        {
           if(obj != null && obj[action.GetActionName()] != null) {
                return obj[action.GetActionName()].ToString();
           }

            return action.GetConfiguration();
        }

    public static List<string> ListAll()
        {
            List<string> profiles = new List<string>();
            try
            {
                string[] files =  Directory.GetFiles(AppConfig.ProfileFolder);
                
                foreach(string fileName in files)
                {
                    string[] len = fileName.Split('\\');
                    string profileName = len[len.Length - 1].Split('.')[0];
                    profiles.Add(profileName);
                }
            }
            catch { }
            return profiles;
        }
    }

}
