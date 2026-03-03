using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace EnrollmentStudentCHRD_Project_GP_10
{
    public static class LocalizationService
    {
        public static void ApplyLanguage(Form form, string langCode)
        {
            LanguageState.CurrentLanguage = langCode;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            foreach (Control c in form.Controls)
            {
                ApplyToControl(c, langCode);
            }
        }

        private static void ApplyToControl(Control c, string langCode)
        {
            // ✅ Only controls that have resource string
            string localizedText =
                Properties.Strings.ResourceManager.GetString(c.Name);

            if (!string.IsNullOrEmpty(localizedText))
            {
                c.Text = localizedText;

                // ✅ Font only for Button
                if (c is Button)
                {
                    c.Font = langCode == "my"
                        ? new Font("Pyidaungsu", 9F)
                        : new Font("Segoe UI", 9F);
                }
            }

            // recursive
            foreach (Control child in c.Controls)
            {
                ApplyToControl(child, langCode);
            }
        }

        // MessageBox helper
        public static string GetString(string key)
        {
            string value = Properties.Strings.ResourceManager.GetString(key);
            return string.IsNullOrEmpty(value) ? key : value;
        }
    }
}
