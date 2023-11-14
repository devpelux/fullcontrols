using FullControls.Common;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    public class TimeBox : Control
    {
        /// <summary>
        /// ContentHost template part.
        /// </summary>
        protected const string PartContentHost = "PART_ContentHost";

        private TextBoxPlus? timeBox;


        /// <summary>
        /// Gets or sets the suggestion displayed if the control is empty.
        /// </summary>
        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Hint"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(TimeBox),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the label displayed alongside the control.
        /// </summary>
        public object Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Label"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(TimeBox),
                new FrameworkPropertyMetadata(null));


        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox),
                new FrameworkPropertyMetadata(typeof(TimeBox)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TimeBox"/>.
        /// </summary>
        public TimeBox() : base()
        {
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //todo add the textbox.
            timeBox = Template.FindName(PartContentHost, this) as TextBoxPlus ?? throw new NullReferenceException();
        }

        public RawTime GetRawTimeDate()
        {
            string text = timeBox?.Text ?? "";
            string daystr = text.Substring(0, 2);
            string monthstr = text.Substring(3, 2);
            string yearstr = text.Substring(6, 4);
            int day = int.Parse(daystr);
            int month = int.Parse(monthstr);
            int year = int.Parse(yearstr);

            return new(year, month, day);
        }

        public RawTime GetRawTimeMinutes()
        {
            string text = timeBox?.Text ?? "";
            string hourstr = text.Substring(0, 2);
            string minutestr = text.Substring(3, 2);
            int hour = int.Parse(hourstr);
            int minute = int.Parse(minutestr);

            return new(hour, minute);
        }
    }
}
