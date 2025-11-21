using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    public class Locator
    {
        public Locator() { }

        public static string getFileName(string name) {
            string executePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string solutionPath = Directory.GetParent(executePath).Parent.Parent.Parent.FullName;

            string completeFileName = Path.Combine(solutionPath, "Data", name);
            return completeFileName;
        }
    }
}
