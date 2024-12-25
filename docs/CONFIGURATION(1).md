
# Configuration Guide

Flora Notes App doesn’t require any complex configuration, but here are some areas where you might want to customize it.

## Data Storage

By default, Flora stores notes in a local `notes.json` file in the app's directory. You can change the file path by editing the `NoteService` class.

### Example: Custom File Path

To use a custom file path for storing notes, modify the following line in the `NoteService` class:

```csharp
private readonly string _filePath = "C:\path\to\your\notes.json";
```

## Themes

Currently, Flora supports a light theme. Future versions will include a dark theme and other customizable options.

## User Preferences

User preferences like font size and layout will be saved in a config file (`preferences.json`). You can modify or reset preferences through the app’s settings menu (coming soon).
    