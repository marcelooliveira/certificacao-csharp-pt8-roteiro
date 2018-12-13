using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Listings
{
    class Ex18
    {
        public Ex18()
        {

        }
    }

    class Counter
    {
        System.Collections.Concurrent.ConcurrentDictionary<string, int> _wordCounts =
        new System.Collections.Concurrent.ConcurrentDictionary<string, int>();
        public Action<DirectoryInfo> ProcessDirectory()
        {
            return (dirInfo =>
            {
                var files = dirInfo.GetFiles("*.cs").AsParallel<FileInfo>();
                files.ForAll<FileInfo>(
                    fileInfo =>
                    {
                        var fileContent = File.ReadAllText(fileInfo.FullName);
                        var sb = new StringBuilder();
                        foreach (var val in fileContent)
                        {
                            sb.Append(char.IsLetter(val) ? val.ToString().ToLowerInvariant() : " ");
                        }
                        string[] wordsInFile = sb.ToString().Split(new[] { ' ' },
                                StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in wordsInFile)
                        {

                        }
                    });
                var directories = dirInfo.GetDirectories().AsParallel<DirectoryInfo>();
                directories.ForAll<DirectoryInfo>(ProcessDirectory());
            });
        }
    }
}

