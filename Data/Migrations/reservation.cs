using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data.Migrations
{
    public class reservation
    {
        public int Id { get; set; }
        public string FacilityID { get; set; }
        public int UserID {get; set; }
        public string Applications { get; set; }
        public int Number {  get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
    }
}
