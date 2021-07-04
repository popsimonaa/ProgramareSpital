using Microsoft.AspNetCore.Mvc;
using ProgramareSpital.Services;
using ProgramareSpital.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgramareSpital.Controllers
{
    public class ProgramareController : Controller
    {
        private readonly IProgramareService _programareService;
        public ProgramareController(IProgramareService programareService)
        {
            _programareService = programareService;
        }
        public IActionResult Index()
        {
            ViewBag.DoctorList= _programareService.GetDoctorList();
            ViewBag.PatientList = _programareService.GetPatientList();
            ViewBag.Duration = Helper.GetTimeDropDown();

            return View();
        }
    }
}
