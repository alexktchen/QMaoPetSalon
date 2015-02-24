using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QMaoPetSalon.Models;

namespace QMaoPetSalon.Helper
{
    public class DataBaseHelper
    {
        readonly string mBaseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public void InitData()
        {
            using (var streamReader = new StreamReader(mBaseDir + "test.txt"))
            {

            }
        }


        async public Task<IList<T>> SaveAsync<T>(T aStr) where T : new()
        {

           
            using (var sr = new StreamReader(mBaseDir + "test.txt"))
            {
                string line = sr.ReadToEnd();
                var petVarietys = JsonConvert.DeserializeObject<List<T>>(line);
                petVarietys.Add(aStr);

                File.Delete(mBaseDir + "test.txt");

                using (var outfile = new StreamWriter(mBaseDir + "test.txt", true))
                {
                    var output = JsonConvert.SerializeObject(petVarietys);

                    await outfile.WriteAsync(string.Empty);
                }

            }



            return null;
        }

        //        async public Task<IEnumerable<T>> LoadAsync<T>() where T : new()
        //        {
        //            using (var sr = new StreamReader(mBaseDir + "test.txt"))
        //            {
        //                String line = sr.ReadToEnd();
        //                var petVariety = JsonConvert.DeserializeObject<PetVariety>(line);
        //
        //                return petVariety;
        //                // MainDataSource.Instance.PetVarietys.Add(petVariety);
        //            }
        //        }
    }
}
