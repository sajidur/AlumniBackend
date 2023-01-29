using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterKITDAL
{
    public class Member: BaseEntity
    {
        public string Name { get; set; }
        public string MemberNo { get; set; }
        public string UniversityBatch { get; set; }
        public string MSSYear { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string WhatsAppp { get; set; }
        public string FacebookId { get; set; }
        public string BloodGroup { get; set; }
        public string Designation { get; set; }
        public string Profession { get; set; }
        public string OfficeAddress { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string SpouseName { get; set; }
        public int NumberOfKids { get; set; }
        public string MarriageAnniversary { get; set; }
        public string Interest { get; set; }
        public string Achievements { get; set; }
        public string ProfilePicture { get; set; }
    }
}
