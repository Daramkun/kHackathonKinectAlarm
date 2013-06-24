using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KinectAlarm.Common
{
	public class MultiplyConverter : IValueConverter
	{
		double AsDouble ( object value )
		{
			return double.Parse ( value.ToString() );
		}

		public object Convert ( object value, Type targetType, object parameter, string language )
		{
            double vvvvvv = AsDouble(value) * AsDouble(parameter);
            Debug.WriteLine(vvvvvv);
			return vvvvvv;
		}

		public object ConvertBack ( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException ();
		}
	}
}
