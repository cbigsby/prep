using System;

namespace code.utility.matching
{
    public delegate Criteria<Value> StartingRange<in Value>();
    public delegate Criteria<Value> EndingRange<in Value>();

    public class Range
    {
        public static StartingRange<Value> starting_at<Value>(Value value, bool inclusive = true) where Value : IComparable<Value>
        {
            if (inclusive)
                return () => { return x => x.CompareTo(value) >= 0;};

            return () => { return x => x.CompareTo(value) > 0; };
        }

        public static EndingRange<Value> ending_at<Value>(Value value, bool inclusive = false) where Value : IComparable<Value>
        {
            if (inclusive)
                return () => { return x => x.CompareTo(value) <= 0; };

            return () => { return x => x.CompareTo(value) < 0; };
        }
    }

    public static class RangeExtensions
    {
        public static Criteria<Item> falls_in<Item, Value>(
            this IProvideAccessToMatchBuilders<Item, Value> extension_point,
            StartingRange<Value> lower_bound, EndingRange<Value> upper_bound) where Value : IComparable<Value>
        {
            return extension_point.create(lower_bound().and(upper_bound()));
        }

        public static Criteria<Item> falls_in<Item, Value>(
            this IProvideAccessToMatchBuilders<Item, Value> extension_point,
            StartingRange<Value> lower_bound) where Value : IComparable<Value>
        {
            return extension_point.create(lower_bound());
        }

        public static Criteria<Item> falls_in<Item, Value>(
            this IProvideAccessToMatchBuilders<Item, Value> extension_point,
            EndingRange<Value> lower_bound) where Value : IComparable<Value>
        {
            return extension_point.create(lower_bound());
        }
    }
}