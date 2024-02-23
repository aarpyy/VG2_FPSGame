using Code.Attributes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Code.Utils;

namespace Code.Code.Editor
{
    [CustomPropertyDrawer(typeof(ConditionalFieldAttribute))]
    public class ConditionalFieldPropertyDrawer : PropertyDrawer
    {
        
        private float _propertyHeight;
 
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _propertyHeight;
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Get conditional attribute
            if (attribute is not ConditionalFieldAttribute conditionalAttribute) return;
            
            // Get the value of the property our conditional field is dependent on
            var propertyPath = property.propertyPath;
            var conditionPath = propertyPath.Replace(property.name, conditionalAttribute.fieldToCheck);
            var comparedField = property.serializedObject.FindProperty(conditionPath);
 
            // Get the value of the compared field.
            var comparedFieldValue = comparedField.GetUnderlyingValue();

            var shouldEnable = conditionalAttribute.comparisonType switch
            {
                ComparisonType.Equals => comparedFieldValue.Equals(conditionalAttribute.compareValue),
                ComparisonType.NotEqual => !comparedFieldValue.Equals(conditionalAttribute.compareValue),
                _ => false
            };
            
            // Store previous GUI enabled value
            var previousGUIState = GUI.enabled;
            
            // Disable the property
            GUI.enabled = shouldEnable;

            if (!shouldEnable)
            {
                _propertyHeight = -EditorGUIUtility.standardVerticalSpacing;
            }
            else
            {
                _propertyHeight = EditorGUI.GetPropertyHeight(property, label, true);
                EditorGUI.PropertyField(position, property, label, true);
            }
            
            // Set previous GUI enabled value
            GUI.enabled = previousGUIState;
        }
    }
}