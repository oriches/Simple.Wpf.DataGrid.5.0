using System;

namespace Simple.Wpf.DataGrid.Helpers;

public static class DateTimeHelper
{
    public static string DetermineFormat(DateTime dateTime) =>
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        dateTime.TimeOfDay.TotalSeconds == 0d
            ? Constants.UI.Grids.DateFormat
            : Constants.UI.Grids.DateTimeFormat;
}