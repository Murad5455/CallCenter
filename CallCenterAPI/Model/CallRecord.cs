using System.ComponentModel.DataAnnotations;

namespace CallCenterAPI.Model
{
    public class CallRecord
    {
        [Key]
        public int Id { get; set; }
        public string? CallId { get; set; }
        public string Internal { get; set; }
        public string External { get; set; }
        public string Status { get; set; }
        public string CallDuration { get; set; }
        public string SecondInternal { get; set; }
        public DateTime CallStart { get; set; }
        public string CallAnswered { get; set; }
        public string CallEnd { get; set; }
        public string Duration { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeAnswered { get; set; }
        public DateTime TimeEnd { get; set; }
        public string ReasonTerminated { get; set; }
        public string FromNo { get; set; }
        public string ToNo { get; set; }
        public string FromDn { get; set; }
        public string ToDn { get; set; }
        public string DialNo { get; set; }
        public string ReasonChanged { get; set; }
        public string FinalNumber { get; set; }
        public string FinalDn { get; set; }

      
        
 
    }
}
