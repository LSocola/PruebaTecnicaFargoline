using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi_MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44396/api/Cliente/Listar");
            
            var lista = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return View(lista);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44396/api/TipoDocumento/Listar");

            var lista = JsonConvert.DeserializeObject<List<TipoDocumento>>(json);
            ViewBag.tipos = new SelectList(lista, "IdDocumento", "Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {

                    httpClient.BaseAddress = new Uri("https://localhost:44396/");
                    String result = httpClient.PostAsync("api/Cliente/Registrar",
                                                  cliente,
                                                  new JsonMediaTypeFormatter()).Result.ToString();
                }
                return RedirectToAction("Index");
            }
            return View(cliente);

        }
        public async Task<ActionResult> Edit(int codigo)
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync("https://localhost:44396/api/TipoDocumento/Listar");

            var lista = JsonConvert.DeserializeObject<List<TipoDocumento>>(json);
            ViewBag.tipos = new SelectList(lista, "IdDocumento", "Descripcion");

            String uri = "https://localhost:44396/api/Cliente/Obtener/" + codigo;
            var json2 = await httpClient.GetStringAsync(uri);

            var cliente = JsonConvert.DeserializeObject<Cliente>(json2);
            if(cliente == null)
            {
                return RedirectToAction("Index");
            }
            return View(cliente);

        }
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    String result = httpClient.PutAsJsonAsync("https://localhost:44396/api/Cliente/Actualizar",cliente).Result.ToString();                  
                }
                return RedirectToAction("Index");
            }
            return View(cliente);

        }
        public ActionResult Delete(int codigo)
        {
            
            using (var httpClient = new HttpClient())
            {      
                String uri = "https://localhost:44396/api/Cliente/Eliminar/" + codigo;
                String result = httpClient.DeleteAsync(uri).Result.ToString();
            }
  
            return RedirectToAction("Index");

        }
        public async Task<ActionResult> Details(int codigo)
        {
            var httpClient = new HttpClient();
            String uri = "https://localhost:44396/api/Cliente/Obtener/" + codigo;
            var json = await httpClient.GetStringAsync(uri);

            var cliente = JsonConvert.DeserializeObject<Cliente>(json);
            if (cliente == null)
            {
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
    }
}