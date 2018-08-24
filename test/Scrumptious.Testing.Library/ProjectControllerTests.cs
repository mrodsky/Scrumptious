using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scrumptious.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Scrumptious.Testing.Library
{
    public class ProjectControllerTests
    {

        HttpClient client = new HttpClient();
        Project p = new Project()
        {
            ProjectName = "PostTest",
            ProjectDescription = "can we post",
            ProjectRequirements = "yes we can"
        };

        [Fact]
        void TestProjectController()
        {
            
            HttpRequestMessage req = new HttpRequestMessage();
            StringContent sc = new StringContent("{ProjectName:Hello}", Encoding.UTF8, "application/json");

            var result = client.PostAsync("http://localhost:62021/api/project", sc);

        }



    }
}
