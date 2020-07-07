# MoviesApp

MoviesApp is an Xamarin.Forms mobile app for Android dedicated to cinephiles and movie hobbyists. 
The app allow to see upcoming movies, search for specific movies and see its details like release date, genrers and an overview about it. 
The data is from [The Movie Database (TMDb)]( https://developers.themoviedb.org/3).

![Screenshots of app](/screenshots/screenshots.jpg)

### Xamarin.Forms App
This project exercises the following platforms, frameworks or features:
* Xamarin.Forms
  * XAML
  * Behaviors
  * Bindings
  * Converters
  * Custom Renderers
* xUnit Tests

# Third-party libraries

### Xamarin.Forms Project
* FFImageLoading – https://github.com/luberda-molinet/FFImageLoading
  * Caching images
  * Support error and loading placeholders
  * Automatically downsampled images to specified size (less memory usage)
* Prism – https://github.com/PrismLibrary/Prism
  * Implementation MVVM design pattern, dependency injection and commands
  * Make the application testable
* Newtonsoft.Json - https://github.com/JamesNK/Newtonsoft.Json
  * Deserialize the JSON to .NET objects

### xUnit Project
* Moq – https://github.com/moq/moq4
  * Quickly setup dependencies for tests