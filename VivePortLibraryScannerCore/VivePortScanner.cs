using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VivePortLibraryScanner
{
    public interface IVivePortScanner
    {
        List<ViveGame> Scan(string appFolder);
    }

    public class VivePortScanner : IVivePortScanner
    {
        public List<ViveGame> Scan(string appFolder)
        {
            
            List<ViveGame> apps = Directory.EnumerateDirectories(appFolder)
                .Select(f => SearchManifest(f))
                .Where(_ => _ != null)
                .OrderBy(g => g.Name).ToList();
            return apps;
        }

        private ViveGame SearchManifest(string path)
        {
            ViveGame retval = null;

            
            var manifest = Path.Combine(path, "app.vrmanifest");

            if (!File.Exists(manifest) || !ViveGame.TryParse(manifest, out retval))
            {
                foreach (var folder in Directory.EnumerateDirectories(path))
                {
                    var apps = SearchManifest(folder);
                    if (apps != null)
                    {
                        retval = apps;
                        break;
                    }

                }
            }
            
            return retval;
        }        
    }

    
}
