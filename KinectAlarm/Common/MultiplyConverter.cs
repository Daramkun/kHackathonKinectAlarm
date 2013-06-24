using System;
using System.Collections.Generic;
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
			var valueText = value as string;
			if ( valueText != null )
				return double.Parse ( valueText );
			else
				return ( double ) value;
		}

		public object Convert ( object value, Type targetType, object parameter, string language )
		{
			return AsDouble ( value ) * AsDouble ( parameter );
		}

		public object ConvertBack ( object value, Type targetType, object parameter, string language )
		{
			throw new NotImplementedException ();
		}
	}
}
