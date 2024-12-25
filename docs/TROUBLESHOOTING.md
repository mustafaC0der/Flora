
# Troubleshooting

Here are some common issues and their solutions.

## App Doesn’t Launch

- **Issue**: The app doesn’t open or crashes immediately after starting.
- **Solution**: Ensure you have the latest version of Visual Studio and the .NET 6.0 SDK installed. If you're still facing issues, try rebuilding the project.

## Notes Not Saving

- **Issue**: Notes are not being saved after the app is closed.
- **Solution**: Check if the `notes.json` file exists in the project directory. If not, ensure the file path is correctly set in the `NoteService` class.

## Missing UI Elements

- **Issue**: Some buttons or text boxes aren’t visible.
- **Solution**: This could be a display issue due to your screen resolution. Try resizing the app window. If the problem persists, check your system's display settings or update your graphics drivers.

## Dependencies Not Found

- **Issue**: Some dependencies may not be found during the build process.
- **Solution**: Try running `dotnet restore` to restore missing NuGet packages.

If none of these solutions work, please open an issue on the [GitHub repository](https://github.com/mustafaC0der/Flora).
    