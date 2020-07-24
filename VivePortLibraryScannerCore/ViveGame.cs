using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace VivePortLibraryScanner
{
    public partial class ViveGame
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public string Thumbnail { get; set; }

        public string AppKey { get; set; }

        public string LaunchType { get; set; }

        public string Arguments { get; set; }

        public string ExePath { get; set; }
    }

    public partial class ViveGame
    {
        public static bool TryParse(string file, out ViveGame game)
        {
            game = Parse(file);
            return game != null;
        }
        public static ViveGame Parse(string file)
        {

            ViveGame retval = null;
            try
            {
                var vapp = JsonConvert.DeserializeObject<ViveApp>(File.ReadAllText(file));
                if (vapp.Applications.Length > 1)
                {

                }
                var app = vapp.Applications.FirstOrDefault();
                if (app != null || !app.IsDashboardOverlay)
                {
                    var folder = Path.GetDirectoryName(file);
                    retval = new ViveGame
                    {
                        Name = app.Strings["en_us"].Name,
                        Url = app.Url,
                        Thumbnail = Path.Combine(folder, app.ImagePath),
                        AppKey = app.AppKey,
                        Arguments = app.Arguments,
                        ExePath = Path.Combine(folder, app.BinaryPathWindows),
                        LaunchType = app.LaunchType

                    };
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(file + ": " + x.Message);
                throw;
            }

            return retval;
        }
    }
}
