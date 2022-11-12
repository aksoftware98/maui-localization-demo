
# Locailzation in .NET MAUI Project
Targetting a wide range of users has never been an easy task, even if your project is working perfectly and accomplishes what it supposed to be doing perfectly, there are some kind of challeneges that you need to tackle before you head internatinally with your piece of software. One of the biggest challenges is basically the langauge that your app is supporting, if you decide to go only with your local language, you are goingto miss a big oppurtunities earning more customers globally in other regions. 
This is why I have released AKSoftware.Localization.MultiLanguages couple years ago, the task of achieving has always been wasting time and a bit hard, so I decided to make it very simple and straightforward, I started first by targeting Blazor WebAssembly applications, and it got expanded to target more .NET frameworks. 
The work in progress right now is bring the library with all its power to .NET MAUI so the developers can built multilanguage UI for their mobile and desktop applications 

## Version 6.x of AKSoftware.Localization.MultiLanguages 
The big version is coming and targeting the end of year, which will contain a big list of features and improvments, and most importantly is the support of .NET MAUI native by providing a good mechanism to mention the localized keys in XAML out of the box. 
## How to get it to work for now
If you are in a hurry and you want to get started, this little example in this repo, shows you how to get started 
- Install the package from NuGet 
 ```
 Install-Package AKSoftware.Localization.MultiLanguages 
 ```
 - Add your English language file under the **Resources** folder, create a new folder and give it the name **Languages**, then a new file with the name **en-US.yml**
 ![Languages folder](https://github.com/aksoftware98/maui-localization-demo/blob/main/images/Create%20a%20new%20folder.png?raw=true)
 
 - Populate the file with some keys 
 ``` YAML
 HelloWorld: Hello, World
DotNetBotDescription: Cute dot net bot waving hi to you!
Welcome: Welcome to Maui Multi Languages
ClickMe: Click me
SingleButtonClickText: You clicked 1 time
MultiButtonClickText: You clicked {clicks} times
```
 - In the properties of the newly created language file, set **Build Action** property of the file to **Embedded resource**
 ![Set Build Action](https://github.com/aksoftware98/maui-localization-demo/blob/main/images/Set%20Action%20Type%20.png?raw=true)
 - If you want to support other languages, you can use the online translator tool [AK MultiLanguages Online Translator](https://akmultilanguages.azrurewebsites.net)
 - Upload the **en-US.yml** file and then download the language file that you want to support, add them in the **Languages** folder and set their **Build Action** to embedded resource
 - Now, you are good to go, navigate to MauiProgram.cs to register the service of the lanaguge and start injecting in your ViewModels and Pages to use it
 - Modify the MauiProgram.cs code to add the namespace of the class and register the service as following 
 ``` C#
 using AKSoftware.Localization.MultiLanguages; // Add this namespace
// Other namespaces goes here

namespace MauiMultiLanguages;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		// Defualt code to initialize the app and the servcies goes here	
	     ...
	     // Register the EmbeddedResourceKeysProvider so you can have access to the ILanguageContainerService
		builder.Services.AddLanguageContainer<EmbeddedResourceKeysProvider>(Assembly.GetExecutingAssembly(), "Resources.Languages");

		return builder.Build();
	}
}

```

- Now, open the code-behind file of the MainPage.xaml and bring the **ILanguageContainerService** from the Dependency Injection container and start using it
 ``` C#
 	private ILanguageContainerService _language;
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        _language = this.Handler.MauiContext.Services.GetService<ILanguageContainerService>();
        count++;

		if (count == 1)
			CounterBtn.Text = _language["SingleButtonClickText"];
		else
			CounterBtn.Text = _language["MultiButtonClickText", new
			{
                clicks = count
			}];

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
```

That's it now you can run the app and get started
![.NET MAUI fetching keys from localized source](https://github.com/aksoftware98/maui-localization-demo/blob/main/images/MAUI%20Screenshot.png?raw=true)
