using CMD.DataAccess.ICMDRepository;
using CMD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD.DataAccess.CMDRepository
{
    public class CommentRepository : ICommentRepository 
    {
        CMDDbContext db = new CMDDbContext();
        /// <inheritdoc/>
        public Appointment GetAppointmentById(int id)
        {
           return db.Appointments.Find(id);
        }
        /// <inheritdoc/>
        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await db.Appointments.Where(app => app.AppointmentId == id).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>

        public Comment GetCommentByAppointmentId(int id)
        {
            Comment comment1 = db.Comments.Where(comment => comment.Appointment.AppointmentId == id).FirstOrDefault();
            return comment1;
        }
        /// <inheritdoc/>
        public async Task<Comment> GetCommentByAppointmentIdAsync(int id)
        {
            return await db.Comments.Where(cmt => cmt.Appointment.AppointmentId == id).FirstOrDefaultAsync();
        }
        /// <inheritdoc/>
        public List<Comment> GetComments()
        {
            return db.Comments.ToList();
        }

        /// <inheritdoc/>
        public async Task<List<Comment>> GetCommentsAsync()
        {
            return await db.Comments.ToListAsync();
        }
        /// <inheritdoc/>
        public bool SaveComment(Comment comment)
        {
            db.Comments.Add(comment);
            return db.SaveChanges() > 0;
        }
        /// <inheritdoc/>
        public async Task<bool> SaveCommentAsync(Comment comment)
        {
            db.Comments.Add(comment);
            return (await db.SaveChangesAsync()>=1); 
        }

        /// <inheritdoc/>
        public bool UpdateAppointment(Appointment appointment)
        {
            db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        /// <inheritdoc/>
        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            db.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            return (await db.SaveChangesAsync() >= 1);
        }

        /// <inheritdoc/>
        public int UpdateComment(Comment comment)
        {
            int cnt = 0;            
                db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
                cnt = db.SaveChanges();   
            return cnt;
        }
        /// <inheritdoc/>
        public async Task<int> UpdateCommentAsync(Comment comment)
        {
            int cnt = 0;
            db.Entry(comment).State = System.Data.Entity.EntityState.Modified;
            cnt = await db.SaveChangesAsync();
            return cnt;
        }
    }
}
