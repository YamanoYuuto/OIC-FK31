using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data
{
    public class reservation
    {
        public int Id { get; set; }
        public int FacilityID { get; set; }
        public int UserDetailID { get; set; }
        public int TimeID { get; set; }
        public string Applications { get; set; }
        public int Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

    }
}
