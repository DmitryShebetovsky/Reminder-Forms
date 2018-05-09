using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    public enum RemindMode
    {
        One = 0,
        EveryMonth,
        EveryYear
    }
    [Serializable]
    public class Event
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public bool IsRemind { get; set; }
        public RemindMode GetRemind { get; set; }
        public override string ToString() 
        {
            if(IsRemind == true)
            return Name + " " + Time.Hour + ":" + Time.Minute + ":" + Time.Second + " !";
            else return Name + " " + Time.Hour + ":" + Time.Minute + ":" + Time.Second;
        }
    }
    [Serializable]
    public class DataBaseEvents : IEnumerable<Event>
    {  
        List<Event> events = new List<Event>();
        public void Add(Event e)
        {
            events.Add(e);
        }
        public void Remove(Event e)
        {
            events.Remove(e);
        }
        public int Length { get { return events.Count; } }
        public List<Event> GetEventsByDate(DateTime dateTime)
        {
            List<Event> listEevents = new List<Event>();
            foreach (var item in events)
            {
                if (dateTime.Month.Equals(item.Date.Month) && dateTime.Day.Equals(item.Date.Day))
                {
                    listEevents.Add(item);
                }
                else if(dateTime.Day.Equals(item.Date.Day) && item.GetRemind == RemindMode.EveryMonth)
                {
                    listEevents.Add(item);
                }
            }
            return listEevents;
        }
        public IEnumerator<Event> GetEnumerator()
        {
            return events.GetEnumerator();
        }
        public Event this[int index]
        {
            get
            {
                return events[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return events.GetEnumerator();
        }
    }
}
