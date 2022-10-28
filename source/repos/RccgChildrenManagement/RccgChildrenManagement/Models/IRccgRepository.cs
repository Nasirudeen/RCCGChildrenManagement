using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RccgChildrenManagement.Models;


namespace RccgChildrenManagement.Models
{
    public interface IRccgRepository
    {
       
        IQueryable<AuditTrail> AuditTrails { get; }
        IQueryable<Attendance> Attendances { get; }
        IQueryable<Children> Childrens { get; }
       
        IQueryable<ResponsibleParty> ResponsiblePartys { get; }
       
        IQueryable<User> Users { get; }

        IQueryable<Role> Roles { get; }
        IQueryable<Otp> Otps { get; }
        



        public void AddAuditTrail(AuditTrail d);
        public void AddAttendance(Attendance d);
        public void AddChildren(Children w);      
       
      
        public void AddResponsibleParty(ResponsibleParty d);
        public void AddRole(Role f);   

        public void AddUser(User q);
        public void AddOtp(Otp q);
     




        public void RemoveAuditTrail(AuditTrail f);
        public void RemoveAttendance(Attendance f);
        public void RemoveChildren(Children f);
          
        public void RemoveResponsibleParty(ResponsibleParty f);
       
        public void RemoveUser(User q);
        public void RemoveRole(Role s);



        public void Save();

        public void Remove();
      
       
    }
}

