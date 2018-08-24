using Newtonsoft.Json;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scrumptious.Testing.Service
{
    public class ProjectControllerTests
    {

        HttpClient client = new HttpClient();

        


        
        void TestProjectController()
        { 
            var P = new Project();
            HttpRequestMessage req = new HttpRequestMessage();
            StringContent sc = new StringContent(JsonConvert.SerializeObject(P), Encoding.UTF8, "application/json");
            
            var result = client.PostAsync("http://localhost:62021/api/project", sc);
        }



      
    }
}
