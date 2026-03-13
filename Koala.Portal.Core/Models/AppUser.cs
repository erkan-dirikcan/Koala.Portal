using Koala.Portal.Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.Core.Models
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Events = new HashSet<AgendaUsers>();
            ManagedProjects = new HashSet<Project>();
            ApplicationLicences = new HashSet<ApplicationLicences>();
            Transactions = new HashSet<Transaction>();
            Vacations = new HashSet<VacationRequest>();
            VacationHistory = new HashSet<VacationHistory>();
        }


        public string? Oid { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Avatar { get; set; }
        public UserStatusEnum Status { get; set; } = UserStatusEnum.Active;
        public string SKey { get; set; } = "";
        public decimal Vacation { get; set; }



        public virtual ICollection<ApplicationLicences> ApplicationLicences { get; set; }
        public virtual ICollection<AgendaUsers> Events { get; set; }


        /// <summary>
        /// Yöneticisi Olduğu Projeler
        /// </summary>
        public virtual ICollection<Project> ManagedProjects { get; set; }

        /// <summary>
        /// Sorumlu Olduğu Fazlar
        /// </summary>
        public virtual ICollection<ProjectLine> ManagedProjectLine { get; set; }
        /// <summary>
        /// Çalıştığı Projeler
        /// </summary>
        public virtual ICollection<ProjectPerson> WorkedProjectLineWorks { get; set; }

        /// <summary>
        ///Kullanıcı Transactionları
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }
        /// <summary>
        /// Kullanıcı İzinleri
        /// </summary>
        public virtual ICollection<VacationRequest> Vacations { get; set; }
        /// <summary>
        /// Kullanıcı İzin Geçmişi
        /// </summary>
        public virtual ICollection<VacationHistory> VacationHistory { get; set; }


        public string GetFullName()
        {
            return $"{Name} {Lastname}";
        }

        public string GetEmail()
        {
            return Email;
        }
    }
}

