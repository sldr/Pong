using Godot;
using System;

public partial class OptRes : Resource
{
	[Export] public bool isSettingsSaved = false;

	[ExportCategory("Volume Settings")]

	[ExportGroup("Stored Volume Settings")]
	[Export(PropertyHint.Range, "-80,6,0.5")] public float MainVolumeDb = 0;
	[Export(PropertyHint.Range, "-80,6,0.5")] public float MusicVolumeDb = 0;
	[Export(PropertyHint.Range, "-80,6,0.5")] public float SFXVolumeDb = 0;

	[Export] public bool MainVolMuted = false;
	[Export] public bool MusicVolMuted = false;
	[Export] public bool SFXVolMuted = false;

	[ExportGroup("Default Settings")]
	[Export(PropertyHint.Range, "-80,6,0.5")] public float DefaultMainVolumeDb = 0;
	[Export(PropertyHint.Range, "-80,6,0.5")] public float DefaultMusicVolumeDb = 0;
	[Export(PropertyHint.Range, "-80,6,0.5")] public float DefaultSFXVolumeDb = 0;

	[Export] public bool DefaultMainVolMuted = false;
	[Export] public bool DefaultMusicVolMuted = false;
	[Export] public bool DefaultSFXVolMuted = false;
}

