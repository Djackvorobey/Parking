using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt_Inzynierski_2._0
{
    class Server
    {
        public static async Task<T> Request<T>(string link)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage http_responge_message = await client.GetAsync(link);

                var ansver_json = await http_responge_message.Content.ReadAsStringAsync();
                var ansver = JsonSerializer.Deserialize<T>(ansver_json);
                return ansver;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return default(T);
            }
            
             
        }
    }
}
