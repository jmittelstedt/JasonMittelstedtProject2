using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JasonMittelstedtProject2.Model
{
    /// <summary>
    /// Provides helper functionality for locating files within the project’s directory
    /// structure, specifically resolving paths to files stored in the application's
    /// Data folder.
    /// </summary>
    public class Locator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Locator"/> class.
        /// </summary>
        public Locator() { }

        /// <summary>
        /// Reference to the owning <see cref="MainForm"/>, if needed.
        /// </summary>
        public MainForm MainForm
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Returns the full file path of a file located in the application's Data folder.
        /// </summary>
        /// <param name="name">The file name to resolve.</param>
        /// <returns>
        /// The absolute path to the specified file inside the Data directory.
        /// </returns>
        public static string getFileName(string name) {
            string executePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string solutionPath = Directory.GetParent(executePath).Parent.Parent.Parent.FullName;

            string completeFileName = Path.Combine(solutionPath, "Data", name);
            return completeFileName;
        }
    }
}
