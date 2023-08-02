using Microsoft.AspNetCore.Components.WebView.Maui;
using HospitalManagementSystem.Data;
using HospitalManagement;

namespace HospitalManagementSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		
		builder.Services.AddBlazorWebViewDeveloperTools();

		var dbHospitalFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"hospital.db3");
		builder.Services.AddSingleton<DoctorInstance>(p => ActivatorUtilities.CreateInstance<DoctorInstance>(p, dbHospitalFile));
        var dbPatientFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"patient.db3");
        builder.Services.AddSingleton<PatientInstance>(p => ActivatorUtilities.CreateInstance<PatientInstance>(p, dbPatientFile));
        var dbFacilityFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Facility.db3");
        builder.Services.AddSingleton<FacilityInstance>(p => ActivatorUtilities.CreateInstance<FacilityInstance>(p, dbFacilityFile));
        var dbEquipmentFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Equipment.db3");
        builder.Services.AddSingleton<EquipmentInstance>(p => ActivatorUtilities.CreateInstance<EquipmentInstance>(p, dbEquipmentFile));
        //builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
	}
}
