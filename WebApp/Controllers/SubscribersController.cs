using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebApp.Models;

namespace WebApp.Controllers;

public class SubscribersController : Controller
{
    public IActionResult Index()
    {
        return View(new SubscribeViewModel());
    }


    [HttpPost]
    public async Task<IActionResult> Index(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                using var http = new HttpClient();

                var url = "https://localhost:7263/api/subscribers";
                var json = JsonConvert.SerializeObject(viewModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await http.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    viewModel.IsSubscribed = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                
            }
           
        }

        return BadRequest(ModelState);
    }

}



