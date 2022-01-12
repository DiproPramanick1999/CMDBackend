using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.ICMDRepository
{
    /// <summary>
    ///  Contract for Performing Get and Update operations on Vitals Table
    /// </summary>
    public interface IVitalRepository
    {
        /// <summary>
        /// to get all the vitals info present in the database
        /// </summary>
        /// <returns>List of Vital</returns>
        List<Vital> getAllVitals();
        /// <summary>
        /// to get vital by vital id 
        /// </summary>
        /// <param name="id">Accepts vital id of type int</param>
        /// <returns>vital info if found else returns null</returns>
        Vital getVitalById(int id);
        /// <summary>
        /// to get vital by appointment id
        /// </summary>
        /// <param name="id">Accepts id of type int which corresponse to an appointment id in vitals table</param>
        /// <returns>vital info corresponding to an appointment id if found else return null</returns>
        Vital getVitalByAppointmentId(int id);
        /// <summary>
        /// To update the info of the vitals in vital table
        /// </summary>
        /// <param name="v">Accepts the vital object to update in database </param>
        /// <returns>the number of rows affected by the current update</returns>
        int updateVital(Vital v);
    }
}
