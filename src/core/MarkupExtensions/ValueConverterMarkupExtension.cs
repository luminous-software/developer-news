﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DeveloperNews.UI.MarkupExtensions
{
    // http://putridparrot.com/blog/markupextension/
    // https://www.broculos.net/2014/04/wpf-how-to-use-converters-without.html

    public abstract class ValueConverterMarkupExtension : MarkupExtension, IValueConverter
    {
        public ValueConverterMarkupExtension()
        { }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}