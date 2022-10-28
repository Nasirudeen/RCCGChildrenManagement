using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RccgChildrenManagement.Models;


namespace RccgChildrenManagement.Models
{
    public class RccgRepository : IRccgRepository
    {
        private RccgDbContext context;

        public RccgRepository(RccgDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<AuditTrail> AuditTrails => context.AuditTrails;
        public IQueryable<Attendance> Attendances => context.Attendances;

        public IQueryable<Children> Childrens => context.Childrens;
      public IQueryable<Role> Roles => context.Roles;
       
        public IQueryable<User> Users => context.Users;

        public IQueryable<ResponsibleParty> ResponsiblePartys => context.ResponsiblePartys;

        public IQueryable<Otp> Otps => context.Otps;
       


        public void AddAuditTrail(AuditTrail a)
        {
            context.AuditTrails.Add(a);
        }
        public void AddAttendance(Attendance a)
        {
            context.Attendances.Add(a);
        }
        public void AddChildren(Children w)
        {
            context.Childrens.Add(w);
        }

        
      
        public void AddUser(User b)
        {
            context.Users.Add(b);
        }
        public void AddRole(Role s)
        {
            context.Roles.Add(s);
        }
        public void AddResponsibleParty(ResponsibleParty s)
        {
            context.ResponsiblePartys.Add(s);
        }
        public void AddOtp(Otp s)
        {
            context.Otps.Add(s);
        }
      

        public void RemoveAuditTrail(AuditTrail a)
        {
            context.AuditTrails.Remove(a);
        }
        public void RemoveAttendance(Attendance b)
        {
            context.Attendances.Remove(b);
        }

        public void RemoveChildren(Children b)
        {
            context.Childrens.Remove(b);
        }
        
       
        public void RemoveRole(Role s)
        {
            context.Roles.Remove(s);
        }
       
        public void RemoveUser(User o)
        {
            context.Users.Remove(o);
        }
        public void RemoveResponsibleParty(ResponsibleParty o)
        {
            context.ResponsiblePartys.Remove(o);
        }

        public void Save()
        {
            context.SaveChanges();

        }

        public void Remove()
        {
            context.SaveChanges();
        }

       
    }
}

