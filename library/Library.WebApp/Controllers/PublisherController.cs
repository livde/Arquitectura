using Microsoft.AspNetCore.Mvc;
using library.application.Contracts;
using library.application.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Application.Dtos.Publisher;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    public class PublisherController(IPublisherService publisherService) : Controller
    {
        private readonly IPublisherService _publisherService = publisherService;
        private int id;

        public IActionResult Index()
        {
            var result = _publisherService.GetAll();
            if (result.Success)
            {
                return View(result.Data); // Asegúrate de que result.Data sea una lista de PublisherGetModel
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(new List<PublisherGetModel>());
            }
        }


        public IActionResult Details(int id)
        {
            var result = _publisherService.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PublisherAddDto publisherAddDto)
        {
            if (!ModelState.IsValid)
            {
                return View(publisherAddDto);
            }

            publisherAddDto.CreationDate = DateTime.UtcNow;
            var result = _publisherService.Save(publisherAddDto);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(publisherAddDto);
            }
        }

        public IActionResult Edit(int id)
        {
            var result = _publisherService.Get(id);
            if (result.Success)
            {
                PublisherGetModel? data = result.Data;
                var publisherList = new List<PublisherGetModel> { data }; // Crear una lista con un solo elemento
                return View(publisherList);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(new List<PublisherGetModel>()); // Devolver una lista vacía si no se encontró el objeto
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PublisherUpdateDto publisherUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(publisherUpdateDto);
            }

            publisherUpdateDto.ChangeDate = DateTime.UtcNow;
            var result = _publisherService.Update(publisherUpdateDto);
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(publisherUpdateDto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var result = _publisherService.Remove(new PublisherRemoveDto { PublisherId = id });
            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Message = result.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
