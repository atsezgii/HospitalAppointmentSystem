using Application.Repositories;
using Domain.Entities;

namespace Application.Services.PatientService
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientManager(IPatientRepository patientRepository)
        {
                _patientRepository = patientRepository;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            Patient? patient = await _patientRepository.GetAsync(i => i.Id == id);
            return patient;
        }
    }
}
