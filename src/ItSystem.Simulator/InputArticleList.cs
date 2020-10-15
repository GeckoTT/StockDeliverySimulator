using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CareFusion.ITSystemSimulator
{
    /// <summary>
    /// Class which defines an article that is allowed for input.
    /// </summary>
    public class InputArticle
    {
        public string Id { get; set; }

        public string ScanCode { get; set; }

        public string Name { get; set; }

        public string DosageForm { get; set; }

        public string PackagingUnit { get; set; }

        public uint MaxSubItemQuantity { get; set; }

        public bool RequiresFridge { get; set; }
    }


    /// <summary>
    /// Class which provides the functionality to load and use a list of configurable input articles.
    /// </summary>
    public class InputArticleList
    {
        #region Members

        private List<InputArticle> _articles = new List<InputArticle>();

        #endregion

        public List<InputArticle> Articles
        {
            get { return _articles.ToList(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputArticleList"/> class.
        /// </summary>
        public InputArticleList()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var inputFile = Path.Combine(directory, "Articles.csv");

            if (File.Exists(inputFile) == false)
                return;

            var regex = new Regex("^(?<scancode>[^;]+);(?<id>[^;]+);(?<name>[^;]*);(?<dosage>[^;]*);(?<packaging>[^;]*);(?<maxsubitems>\\d+);(?<fridge>(True|False)+).*$", 
                                  RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

            try
            {
                var knownArticleIds = new List<string>();

                using (var reader = new StreamReader(inputFile))
                {
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var match = regex.Match(line);

                        if (match.Success == false)
                            continue;

                        var articleId = match.Groups["id"].Value;
                        var scanCode = match.Groups["scancode"].Value;

                        if (knownArticleIds.Contains(scanCode))
                            continue;

                        knownArticleIds.Add(scanCode);

                        _articles.Add(new InputArticle()
                        {
                            Id = articleId,
                            ScanCode = match.Groups["scancode"].Value.TrimStart('0'),
                            Name = match.Groups["name"].Value,
                            DosageForm = match.Groups["dosage"].Value,
                            PackagingUnit = match.Groups["packaging"].Value,
                            MaxSubItemQuantity = uint.Parse(match.Groups["maxsubitems"].Value),
                            RequiresFridge = bool.Parse(match.Groups["fridge"].Value)
                        });
                    }
                }
            }
            catch (Exception)
            {                
            }
        }

        /// <summary>
        /// Gets the article with the specified scan code.
        /// </summary>
        /// <param name="scancode">The scancode of the article to get.</param>
        /// <returns>According article if found; null otherwise.</returns>
        public InputArticle GetArticleByScanCode(string scancode)
        {
            scancode = scancode.TrimStart('0');
            return _articles.Find(a => a.ScanCode == scancode);
        }

        /// <summary>
        /// Gets the article by scan code or default.
        /// </summary>
        /// <param name="scancode">The scancode.</param>
        /// <returns></returns>
        public InputArticle GetArticleByScanCodeOrDefault(string scancode)
        {
            var article = GetArticleByScanCode(scancode);

            if (article != null)
                return article;

            return new InputArticle()
            {
                Id = scancode,
                ScanCode = scancode,
                Name = "BD | Rowa Article",
                DosageForm = string.Empty,
                PackagingUnit = string.Empty,
                MaxSubItemQuantity = (uint)(10 + scancode.Length)
            };
        }
    }
}
