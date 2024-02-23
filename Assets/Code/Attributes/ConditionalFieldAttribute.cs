using System;
using Code.Utils;
using UnityEngine;

namespace Code.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class |
                    AttributeTargets.Struct)]
    public class ConditionalFieldAttribute : PropertyAttribute
    {
        public string fieldToCheck;
        public object compareValue;
        public ComparisonType comparisonType;

        public ConditionalFieldAttribute(string fieldToCheck, object compareValue, ComparisonType comparisonType)
        {
            this.fieldToCheck = fieldToCheck;
            this.compareValue = compareValue;
            this.comparisonType = comparisonType;
        }
    }
}