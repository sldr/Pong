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
		}
	}

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
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
}
