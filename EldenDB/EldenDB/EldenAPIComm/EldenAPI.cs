using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace EldenAPIComm
{
#pragma warning disable CS8600
    //Code to access the API
    public class EldenAPI : IDisposable
    {
        const string BASE_URL = "https://eldenring.fanapis.com/api/";
        private HttpClient httpClient;
        public EldenAPI()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URL);
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        private async Task<T> HttpGet<T>(string endpoint)
        {
            T data = default(T);
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>();
            }
            return data;
        }

        public async Task<WeaponEndpoint.Datum> WeaponCallByNameAsync(string name)
        {
            WeaponEndpoint.Weapon retData =  await HttpGet<WeaponEndpoint.Weapon>($"weapons?name={name}");
            if (retData.count > 1) {
                foreach(WeaponEndpoint.Datum w in retData.data)
                {
                    if(w.name == name)
                    {
                        return w;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return retData.data[0];
            }
            return null;
        }
        public async Task<List<WeaponEndpoint.Datum>> InitializeWeaponData()
        {
            List<WeaponEndpoint.Datum> weaponList = new List<WeaponEndpoint.Datum>();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "weapondata.txt");
            if (!File.Exists(path))
            {
                for (int i = 0; i < 4; i++)
                {
                    WeaponEndpoint.Weapon retData = await HttpGet<WeaponEndpoint.Weapon>($"weapons?limit=100&page={i}");
                    for (int x = 0; x < retData.count; x++)
                    {
                        weaponList.Add(retData.data[x]);
                    }
                }
                using (StreamWriter sw = File.CreateText(path))
                {
                    await sw.WriteAsync(JsonSerializer.Serialize(weaponList));
                }
            }
            else
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string result = reader.ReadToEnd();
                    weaponList = JsonSerializer.Deserialize<List<WeaponEndpoint.Datum>>(result);
                }
            }
            return weaponList;
        }
        public async Task<List<ArmorEndpoint.Datum>> InitializeArmorData()
        {
            List<ArmorEndpoint.Datum> armorList = new List<ArmorEndpoint.Datum>();
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "armordata.txt");
            if (!File.Exists(path))
            {
                for (int i = 0; i < 6; i++)
                {
                    ArmorEndpoint.Armor retData = await HttpGet<ArmorEndpoint.Armor>($"armors?limit=100&page={i}");
                    for (int x = 0; x < retData.count; x++)
                    {
                        armorList.Add(retData.data[x]);
                    }
                }
                using (StreamWriter sw = File.CreateText(path))
                {
                    await sw.WriteAsync(JsonSerializer.Serialize(armorList));
                }
            }
            else
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    string result = reader.ReadToEnd();
                    armorList = JsonSerializer.Deserialize<List<ArmorEndpoint.Datum>>(result);
                }
            }
            return armorList;
        }
    }
#pragma warning restore CS8600
}
