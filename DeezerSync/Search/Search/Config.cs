﻿using System.IO;
using Search.Model;
using Newtonsoft.Json;

namespace Search
{
    public class Config
    {
        public static string soundcloud_profile { get; private set; }
        public static string soundcloud_clientid { get; private set; }
        public static string deezer_secret { get; private set; }

        private string path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");

        public Config()
        {

        }

        public Config(string path)
        {
            this.path = path;
        }

        public void Read()
        {
            try
            {
                string config = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<ConfigModel>(config);

                soundcloud_profile = result.SoundCloud_Username;
                soundcloud_clientid = result.SoundCloud_ClientID;
                deezer_secret = result.Deezer_Secret;

            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("No Config File in "+path+" found.");
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
            catch(JsonException ex)
            {
                throw new JsonException(ex.Message);
            }
        }
    }
}
