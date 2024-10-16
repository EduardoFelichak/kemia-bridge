using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KemiaBridge.Domain.Entities
{
    [Table("activity")]
    public class Activity
    {
        [Key]
        public int ActivityId { get; private set; }
        public string Title { get; private set; }
        public int Priority { get; private set; }
        public DateTime LimitDate { get; private set; }
        public int Status { get; private set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; private set; }
        [ForeignKey(nameof(Station))]
        public int StationId { get; private set; }-

        #pragma warning disable CS8618
        public Activity() { }

        public Activity(int activityId, string title,  int priority, DateTime limitDate, int status, int userId, int stationId)
        {
            ActivityId = activityId;
            Title      = title;
            Priority   = priority;
            LimitDate  = limitDate;
            Status     = status;    
            UserId     = userId;
            StationId  = stationId;
        }
    }
}
