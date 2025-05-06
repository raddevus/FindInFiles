   Console.WriteLine ("Enter the path you want to search.");
	string searchPath = Console.ReadLine();
	Console.WriteLine(string.Format("Searching : {0}", searchPath));
	DirectoryInfo DirInfo = new DirectoryInfo(searchPath);
	Console.Write("Search Term: ");
	string searchTerm = Console.ReadLine().ToUpper();
	Console.WriteLine(searchTerm);
	Console.WriteLine("Enter the file pattern you want search against.");
	string filePattern = Console.ReadLine();
	try
	{
	var files =  DirInfo.EnumerateFiles(filePattern,SearchOption.AllDirectories);
	foreach (var f in files)
	{
		// Console.WriteLine($"Searching {Path.GetFileName(f.Name)}"); // uncomment to view files searched
		string [] allLines = File.ReadAllLines(f.FullName);
		int lineCount = 1;
		bool foundInFile = false;
		foreach (string line in allLines)
		{
			if (line.ToUpper().Contains(searchTerm))
			{
				if (!foundInFile)
				{
					// insures it only prints filename once
					Console.WriteLine("searching {0}", f.FullName.ToUpper());
					foundInFile=true;	
				}
				Console.WriteLine(string.Format("FOUND : {0}  {1}",lineCount, line));
			}
			lineCount++;
		}
		if (foundInFile)
		{
			Console.WriteLine("#############################");
			Console.WriteLine();
		}
	}
	}
	finally
	{
	
	}
