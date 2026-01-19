using Godot;
using System;

public partial class Options : Node2D
{
	public float MainVolumeDb = 0;
	public float MusicVolumeDb = 0;
	public float SFXVolumeDb = 0;
	public bool MainVolMuted = false;
	public bool MusicVolMuted = false;
	public bool SFXVolMuted = false;

	private OptRes optRes = GD.Load<OptRes>("res://Options.tres");
	public override void _Ready()
	{
		if (optRes.isSettingsSaved)
		{
			// Load saved settings
			MainVolumeDb = optRes.MainVolumeDb;
			MusicVolumeDb = optRes.MusicVolumeDb;
			SFXVolumeDb = optRes.SFXVolumeDb;
			MainVolMuted = optRes.MainVolMuted;
			MusicVolMuted = optRes.MusicVolMuted;
			SFXVolMuted = optRes.SFXVolMuted;
			// Apply all saved states to audio server
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), MainVolumeDb);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Music"), MusicVolumeDb);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Sfx"), SFXVolumeDb);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), MainVolMuted);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Music"), MusicVolMuted);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Sfx"), SFXVolMuted);
			// Apply all saved states to sliders
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolSlider").Value = MainVolumeDb;
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolSlider").Value = MusicVolumeDb;
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolSlider").Value = SFXVolumeDb;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolMute").ButtonPressed = MainVolMuted;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolMute").ButtonPressed = MusicVolMuted;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolMute").ButtonPressed = SFXVolMuted;
		}
		else
		{
			// Load default settings
			MainVolumeDb = optRes.DefaultMainVolumeDb;
			MusicVolumeDb = optRes.DefaultMusicVolumeDb;
			SFXVolumeDb = optRes.DefaultSFXVolumeDb;
			MainVolMuted = optRes.DefaultMainVolMuted;
			MusicVolMuted = optRes.DefaultMusicVolMuted;
			SFXVolMuted = optRes.DefaultSFXVolMuted;
			// Apply all default states to audio server
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), MainVolumeDb);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Music"), MusicVolumeDb);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Sfx"), SFXVolumeDb);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), MainVolMuted);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Music"), MusicVolMuted);
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Sfx"), SFXVolMuted);
			// Apply all default states to sliders
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolSlider").Value = MainVolumeDb;
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolSlider").Value = MusicVolumeDb;
			GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolSlider").Value = SFXVolumeDb;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolMute").ButtonPressed = MainVolMuted;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolMute").ButtonPressed = MusicVolMuted;
			GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolMute").ButtonPressed = SFXVolMuted;
		}
	}
#region Button Signals
	/// <summary>
	/// Each button signal changes the value of the local variable and updates the audio server to listen as a preview for the user.
	/// Reset buttons set the sliders to the defaults defined in the Options Resource, which in return updates the corresponding signal.
	/// The save button simply updates the Options Resource Stored Volume Settings.
	/// The exit button loads the saved settings and applies it to the audio server, therefore reverting any unsaved changes.
	/// </summary>
	/// <param name="value"></param>
	private void _on_main_vol_slider_value_changed(float value)
	{
		MainVolumeDb = value;
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), MainVolumeDb);
	}

	private void _on_sfx_vol_slider_value_changed(float value)
	{
		SFXVolumeDb = value;
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Sfx"), SFXVolumeDb);
	}

	private void _on_music_vol_slider_value_changed(float value)
	{
		MusicVolumeDb = value;
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Music"), MusicVolumeDb);
	}
	private void _on_main_vol_mute_toggled(bool pressed)
	{
		MainVolMuted = pressed;
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), MainVolMuted);
	}
	private void _on_music_vol_mute_toggled(bool pressed)
	{
		MusicVolMuted = pressed;
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Music"), MusicVolMuted);
	}
	private void _on_sfx_vol_mute_toggled(bool pressed)
	{
		SFXVolMuted = pressed;
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Sfx"), SFXVolMuted);
	}
	private void _on_main_vol_reset_pressed()
	{
		MainVolumeDb = optRes.DefaultMainVolumeDb;
		MainVolMuted = optRes.DefaultMainVolMuted;
		GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolSlider").Value = MainVolumeDb;
		GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MainVol/MainVolMute").ButtonPressed = MainVolMuted;
	}
	private void _on_music_vol_reset_pressed()
	{
		MusicVolumeDb = optRes.DefaultMusicVolumeDb;
		MusicVolMuted = optRes.DefaultMusicVolMuted;
		GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolSlider").Value = MusicVolumeDb;
		GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/MusicVol/MusicVolMute").ButtonPressed = MusicVolMuted;
	}
	private void _on_sfx_vol_reset_pressed()
	{
		SFXVolumeDb = optRes.DefaultSFXVolumeDb;
		SFXVolMuted = optRes.DefaultSFXVolMuted;
		GetNode<Slider>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolSlider").Value = SFXVolumeDb;
		GetNode<BaseButton>("Menu/AspectRatioContainer/CenterContainer/PanelContainer/MarginContainer/VBoxContainer/SfxVol/SfxVolMute").ButtonPressed = SFXVolMuted;
	}

	private void _on_save_pressed()
	{
		optRes.MainVolumeDb = MainVolumeDb;
		optRes.MusicVolumeDb = MusicVolumeDb;
		optRes.SFXVolumeDb = SFXVolumeDb;
		optRes.MainVolMuted = MainVolMuted;
		optRes.MusicVolMuted = MusicVolMuted;
		optRes.SFXVolMuted = SFXVolMuted;
		ResourceSaver.Save(optRes, "res://Options.tres");
		optRes.isSettingsSaved = true;
	}

	public void _on_exit_pressed()
	{
		// Load saved settings
		MainVolumeDb = optRes.MainVolumeDb;
		MusicVolumeDb = optRes.MusicVolumeDb;
		SFXVolumeDb = optRes.SFXVolumeDb;
		MainVolMuted = optRes.MainVolMuted;
		MusicVolMuted = optRes.MusicVolMuted;
		SFXVolMuted = optRes.SFXVolMuted;
		// Apply all saved states to audio server
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), MainVolumeDb);
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Music"), MusicVolumeDb);
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Sfx"), SFXVolumeDb);
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), MainVolMuted);
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Music"), MusicVolMuted);
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Sfx"), SFXVolMuted);
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
#endregion
}
