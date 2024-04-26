# Maui_Sample
 A sample project using .NET Maui that shows a list of safety inspections with the ability to add and edit. I also wrote a minimal API to serve as the backend as opposed to standing up a local DB or dedicated server. 


https://github.com/WH-Creations/Maui_Sample/assets/97212578/05a4d15a-b228-419d-930c-317ea4417564


## Architecture
- MVVM
- Dependency Injection
- Services/Repository
- Publisher/Subscriber

## Packages
- CommunityToolkit.Maui
- CommunityToolkit.Mvvm
- Microsoft.Extensions.Http
- Microsoft.Extensions.Logging.Debug

## TODO
- Fix release mode crash (likely XAML) in the Inspection Detail page, but runs fine in debug for the time being.
- Handle keyboard presentation gracefully to avoid UI components being covered on smaller devices.
- Add ability to select picture from camera roll (time permitting)
- Code cleanup (It is 2am, there is probably some code cleanup to do but that will have to wait)

## API
<img width="724" alt="image" src="https://github.com/WH-Creations/Maui_Sample/assets/97212578/7c8b67bf-d9ec-4374-a0a9-d75804b75586">
