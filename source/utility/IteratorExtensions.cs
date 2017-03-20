﻿using System.Collections.Generic;
using code.utility.matching;

namespace code.utility
{
  public static class IteratorExtensions
  {
    public static IEnumerable<Element> one_at_a_time<Element>(this IEnumerable<Element> items)
    {
      foreach (var element in items)
         yield return element;
    }

    public static IEnumerable<Element> filter_using<Element>(this IEnumerable<Element> items, Criteria<Element> criteria)
    {
      foreach (var element in items) if (criteria(element)) yield return element;
    }

    public static IEnumerable<Element> filter_using<Element>(this IEnumerable<Element> items, IMatchA<Element> criteria)
    {
      return items.filter_using(criteria.matches);
    }

    public static void each<Element>(this IEnumerable<Element> items, ElementVisitor<Element> visitor)
    {
      foreach (var element in items)
      {
        var result = visitor(element);
        if (! result) return;
      }
    }


    public static Value reduce<Element, Value>(this IEnumerable<Element> items, .....)
    {
      return value;
    }
  }
}