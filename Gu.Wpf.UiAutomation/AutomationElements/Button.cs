﻿namespace Gu.Wpf.UiAutomation
{
    using System.Windows.Automation;

    public class Button : InvokeAutomationElement
    {
        public Button(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public string Text
        {
            get
            {
                var children = this.AutomationElement.FindAllChildren( System.Windows.Automation.Condition.TrueCondition);
                if (children.Count == 1 &&
                    children[0].Current.ControlType.Id == ControlType.Text.Id)
                {
                    return children[0].Current.Name;
                }

                return this.Name;
            }
        }

        public UiElement Content => this.FindFirstChild();
    }
}
