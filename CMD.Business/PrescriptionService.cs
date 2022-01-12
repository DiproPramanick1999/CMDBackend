using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using CMD.DTO.APIEntities;
using CMD.DTO.Converters;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.Business
{
    /// <summary>
    /// Implementation of Prescription Service to do the necessary CRUD operations
    /// </summary>
    public class PrescriptionService:IPrescriptionService
    {
        private IPrescriptionRepository repo = null;
        //DIP injection of repository
        public PrescriptionService()
        {
            this.repo = new PrescriptionRepository();
        }
        public PrescriptionService(IPrescriptionRepository repo)
        {
            this.repo = repo;
        }
        #region Prescription Functions Implementation
        /// <summary>
        /// To Get all the Existing Prescription info in the database
        /// </summary>
        /// <returns>The List of Prescription present in the database</returns>
        public List<Prescription> GetPrescriptions()
        {
            return repo.GetPrescriptions();
        }
        /// <summary>
        /// To Get the Prescription by the Prescription Id
        /// </summary>
        /// <param name="id">Takes int id as the parameter</param>
        /// <returns>Should return Prescription having the given prescription id</returns>
        public Prescription GetPrescriptionById(int id)
        {
            return repo.GetPrescriptionById(id);
        }
        /// <summary>
        /// To Add PrescriptionDTO info in the database
        /// </summary>
        /// <param name="prescription">Passing Prescription object as parameter</param>
        /// <returns>The Prescription after being added to the database</returns>
        public Prescription SavePrescription(Prescription prescription)
        {
            return repo.SavePrescription(prescription);
        }
        /// <summary>
        /// To Update an Existing Prescription info in the database
        /// </summary>
        /// <param name="prescription">Passing Prescription object as parameter</param>
        /// <returns>The Number of Rows Affected for Current Update </returns>
        public int EditPrescription(Prescription prescription)
        {
            return repo.EditPrescription(prescription);
        }
        /// <summary>
        /// To Delete the Prescription info from the database
        /// </summary>
        /// <param name="id">Takes int id as the parameter</param>
        /// <returns></returns>
        public int DeletePrescription(int id)
        {
            return repo.DeletePrescription(id);
        }
        #endregion

        #region PrescriptionDTO Functions Implementation
        /// <summary>
        /// To Get all the Existing PrescriptionDTO info in the database
        /// </summary>
        /// <returns>The List of PrescriptionDTO present in the database</returns>
        public List<PrescriptionDTO> GetPrescriptionDTOs()
        {
            List<PrescriptionDTO> dto = new List<PrescriptionDTO>();
            foreach (Prescription prescription in repo.GetPrescriptions())
            {
                dto.Add(prescription.ToPrescriptionDTO());
            }
            return dto;
        }
        /// <summary>
        /// To Get the PrescriptionDTO by the Prescription Id
        /// </summary>
        /// <param name="id">Takes int id as the parameter</param>
        /// <returns>Should return PrescriptionDTO having the given prescription id</returns>
        public PrescriptionDTO GetPrescriptionDTOById(int id)
        {
            return repo.GetPrescriptionById(id).ToPrescriptionDTO();
        }

        /// <summary>
        /// To Add PrescriptionDTO info in the database
        /// </summary>
        /// <param name="prescriptionDTO">Passing PrescriptionDTO object as parameter</param>
        /// <returns>The Prescription after being added to the database</returns>
        public PrescriptionDTO SavePrescriptionDTO(PrescriptionDTO prescriptionDTO)
        {
            return repo.SavePrescription(prescriptionDTO.ToPrescription(repo)).ToPrescriptionDTO();
        }
        /// <summary>
        /// To Update an Existing PrescriptionDTO info in the database
        /// </summary>
        /// <param name="prescriptionDTO">Passing PrescriptionDTO object as parameter</param>
        /// <returns>The Number of Rows Affected for Current Update </returns>
        public int EditPrescriptionDTO(PrescriptionDTO prescriptionDTO)
        {
            return repo.EditPrescription(prescriptionDTO.ToPrescription(repo));
        }
        #endregion

        #region Appointment Method Implementation
        /// <summary>
        /// To Get Appointment from the appointment id
        /// </summary>
        /// <param name="id">Takes int id as the parameter</param>
        /// <returns>The Appointment which has the given Appointment ID</returns>
        public Appointment GetAppointmentByAppointmentId(int id)
        {
            return repo.GetAppointmentByAppointmentId(id);
        }
        #endregion
    }
}
