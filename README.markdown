# ASP.NET MVC Helper functions/extension methods

###This repo is meant to hold some of the helper functions that I use on a daily/weekly basis while developing ASP.NET MVC projects.

This solution includes but is not limited to:
#### Devlife
1. StringExtensions
##### Cast

	```
	int myInt = "123".Cast<int>();
	Assert.AreEqual(123, myInt);

	int myInt = "abc".Cast<int>(defaultValue: 10, throwIfException: false);
	Assert.AreEqual(10, myInt);
	```

#### Devlife.Mvc
1. HtmlHelper.Script() - Renders a &lt;script type="text/javascript" /&gt; element
2. HtmlHelper.StyleSheet() - Renders a &lt;link rel="stylesheet" type="text/css" /&gt;  element
3. HtmlHelper.Image() - Renders an &lt;img /&gt; element