using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reminder
{
    public partial class Reminder : Form
    {
        DataBaseEvents DBEvents = new DataBaseEvents();
        BindingList<Event> currentEventsDay = new BindingList<Event>();
        bool editMode = false;
        public Reminder()
        {
            InitializeComponent();
            DeSerializeDB();
            Events.DataSource = currentEventsDay;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Handler);
            timer.Start();
        }

        private void Handler(Object o, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            bool isChange = false;
            for (int item = 0; item < DBEvents.Length; item++)
            {
                if (DBEvents[item].IsRemind)
                {
                    if (currentTime.Month == DBEvents[item].Date.Month
                    && currentTime.Day == DBEvents[item].Date.Day)
                    {
                        if (currentTime.Hour == DBEvents[item].Time.Hour
                        && currentTime.Minute == DBEvents[item].Time.Minute
                        && currentTime.Second == DBEvents[item].Time.Second)
                        {
                            MessageBox.Show(DBEvents[item].Name, "Напоминание!");
                            if (DBEvents[item].GetRemind == RemindMode.One)
                            {
                                if (Calendar.SelectionStart.Day == DBEvents[item].Date.Day
                                && Calendar.SelectionStart.Month == DBEvents[item].Date.Month)
                                {

                                    DBEvents.Remove(DBEvents[item]);
                                    Events.DataSource = DBEvents.GetEventsByDate(Calendar.SelectionStart);
                                }
                                else DBEvents.Remove(DBEvents[item]);
                                Events.Update();
                                item--;
                                isChange = true;
                            }
                        }
                    }
                    else if (DBEvents[item].GetRemind == RemindMode.EveryMonth
                         && currentTime.Day == DBEvents[item].Date.Day)
                    {
                        if (currentTime.Date.Hour == DBEvents[item].Time.Hour
                        && currentTime.Date.Minute == DBEvents[item].Time.Minute
                        && currentTime.Date.Second == DBEvents[item].Time.Second)
                        {
                            MessageBox.Show(DBEvents[item].Name, "Напоминание!");
                            if (Calendar.SelectionStart.Day == DBEvents[item].Date.Day
                                && Calendar.SelectionStart.Month == DBEvents[item].Date.Month)
                            {

                                DBEvents.Remove(DBEvents[item]);
                                Events.DataSource = DBEvents.GetEventsByDate(Calendar.SelectionStart);
                            }
                            else DBEvents.Remove(DBEvents[item]);
                            Events.Update();
                            item--;
                            isChange = true;
                        }
                    }
                }
            }
            if (isChange)
            {
                SerializeDB();

                setBoldedDayToCalendar();
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            EventBox.Enabled = true;
            editMode = false;
            DateEvent.Value = DateTime.Now;
            AddButton.Enabled = false;
            EditButton.Enabled = false;
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            EventBox.Enabled = true;
            editMode = true;
            Event changedEvent = (Event)Events.SelectedItem;
            panel1.Enabled = false;
            Calendar.Enabled = false;
            Events.Enabled = false;
            NameEvent.Text = changedEvent.Name;
            Repeat.SelectedIndex = (int)changedEvent.GetRemind;
            DateEvent.Value = changedEvent.Time;
            IsRemind.Checked = changedEvent.IsRemind;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            Calendar.Enabled = true;
            Events.Enabled = true;
            EnableEditDel();
            panel1.Enabled = true;
            EventBox.Enabled = false;
            NameEvent.Clear();
            Repeat.Text = null;
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (editMode) { OKEdit(); }
            else { OKAdd(); }
            EventBox.Enabled = false;
            AddButton.Enabled = true;
            Calendar.Enabled = true;
            Events.Enabled = true;
            EnableEditDel();
            panel1.Enabled = true;
            NameEvent.Clear();
            Repeat.Text = null;
        }
        private void OKAdd()
        {
            Event e = new Event();
            e.Name = NameEvent.Text;
            if (e.Name == "")
                return;

            e.IsRemind = IsRemind.Checked;

            if (Repeat.SelectedIndex != -1)
            {
                if (Repeat.SelectedIndex == 0)
                    e.GetRemind = RemindMode.One;
                else if (Repeat.SelectedIndex == 1)
                    e.GetRemind = RemindMode.EveryMonth;
                else if (Repeat.SelectedIndex == 2)
                    e.GetRemind = RemindMode.EveryYear;
            }
            e.Time = DateEvent.Value;
            e.Date = Calendar.SelectionStart;
            switch (e.GetRemind)
            {
                case RemindMode.One:
                    var newListBoldedDates = Calendar.BoldedDates.ToList();
                    newListBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.BoldedDates = newListBoldedDates.ToArray();
                    break;

                case RemindMode.EveryMonth:
                    var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                    newListMonthlyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                    break;

                case RemindMode.EveryYear:
                    var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                    AnnuallyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                    break;
                default:
                    break;
            }
            DBEvents.Add(e);
            Calendar_DateSelected(null, null);
            SerializeDB();
        }

        private void OKEdit()
        {
            if (NameEvent.Text == "")
                return;
            Event changedEvent = (Event)Events.SelectedItem;
            changedEvent.IsRemind = IsRemind.Checked;
            changedEvent.Name = NameEvent.Text;
            if (Repeat.SelectedIndex != -1)
            {
                if (Repeat.SelectedIndex == 0)
                    changedEvent.GetRemind = RemindMode.One;
                else if (Repeat.SelectedIndex == 1)
                    changedEvent.GetRemind = RemindMode.EveryMonth;
                else if (Repeat.SelectedIndex == 2)
                    changedEvent.GetRemind = RemindMode.EveryYear;
            }
            changedEvent.Time = DateEvent.Value;
            changedEvent.Date = Calendar.SelectionStart;
            switch (changedEvent.GetRemind)
            {
                case RemindMode.One:
                    var newListBoldedDates = Calendar.BoldedDates.ToList();
                    newListBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.BoldedDates = newListBoldedDates.ToArray();
                    break;
                case RemindMode.EveryMonth:
                    var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                    newListMonthlyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                    break;
                case RemindMode.EveryYear:
                    var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                    AnnuallyBoldedDates.Add(Calendar.SelectionStart);
                    Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                    break;
                default:
                    break;
            }
            setBoldedDayToCalendar();
            SerializeDB();
            Events.Update();
        }
        private void EnableEditDel()
        {
            if (Events.SelectedIndex != -1)
            {
                EditButton.Enabled = true;
                DelButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DelButton.Enabled = false;
            }
        }
        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            currentEventsDay = new BindingList<Event>(DBEvents.GetEventsByDate(Calendar.SelectionStart));
            Events.DataSource = currentEventsDay;
            EnableEditDel();
        }
        private void SerializeDB()
        {
            FileStream fs = new FileStream("Events.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, DBEvents);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        private void DeSerializeDB()
        {
            FileStream fs = new FileStream("Events.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                DBEvents = (DataBaseEvents)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Error: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
            setBoldedDayToCalendar();
        }
        private void setBoldedDayToCalendar()
        {
            Calendar.BoldedDates = null;
            Calendar.MonthlyBoldedDates = null;
            Calendar.AnnuallyBoldedDates = null;
            foreach (var item in DBEvents)
            {
                switch (item.GetRemind)
                {
                    case RemindMode.One:
                        var newListBoldedDates = Calendar.BoldedDates.ToList();
                        newListBoldedDates.Add(item.Date);
                        Calendar.BoldedDates = newListBoldedDates.ToArray();
                        break;

                    case RemindMode.EveryMonth:
                        var newListMonthlyBoldedDates = Calendar.MonthlyBoldedDates.ToList();
                        newListMonthlyBoldedDates.Add(item.Date);
                        Calendar.MonthlyBoldedDates = newListMonthlyBoldedDates.ToArray();
                        break;

                    case RemindMode.EveryYear:
                        var AnnuallyBoldedDates = Calendar.AnnuallyBoldedDates.ToList();
                        AnnuallyBoldedDates.Add(item.Date);
                        Calendar.AnnuallyBoldedDates = AnnuallyBoldedDates.ToArray();
                        break;
                    default:
                        break;
                }
            }
        }
        private void DelButton_Click(object sender, EventArgs e)
        {
            Event removedItem = (Event)Events.SelectedItem;
            DBEvents.Remove(removedItem);
            currentEventsDay.Remove(removedItem);
            removedItem = null;
            SerializeDB();
            if (Events.SelectedIndex != -1)
            {
                EditButton.Enabled = true;
                DelButton.Enabled = true;
            }
            else
            {
                EditButton.Enabled = false;
                DelButton.Enabled = false;
            }
            setBoldedDayToCalendar();
        }
    }
}
