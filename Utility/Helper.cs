using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProgramareSpital.Utility
{
    //static=>pt a fii folosit in tot codul
    public static class Helper 
    {
        public static string Admin = "Admin";
        public static string Pacient = "Pacient";
        public static string Medic = "Medic";
        public static string appointmentAdded = "Programarea a fost adaugata cu succes.";
        public static string appointmentUpdated = "Programarea a fost actualizata cu succes.";
        public static string appointmentDeleted = "Programarea a fost stearsa cu succes.";
        public static string appointmentExists = "Exista deja o programare pentru data si ora selectata.";
        public static string appointmentNotExists = "Programarea nu exista.";
        public static string meetingConfirm = "Programarea a fost confirmata cu succes.";
        public static string meetingConfirmError = "Eroare la confirmarea programarii.";
        public static string appointmentAddError = "Ceva nu a mers cum trebuie, te rog incearca din nou!";
        public static string appointmentUpdatError = "Ceva nu a mers cum trebuie, te rog incearca din nou!";
        public static string somethingWentWrong = "Ceva nu a mers cum trebuie, te rog incearca din nou!";
        public static int success_code = 1;
        public static int failure_code = 0;
        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                //new SelectListItem{Value = Helper.Admin, Text=Helper.Admin},
                new SelectListItem{Value = Helper.Pacient, Text=Helper.Pacient},
                new SelectListItem{Value = Helper.Medic, Text=Helper.Medic}
            };
        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for(int i=1; i <= 2; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr 30 min" });
            }
            return duration;
        }
    }
}
