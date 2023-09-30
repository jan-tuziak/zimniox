using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZimnioX
{
    public class DecimalEntry : Entry
    {
        public DecimalEntry()
        {
            TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = e.NewTextValue;

            char decimalPoint = ',';

            // Remove any non-digit characters
            newText = new string(newText.Where(c => char.IsDigit(c) || c == decimalPoint).ToArray());

            // Ensure only one decimal point exists
            if (newText.Count(c => c == decimalPoint) > 1)
            {
                // More than one decimal point, remove extras
                int firstDotIndex = newText.IndexOf(decimalPoint);
                int lastDotIndex = newText.LastIndexOf(decimalPoint);
                newText = newText.Remove(lastDotIndex, 1);
            }

            Text = newText;
        }
    }
}
