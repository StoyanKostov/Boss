using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.ViewModels;
using WebApplication.Services;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private IAppRepository _repository;

        public AppController(IMailService mailSService, IConfigurationRoot config, IAppRepository repository)
        {
            _mailService = mailSService;
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}