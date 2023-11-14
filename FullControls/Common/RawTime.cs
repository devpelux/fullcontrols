using System;

namespace FullControls.Common
{
    /// <summary>
    /// Manages raw date and time rappresentation, in a raw way, that is independent from time zone.
    /// </summary>
    public class RawTime
    {
        /// <summary>
        /// Gets the year.
        /// </summary>
        public int Year { get; private set; } = 1;

        /// <summary>
        /// Gets the month.
        /// </summary>
        public int Month { get; private set; } = 1;

        /// <summary>
        /// Gets the day.
        /// </summary>
        public int Day { get; private set; } = 1;

        /// <summary>
        /// Gets the hour in 24 military format.
        /// </summary>
        public int Hour { get; private set; } = 0;

        /// <summary>
        /// Gets the minute.
        /// </summary>
        public int Minute { get; private set; } = 0;

        /// <summary>
        /// Gets the second.
        /// </summary>
        public int Second { get; private set; } = 0;

        /// <summary>
        /// Gets the millisecond.
        /// </summary>
        public int Millisecond { get; private set; } = 0;

        /// <summary>
        /// Initializes a new instance.
        /// The date will be 01/Jan/0001.
        /// </summary>
        public RawTime(int hour, int minute) => SetTime(1, 1, 1, hour, minute, 0, 0);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RawTime(int year, int month, int day) => SetTime(year, month, day, 0, 0, 0, 0);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RawTime(int year, int month, int day, int hour, int minute) => SetTime(year, month, day, hour, minute, 0, 0);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RawTime(int year, int month, int day, int hour, int minute, int second) => SetTime(year, month, day, hour, minute, second, 0);

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public RawTime(int year, int month, int day, int hour, int minute, int second, int millisecond) => SetTime(year, month, day, hour, minute, second, millisecond);

        /// <summary>
        /// Gets a new instance from a raw long truncated to the day.
        /// </summary>
        public static RawTime FromRawLongDay(long raw) => FromRawLong(raw * 1000000000);

        /// <summary>
        /// Gets a new instance from a raw long truncated to the minute.
        /// </summary>
        public static RawTime FromRawLongMinute(long raw) => FromRawLong(raw * 100000);

        /// <summary>
        /// Gets a new instance from a raw long truncated to the second.
        /// </summary>
        public static RawTime FromRawLongSecond(long raw) => FromRawLong(raw * 1000);

        /// <summary>
        /// Gets a new instance from a raw long.
        /// </summary>
        public static RawTime FromRawLong(long raw)
        {
            int millisecond = (int)(raw % 1000);
            raw /= 1000;
            int second = (int)(raw % 100);
            raw /= 100;
            int minute = (int)(raw % 100);
            raw /= 100;
            int hour = (int)(raw % 100);
            raw /= 100;
            int day = (int)(raw % 100);
            raw /= 100;
            int month = (int)(raw % 100);
            raw /= 100;
            int year = (int)raw;

            return new RawTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Gets a new instance from the current time on this computer.
        /// </summary>
        public static RawTime GetCurrentTime()
        {
            DateTime time = DateTime.Now;
            return new RawTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }

        public long EncodeToRawLong() => EncodeToRawLongSecond() * 1000 + Millisecond;

        public long EncodeToRawLongSecond() => EncodeToRawLongMinute() * 100 + Second;

        public long EncodeToRawLongMinute()
        {
            long encodedTime = EncodeToRawLongDay();
            encodedTime *= 100;
            encodedTime += Hour;
            encodedTime *= 100;
            encodedTime += Minute;
            return encodedTime;
        }

        /// <summary>
        /// Codifica in formato long in modo posizionale troncando al giorno.
        /// L'anno occuperà le prime cifre, poi saranno inseriti mese e giorno.
        /// </summary>
        public long EncodeToRawLongDay()
        {
            long encodedTime = Year;
            encodedTime *= 100;
            encodedTime += Month;
            encodedTime *= 100;
            encodedTime += Day;
            return encodedTime;
        }

        /// <summary>
        /// Gets a new instance by truncating the time to the day.
        /// </summary>
        public RawTime Date() => new(Year, Month, Day);

        /// <summary>
        /// Gets a new instance with only hour, minute, and second.
        /// </summary>
        public RawTime TimeOfDay() => new(Hour, Minute, Second);

        /// <summary>
        /// Gets a new instance with only hour and minute.
        /// </summary>
        public RawTime TimeOfDayMinutes() => new(Hour, Minute);

        public RawTime AddHours(int hours)
        {
            DateTime time = new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond).AddHours(hours);
            return new RawTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }

        /// <summary>
        /// Gets the current minute of the day.
        /// </summary>
        public long MinuteOfDay() => (Hour * 60) + Minute;

        public DayOfWeek DayOfWeek() => new DateTime(Year, Month, Day).DayOfWeek;

        public string ToString(string type)
        {
            return type switch
            {
                "d" => $"{Day}/{Month}/{Year}",
                "t" => $"{TwoDigits(Hour)}:{TwoDigits(Minute)}",
                _ => $"{TwoDigits(Day)}/{TwoDigits(Month)}/{FourDigits(Year)} - {TwoDigits(Hour)}:{TwoDigits(Minute)}",
            };
        }

        public override string ToString() => ToString("dt");

        /// <summary>
        /// Gets the difference between two times.
        /// </summary>
        public static TimeSpan Difference(RawTime left, RawTime right)
        {
            DateTime leftTime = new(left.Year, left.Month, left.Day, left.Hour, left.Minute, left.Second, left.Millisecond);
            DateTime rightTime = new(right.Year, right.Month, right.Day, right.Hour, right.Minute, right.Second, right.Millisecond);
            return leftTime - rightTime;
        }

        /// <summary>
        /// Gets the difference between two times in minutes.
        /// </summary>
        public static long DifferenceInMinutes(RawTime left, RawTime right) => (long)Difference(left, right).TotalMinutes;

        /// <summary>
        /// Sets the specified time.
        /// </summary>
        private void SetTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            if (year < 1 || year > 9999) throw new ArgumentOutOfRangeException(nameof(year));
            if (month < 1 || month > 12) throw new ArgumentOutOfRangeException(nameof(month));
            if (day < 1 || day > DateTime.DaysInMonth(year, month)) throw new ArgumentOutOfRangeException(nameof(day));
            if (hour < 0 || hour > 23) throw new ArgumentOutOfRangeException(nameof(hour));
            if (minute < 0 || minute > 59) throw new ArgumentOutOfRangeException(nameof(minute));
            if (second < 0 || second > 59) throw new ArgumentOutOfRangeException(nameof(second));
            if (millisecond < 0 || millisecond > 59) throw new ArgumentOutOfRangeException(nameof(millisecond));

            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }
        
        private static string TwoDigits(long number) => number.ToString().PadLeft(2, '0');
        private static string FourDigits(long number) => number.ToString().PadLeft(4, '0');
    }
}
