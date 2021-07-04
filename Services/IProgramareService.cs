using ProgramareSpital.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgramareSpital.Services
{
    public interface IProgramareService 
    {
        public List<MedicVM> GetDoctorList();
        public List<PacientVM> GetPatientList();
        public Task<int> AddUpdate(AppointmentVM model);

        //pt a afisa programarile in functie de medicul selectat
        public List<AppointmentVM> DoctorsEventsById(string doctorId);
        public List<AppointmentVM> PatientsEventsById(string patientId);
        public AppointmentVM GetById(int id);
        public Task<int> Delete(int id);
        public Task<int> ConfirmEvent(int id);

    }
}
