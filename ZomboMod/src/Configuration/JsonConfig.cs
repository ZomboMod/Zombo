using System;
using System.IO;
using Newtonsoft.Json;

namespace ZomboMod.Configuration
{
    public abstract class JsonConfig : IConfig
    {
        [JsonIgnore]
        public string FileName { get; set; } = "config.json";

        public virtual void Load( string filePath )
        {
            if ( File.Exists( filePath ) )
            {
                try
                {
                    JsonConvert.PopulateObject( File.ReadAllText( filePath ), this );
                }
                catch (JsonReaderException ex)
                {
                    Console.Error.WriteLine( $"Invalid configuration '{FileName}'.");
                    Console.Error.WriteLine( ex );
                }
            }
            else
            {
                LoadDefaults();
                Save( filePath );
            }
        }

        public virtual void Save( string filePath )
        {
            File.WriteAllText( filePath, "" );

            FileStream fs = null;
            try
            {
                fs = new FileStream( filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite );

                using (TextWriter writer = new StreamWriter( fs ))
                {
                    var jsonWriter = new JsonTextWriter( writer );
                    var serializer = JsonSerializer.Create();

                    serializer.Formatting = Formatting.Indented;
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    serializer.Serialize( jsonWriter, this );

                    jsonWriter.Close();
                    writer.Close();
                }
            }
            finally
            {
                fs?.Dispose();
            }
        }

        public virtual void LoadDefaults() {}
    }
}
