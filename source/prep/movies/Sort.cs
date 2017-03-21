using System;
using code.utility;
using code.utility.matching;

namespace code.prep.movies
{
  public class SortOrder
  {
    public static int ascending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return a.CompareTo(b);
    }

    public static int descending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return b.CompareTo(a);
    }
  }

  public class Sort<Item>
  {
    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor, ICompareTwoItems<Property> order)
      where Property : IComparable<Property>
    {
      return (a, b) => order(accessor(a), accessor(b));
    }

    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor,
      params Property[] sort_order)
    {
      return (a, b) => Array.IndexOf(sort_order, accessor(a)) - Array.IndexOf(sort_order, accessor(b));
    }
  }

  public static class SortExtensions
  {
    public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer,
      IGetTheValueOfAProperty<Item, Property> accessor, ICompareTwoItems<Property> order) where Property : IComparable<Property>
    {
      return (a, b) =>
      {
        var previous_result = previous_comparer(a, b);
        return previous_result == 0 ? Sort<Item>.by(accessor, order)(a, b) : previous_result;
      };
    }
  }
}