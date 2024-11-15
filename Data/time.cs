using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data
{
    public class time
    {
        public int TimeID { get; set; }
        public int FacilityID { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartTime  { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

    }
}
