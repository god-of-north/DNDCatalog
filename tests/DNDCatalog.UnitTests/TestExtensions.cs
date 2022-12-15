using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCatalog.UnitTests;

public static class TestExtensions
{
    /// <summary>
    /// Generates set of uniq combinations like this:
    /// for set 1,2,3:
    /// [1]
    /// [2]
    /// [3]
    /// [1,2]
    /// [1,3]
    /// [2,3]
    /// [1,2,3]
    /// </summary>
    /// <typeparam name="T">type of allValues items</typeparam>
    /// <param name="allValues">Set of all possible values</param>
    /// <returns>Set of uniq combinations</returns>
    public static IEnumerable<T[]> GetCombinations<T>(this IEnumerable<T> allValues)
    {
        var ret = new List<T[]>();
        foreach (var value in allValues)
        {
            ret.Add(new T[] { value });
        }

        var previousLevelValues = ret;
        for (int i = 0; i < (allValues.Count() - 1); i++)
        {
            var currentLevel = new List<T[]>();
            for (int j = 0; j < previousLevelValues.Count(); j++)
            {
                var clearValues = allValues.Skip(j + i + 1);
                var previousValues = previousLevelValues[j];
                foreach (var clearValue in clearValues)
                {
                    currentLevel.Add(previousValues.Concat(new T[] { clearValue }).ToArray());
                }
            }
            ret = ret.Concat(currentLevel).ToList();
            previousLevelValues = currentLevel;
        }
        return ret;
    }

}
